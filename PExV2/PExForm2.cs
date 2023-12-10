using System.Data;

namespace PExV2
{
    public partial class PExForm2 : Form
    {
        private SqlDatabase mysql;
        private DataRow data;

        public PExForm2(DataRow data, SqlDatabase mysql)
        {
            InitializeComponent();

            DataTable getListMonThi = mysql.ExecuteQuery("SELECT * FROM `mon_thi` WHERE `MaNganh` = '" + data["MaNganhHoc"] + "'");

            for (int i = 0; i < getListMonThi.Rows.Count; i++)
            {
                DataRow dataRow = getListMonThi.Rows[i];
                comboBox1.Items.Add(dataRow["NAME"] + " - " + dataRow["MMH"] + " - " + dataRow["KI_THI"] + " (" + dataRow["DURATION"] + " phút)");
            }

            this.mysql = mysql;
            this.data = data;
        }

        private void PExForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PExForm1(mysql).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn môn thi.", "PEx - Có lỗi xảy ra!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string MMT = comboBox1.Text.Split(" - ")[1];

            this.Hide();
            new PExForm3(MMT, data, mysql).ShowDialog();
        }
    }
}
