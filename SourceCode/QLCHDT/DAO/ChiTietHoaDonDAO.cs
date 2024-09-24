using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    public class ChiTietHoaDonDAO
    {
        SQLConnect connect;
        public ChiTietHoaDonDAO()
        {
            connect = new SQLConnect();
        }
        public DataTable getChiTietMa(string maHoaDon)
        {
            string query = $"SELECT * FROM ChiTietHoaDon WHERE MaHoaDon ='{maHoaDon}'";
            return connect.getDataTable(query);
        }
        public DataTable getAll()
        {
            string query = $"SELECT * FROM ChiTietHoaDon";
            return connect.getDataTable(query);
        }
        public bool kiemTraTrungSanPham(string maHoaDon, string maSanPham)
        {
            string query = $"SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = '{maHoaDon}' AND MaSanPham = '{maSanPham}'";
            int kq = (int) connect.GetData(query);
            return kq > 0;
        }
        public bool updateChiTietHoaDon(string maHoaDon, string maSanPham, int soLuong, int donGia, int thanhTien, string ghiChu)
        {
            string query = $"UPDATE ChiTietHoaDon SET SoLuong = {soLuong}, DonGia = {donGia}, ThanhTien = {thanhTien}, GhiChu = N'{ghiChu}' WHERE MaHoaDon = '{maHoaDon}' AND MaSanPham = '{maSanPham}'";

            return connect.ExecuteNonQuery(query);
        }

        public bool addChiTietHoaDon(string maHoaDon, string maSanPham, int soLuong, int donGia, int thanhTien, string ghiChu)
        {
            string query = $"INSERT INTO ChiTietHoaDon VALUES ('{maHoaDon}', '{maSanPham}',{soLuong},{donGia},{thanhTien},N'{ghiChu}')";
            return connect.ExecuteNonQuery(query);
        }
    }
}
