using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class BaoHanhDTO
    {
        int maBaoHanh;
        int maChiTietDonMuaHang;
        int idSanPham;
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        string trangThai;

        public BaoHanhDTO()
        {
        }

        public BaoHanhDTO(int maBaoHanh, int maChiTietDonMuaHang, int idSanPham, DateTime ngayBatDau, DateTime ngayKetThuc, string trangThai)
        {
            this.MaBaoHanh = maBaoHanh;
            this.MaChiTietDonMuaHang = maChiTietDonMuaHang;
            this.IdSanPham = idSanPham;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
            this.TrangThai = trangThai;
        }

        public int MaBaoHanh { get => maBaoHanh; set => maBaoHanh = value; }
        public int MaChiTietDonMuaHang { get => maChiTietDonMuaHang; set => maChiTietDonMuaHang = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
