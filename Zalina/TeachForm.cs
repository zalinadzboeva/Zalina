using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zalina
{
    public partial class TeachForm : Form
    {
        TeachBox turned = null;
        string[] indexArr = { "0", "0", "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7" };
        List<TeachBox> BoxList = new List<TeachBox>();
        public TeachForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            Init();
        }

        private void Init()
        {
            this.Width = 4 * 110;
            ShuffleArray(indexArr);

            /*Инициализация панелей*/
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TeachBox box = new TeachBox();

                    Panel panel = new Panel();
                    panel.Location = new Point(j * 100 + 10, i * 100 + 10);
                    panel.Size = new Size(100, 100);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.BackColor = Color.Azure;
                    panel.Click += new System.EventHandler(this.ClickOnPanel);
                    box.Panel = panel;

                    // Создаем новый pictureBox и задаем ему параметры
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(15, 15);
                    pictureBox.Size = new Size(75, 75);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Enabled = false;
                    box.Image = pictureBox;
                    box.ImageUrl = "Teach/" + indexArr[BoxList.Count] + ".png";

                    /*pictureBox.Image = Image.FromFile("Teach/" + indexArr[BoxList.Count] + ".png");*/

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
            Panel panel = (Panel)sender;
            int index = GetPanelIndex(panel.Location);
            if (index == -1)
            {
                MessageBox.Show("Something was wrong", "Error");
                this.Close();
            }
            TeachBox box = BoxList[index];
            if (box.IsGreen) return; /*Если уже перевернута, то нельзя еще раз воспользоваться*/

            /*Перевернули карточку*/
            box.Panel.Enabled = false;
            box.Image.Image = Image.FromFile(box.ImageUrl);


            if (turned == null) /*Если еще нет перевернутой*/
            {
                turned = box;
            }
            else /*Если уже есть перевернутая*/
            {
                if (turned.ImageUrl == box.ImageUrl) /*Если перевернутые карточки одинаковые*/
                {
                    turned.Panel.BackColor = Color.Green;
                    box.Panel.BackColor = Color.Green;
                    turned.IsGreen = true;
                    box.IsGreen = true;


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

    }

}
