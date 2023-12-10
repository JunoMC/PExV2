using Newtonsoft.Json;
using System.Data;
using System.Web;

namespace PExV2
{
    public partial class PExForm3 : Form
    {
        private int remainingSeconds = 60;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private DataRow dataSV;
        private string MMT;
        private SqlDatabase mysql;

        private static readonly Random r = new Random();
        private static readonly object syncLock = new object();

        private bool isStop = false;

        public static int random(int min, int max)
        {
            lock (syncLock)
            {
                return r.Next(min, max + 1);
            }
        }

        public PExForm3(string MMT, DataRow dataSV, SqlDatabase mysql)
        {
            this.dataSV = dataSV;
            this.MMT = MMT;
            this.mysql = mysql;

            InitializeComponent();

            renderUI();
        }

        private int btnDangChon = 0;

        private Dictionary<int, string> DanhSachCauHoi = new Dictionary<int, string>();
        private List<int> DanhSachViTriCauHoiDaRandom = new List<int>();
        private Dictionary<int, Button> DanhSachNutCauHoi = new Dictionary<int, Button>();
        private Dictionary<int, Dictionary<int, string>> DanhSachDapAn = new Dictionary<int, Dictionary<int, string>>();
        private Dictionary<int, int[]> DanhSachViTriDapAnDaRandom = new Dictionary<int, int[]>();
        private Dictionary<int, int> DanhSachDapAnDaChon = new Dictionary<int, int>(); //<vị trí đáp án thật, vị trí đáp án đã chọn>

        private string ConvertToJSON()
        {
            List<string> data = new List<string>();

            int countKetQuaDung = 0;

            foreach (int realOrder in DanhSachViTriCauHoiDaRandom)
            {
                List<string> dapAnList = new List<string>();

                for (int i = 0; i < DanhSachViTriDapAnDaRandom[realOrder].Length; i++)
                {
                    int viTriDapAn = DanhSachViTriDapAnDaRandom[realOrder][i];
                    bool daChon = DanhSachDapAnDaChon.ContainsKey(realOrder) ? DanhSachDapAnDaChon[realOrder] == i : false;
                    bool dapAnDung = viTriDapAn == 3;

                    if (daChon && dapAnDung) countKetQuaDung++;

                    string dapAnJson = "{\"DaChon\": " + daChon.ToString().ToLower() + ", \"DapAnDung\": " + dapAnDung.ToString().ToLower() + ", \"text\": \"" + DanhSachDapAn[realOrder][viTriDapAn] + "\"}";
                    dapAnList.Add(dapAnJson);
                }

                string cauHoiJson = "{\"CauHoi\": \"" + DanhSachCauHoi[realOrder] + "\", \"DapAn\": [" + string.Join(",", dapAnList) + "]}";
                data.Add(cauHoiJson);
            }

            double soDiem = (double)(DanhSachCauHoi.Count / (double)10) * (double)countKetQuaDung;

            // Tạo chuỗi JSON
            string jsonData = "{\"data\": [" + string.Join(",", data) + "], \"SoKetQuaDung\": " + countKetQuaDung + ", \"SoDiem\": " + Math.Round(soDiem, 2) + "}";

            return jsonData;
        }

        private void ThemCauHoi(int index, string text)
        {
            if (DanhSachCauHoi.ContainsKey(index))
            {
                DanhSachCauHoi.Remove(index);
            }

            DanhSachCauHoi.Add(index, text);
        }

        private void ThemNutCauHoi(int index, Button btn)
        {
            if (DanhSachNutCauHoi.ContainsKey(index))
            {
                DanhSachNutCauHoi.Remove(index);
            }

            DanhSachNutCauHoi.Add(index, btn);
        }

