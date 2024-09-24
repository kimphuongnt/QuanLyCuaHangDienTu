using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class DoiTraDTO
    {
        int maDoiTra;
        int maDonMuaHang;
        DateTime ngayDoiTra;
        string lyDo;
        string trangThai;

        public DoiTraDTO()
        {
        }

        public DoiTraDTO(int maDoiTra, int maDonMuaHang, DateTime ngayDoiTra, string lyDo, string trangThai)
        {
            this.MaDoiTra = maDoiTra;
            this.MaDonMuaHang = maDonMuaHang;
            this.NgayDoiTra = ngayDoiTra;
            this.LyDo = lyDo;
            this.TrangThai = trangThai;
        }

        public int MaDoiTra { get => maDoiTra; set => maDoiTra = value; }
        public int MaDonMuaHang { get => maDonMuaHang; set => maDonMuaHang = value; }
        public DateTime NgayDoiTra { get => ngayDoiTra; set => ngayDoiTra = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
