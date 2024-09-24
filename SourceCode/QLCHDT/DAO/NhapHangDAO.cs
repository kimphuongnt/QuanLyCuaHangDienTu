using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    public class NhapHangDAO
    {
        SQLConnect connect;
        public NhapHangDAO()
        {
            connect = new SQLConnect();
        }
        public DataTable getAll()
        {
            string query = "sELECT * FROM DonDatHangNhaCungCap";
            return connect.getDataTable(query);
        }
        public bool addDonNhapHang(string maNhaCungCap, DateTime ngayDatHang)
        {
            string query = $"INSERT INTO DonDatHangNhaCungCap (MaNhaCungCap, NgayDatHang) " +
                           $"VALUES ('{maNhaCungCap}', '{ngayDatHang}')";
            return connect.ExecuteNonQuery(query);
        }

        public string layDonMoi()
        {
            string query = "SELECT TOP 1 MaDonDatHang FROM DonDatHangNhaCungCap ORDER BY CAST(SUBSTRING(MaDonDatHang, 3, LEN(MaDonDatHang) - 2) AS INT) DESC";
            string result = (string) connect.GetData(query);
            return result;
        }
        public DataTable searchDonNhapHang(string key)
        {
            string query = $@"
                SELECT DISTINCT ddh.MaDonDatHang, ddh.MaNhaCungCap, ddh.NgayDatHang, ddh.TongTien, ddh.TrangThai
                FROM DonDatHangNhaCungCap ddh
                LEFT JOIN ChiTietDonDatHangNhaCungCap ctdh ON ddh.MaDonDatHang = ctdh.MaDonDatHang
                LEFT JOIN SanPham sp ON ctdh.MaSanPham = sp.MaSanPham
                WHERE ddh.MaDonDatHang LIKE '%{key}%'
                OR ddh.MaNhaCungCap LIKE '%{key}%'
                OR sp.TenSanPham LIKE N'%{key}%'
                OR ddh.TrangThai LIKE N'%{key}%'";
            return connect.getDataTable(query);
        }


        public bool deleteDonNhapHang(string maDonDatHang)
        {
            string query = $"DELETE FROM DonDatHangNhaCungCap WHERE MaDonDatHang = '{maDonDatHang}'";
            return connect.ExecuteNonQuery(query);
        }
        public bool updateDonNhapHang(string maDonDatHang, string trangThai)
        {
            string query = $"UPDATE DonDatHangNhaCungCap SET TrangThai = N'{trangThai}' WHERE MaDonDatHang = '{maDonDatHang}'";
            return connect.ExecuteNonQuery(query);
        }
    }
}
