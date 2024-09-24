using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    public class YeuCauBaoHanhDAO
    {
        SQLConnect connect;
        public YeuCauBaoHanhDAO()
        {
            connect = new SQLConnect();
        }
        public DataTable getAll()
        {
            string query = "SELECT * FROM YeuCauBaoHanh";
            return connect.getDataTable(query);
        }
        public bool addYeuCauBaoHanh(string maHoaDon, string maSanPham, DateTime ngayYeuCau, string lyDo, string trangThai)
        {
            string query = $"INSERT INTO YeuCauBaoHanh (MaHoaDon, MaSanPham, NgayYeuCau, LyDo, TrangThai) VALUES ('{maHoaDon}', '{maSanPham}', '{ngayYeuCau}',N'{lyDo}',N'{trangThai}')";
            return connect.ExecuteNonQuery(query);
        }
        public bool deleteYeuCauBaoHanh(string maYeuCau)
        {
            string query = $"DELETE FROM YeuCauBaoHanh WHERE MaYeuCauBaoHanh = '{maYeuCau}'";
            return connect.ExecuteNonQuery(query);
        }
        public bool updateYeuCauBaoHanh(string maYeuCau, string trangThai)
        {
            string query = $"UPDATE YeuCauBaoHanh SET TrangThai = N'{trangThai}' WHERE MaYeuCauBaoHanh = '{maYeuCau}'";
            return connect.ExecuteNonQuery(query);
        }
        public DataTable searchYeuCauBaoHanh(string key)
        {
            string query = "SELECT * FROM YeuCauBaoHanh WHERE MaHoaDon LIKE '%" + key + "%' OR MaSanPham LIKE '%" + key + "%' OR TrangThai LIKE N'%" + key + "%'";
            return connect.getDataTable(query);
        }
        public DataTable inYeuCauBaoHanh(string ma)
        {
            string query = $@"SELECT 
                            ycbh.MaYeuCauBaoHanh,
                            ycbh.MaHoaDon,
                            sp.TenSanPham,
                            ycbh.NgayYeuCau,
                            ycbh.LyDo,
                            kh.TenKhachHang,
                            kh.SoDienThoai
                        FROM 
                            YeuCauBaoHanh ycbh
                        INNER JOIN 
                            HoaDon hd ON ycbh.MaHoaDon = hd.MaHoaDon
                        INNER JOIN 
                            ChiTietHoaDon cthd ON hd.MaHoaDon = cthd.MaHoaDon AND ycbh.MaSanPham = cthd.MaSanPham
                        INNER JOIN 
                            SanPham sp ON ycbh.MaSanPham = sp.MaSanPham
                        INNER JOIN 
                            KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                        WHERE 
                            ycbh.MaYeuCauBaoHanh = 'BH00001'";
            return connect.getDataTable(query);
        }
    }
}
