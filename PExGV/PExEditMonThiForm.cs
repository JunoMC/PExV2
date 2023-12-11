using System.Data;

namespace PExGV
{
    public partial class PExEditMonThiForm : Form
    {
        private SqlDatabase mysql;
        private int id;

        public PExEditMonThiForm(SqlDatabase mysql, int id)
        {
            this.id = id;
            this.mysql = mysql;
            InitializeComponent();

            DataTable getMonThi = mysql.ExecuteQuery("SELECT * FROM `mon_thi` WHERE `ID` = " + id);
            DataRow mtRow = getMonThi.Rows[0];

            DataTable getListMonThi = mysql.ExecuteQuery("SELECT * FROM `mon_thi`");

            for (int i = 0; i < getListMonThi.Rows.Count; i++)
            {
                DataRow dataRow = getListMonThi.Rows[i];

                comboBox1.Items.Add(dataRow["MMH"] + " - " + dataRow["NAME"]);

                if (Int32.Parse(dataRow["ID"].ToString()) == id)
                {
                    comboBox1.SelectedIndex = i;
                }
            }

            textBox1.Text = mtRow["NAME"].ToString();
            textBox2.Text = mtRow["KI_THI"].ToString();

            DataTable getListNganh = mysql.ExecuteQuery("SELECT * FROM `nganh_hoc`");

            for (int i = 0; i < getListNganh.Rows.Count; i++)
            {
                DataRow dataRow = getListNganh.Rows[i];

                comboBox2.Items.Add(dataRow["ID"] + " - " + dataRow["TenNganh"]);

                if (Int32.Parse(dataRow["ID"].ToString()) == Int32.Parse(mtRow["MaNganh"].ToString()))
                {
                    comboBox2.SelectedIndex = i;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
