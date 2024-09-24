using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    public class ChiTietNhapHangDAO
    {
        SQLConnect connect;
        public ChiTietNhapHangDAO()
        {
            connect = new SQLConnect();
        }
        public DataTable getAll(string maDonDatHang)
        {
            string query = $"SELECT * FROM ChiTietDonDatHangNhaCungCap WHERE MaDonDatHang = '{maDonDatHang}'";
            return connect.getDataTable(query);
        }
        public bool addChiTietDonNhapHang(string maDonDatHang, string maSanPham, int soLuong, int donGia, out string errorMessage)
        {
            errorMessage = string.Empty;
            string queryCheck = $"SELECT COUNT(*) FROM ChiTietDonDatHangNhaCungCap WHERE MaDonDatHang = '{maDonDatHang}' AND MaSanPham = '{maSanPham}'";
            int count = (int) connect.GetData(queryCheck);

            if (count > 0)
            {
                string queryCheckTonTai = $"SELECT DonGia FROM ChiTietDonDatHangNhaCungCap WHERE MaDonDatHang = '{maDonDatHang}' AND MaSanPham = '{maSanPham}'";
                int tonTaiDonGia = (int) connect.GetData(queryCheckTonTai);

                if (tonTaiDonGia != donGia)
                {
                   
                    errorMessage = "Đơn giá không khớp với đơn giá đã lưu. Vui lòng kiểm tra lại.";
                    return false;
                }
                else
                {
                    string querySoLuong = $"UPDATE ChiTietDonDatHangNhaCungCap SET SoLuong = SoLuong + {soLuong}, ThanhTien = (SoLuong + {soLuong}) * DonGia WHERE MaDonDatHang = '{maDonDatHang}' AND MaSanPham = '{maSanPham}'";
                    return connect.ExecuteNonQuery(querySoLuong);
                }
            }
            else
            {
                string queryAdd = $"INSERT INTO ChiTietDonDatHangNhaCungCap (MaDonDatHang, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES ('{maDonDatHang}', '{maSanPham}', {soLuong}, {donGia}, {soLuong * donGia})";
                return connect.ExecuteNonQuery(queryAdd);
            }
        }



    }
}
