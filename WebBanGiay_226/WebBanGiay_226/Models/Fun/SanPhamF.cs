using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Models.Fun
{
    public class SanPhamF
    {
        WebGiay db = null;
        public SanPhamF()
        {
            db = new WebGiay();
        }
        public List<SanPham> ListSP(int top)
        {
            return db.SanPhams.Take(top).ToList();
        }
        public SanPham ViewDetail(long id)
        {
            return db.SanPhams.Find(id);
        }
        public List<ViewSanPham> TimKiemSP(string TenSanPham)
        {
            return db.ViewSanPhams.Where(x => x.TenSanPham == TenSanPham).ToList();
        }
        public ViewSanPham FindEntity(long MaOD)
        {
            return db.ViewSanPhams.Find(MaOD);
        }
    }
}