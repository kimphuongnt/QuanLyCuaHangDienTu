using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class SanPhamDTO
    {
        int id;
        string imei;
        string maSanPham;
        string tenSanPham;
        int maDanhMuc;
        string moTa;
        decimal giaBan;
        decimal giaNhap;
        int soLuong;
        int thoiGianBaoHanh;
        int maNhaCungCap;

        public int Id { get => id; set => id = value; }
        public string Imei { get => imei; set => imei = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int MaDanhMuc { get => maDanhMuc; set => maDanhMuc = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public decimal GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int ThoiGianBaoHanh { get => thoiGianBaoHanh; set => thoiGianBaoHanh = value; }
        public int MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }

        public SanPhamDTO(int id, string imei, string maSanPham, string tenSanPham, int maDanhMuc, int maNhaCungCap, string moTa, decimal giaBan, decimal giaNhap, int soLuong, int thoiGianBaoHanh)
        {
            this.id = id;
            this.imei = imei;
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.maDanhMuc = maDanhMuc;
            this.moTa = moTa;
            this.giaBan = giaBan;
            this.giaNhap = giaNhap;
            this.soLuong = soLuong;
            this.thoiGianBaoHanh = thoiGianBaoHanh;
            this.maNhaCungCap = maNhaCungCap;
        }

        public SanPhamDTO()
        {
        }
    }
}
