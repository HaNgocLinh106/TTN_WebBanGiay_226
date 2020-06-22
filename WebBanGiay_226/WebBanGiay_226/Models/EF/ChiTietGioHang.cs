namespace WebBanGiay_226.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGioHang")]
    public partial class ChiTietGioHang
    {
        [Key]
        public long MaChiTietGioHang { get; set; }

        public long? MaGioHang { get; set; }

        public long? MaCTSP { get; set; }

        public int? DonGia { get; set; }

        public int? SoLuong { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }

        public virtual GioHang GioHang { get; set; }
    }
}
