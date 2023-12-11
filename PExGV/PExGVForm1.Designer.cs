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
            mgvGroupBox = new GroupBox();
            mgvTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PExLogoBox).BeginInit();
            passGroupBox.SuspendLayout();
            mgvGroupBox.SuspendLayout();
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
            // mgvGroupBox
            // 
            mgvGroupBox.Controls.Add(mgvTextBox);
            mgvGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            mgvGroupBox.Location = new Point(77, 182);
            mgvGroupBox.Name = "mgvGroupBox";
            mgvGroupBox.Size = new Size(292, 64);
            mgvGroupBox.TabIndex = 3;
            mgvGroupBox.TabStop = false;
            mgvGroupBox.Text = "Mã giảng viên (*)";
            // 
            // mgvTextBox
            // 
            mgvTextBox.AllowDrop = true;
            mgvTextBox.CharacterCasing = CharacterCasing.Upper;
            mgvTextBox.Location = new Point(6, 28);
            mgvTextBox.MaxLength = 50;
            mgvTextBox.Name = "mgvTextBox";
            mgvTextBox.Size = new Size(280, 29);
            mgvTextBox.TabIndex = 0;
            mgvTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // PExGVForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 392);
            Controls.Add(passGroupBox);
            Controls.Add(mgvGroupBox);
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
            mgvGroupBox.ResumeLayout(false);
            mgvGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox PExLogoBox;
        private Button button1;
        private TextBox passTextBox;
        private GroupBox passGroupBox;
        private GroupBox mgvGroupBox;
        private TextBox mgvTextBox;
    }
}