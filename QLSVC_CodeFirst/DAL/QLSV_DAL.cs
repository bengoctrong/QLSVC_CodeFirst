using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSVC_CodeFirst
{
    public class QLSV_DAL
    {
        public QuanLySinhVien_CodeFirst db;
        public QLSV_DAL()
        {
            db = new QuanLySinhVien_CodeFirst();
        }
        public List<SVShow> Get_ListSV_DAL()
        {
            List<SVShow> list = new List<SVShow>();
            var s = db.SinhViens.Select(p => new { p.MaSinhVien, p.TenSinhVien, p.NgaySinh, p.GioiTinh, p.HoKhau, p.QueQuan, p.DiemTL, p.Khoas.TenKhoa });
            foreach (var item in s)
            {
                SVShow sv = new SVShow();
                sv.MaSinhVien = item.MaSinhVien;
                sv.TenSinhVien = item.TenSinhVien;
                sv.NgaySinh = item.NgaySinh;
                sv.HoKhau = item.HoKhau;
                sv.QueQuan = item.QueQuan;
                sv.GioiTinh = item.GioiTinh;
                sv.DiemTL = item.DiemTL;
                sv.TenKhoa = item.TenKhoa;
                list.Add(sv);
            }
            return list;
        }
        public SVShow Get_SV_DAL(int ms)
        {
            SVShow sv = new SVShow();
            var s = db.SinhViens.Where(p => p.MaSinhVien == ms).Select(p => new { p.MaSinhVien, p.TenSinhVien, p.NgaySinh, p.GioiTinh, p.HoKhau, p.QueQuan, p.DiemTL, p.Khoas.TenKhoa });
            foreach (var item in s)
            {
                sv.MaSinhVien = item.MaSinhVien;
                sv.TenSinhVien = item.TenSinhVien;
                sv.NgaySinh = item.NgaySinh;
                sv.HoKhau = item.HoKhau;
                sv.QueQuan = item.QueQuan;
                sv.GioiTinh = item.GioiTinh;
                sv.DiemTL = item.DiemTL;
                sv.TenKhoa = item.TenKhoa;
            }
            return sv;
        }
        public List<SVShow> Get_ListSV_Search_DAL(int[] mssv)
        {
            List<SVShow> list = new List<SVShow>();
            foreach (int i in mssv)
            {
                list.Add(Get_SV_DAL(i));
        }
            return list;
        }
            
        public void AddSV_DAL(SinhVien sv, string tenKhoa)
        {
            sv.MaKhoa = Get_MaKhoa_DAL(tenKhoa);
            db.SinhViens.Add(sv);
            db.SaveChanges();
        }
        public string Get_MaKhoa_DAL(string tenKhoa)
        {
            string maKhoa;
            var s = db.Khoas.Where(p => p.TenKhoa == tenKhoa).Single();
            maKhoa = s.MaKhoa;
            return maKhoa;
        }
        public List<string> Get_TenKhoa_DAL()
        {
            List<string> list = new List<string>();
            var s = db.Khoas.Select(p => p).Distinct();
            foreach (var i in s)
            {
                list.Add(i.TenKhoa);
            }
            return list;
        }
        public List<string> Get_QueQuan_DAL()
        {
            List<string> list = new List<string>();
            //var s = db.Khoas.Select(p => p).Distinct();
            var s = db.SinhViens.Select(p => p.QueQuan).Distinct();
            foreach (var i in s)
            {
                list.Add(i);
            }
            return list;
        }
        public List<string> Get_HoKhau_DAL()
        {
            List<string> list = new List<string>();
            //var s = db.Khoas.Select(p => p).Distinct();
            var s = db.SinhViens.Select(p => p.HoKhau).Distinct();
            foreach (var i in s)
            {
                list.Add(i);
            }
            return list;
        }
        public void Del_SV_DAL(int ms)
        {
            SinhVien a = db.SinhViens.Where(p => p.MaSinhVien == ms).Single();
            db.SinhViens.Remove(a);
            db.SaveChanges();
        }
        public void Edit_SV_DAL(SinhVien sv)
        {
            SinhVien s = db.SinhViens.Where(p => p.MaSinhVien == sv.MaSinhVien).Single();
            s.TenSinhVien = sv.TenSinhVien;
            s.NgaySinh = sv.NgaySinh;
            s.QueQuan = sv.QueQuan;
            s.HoKhau = sv.HoKhau;
            s.GioiTinh = sv.GioiTinh;
            s.DiemTL = sv.DiemTL;
            s.MaKhoa = sv.MaKhoa;
            db.SaveChanges(); 
        }
        public List<SVShow> Search_DAL(string str)
        {
            List<SVShow> list = new List<SVShow>();
            var s = db.SinhViens.Where(p=>p.TenSinhVien.Contains(str)).Select(p => new { p.MaSinhVien, p.TenSinhVien, p.NgaySinh, p.GioiTinh, p.HoKhau, p.QueQuan, p.DiemTL, p.Khoas.TenKhoa });
            foreach (var item in s)
            {
                SVShow sv = new SVShow();
                sv.MaSinhVien = item.MaSinhVien;
                sv.TenSinhVien = item.TenSinhVien;
                sv.NgaySinh = item.NgaySinh;
                sv.HoKhau = item.HoKhau;
                sv.QueQuan = item.QueQuan;
                sv.GioiTinh = item.GioiTinh;
                sv.DiemTL = item.DiemTL;
                sv.TenKhoa = item.TenKhoa;
                list.Add(sv);
            }
            return list;
        }
        public delegate bool Compare(object o1, object o2); 
        public static List<SVShow> SORT_DAL(List<SVShow> obj, Compare cmp)
        {
            for (int i = 0; i < obj.Count - 1; i++)
            {
                for (int j = i + 1; j < obj.Count; j++)
                {
                    if (cmp(obj[i], obj[j]) == false)
                    {
                        //HV(ref obj[i], ref obj[j]);
                        SVShow tmp = obj[i];
                        obj[i] = obj[j];
                        obj[j] = tmp;
                    };
                }
            }
            return obj;
        }
    }
}
