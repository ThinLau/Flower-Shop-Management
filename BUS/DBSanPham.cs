using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBSanPham
    {
        QuanLyBanHoaEntities context = new QuanLyBanHoaEntities();

        public List<SanPham> GetAllProduct()
        {
            List<SanPham> sps = context.SanPhams.ToList();
            return sps;
        }

        public string SetNewPrimaryKey()
        {
            string nextPrimaryKey = context.SanPhams
                          .Select(e => e.MaSP)
                          .OrderByDescending(p => p)
                          .FirstOrDefault();

            int t = int.Parse(nextPrimaryKey);
            return ((t + 1) < 10 ? "0" + (t + 1).ToString() : (t + 1).ToString());
        }
        public List<SanPham> Fillter(string colName, string value)
        {
            List<SanPham> dv = new List<SanPham>();
            if (colName == "TenSP")
                dv = context.SanPhams.Where(s => s.TenSP.Contains(value)).ToList();
            if (colName == "MaSP")
                dv = context.SanPhams.Where(s => s.MaSP.Contains(value)).ToList();
            if (colName == "DonViTinh")
                dv = context.SanPhams.Where(s => s.DonViTinh.Contains(value)).ToList();
            if (colName == "SoLuong")
            {
                try
                {
                    int sl = int.Parse(value);
                    dv = context.SanPhams.Where(s => s.SoLuong.Equals(sl)).ToList();
                }
                catch { }
            }
            if (colName == "GiaMua")
            {
                try
                {
                    decimal giaMua = decimal.Parse(value);
                    dv = context.SanPhams.Where(s => s.SoLuong.Equals(giaMua)).ToList();
                }
                catch { }
            }
            if (colName == "GiaBan")
            {
                try
                {
                    decimal giaBan = decimal.Parse(value);
                    dv = context.SanPhams.Where(s => s.SoLuong.Equals(giaBan)).ToList();
                }
                catch { }
            }
            return dv;
        }
        public bool InsertProduct(string maSP, string tenSP, int? soLuong, decimal? giaMua, decimal? giaban, string donViTinh)
        {

            try
            {
                SanPham sp = new SanPham
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    GiaBan = giaban,
                    GiaMua = giaMua,
                    DonViTinh = donViTinh
                };
                context.SanPhams.Add(sp);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateProduct(string maSP, string tenSP, int? soLuong, decimal? giaMua, decimal? giaban, string donViTinh)
        {
            try
            {
                SanPham sp = context.SanPhams.Single(s => s.MaSP.Equals(maSP));
                sp.TenSP = tenSP;
                sp.SoLuong = soLuong;
                sp.GiaBan = giaban;
                sp.GiaMua = giaMua;
                sp.DonViTinh = donViTinh;

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void UpdateProductAmount(string maSP, int soLuongAdd)
        {
            try
            {
                SanPham sp = context.SanPhams.Single(s => s.MaSP.Equals(maSP));
                sp.SoLuong += soLuongAdd;
                context.SaveChanges();
            }
            catch
            { }
        }
        public bool DeleteProduct(string maSP)
        {
            try
            {
                SanPham sp = context.SanPhams.Single(s => s.MaSP.Equals(maSP));

                context.SanPhams.Remove(sp);
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
