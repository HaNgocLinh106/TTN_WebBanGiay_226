using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_226.Models.Fun;

namespace WebBanGiay_226.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult DanhMuc()
        {
            var model = new DanhMucF().ListAll();
            return PartialView(model);
        }

        public PartialViewResult ListSanPham()
        {
            var model = new SanPhamF().ListSP(3);
            return PartialView(model);
        }

        public ActionResult SanPham(long MaDanhMuc)
        {
            var danhmuc = new DanhMucF().DanhMucSP(MaDanhMuc);
            ViewBag.SanPham = new DanhMucF().ListAllSP(danhmuc.MaDanhMuc);
            return View(MaDanhMuc);
        }

        public ActionResult ChiTietSanPham(long MaSanPham)
        {

            var product = new SanPhamF().ViewDetail(MaSanPham);
            ViewBag.GiayOD = new ChiTietSanPhamF().ViewDetail(product.MaSanPham);
            ViewBag.Giay = new ChiTietSanPhamF().ListGiaylQ(product.MaSanPham);

            return View(MaSanPham);
        }


    }
}