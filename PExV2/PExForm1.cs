using System.Data;

namespace PExV2
{
    public partial class PExForm1 : Form
    {
        private SqlDatabase mysql;

        public PExForm1(SqlDatabase mysql)
        {
            this.mysql = mysql;
            InitializeComponent();
        }

        private bool checkNullBox(TextBox box)
        {
            if (passTextBox.Text == null) return true;
            if (passTextBox.Text.Replace(" ", "") == "") return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkNullBox(passTextBox) || checkNullBox(mssvTextBox))
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin đã nhập.", "PEx - Có lỗi xảy ra!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mssvTextBox.Enabled = false;
            passTextBox.Enabled = false;

            button1.Enabled = false;
            button1.BackColor = Color.Gray;
            button1.Text = "Đang đăng nhập...";

            DataTable selectSinhVien = mysql.ExecuteQuery("SELECT * FROM `sinh_vien` WHERE `MaSinhVien` = '" + mssvTextBox.Text + "'");

            bool canLogin = false;

            if (selectSinhVien.Rows.Count > 0)
            {
                string encodedPass = selectSinhVien.Rows[0]["MatKhau"].ToString();

                Crypto crypto = new Crypto();
                canLogin = crypto.Compare(passTextBox.Text, encodedPass);
            }

            if (!canLogin)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "PEx - Có lỗi xảy ra!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mssvTextBox.Enabled = true;
                passTextBox.Enabled = true;

                button1.Enabled = true;
                button1.BackColor = Color.LightSeaGreen;
                button1.Text = "ĐĂNG NHẬP";
            }
            else
            {
                //MessageBox.Show("Đăng nhập thành công.", "PEx - thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new PExForm2(selectSinhVien.Rows[0], mysql).ShowDialog();
            }

            // Xử lý dữ liệu từ DataTable
            /*foreach (DataRow row in results.Rows)
            {
                Console.WriteLine(row["MMH"].ToString());
            }*/
        }

        private void PExForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
