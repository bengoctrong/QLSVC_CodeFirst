using QLSVC_CodeFirst.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVC_CodeFirst
{
    public partial class Form1 : Form
    {
        public QLSV_BLL BLL { get; set; }
        public Form1()
        {
            InitializeComponent();
            BLL = new QLSV_BLL();
            load_cB();
            
        }
        public void load_cB()
        {
            cBTenKhoa.DataSource = BLL.Get_TenKhoa_BLL();
            cBQueQuan.DataSource = BLL.Get_QueQuan_BLL();
            cBHoKhau.DataSource = BLL.Get_HoKhau_BLL();
            cBSort.Items.Add("Mã Sinh Viên");
            cBSort.Items.Add("Tên Sinh Viên");
        }
        public void HienThi()
        {
            dataGridView1.DataSource = BLL.Get_ListSV_BLL();
        }
        private void btShow_Click(object sender, EventArgs e)
        {
            HienThi();
        }
        public void Add_Form1(SinhVien sv, string tenKhoa)
        {
            BLL.AddSV_BLL(sv, tenKhoa);
            HienThi();
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(BLL.Get_TenKhoa_BLL(),BLL.Get_QueQuan_BLL(),BLL.Get_HoKhau_BLL());
            f.a = new Form2.Add(Add_Form1);
            //f.g = new Form2.GetMaKhoa(BLL.Get_MaKhoa_BLL);
            f.Show();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int ms = Int32.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                BLL.Del_SV_BLL(ms);
            }
            HienThi();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tBMSSV.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tBHoTen.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dTPNgSinh.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "True") rBNam.Checked = true;
            else rBNu.Checked = true;
            cBHoKhau.SelectedIndex = cBHoKhau.FindStringExact(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            cBQueQuan.SelectedIndex = cBQueQuan.FindStringExact(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            tBDTL.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cBTenKhoa.SelectedIndex = cBTenKhoa.FindStringExact(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSinhVien = Int32.Parse(tBMSSV.Text);
            sv.TenSinhVien = tBHoTen.Text;
            sv.NgaySinh = dTPNgSinh.Value;
            sv.QueQuan = cBQueQuan.Text;
            sv.HoKhau = cBHoKhau.Text;
            sv.GioiTinh = rBNam.Checked;
            sv.DiemTL = double.Parse(tBDTL.Text);
            //sv.MaKhoa = "B001";
            string tenKhoa = cBTenKhoa.SelectedItem.ToString();
            sv.MaKhoa = BLL.Get_MaKhoa_BLL(tenKhoa);
            BLL.Edit_SV_BLL(sv);
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string search = tBSearch.Text;
            
            dataGridView1.DataSource = BLL.Search_BLL(search);
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            int[] mssv = new int[dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
               mssv[i] =Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }

            if(cBSort.SelectedIndex==0)
            dataGridView1.DataSource = QLSV_BLL.SORT_BLL(BLL.Get_ListSV_Search_BLL(mssv), SVShow.cmpMSSV);
            if (cBSort.SelectedIndex == 1)
                dataGridView1.DataSource = QLSV_BLL.SORT_BLL(BLL.Get_ListSV_Search_BLL(mssv), SVShow.cmpTen);
        }
    }
}
