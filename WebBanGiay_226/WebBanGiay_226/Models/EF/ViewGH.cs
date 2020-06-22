namespace WebBanGiay_226.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGH")]
    public partial class ViewGH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNguoiDung { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaGioHang { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        public int? DonGia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(20)]
        public string Mau { get; set; }

        public int? Size { get; set; }

        [StringLength(20)]
        public string LinkAnh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThang { get; set; }

        [StringLength(250)]
        public string HinhThucThanhToan { get; set; }

        [StringLength(250)]
        public string TenNguoiDung { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }
    }
}
