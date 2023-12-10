namespace PExV2
{
    partial class PExForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PExForm2));
            PExLogoBox = new PictureBox();
            passGroupBox = new GroupBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)PExLogoBox).BeginInit();
            passGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // PExLogoBox
            // 
            PExLogoBox.Image = (Image)resources.GetObject("PExLogoBox.Image");
            PExLogoBox.Location = new Point(67, -35);
            PExLogoBox.Name = "PExLogoBox";
            PExLogoBox.Size = new Size(363, 254);
            PExLogoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PExLogoBox.TabIndex = 1;
            PExLogoBox.TabStop = false;
            // 
            // passGroupBox
            // 
            passGroupBox.Controls.Add(comboBox1);
            passGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            passGroupBox.Location = new Point(12, 202);
            passGroupBox.Name = "passGroupBox";
            passGroupBox.Size = new Size(470, 64);
            passGroupBox.TabIndex = 7;
            passGroupBox.TabStop = false;
            passGroupBox.Text = "Chọn môn thi trắc nghiệm (*)";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(458, 25);
            comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSeaGreen;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 283);
            button1.Name = "button1";
            button1.Size = new Size(278, 34);
            button1.TabIndex = 6;
            button1.Text = "BẮT ĐẦU THI";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(296, 283);
            button2.Name = "button2";
            button2.Size = new Size(186, 34);
            button2.TabIndex = 8;
            button2.Text = "ĐĂNG XUẤT";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // PExForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 344);
            Controls.Add(button2);
            Controls.Add(passGroupBox);
            Controls.Add(button1);
            Controls.Add(PExLogoBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PExForm2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PEx © 2023 by Nhom 9";
            FormClosed += PExForm2_FormClosed;
            ((System.ComponentModel.ISupportInitialize)PExLogoBox).EndInit();
            passGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PExLogoBox;
        private GroupBox passGroupBox;
        private Button button1;
        private ComboBox comboBox1;
        private Button button2;
    }
}