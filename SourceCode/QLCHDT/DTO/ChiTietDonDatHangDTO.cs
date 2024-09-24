using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class ChiTietDonDatHangDTO
    {
        int maChiTietDonDatHang;
        int maDonDatHang;
        int idSanPham;
        int soLuong;
        int donGia;
        int thanhTien;

        public ChiTietDonDatHangDTO()
        {
        }

        public ChiTietDonDatHangDTO(int maChiTietDonDatHang, int maDonDatHang, int idSanPham, int soLuong, int donGia, int thanhTien)
        {
            this.MaChiTietDonDatHang = maChiTietDonDatHang;
            this.MaDonDatHang = maDonDatHang;
            this.IdSanPham = idSanPham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public int MaChiTietDonDatHang { get => maChiTietDonDatHang; set => maChiTietDonDatHang = value; }
        public int MaDonDatHang { get => maDonDatHang; set => maDonDatHang = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
