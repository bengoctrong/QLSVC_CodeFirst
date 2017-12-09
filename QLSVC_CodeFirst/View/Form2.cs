using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVC_CodeFirst.View
{
    public partial class Form2 : Form
    {
        public delegate void Add(SinhVien s, string tenKhoa);
        public Add a;
        //public delegate string GetMaKhoa(string tenKhoa);
        //public GetMaKhoa g;
        public Form2(List<string> tenKhoa, List<string> queQuan, List<string> hoKhau)
        {
            InitializeComponent();
            cBTenKhoa.DataSource = tenKhoa;
            cBHoKhau.DataSource = hoKhau;
            cBQueQuan.DataSource = queQuan;
        }

        private void btOK_Click(object sender, EventArgs e)
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
           // sv.MaKhoa = g.Invoke(tenKhoa);
            //BLL.AddSV_BLL(sv);
            a.Invoke(sv,tenKhoa);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
