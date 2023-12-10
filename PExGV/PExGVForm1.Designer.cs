namespace PExGV
{
    partial class PExGVForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PExGVForm1));
            PExLogoBox = new PictureBox();
            button1 = new Button();
            passTextBox = new TextBox();
            passGroupBox = new GroupBox();
            mssvGroupBox = new GroupBox();
            mssvTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PExLogoBox).BeginInit();
            passGroupBox.SuspendLayout();
            mssvGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // PExLogoBox
            // 
            PExLogoBox.Image = (Image)resources.GetObject("PExLogoBox.Image");
            PExLogoBox.Location = new Point(41, -36);
            PExLogoBox.Name = "PExLogoBox";
            PExLogoBox.Size = new Size(363, 254);
            PExLogoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PExLogoBox.TabIndex = 0;
            PExLogoBox.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSeaGreen;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(77, 333);
            button1.Name = "button1";
            button1.Size = new Size(292, 34);
            button1.TabIndex = 4;
            button1.Text = "ĐĂNG NHẬP";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // passTextBox
            // 
            passTextBox.AllowDrop = true;
            passTextBox.Location = new Point(6, 28);
            passTextBox.MaxLength = 50;
            passTextBox.Name = "passTextBox";
            passTextBox.PasswordChar = '•';
            passTextBox.Size = new Size(280, 29);
            passTextBox.TabIndex = 0;
            passTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // passGroupBox
            // 
            passGroupBox.Controls.Add(passTextBox);
            passGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            passGroupBox.Location = new Point(77, 252);
            passGroupBox.Name = "passGroupBox";
            passGroupBox.Size = new Size(292, 64);
            passGroupBox.TabIndex = 5;
            passGroupBox.TabStop = false;
            passGroupBox.Text = "Mật khẩu (*)";
            // 
            // mssvGroupBox
            // 
            mssvGroupBox.Controls.Add(mssvTextBox);
            mssvGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            mssvGroupBox.Location = new Point(77, 182);
            mssvGroupBox.Name = "mssvGroupBox";
            mssvGroupBox.Size = new Size(292, 64);
            mssvGroupBox.TabIndex = 3;
            mssvGroupBox.TabStop = false;
            mssvGroupBox.Text = "Mã giảng viên (*)";
            // 
            // mssvTextBox
            // 
            mssvTextBox.AllowDrop = true;
            mssvTextBox.CharacterCasing = CharacterCasing.Upper;
            mssvTextBox.Location = new Point(6, 28);
            mssvTextBox.MaxLength = 50;
            mssvTextBox.Name = "mssvTextBox";
            mssvTextBox.Size = new Size(280, 29);
            mssvTextBox.TabIndex = 0;
            mssvTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // PExGVForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 392);
            Controls.Add(passGroupBox);
            Controls.Add(mssvGroupBox);
            Controls.Add(button1);
            Controls.Add(PExLogoBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PExGVForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PEx © 2023 by Nhom 9";
            FormClosed += PExGVForm1_FormClosed;
            ((System.ComponentModel.ISupportInitialize)PExLogoBox).EndInit();
            passGroupBox.ResumeLayout(false);
            passGroupBox.PerformLayout();
            mssvGroupBox.ResumeLayout(false);
            mssvGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox PExLogoBox;
        private Button button1;
        private TextBox passTextBox;
        private GroupBox passGroupBox;
        private GroupBox mssvGroupBox;
        private TextBox mssvTextBox;
    }
}