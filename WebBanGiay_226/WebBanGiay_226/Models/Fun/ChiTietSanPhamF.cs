using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Models.Fun
{
    public class ChiTietSanPhamF
    {
        WebGiay db = null;
        public ChiTietSanPhamF()
        {
            db = new WebGiay();
        }
        public ViewSanPham ViewDetail(long MaSP)
        {
            var sp = db.SanPhams.Find(MaSP);
            return db.ViewSanPhams.FirstOrDefault(x => x.MaSanPham == sp.MaSanPham);
        }
        public List<ViewSanPham> LienQuan(long MG)
        {
            var sp = db.ViewSanPhams.Find(MG);
            return db.ViewSanPhams.Where(x => x.MaCTSP != MG && x.MaSanPham == sp.MaSanPham).ToList();
        }

        public List<ViewSanPham> ListGiaylQ(long MaSP)
        {
            var sp = db.SanPhams.Find(MaSP);
            return db.ViewSanPhams.Where(x => x.MaSanPham == sp.MaSanPham).ToList();
        }
    }
}