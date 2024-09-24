using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Ink;

namespace QLCHDT.DAO
{
    public class HoaDonDAO
    {
        SQLConnect connect;
        public HoaDonDAO()
        {
            connect = new SQLConnect();
        }
        public bool addHoaDon(string maKhachHang, string maNhanVien, string maKhuyenMai, DateTime ngayLapHoaDon, int tongTien, string phuongThucThanhToan, int diemDung)
        {
            string query = $"INSERT INTO HoaDon (MaKhachHang, MaNhanVien, MaKhuyenMai, NgayLapHoaDon, TongTien, PhuongThucThanhToan, DiemDaDung) VALUES ('{maKhachHang}', '{maNhanVien}','{maKhuyenMai}','{ngayLapHoaDon}',{tongTien}, N'{phuongThucThanhToan}', {diemDung})";
            return connect.ExecuteNonQuery(query);
        }

        public string layMaPhieuMoiNhat()
        {
            string query = "SELECT TOP 1 MaHoaDon FROM HoaDon ORDER BY CAST(SUBSTRING(MaHoaDon, 3, LEN(MaHoaDon) - 2) AS INT) DESC";
            string kq = (string) connect.GetData(query);
            return kq;
        }

        public bool hoaDonMoi(string maNhanVien, DateTime ngayLap)
        {
            string query = $"INSERT INTO HoaDon (MaNhanVien, NgayLapHoaDon) VALUES('{maNhanVien}','{ngayLap}')";
            return connect.ExecuteNonQuery(query);
        }
        public bool deleteHoaDon(string maNhanVien, DateTime ngayLap)
        {
            string query = $"INSERT INTO HoaDon (MaNhanVien, NgayLapHoaDon) VALUES('{maNhanVien}','{ngayLap}')";
            return connect.ExecuteNonQuery(query);
        }

        public bool updateHoaDon(string maHoaDon, string maKhachHang, string maKhuyenMai, int tongTien, string phuongThucThanhToan, int diemDung)
        {
            string query = $"UPDATE HoaDon SET MaKhachHang = '{maKhachHang}', MaKhuyenMai = '{maKhuyenMai}', TongTien = '{tongTien}', PhuongThucThanhToan = '{phuongThucThanhToan}', DiemDaDung ='{diemDung}' WHERE MaHoaDon = '{maHoaDon}'";
            return connect.ExecuteNonQuery(query);
        }
        public DataTable getAll()
        {
            string query = "SELECT * FROM HoaDon";
            return connect.getDataTable(query);
        }

        public DataTable searchHoaDon(string key)
        {
            string query = $" SELECT hd.* FROM HoaDon hd JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang WHERE hd.MaHoaDon LIKE '%" + key + "%' OR hd.MaNhanVien LIKE '%" + key + "%' OR hd.MaKhachHang LIKE '%" + key + "%' OR kh.TenKhachHang LIKE N'%" + key + "%'";
            return connect.getDataTable(query);
        }
        public bool deleteHoaDon(string maHoaDon)
        {
            string query = $"DELETE FROM HoaDon WHERE MaHoaDon = '{maHoaDon}'";
            return connect.ExecuteNonQuery(query);
        }

        public DataTable laySanPhamTuHoaDon(string maHoaDon)
        {
            string query = $"SELECT ChiTietHoaDon.MaSanPham, TenSanPham, NgayLapHoaDon FROM HoaDon, SanPham, ChiTietHoaDon WHERE SanPham.MaSanPham = ChiTietHoaDon.MaSanPham and HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon AND HoaDon.MaHoaDon = '{maHoaDon}'";
            return connect.getDataTable(query);
        }
        public DateTime layNgayMua(string maHoaDon)
        {
            string query = $"SELECT NgayLapHoaDon FROM HoaDon WHERE MaHoaDon = '{maHoaDon}'";
            DataTable kq = connect.getDataTable(query);
            if (kq.Rows.Count > 0)
            {
                return DateTime.Parse(kq.Rows[0]["NgayLapHoaDon"].ToString());
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
