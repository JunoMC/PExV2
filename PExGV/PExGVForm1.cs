﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PExGV
{
    public partial class PExGVForm1 : Form
    {
        private SqlDatabase mysql;

        public PExGVForm1(SqlDatabase mysql)
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
            if (checkNullBox(passTextBox) || checkNullBox(mgvTextBox))
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin đã nhập.", "PEx - Có lỗi xảy ra!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mgvTextBox.Enabled = false;
            passTextBox.Enabled = false;

            button1.Enabled = false;
            button1.BackColor = Color.Gray;
            button1.Text = "Đang đăng nhập...";

            DataTable selectGV = mysql.ExecuteQuery("SELECT * FROM `giang_vien` WHERE `MaGV` = '" + mgvTextBox.Text + "'");

            bool canLogin = false;

            if (selectGV.Rows.Count > 0)
            {
                string encodedPass = selectGV.Rows[0]["MatKhau"].ToString();

                Crypto crypto = new Crypto();
                canLogin = crypto.Compare(passTextBox.Text, encodedPass);
            }

            if (!canLogin)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "PEx - Có lỗi xảy ra!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mgvTextBox.Enabled = true;
                passTextBox.Enabled = true;

                button1.Enabled = true;
                button1.BackColor = Color.LightSeaGreen;
                button1.Text = "ĐĂNG NHẬP";
            }
            else
            {
                //MessageBox.Show("Đăng nhập thành công.", "PEx - thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new PExGVForm2(mysql).ShowDialog();
            }

            // Xử lý dữ liệu từ DataTable
            /*foreach (DataRow row in results.Rows)
            {
                Console.WriteLine(row["MMH"].ToString());
            }*/
        }

        private void PExGVForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
