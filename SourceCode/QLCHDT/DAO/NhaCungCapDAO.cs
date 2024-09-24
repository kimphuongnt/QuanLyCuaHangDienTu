using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    public class NhaCungCapDAO
    {
        private SQLConnect connect;
        public NhaCungCapDAO()
        {
            connect = new SQLConnect();
        }
        public DataTable getAll()
        {
            string query = "SELECT * FROM NHACUNGCAP";
            return connect.getDataTable(query);
        }

        public bool addNhaCungCap(string tenNhaCungCap, string nguoiLienHe, string diaChi, string soDienThoai, string email)
        {
            string query = $"INSERT INTO NhaCungCap (tenNhaCungCap, nguoiLienHe, diaChi, soDienThoai, email) VALUES (N'{tenNhaCungCap}', N'{nguoiLienHe}', N'{diaChi}', N'{soDienThoai}', N'{email}')";
            return connect.ExecuteNonQuery(query);
        }

        public bool updateNhaCungCap(int maNhaCungCap, string tenNhaCungCap, string nguoiLienHe, string diaChi, string soDienThoai, string email)
        {
            string query = $"UPDATE NhaCungCap SET TenNhaCungCap = N'{tenNhaCungCap}', NguoiLienHe = N'{nguoiLienHe}', DiaChi = N'{diaChi}', SoDienThoai = N'{soDienThoai}', Email = N'{email}' WHERE MaNhaCungCap = {maNhaCungCap}";
            
            return connect.ExecuteNonQuery(query);
        }

        public bool deleteNhaCungCap(int maNhaCungCap)
        {
            string query = $"DELETE FROM NhaCungCap WHERE MaNhaCungCap = {maNhaCungCap}";
            return connect.ExecuteNonQuery(query);
        }

        public DataTable searchNhaCungCap(string key)
        {
            string query = "SELECT * FROM NHACUNGCAP WHERE TenNhaCungCap LIKE N'%" + key + "%' OR MaNhaCungCap LIKE '%" + key + "%' OR NguoiLienhe LIKE '%" + key + "%' OR SoDienThoai LIKE '%" + key + "%' OR Email LIKE '%" + key + "%' OR DiaChi LIKE '%" + key + "%'";
            return connect.getDataTable(query);
        }
    }
}
