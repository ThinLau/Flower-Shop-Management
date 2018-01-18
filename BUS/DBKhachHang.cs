using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class DBKhachHang
    {
        QuanLyBanHoaEntities context = new QuanLyBanHoaEntities();

        public List<KhachHang> GetAllCustomer()
        {
            List<KhachHang> khs = context.KhachHangs.ToList();
            return khs;
        }
        public string SetNewPrimaryKey()
        {
            string nextPrimaryKey = context.KhachHangs
                          .Select(e => e.MaKH)
                          .OrderByDescending(p => p)
                          .FirstOrDefault();

            int t = int.Parse(nextPrimaryKey.Substring(2));
            return "KH"+((t + 1) < 10 ? "0" + (t + 1).ToString() : (t + 1).ToString());
        }
        public List<KhachHang> Fillter(string colName, string value)
        {
            List<KhachHang> dv = new List<KhachHang>();
            if (colName == "TenKH")
                dv = context.KhachHangs.Where(s => s.TenKH.Contains(value)).ToList();
            if (colName == "MaKH")
                dv = context.KhachHangs.Where(s => s.MaKH.Contains(value)).ToList();
            if (colName == "GioiTinh")
                dv = context.KhachHangs.Where(s => s.GioiTinh.Contains(value)).ToList();
            if (colName == "DiaChi")
                dv = context.KhachHangs.Where(s => s.DiaChi.Contains(value)).ToList();
            if (colName == "SDT")
                dv = context.KhachHangs.Where(s => s.SDT.Contains(value)).ToList();
            if (colName == "MaLoaiKH")
                dv = context.KhachHangs.Where(s => s.MaLoaiKH.Contains(value)).ToList();
            if (colName == "NgaySinh")
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(value);
                    dv = context.KhachHangs.Where(s => s.NgaySinh == dt).ToList();
                }
                catch { }
            }
            return dv;
        }
        public bool InsertCustomer(string maKH, string tenKH,DateTime? ngaySinh,string gioiTinh, string diaChi,string sdt,string maLoaiKH)
        {
          
            try
            {
                KhachHang kh = new KhachHang
                {
                    MaKH = maKH,
                    TenKH = tenKH,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    SDT = sdt,
                    MaLoaiKH = maLoaiKH
                };
                context.KhachHangs.Add(kh);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateCustomer(string maKH, string tenKH, DateTime? ngaySinh, string gioiTinh, string diaChi, string sdt, string maLoaiKH)
        {
            try
            {
                KhachHang kh = context.KhachHangs.Single(s => s.MaKH.Equals(maKH));
                kh.TenKH = tenKH;
                kh.NgaySinh = ngaySinh;
                kh.GioiTinh = gioiTinh;
                kh.DiaChi = diaChi;
                kh.SDT = sdt;
                kh.MaLoaiKH = maLoaiKH;

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCustomer(string maKH)
        {
            try
            {
                KhachHang kh = context.KhachHangs.Single(s => s.MaKH.Equals(maKH));

                context.KhachHangs.Remove(kh);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
