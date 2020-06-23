using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_226.Models.Fun;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = (Cart)Session[CartSession];

            var list = new List<CartItem>();

            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
            }

            return View(list);
        }



        public ActionResult AddItem(long Id, string returnURL)
        {

            var product = new SanPhamF().FindEntity(Id);
            var cart = (Cart)Session[CartSession];

            var sizemau = Request.Form["sizemau"];
            Console.WriteLine(sizemau);           

            if (cart != null)
            {
                cart.AddItem(product, 1, sizemau);
                //Gán vào session
                Session[CartSession] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1, sizemau);
                //Gán vào session
                Session[CartSession] = cart;
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }

            return Redirect(returnURL);

        }
        public ActionResult UpdateCart(long Id, FormCollection fr)
        {

            var product = new SanPhamF().FindEntity(Id);

            var cart = (Cart)Session[CartSession];

            var sizemau = Request.Form["sizemau"];
            Console.WriteLine(sizemau);

            if (cart != null)
            {
                int NewQuantity = int.Parse(fr["txtQuantity"].ToString());
                cart.UpdateItem(product, NewQuantity);
                //Gán vào session
                Session[CartSession] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1, sizemau);
                //Gán vào session
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index");

        }

        // GET: /Cart/Details/5
        public ActionResult RemoveLine(long Id)
        {

            var product = new SanPhamF().FindEntity(Id);

            var cart = (Cart)Session[CartSession];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            var cart = (Cart)Session[CartSession];
            cart.Clear();
            Session[CartSession] = cart;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = (Cart)Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult ThanhToan(string shipName, string mobile, string address, string hinhthuctt)
        {
            var giohang = new GioHang();
            giohang.NgayThang = DateTime.Now;
            giohang.DiaChi = address;
            giohang.SDT = mobile;
            giohang.TenNguoiDung = shipName;
            giohang.HinhThucThanhToan = hinhthuctt;

            try
            {
                var id = new CartF().Insert(giohang);
                var cart = (Cart)Session[CartSession];
                var ctghF = new CartDetailF();
                foreach (var it in cart.Lines)
                {
                    var ctgh = new ChiTietGioHang();
                    ctgh.MaCTSP = it.ViewSanPham.MaCTSP;
                    ctgh.MaGioHang = id;
                    ctgh.DonGia = it.ViewSanPham.DonGia;
                    ctgh.SoLuong = it.Quantity;
                    ctghF.Insert(ctgh);
                }
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult ThanhCong()
        {
            return View();
        }
    }
}