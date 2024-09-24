using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class NhanVienDTO
    {
        int maNhanVien;
        string tenNhanVien;
        string soDienThoai;
        string email;
        string chucVu;
        string taiKhoan;
        string matKhau;

        public NhanVienDTO() { }

        public NhanVienDTO(int maNhanVien, string tenNhanVien, string soDienThoai, string email, string chucVu, string taiKhoan, string matKhau)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
            this.ChucVu = chucVu;
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
