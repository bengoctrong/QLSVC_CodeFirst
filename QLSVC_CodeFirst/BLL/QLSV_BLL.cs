using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSVC_CodeFirst
{
    public class QLSV_BLL
    {
        public QLSV_DAL DAL { get; set; }
        public QLSV_BLL()
        {
            DAL = new QLSV_DAL();
        }
        
        public List<SVShow> Get_ListSV_BLL()
        {
            return DAL.Get_ListSV_DAL();
        }
        public List<SVShow> Get_ListSV_Search_BLL(int[] mssv)
        {
            return DAL.Get_ListSV_Search_DAL(mssv);
        }
        public void AddSV_BLL(SinhVien sv, string tenKhoa)
        {
            DAL.AddSV_DAL(sv, tenKhoa);
        }
        public string Get_MaKhoa_BLL(string tenKhoa)
        {
            return DAL.Get_MaKhoa_DAL(tenKhoa);
        }
        public List<string> Get_TenKhoa_BLL()
        {
            return DAL.Get_TenKhoa_DAL();
        }
        public List<string> Get_QueQuan_BLL()
        {
            return DAL.Get_QueQuan_DAL();
        }
        public List<string> Get_HoKhau_BLL()
        {
            return DAL.Get_HoKhau_DAL();
        }
        public void Del_SV_BLL(int ms)
        {
            DAL.Del_SV_DAL(ms);
        }
        public void Edit_SV_BLL(SinhVien sv)
        {
            DAL.Edit_SV_DAL(sv);
        }
        public List<SVShow> Search_BLL(string str)
        {
            return DAL.Search_DAL(str);
        }
        public static List<SVShow> SORT_BLL(List<SVShow> obj, QLSV_DAL.Compare cmp)
        {
            return QLSV_DAL.SORT_DAL(obj, cmp);
        }
    }
}
