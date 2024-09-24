using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class DonMuaHangDTO
    {
        int maDonMuaHang;
        int maKhachHang;
        int maNhanVien;
        DateTime ngayMua;
        decimal tongTien;
        decimal giamGia;
        string phuongThucThanhToan;
        string trangThai;

        public DonMuaHangDTO()
        {
        }

        public DonMuaHangDTO(int maDonMuaHang, int maKhachHang, int maNhanVien, DateTime ngayMua, decimal tongTien, decimal giamGia, string phuongThucThanhToan, string trangThai)
        {
            this.MaDonMuaHang = maDonMuaHang;
            this.MaKhachHang = maKhachHang;
            this.MaNhanVien = maNhanVien;
            this.NgayMua = ngayMua;
            this.TongTien = tongTien;
            this.GiamGia = giamGia;
            this.PhuongThucThanhToan = phuongThucThanhToan;
            this.TrangThai = trangThai;
        }

        public int MaDonMuaHang { get => maDonMuaHang; set => maDonMuaHang = value; }
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public decimal GiamGia { get => giamGia; set => giamGia = value; }
        public string PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
