using PExGV.Properties;
using System;
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
    public partial class PExGVForm2 : Form
    {
        private List<MonThi> danhSachMonThi = new List<MonThi>();

        private SqlDatabase mysql;

        public PExGVForm2(SqlDatabase mysql)
        {
            this.mysql = mysql;
            InitializeComponent();
            HienThiDanhSachDeThi();
        }

        private void HienThiDanhSachDeThi()
        {
            DataTable selectMT = mysql.ExecuteQuery("SELECT * FROM `mon_thi`");

            for (int i = 0; i < selectMT.Rows.Count; i++)
            {
                DataRow row = selectMT.Rows[i];

                DataTable selectNganhHoc = mysql.ExecuteQuery("SELECT * FROM `nganh_hoc` WHERE `ID` = " + row["MaNganh"]);
                string TenNganhHoc = selectNganhHoc.Rows[0]["TenNganh"].ToString();

                danhSachMonThi.Add(new MonThi()
                {
                    ID = i + 1,
                    MHH = row["MMH"].ToString(),
                    TenMH = row["NAME"].ToString(),
                    Nganh = TenNganhHoc,
                    TenKiThi = row["KI_THI"].ToString(),
                    ThoiGianThi = Int32.Parse(row["DURATION"].ToString()),
                    KichHoat = row["ACTIVE"].ToString() == "1" ? "true" : "false"
                });
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            dataGridView1.DataSource = danhSachMonThi;

            dataGridView1.Columns["ID"].HeaderText = "ID";
            dataGridView1.Columns["MHH"].HeaderText = "MÃ MÔN HỌC";
            dataGridView1.Columns["TenMH"].HeaderText = "TÊN MÔN HỌC";
            dataGridView1.Columns["Nganh"].HeaderText = "NGÀNH";
            dataGridView1.Columns["TenKiThi"].HeaderText = "TÊN KÌ THI";
            dataGridView1.Columns["ThoiGianThi"].HeaderText = "THỜI GIAN";
            dataGridView1.Columns["KichHoat"].HeaderText = "KÍCH HOẠT";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.FillWeight = 1;
            }

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "THAO TÁC";
            buttonColumn.Name = "btnThaoTac";
            buttonColumn.Text = "Chỉnh sửa";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.CellContentClick += dataGridViewMonThi_CellContentClick;

        }

        private void dataGridViewMonThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnThaoTac"].Index && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                DataGridViewCellCollection row = dataGridView1.Rows[rowIndex].Cells;
                new PExEditMonThiForm(mysql, Int32.Parse(row["ID"].Value.ToString())).Show();
            }
        }
    }
}
