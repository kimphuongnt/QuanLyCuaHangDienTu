using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class NhaCungCapDTO
    {
        int maNhaCungCap;
        string tenNhaCungCap;
        string nguoiLienHe;
        string soDienThoai;
        string email;
        string diaChi;

        public int MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public string TenNhaCungCap { get => tenNhaCungCap; set => tenNhaCungCap = value; }
        public string NguoiLienHe { get => nguoiLienHe; set => nguoiLienHe = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public NhaCungCapDTO(int maNhaCungCap, string tenNhaCungCap, string nguoiLienHe, string soDienThoai, string email, string diaChi)
        {
            this.MaNhaCungCap = maNhaCungCap;
            this.TenNhaCungCap = tenNhaCungCap;
            this.NguoiLienHe = nguoiLienHe;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
            this.DiaChi = diaChi;
        }

        public NhaCungCapDTO()
        {
        }
    }
}
