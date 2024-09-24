using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class KhachHangDTO
    {
        int maKhachHang;
        string tenKhachHang;
        string soDienThoai;
        string email;
        string diaChi;
        int diemTichLuy;

        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int DiemTichLuy { get => diemTichLuy; set => diemTichLuy = value; }

        public KhachHangDTO(int maKhachHang, string tenKhachHang, string soDienThoai, string email, string diaChi, int diemTichLuy)
        {
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.diaChi = diaChi;
            this.diemTichLuy = diemTichLuy;
        }

        public KhachHangDTO()
        {
        }
    }
}
