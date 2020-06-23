using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_226.Models.EF;
using WebBanGiay_226.Models.Fun;

namespace WebBanGiay_226.Controllers
{
    public class HomeController : Controller
    {
        WebGiay db = new WebGiay();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }       
        public ActionResult PhanHoi()
        {
            return View();
        }
        public ActionResult AllSanPham()
        {
            var model = db.SanPhams.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult TimKiem(string search)
        {
            var model = new SanPhamF().TimKiemSP(search);
            return View(model);
        }
    }
}