        private void ThemDapAnChoCauHoi(int indexCauHoi, int indexDapAn, string text)
        {
            if (DanhSachDapAn.ContainsKey(indexCauHoi))
            {
                if (DanhSachDapAn[indexCauHoi].ContainsKey(indexDapAn))
                {
                    DanhSachDapAn[indexCauHoi].Remove(indexDapAn);
                }
                else
                {
                    DanhSachDapAn[indexCauHoi].Add(indexDapAn, text);
                }
            }
            else
            {
                Dictionary<int, string> newDic = new Dictionary<int, string>();
                newDic.Add(indexDapAn, text);

                DanhSachDapAn.Add(indexCauHoi, newDic);
            }
        }

        private void ThemThuTuDapAnDaRandom(int indexCauHoi, int[] danhSachViTri)
        {
            if (DanhSachViTriDapAnDaRandom.ContainsKey(indexCauHoi))
            {
                DanhSachViTriDapAnDaRandom.Remove(indexCauHoi);
            }

            DanhSachViTriDapAnDaRandom.Add(indexCauHoi, danhSachViTri);
        }

        private void ThemDapAnDaChon(int indexCauHoi, int indexDapAn)
        {
            if (DanhSachDapAnDaChon.ContainsKey(indexCauHoi))
            {
                DanhSachDapAnDaChon.Remove(indexCauHoi);
            }

            DanhSachDapAnDaChon.Add(indexCauHoi, indexDapAn);
        }

        private int[] DaoViTri(int count)
        {
            int[] index = Enumerable.Range(0, count).ToArray();
            int n = index.Length;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                int temp = index[n];
                index[n] = index[k];
                index[k] = temp;
            }

            //foreach (int i in index) Console.WriteLine(i);
            return index;
        }

        private int[] RandomViTriDapAn()
        {
            int[] numbers = { 0, 1, 2, 3 };
            int n = numbers.Length;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                int temp = numbers[n];
                numbers[n] = numbers[k];
                numbers[k] = temp;
            }

