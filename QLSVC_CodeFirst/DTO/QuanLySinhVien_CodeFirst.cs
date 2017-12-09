namespace QLSVC_CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class QuanLySinhVien_CodeFirst : DbContext
    {
        // Your context has been configured to use a 'QuanLySinhVien_CodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLSVC_CodeFirst.DTO.QuanLySinhVien_CodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QuanLySinhVien_CodeFirst' 
        // connection string in the application configuration file.
        public QuanLySinhVien_CodeFirst()
            : base("name=QuanLySinhVien_CodeFirst")
        {
            Database.SetInitializer<QuanLySinhVien_CodeFirst>(new Initializer());
        }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        
        public class Initializer : DropCreateDatabaseIfModelChanges<QuanLySinhVien_CodeFirst>
        {
            protected override void Seed(QuanLySinhVien_CodeFirst context)
            {
                context.Khoas.Add(new Khoa { MaKhoa = "A001", TenKhoa = "Công Nghệ Thông Tin" });
                context.Khoas.Add(new Khoa { MaKhoa = "B001", TenKhoa = "Điện - Điện Tử" });
                context.Khoas.Add(new Khoa { MaKhoa = "C001", TenKhoa = "Môi Trường" });
                context.Khoas.Add(new Khoa { MaKhoa = "D001", TenKhoa = "Sư Phạm Kỹ Thuật" });
                //context.SinhViens.Add(new SinhVien { MaSinhVien = 001, TenSinhVien = "Bế Ngọc Trọng", NgaySinh = DateTime.Parse("1996/03/25"), HoKhau = "Đắk Lắk", QueQuan = "Cao Bằng", GioiTinh = true, DiemTL = 3.0, MaKhoa = "A001" });
                context.SaveChanges();
            }
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class SinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSinhVien { get; set; }
        [Required]
        public string TenSinhVien { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string QueQuan { get; set; }
        [Required]
        public string HoKhau { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public double DiemTL { get; set; }
        [Required]
        public string MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa Khoas { get; set; }
        public SinhVien ()
        {

        }
        
    }
    public class SVShow
    {
        public int MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string HoKhau { get; set; }
        public string QueQuan { get; set; }
        public double DiemTL { get; set; }
        public string TenKhoa { get; set; }
        public static bool cmpMSSV(object a, object b)
        {
            if (((SVShow)a).MaSinhVien > ((SVShow)b).MaSinhVien) return false;
            else return true;
        }
        public static bool cmpTen(object a, object b)
        {
            if (((SVShow)a).TenSinhVien[0] > ((SVShow)b).TenSinhVien[0]) return false;
            else return true;
        }
        public static bool cmpNgaySinh(object a, object b)
        {
            if (((SVShow)a).NgaySinh > ((SVShow)b).NgaySinh) return false;
            else return true;
        }
        public static bool cmpHoKhau(object a, object b)
        {
            if (((SVShow)a).HoKhau[0] > ((SVShow)b).HoKhau[0]) return false;
            else return true;
        }
        public static bool cmpQueQuan(object a, object b)
        {
            if (((SVShow)a).QueQuan[0] > ((SVShow)b).QueQuan[0]) return false;
            else return true;
        }
        public static bool cmpDiem(object a, object b)
        {
            if (((SVShow)a).DiemTL > ((SVShow)b).DiemTL) return false;
            else return true;
        }

    }
    public class Khoa
    {
        [Key]
        public string MaKhoa { get; set; }
        [Required]
        public string TenKhoa { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
        public Khoa()
        { }
    }
}