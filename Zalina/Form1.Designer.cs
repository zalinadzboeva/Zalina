namespace Zalina
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TeachBtn = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.BestScoreBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TeachBtn
            // 
            this.TeachBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeachBtn.Location = new System.Drawing.Point(18, 18);
            this.TeachBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TeachBtn.Name = "TeachBtn";
            this.TeachBtn.Size = new System.Drawing.Size(322, 48);
            this.TeachBtn.TabIndex = 0;
            this.TeachBtn.Text = "Обучение";
            this.TeachBtn.UseVisualStyleBackColor = true;
            // 
            // TestBtn
            // 
            this.TestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestBtn.Location = new System.Drawing.Point(18, 82);
            this.TestBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(322, 48);
            this.TestBtn.TabIndex = 1;
            this.TestBtn.Text = "Тест";
            this.TestBtn.UseVisualStyleBackColor = true;
            // 
            // BestScoreBtn
            // 
            this.BestScoreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BestScoreBtn.Location = new System.Drawing.Point(18, 138);
            this.BestScoreBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BestScoreBtn.Name = "BestScoreBtn";
            this.BestScoreBtn.Size = new System.Drawing.Size(322, 48);
            this.BestScoreBtn.TabIndex = 2;
            this.BestScoreBtn.Text = "button2";
            this.BestScoreBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 202);
            this.Controls.Add(this.BestScoreBtn);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.TeachBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Главная ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TeachBtn;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Button BestScoreBtn;
    }
}

