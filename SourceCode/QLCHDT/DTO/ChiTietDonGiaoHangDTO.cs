using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class ChiTietDonGiaoHangDTO
    {
        int maChiTietDonGiaoHang;
        int maDonGiaoHang;
        int idSanPham;
        int soLuong;
        decimal donGia;
        decimal thanhTien;

        public int MaChiTietDonGiaoHang { get => maChiTietDonGiaoHang; set => maChiTietDonGiaoHang = value; }
        public int MaDonGiaoHang { get => maDonGiaoHang; set => maDonGiaoHang = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }

        public ChiTietDonGiaoHangDTO(int maChiTietDonGiaoHang, int maDonGiaoHang, int idSanPham, int soLuong, decimal donGia, decimal thanhTien)
        {
            this.MaChiTietDonGiaoHang = maChiTietDonGiaoHang;
            this.MaDonGiaoHang = maDonGiaoHang;
            this.IdSanPham = idSanPham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public ChiTietDonGiaoHangDTO()
        {
        }
    }
}
