using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class KhuyenMaiDTO
    {
        int maKhuyenMai;
        string tenChuongTrinh;
        decimal giaTriKhuyenMai;
        string mota;
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        string dieuKienApDung;
        decimal giaTriDonHangToiThieu;

        public KhuyenMaiDTO()
        {
        }

        public KhuyenMaiDTO(int maKhuyenMai, string tenChuongTrinh, decimal giaTriKhuyenMai, string mota, DateTime ngayBatDau, DateTime ngayKetThuc, string dieuKienApDung, decimal giaTriDonHangToiThieu)
        {
            MaKhuyenMai = maKhuyenMai;
            TenChuongTrinh = tenChuongTrinh;
            GiaTriKhuyenMai = giaTriKhuyenMai;
            MoTa = mota;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            DieuKienApDung = dieuKienApDung;
            GiaTriDonHangToiThieu = giaTriDonHangToiThieu;
        }

        public int MaKhuyenMai { get => maKhuyenMai; set => maKhuyenMai = value; }
        public string TenChuongTrinh { get => tenChuongTrinh; set => tenChuongTrinh = value; }
        public decimal GiaTriKhuyenMai { get => giaTriKhuyenMai; set => giaTriKhuyenMai = value; }
        public string MoTa { get => mota; set => mota = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string DieuKienApDung { get => dieuKienApDung; set => dieuKienApDung = value; }
        public decimal GiaTriDonHangToiThieu { get => giaTriDonHangToiThieu; set => giaTriDonHangToiThieu = value; }
    }
}
