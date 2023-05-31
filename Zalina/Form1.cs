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
    public partial class Form1 : Form
    {
        string filePath = "result.txt";
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private void TeachBtn_Click_1(object sender, EventArgs e)
        {
            Form teachForm = new TeachForm();
            this.Hide();
            teachForm.ShowDialog();
            this.Close();
        }
        private void TestBtn_Click_1(object sender, EventArgs e)
        {
            Form testForm = new TestForm();
            this.Hide();
            testForm.ShowDialog();
            this.Close();
        }
        private void BestScoreBtn_Click_1(object sender, EventArgs e)
        {
            FileHandler fh = new FileHandler(filePath);
            string bestScore = fh.ReadFromFile();
            MessageBox.Show("Лучший счет - " + bestScore);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
