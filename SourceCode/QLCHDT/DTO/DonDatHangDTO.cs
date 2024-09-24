using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class DonDatHangDTO
    {
        int maDonDatHang;
        int maNhaCungCap;
        DateTime ngayDatHang;
        decimal tongTien;
        string trangThai;

        public DonDatHangDTO()
        {
        }

        public DonDatHangDTO(int maDonDatHang, int maNhaCungCap, DateTime ngayDatHang, decimal tongTien, string trangThai)
        {
            this.MaDonDatHang = maDonDatHang;
            this.MaNhaCungCap = maNhaCungCap;
            this.NgayDatHang = ngayDatHang;
            this.TongTien = tongTien;
            this.TrangThai = trangThai;
        }

        public int MaDonDatHang { get => maDonDatHang; set => maDonDatHang = value; }
        public int MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public DateTime NgayDatHang { get => ngayDatHang; set => ngayDatHang = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
