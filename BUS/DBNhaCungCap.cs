﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class DBNhaCungCap
    {
        QuanLyBanHoaEntities context = new QuanLyBanHoaEntities();

        public List<NhaCungCap> GetAllNhaCC()
        {
            return context.NhaCungCaps.ToList();
        }
        public List<NhaCungCap> Fillter(string colName, string value)
        {
            List<NhaCungCap> dv = new List<NhaCungCap>();
            if (colName == "MaNCC")
                dv = context.NhaCungCaps.Where(s => s.MaNCC.Contains(value)).ToList();
            if (colName == "TenNCC")
                dv = context.NhaCungCaps.Where(s => s.TenNCC.Contains(value)).ToList();
            if (colName == "DiaChi")
                dv = context.NhaCungCaps.Where(s => s.DiaChi.Contains(value)).ToList();
            if (colName == "SDT")
                dv = context.NhaCungCaps.Where(s => s.SDT.Contains(value)).ToList();
            return dv;
        }
        public bool InsertNhaCC(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap
                {
                    MaNCC = maNCC,
                    TenNCC = tenNCC,
                    DiaChi = diaChi,
                    SDT = sdt,
                };
                context.NhaCungCaps.Add(ncc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateNhaCC(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            try
            {
                NhaCungCap ncc = context.NhaCungCaps.Single(n => n.MaNCC.Equals(maNCC));
                ncc.TenNCC = tenNCC;
                ncc.DiaChi = diaChi;
                ncc.SDT = sdt;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteNhaCC(string maNCC)
        {
            try
            {
                NhaCungCap ncc = context.NhaCungCaps.Single(n => n.MaNCC.Equals(maNCC));

                context.NhaCungCaps.Remove(ncc);
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