            return numbers;
        }

        private void renderUI()
        {
            tenSVLabel.Text = dataSV["HoTen"].ToString();
            MSVLabel.Text = dataSV["MaSinhVien"].ToString();

            label1.Focus();

            DataTable selectMMT = mysql.ExecuteQuery("SELECT * FROM `mon_thi` WHERE `MMH` = '" + MMT + "'");
            DataRow MMTRow = selectMMT.Rows[0];

            label5.Text = MMTRow["NAME"].ToString().ToUpper();

            string ThoiGianThi = MMTRow["DURATION"].ToString();

            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            label11.Text = formattedDate;
            label9.Text = ThoiGianThi + " phút";
            label7.Text = MMTRow["KI_THI"].ToString();

            DataTable searchQuestions = mysql.ExecuteQuery("SELECT * FROM `de_thi` WHERE `MMH` = '" + MMT + "'");

            for (int i = 0; i < searchQuestions.Rows.Count; i++)
            {
                DataRow row = searchQuestions.Rows[i];

                ThemCauHoi(i, row["CAUHOI"].ToString());

                int[] viTriDaRandom = RandomViTriDapAn();

                ThemThuTuDapAnDaRandom(i, viTriDaRandom);

                ThemDapAnChoCauHoi(i, 0, row["DAP_AN_SAI_1"].ToString());
                ThemDapAnChoCauHoi(i, 1, row["DAP_AN_SAI_2"].ToString());
                ThemDapAnChoCauHoi(i, 2, row["DAP_AN_SAI_3"].ToString());
                ThemDapAnChoCauHoi(i, 3, row["DAP_AN_DUNG"].ToString());
            }

            int countCauHoi = 1;
            int[] viTriCauHoiRandom = DaoViTri(DanhSachCauHoi.Count);

            DanhSachViTriCauHoiDaRandom = viTriCauHoiRandom.ToList();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (countCauHoi <= viTriCauHoiRandom.Count())
                    {
                        Button newBtn = new Button();
                        newBtn.Name = "btn_" + countCauHoi + "_" + viTriCauHoiRandom[countCauHoi - 1];
                        newBtn.Size = new Size(71, 43);
                        newBtn.TabIndex = 26;
                        newBtn.Text = "Câu " + countCauHoi;
                        newBtn.UseVisualStyleBackColor = true;
                        newBtn.Cursor = Cursors.Hand;
                        newBtn.BackColor = Color.Gainsboro;
                        newBtn.ForeColor = Color.Black;
                        newBtn.FlatStyle = FlatStyle.Flat;
                        newBtn.Click += newBtn_Click;
                        tableLayoutPanel1.Controls.Add(newBtn, j, i);
                        ThemNutCauHoi(countCauHoi - 1, newBtn);
                        countCauHoi++;
                    }
                }
            }

            showCauHoi(1, viTriCauHoiRandom[0]);

            remainingSeconds = Int32.Parse(ThoiGianThi) * 60;

            timer.Interval = 100;
            timer.Tick += demNguoc;
            timer.Start();
        }

        private void showCauHoi(int cau, int realOrder)
        {
            string cauHoi = DanhSachCauHoi[realOrder];

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if (DanhSachDapAnDaChon.ContainsKey(realOrder))
            {
                int viTriDapAnDaChon = DanhSachDapAnDaChon[realOrder];

                switch (viTriDapAnDaChon)
                {
                    case 0:
                        radioButton1.Checked = true;
                        break;
                    case 1:
                        radioButton2.Checked = true;
                        break;
                    case 2:
                        radioButton3.Checked = true;
                        break;
                    case 3:
                        radioButton4.Checked = true;
                        break;
                }
            }

            //Console.WriteLine(cauHoi);

            label2.Text = "Câu " + cau + ":";
            label3.Text = cauHoi;

            radioButton1.Click -= DapAnBtn_Click;
            radioButton2.Click -= DapAnBtn_Click;
            radioButton3.Click -= DapAnBtn_Click;
            radioButton4.Click -= DapAnBtn_Click;

            int i = 0;

            foreach (int index in DanhSachViTriDapAnDaRandom[realOrder])
            {
                //Console.WriteLine(index);
                bool isDapAnDung = false;
                if (index == 3)
                {
                    isDapAnDung = true;
                }

                switch (i)
                {
                    case 0:
                        radioButton1.Text = (char)('A' + i) + ". " + DanhSachDapAn[realOrder][index];
                        radioButton1.Tag = "dapan_" + realOrder + "_" + i + "_" + index + "_" + isDapAnDung;
                        radioButton1.Click += DapAnBtn_Click;
                        break;
                    case 1:
                        radioButton2.Text = (char)('A' + i) + ". " + DanhSachDapAn[realOrder][index];
                        radioButton2.Tag = "dapan_" + realOrder + "_" + i + "_" + index + "_" + isDapAnDung;
                        radioButton2.Click += DapAnBtn_Click;
                        break;
                    case 2:
                        radioButton3.Text = (char)('A' + i) + ". " + DanhSachDapAn[realOrder][index];
                        radioButton3.Tag = "dapan_" + realOrder + "_" + i + "_" + index + "_" + isDapAnDung;
                        radioButton3.Click += DapAnBtn_Click;
                        break;
                    case 3:
                        radioButton4.Text = (char)('A' + i) + ". " + DanhSachDapAn[realOrder][index];
                        radioButton4.Tag = "dapan_" + realOrder + "_" + i + "_" + index + "_" + isDapAnDung;
                        radioButton4.Click += DapAnBtn_Click;
                        break;
                }
                i++;
            }
        }

        private void LoadBtnChonCau()
        {
            for (int i = 0; i < DanhSachNutCauHoi.Count; i++)
            {
                Button btn = DanhSachNutCauHoi[i];
                btn.BackColor = Color.Gainsboro;
                btn.ForeColor = Color.Black;

                string btnTag = btn.Name;
                string[] btnSplited = btnTag.Split("_");

                int order = Int32.Parse(btnSplited[1]);
                int realOrder = Int32.Parse(btnSplited[2]);


                if (DanhSachDapAnDaChon.ContainsKey(realOrder))
                {
                    btn.BackColor = Color.MediumSeaGreen;
                    btn.ForeColor = Color.White;
                }

                if (i == btnDangChon)
                {
                    btn.Font = new Font("Tw Cen MT Condensed Extra Bold", 14F, FontStyle.Underline, GraphicsUnit.Point);
                }
                else
                {
                    btn.Font = new Font("Tw Cen MT Condensed Extra Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            bunifuFlatButton2.Show();
            bunifuFlatButton3.Show();

            if (btnDangChon == 0)
            {
                bunifuFlatButton2.Hide();
            }

            if (btnDangChon == DanhSachNutCauHoi.Count - 1)
            {
                bunifuFlatButton3.Hide();
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                bunifuCards1.Focus();
                string[] btnSplited = clickedButton.Name.Split("_");

                int order = Int32.Parse(btnSplited[1]);
                int realOrder = Int32.Parse(btnSplited[2]);
                btnDangChon = order - 1;
                showCauHoi(order, realOrder);
            }
        }

        private void DapAnBtn_Click(object sender, EventArgs e)
        {
            if (sender is RadioButton clickedBtn)
            {
                LoadBtnChonCau();
                string radioBtnTag = clickedBtn.Tag.ToString();
                string[] tagSplited = radioBtnTag.Split("_");
                int cau = Int32.Parse(tagSplited[1]);
                int viTriDapAn = Int32.Parse(tagSplited[2]);

                //Console.WriteLine(cau);

                if (DanhSachDapAnDaChon.ContainsKey(cau))
                {
                    if (DanhSachDapAnDaChon[cau] == viTriDapAn)
                    {
                        DanhSachDapAnDaChon.Remove(cau);
                        clickedBtn.Checked = false;
                    }
                    else
                    {
                        DanhSachDapAnDaChon[cau] = viTriDapAn;
                    }
                }
                else
                {
                    ThemDapAnDaChon(cau, viTriDapAn);
                }
            }
        }

        private int countToMinus = 0;

        private void demNguoc(object sender, EventArgs e)
        {
            countToMinus++;
            if (countToMinus == 10)
            {
                countToMinus = 0;
                remainingSeconds--;
            }

            LoadBtnChonCau();

            TimeSpan timeSpan = TimeSpan.FromSeconds(remainingSeconds);
            counterLabel.Text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";

            if (remainingSeconds <= 0 && !isStop)
            {
                timer.Stop();
                isStop = true;
                NopBai();
            }
        }

        private void PExForm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (btnDangChon < DanhSachNutCauHoi.Count - 1)
            {
                btnDangChon++;
                DanhSachNutCauHoi[btnDangChon].PerformClick();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (btnDangChon > 0)
            {
                btnDangChon--;
                DanhSachNutCauHoi[btnDangChon].PerformClick();
            }
        }

        private void NopBai()
        {
            string jsonData = ConvertToJSON();

            dynamic json = JsonConvert.DeserializeObject(jsonData);

            mysql.ExecuteNonQuery("INSERT INTO `diem_thi`(`MaSinhVien`, `MMH`, `LOGS`, `Diem`) VALUES ('" + dataSV["MaSinhVien"] + "', '" + MMT + "', '" + jsonData + "', " + json.SoDiem + ")");

            DialogResult diaRes = MessageBox.Show(dataSV["HoTen"] + " - " + dataSV["MaSinhVien"] + "\n- Tổng số câu đúng: " + json.SoKetQuaDung + "\n- Tổng điểm: " + json.SoDiem, "PEx - thông báo kết quả bài làm!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (diaRes.ToString() == "OK")
            {
                this.Hide();
                new PExForm1(mysql).ShowDialog();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bool confirm = false;
            if (DanhSachDapAnDaChon.Count < DanhSachNutCauHoi.Count)
            {
                int CauHoiConLai = DanhSachNutCauHoi.Count - DanhSachDapAnDaChon.Count;
                DialogResult diaRes = MessageBox.Show("Còn lại " + CauHoiConLai + " chưa hoàn thành, bạn có chắc chắn muốn nộp bài không?", "PEx - thông báo!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (diaRes.ToString() == "Yes")
                {
                    confirm = true;
                }
            }

            if (confirm)
            {
                NopBai();
            }
        }
    }
}
