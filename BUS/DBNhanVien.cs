using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class DBNhanVien
    {
        QuanLyBanHoaEntities context = new QuanLyBanHoaEntities();

        public List<NhanVien> GetAllEmployee()
        {
            return context.NhanViens.ToList();
        }
        public string SetNewPrimaryKey()
        {
            string nextPrimaryKey = context.NhanViens
                          .Select(e => e.MaNV)
                          .OrderByDescending(p => p)
                          .FirstOrDefault();

            int t = int.Parse(nextPrimaryKey);
            return ((t + 1) < 10 ? "0" + (t + 1).ToString() : (t + 1).ToString());
        }
        public List<NhanVien> Fillter(string colName, string value)
        {
            List<NhanVien> dv = new List<NhanVien>();
            if (colName == "MaNV")
                dv = context.NhanViens.Where(s => s.MaNV.Contains(value)).ToList();
            if (colName == "HoTenNV")
                dv = context.NhanViens.Where(s => s.HoTenNV.Contains(value)).ToList();
            if (colName == "GioiTinh")
                dv = context.NhanViens.Where(s => s.GioiTinh.Contains(value)).ToList();
            if (colName == "DiaChi")
                dv = context.NhanViens.Where(s => s.DiaChi.Contains(value)).ToList();
            if (colName == "SDT")
                dv = context.NhanViens.Where(s => s.SDT.Contains(value)).ToList();
            if (colName == "NgaySinh")
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(value);
                    dv = context.NhanViens.Where(s => s.NgaySinh == dt).ToList();
                }
                catch { }
            }
            return dv;
        }

        public bool InsertEmployee(string maNV, string tenNV, DateTime? ngaySinh, string sdt, string diaChi,string gioiTinh, decimal? luong)
        {
            
            try
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = maNV,
                    HoTenNV = tenNV,
                    NgaySinh = ngaySinh,
                    SDT = sdt,
                    DiaChi = diaChi,
                    GioiTinh = gioiTinh,
                    Luong = luong
                };
                context.NhanViens.Add(nv);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateEmployee(string maNV, string tenNV, DateTime? ngaySinh, string sdt, string diaChi, string gioiTinh, decimal? luong)
        {
            try
            {
                NhanVien nv = context.NhanViens.Single(s => s.MaNV.Equals(maNV));
                nv.HoTenNV = tenNV;
                nv.NgaySinh = ngaySinh;
                nv.SDT = sdt;
                nv.DiaChi = diaChi;
                nv.GioiTinh = gioiTinh;
                nv.Luong = luong;

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployee(string maNV)
        {
            try
            {
                NhanVien nv = context.NhanViens.Single(s => s.MaNV.Equals(maNV));
                context.NhanViens.Remove(nv);
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
