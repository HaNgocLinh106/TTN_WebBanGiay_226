using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Models.Fun
{
    public class CartDetailF
    {
        WebGiay db = null;
        public CartDetailF()
        {
            db = new WebGiay();
        }
        public bool Insert(ChiTietGioHang ctgh)
        {
            try
            {
                db.ChiTietGioHangs.Add(ctgh);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}