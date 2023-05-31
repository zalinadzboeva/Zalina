using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zalina
{
    public partial class TestForm : Form
    {
        TestBox turned = null;
        string[] indexArr = { "0", "0_0", "1", "1_0", "2", "2_0", "3", "3_0", "4", "4_0", "5", "5_0", "6", "6_0", "7", "7_0" };
        List<TestBox> BoxList = new List<TestBox>();
        int score = 0;
        string filePath = "result.txt";
        public TestForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            Init();
        }
        private void Init()
        {

            this.Width = 4 * 110;
            ShuffleArray(indexArr);


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TestBox box = new TestBox();

                    Panel panel = new Panel();
                    panel.Location = new Point(j * 100 + 10, i * 100 + 10);
                    panel.Size = new Size(100, 100);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.BackColor = Color.Azure;
                    panel.Click += new System.EventHandler(this.ClickOnPanel);

                    // Создаем новый pictureBox и задаем ему параметры
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(15, 15);
                    pictureBox.Size = new Size(75, 75);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Enabled = false;


                    box.Panel = panel;
                    box.Image = pictureBox;
                    box.ImageUrl = "Test/" + indexArr[BoxList.Count] + ".png";
                    box.Index = indexArr[BoxList.Count].Substring(0, 1);

                    // Добавляем pictureBox в панель
                    panel.Controls.Add(pictureBox);
                    // Добавляем панель в динамический массив
                    BoxList.Add(box);
                    // Добавляем панель на форму
                    this.Controls.Add(panel);
                }
            }

        }

        private async void ClickOnPanel(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;/*Получили панель, которая была нажата и записали ее в переменную*/

            int index = GetPanelIndex(panel.Location); /*Получили ее индекс в динамическом листе панелей*/
            if (index == -1) /*Если такого не обноружилось, выводим ошибку и завершаем программу*/
            {
                MessageBox.Show("Something was wrong", "Error");
                this.Close();
            }

            TestBox box = BoxList[index]; /*Получили бокс, панель которого была нажата, и записали его в перменную*/
            if (box.IsGreen) return; /*Если уже перевернута, то нельзя еще раз воспользоваться*/

            /*Перевернули карточку*/
            box.Panel.Enabled = false;
            box.Image.Image = Image.FromFile(box.ImageUrl);


            if (turned == null) /*Если еще нет перевернутой*/
            {
                turned = box;/*Записываем в переменную перевернутый бокс*/
            }
            else /*Если уже есть перевернутая*/
            {
                if (turned.Index == box.Index) /*Если перевернутые карточки одинаковые*/
                {
                    turned.Panel.BackColor = Color.Green;
                    box.Panel.BackColor = Color.Green;
                    turned.IsGreen = true;
                    box.IsGreen = true;

                    score++;

                    if (IsWin())
                    {
                        MessageBox.Show("Вы победили", "Поздравляю!!!");
                        this.Close();
                    }
                }
                else /*Если перевернутые карточки разные*/
                {
                    /*Показали, что карточки разные*/
                    turned.Panel.BackColor = Color.Red;
                    box.Panel.BackColor = Color.Red;

                    /*Сделали задержку*/
                    EnablePanels();
                    await Task.Delay(1000);
                    EnablePanels();

                    /*Переворачиваем карточки обратно*/
                    turned.Panel.BackColor = Color.Azure;
                    turned.Panel.Enabled = true;
                    turned.Image.Image = null;
                    box.Panel.BackColor = Color.Azure;
                    box.Panel.Enabled = true;
                    box.Image.Image = null;

                    score++;

                }
                turned = null;
            }
        }



        private static void ShuffleArray(string[] array)
        {
            Random rand = new Random();

            // Итерируемся по массиву с конца
            for (int i = array.Length - 1; i > 0; i--)
            {
                // Генерируем случайное число в диапазоне [0, i]
                int j = rand.Next(0, i + 1);

                // Меняем местами элементы с индексами i и j
                string temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private int GetPanelIndex(Point loc)
        {
            int index = 0;
            for (int i = 0; i < BoxList.Count; i++)
            {
                if (BoxList[i].Panel.Location == loc)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void EnablePanels()
        {
            for (int i = 0; i < BoxList.Count; i++)
            {
                BoxList[i].Panel.Enabled = !BoxList[i].Panel.Enabled;
            }
        }

        private bool IsWin()
        {
            for (int i = 0; i < BoxList.Count; i++)
            {
                if (BoxList[i].IsGreen == false) return false;
            }
            WriteResult();
            return true;
        }

        private void WriteResult()
        {
            FileHandler fh = new FileHandler(filePath);

            try
            {
                int bestScore = int.Parse(fh.ReadFromFile());
                if (bestScore <= score) return;
                fh.WriteToFile(Convert.ToString(score));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
