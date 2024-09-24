using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class ChiTietDoiTraDTO
    {
        int maChiTietDoiTra;
        int maDoiTra;
        int idSanPham;
        int soLuong;

        public int MaChiTietDoiTra { get => maChiTietDoiTra; set => maChiTietDoiTra = value; }
        public int MaDoiTra { get => maDoiTra; set => maDoiTra = value; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietDoiTraDTO(int maChiTietDoiTra, int maDoiTra, int idSanPham, int soLuong)
        {
            this.MaChiTietDoiTra = maChiTietDoiTra;
            this.MaDoiTra = maDoiTra;
            this.IdSanPham = idSanPham;
            this.SoLuong = soLuong;
        }

        public ChiTietDoiTraDTO()
        {
        }
    }
}
