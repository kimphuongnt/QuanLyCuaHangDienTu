using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class DonGiaoHangDTO
    {
        int maDonGiaoHang;
        int maKhachHang;
        DateTime ngayDatHang;
        DateTime ngayGiaoHang;
        string diaChiGiao;
        int tongTien;
        decimal phiVanChuyen;
        string trangThaiGiao;

        public int MaDonGiaoHang { get => maDonGiaoHang; set => maDonGiaoHang = value; }
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public DateTime NgayDatHang { get => ngayDatHang; set => ngayDatHang = value; }
        public DateTime NgayGiaoHang { get => ngayGiaoHang; set => ngayGiaoHang = value; }
        public string DiaChiGiao { get => diaChiGiao; set => diaChiGiao = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public decimal PhiVanChuyen { get => phiVanChuyen; set => phiVanChuyen = value; }
        public string TrangThaiGiao { get => trangThaiGiao; set => trangThaiGiao = value; }

        public DonGiaoHangDTO(int maDonGiaoHang, int maKhachHang, DateTime ngayDatHang, DateTime ngayGiaoHang, string diaChiGiao, int tongTien, decimal phiVanChuyen, string trangThaiGiao)
        {
            this.MaDonGiaoHang = maDonGiaoHang;
            this.MaKhachHang = maKhachHang;
            this.NgayDatHang = ngayDatHang;
            this.NgayGiaoHang = ngayGiaoHang;
            this.DiaChiGiao = diaChiGiao;
            this.TongTien = tongTien;
            this.PhiVanChuyen = phiVanChuyen;
            this.TrangThaiGiao = trangThaiGiao;
        }

        public DonGiaoHangDTO()
        {
        }
    }
}
