using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiay_226.Models.EF
{
    [Serializable]
    public class CartItem
    {
        public ViewSanPham ViewSanPham { get; set; }
        public int Quantity { set; get; }
        public string Sizemau { set; get; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(ViewSanPham sp, int quantity, string sizemau)
        {
            CartItem line = lineCollection
                .Where(p => p.ViewSanPham.MaCTSP == sp.MaCTSP)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    ViewSanPham = sp,
                    Quantity = quantity,
                    Sizemau = sizemau,
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.ViewSanPham.MaCTSP == sp.MaCTSP);
                }
            }
        }

        public void UpdateItem(ViewSanPham sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.ViewSanPham.MaCTSP == sp.MaCTSP)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.ViewSanPham.MaCTSP == sp.MaCTSP);
                }
            }
        }

        public void RemoveLine(ViewSanPham sp)
        {
            lineCollection.RemoveAll(l => l.ViewSanPham.MaCTSP == sp.MaCTSP);
        }

        public int? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.ViewSanPham.DonGia * e.Quantity);

        }
        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}