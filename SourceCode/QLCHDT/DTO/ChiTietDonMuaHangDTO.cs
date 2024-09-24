using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class ChiTietDonMuaHangDTO
    {
        int maChiTietDonMuaHang;
        int maDonMuaHang;
        int idSanPham;
        int soLuong;
        decimal donGia;
        decimal thanhTien;

        public int MaChiTietDonMuaHang { get => maChiTietDonMuaHang; set => maChiTietDonMuaHang = value; }
        public int MaDonMuaHang { get => maDonMuaHang; set => maDonMuaHang = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }

        public ChiTietDonMuaHangDTO(int maChiTietDonMuaHang, int maDonMuaHang, int idSanPham, int soLuong, decimal donGia, decimal thanhTien)
        {
            this.MaChiTietDonMuaHang = maChiTietDonMuaHang;
            this.MaDonMuaHang = maDonMuaHang;
            this.IdSanPham = idSanPham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public ChiTietDonMuaHangDTO()
        {
        }
    }
}
