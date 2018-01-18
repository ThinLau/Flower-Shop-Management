using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBCTHopDong
    {
        QuanLyBanHoaEntities context = new QuanLyBanHoaEntities();
        public List<ChiTietHopDong> GetAllCTHopDong()
        {
            return context.ChiTietHopDongs.ToList();
        }
        public List<ChiTietHopDong> Fillter(string colName, string value)
        {
            List<ChiTietHopDong> dv = new List<ChiTietHopDong>();
            if (colName == "SoHopDong")
                dv = context.ChiTietHopDongs.Where(s => s.SoHopDong.Contains(value)).ToList();
            if (colName == "MaSP")
                dv = context.ChiTietHopDongs.Where(s => s.MaSP.Contains(value)).ToList();
            return dv;
        }
        public bool InsertCTHopDong(ref string err, string soHopDong, string maSP, int soLuong, decimal? donGia)
        {
            try
            {
                ChiTietHopDong cthd = new ChiTietHopDong
                {
                    SoHopDong = soHopDong,
                    MaSP = maSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                };
                context.ChiTietHopDongs.Add(cthd);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }
        public bool UpdateCTHopDong(string soHopDong, string maSP, int soLuong, decimal? donGia)
        {
            try
            {
                ChiTietHopDong cthd = context.ChiTietHopDongs.Single(s => s.SoHopDong.Equals(soHopDong) && s.MaSP.Equals(maSP));
                cthd.SoLuong = soLuong;
                cthd.DonGia = donGia;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCTHopDong(string soHopDong, string maSP)
        {
            try
            {
                ChiTietHopDong cthd = context.ChiTietHopDongs.Single(s => s.SoHopDong.Equals(soHopDong) && s.MaSP.Equals(maSP));
                context.ChiTietHopDongs.Remove(cthd);
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
