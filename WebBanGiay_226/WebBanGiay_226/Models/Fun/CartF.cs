using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Models.Fun
{
    public class CartF
    {
        WebGiay db = null;
        public CartF()
        {
            db = new WebGiay();
        }
        public long Insert(GioHang giohang)
        {
            db.GioHangs.Add(giohang);
            db.SaveChanges();
            return giohang.MaGioHang;
        }
    }
}