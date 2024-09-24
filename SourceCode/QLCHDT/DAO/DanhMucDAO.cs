using Microsoft.SqlServer.Server;
using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    public class DanhMucDAO
    {
        private SQLConnect connect;

        public DanhMucDAO()
        {
            connect = new SQLConnect();
        }

        public DataTable getAll()
        {
            string query = "SELECT * FROM DANHMUC";
            return connect.getDataTable(query);
        }

        public bool addDanhMuc(string tenDanhMuc, string moTa)
        {
            string query = $"INSERT INTO DanhMuc (TenDanhMuc, MoTa) VALUES (N'{tenDanhMuc}', N'{moTa}')";
            return connect.ExecuteNonQuery(query);
        }

        public bool updateDanhMuc(int maDanhMuc, string tenDanhMuc, string moTa)
        {
            string query = $"UPDATE DanhMuc SET TenDanhMuc = N'{tenDanhMuc}', MoTa = N'{moTa}' WHERE MaDanhMuc = {maDanhMuc}";
            return connect.ExecuteNonQuery(query);
        }

        public bool deleteDanhMuc(int maDanhMuc)
        {
            string query = $"DELETE FROM DanhMuc WHERE MaDanhMuc = {maDanhMuc}";
            return connect.ExecuteNonQuery(query);
        }

        public DataTable searchDanhMuc(string key)
        {
            string query = "SELECT * FROM DANHMUC WHERE TenDanhMuc LIKE N'%" + key + "%' OR MaDanhMuc LIKE '%" + key + "%'";
            return connect.getDataTable(query);
        }

        public int tongSanPham(int maDanhMuc)
        {
            string query = $@"
            SELECT COUNT(sp.MaSanPham) AS TongSoSanPham
            FROM 
                DanhMuc dm
            LEFT JOIN 
                SanPham sp
            ON 
                dm.MaDanhMuc = sp.MaDanhMuc
            WHERE 
                dm.MaDanhMuc = {maDanhMuc}
            GROUP BY 
                dm.MaDanhMuc";
            int kq = (int) connect.GetData(query);
            return kq;
        }


    }
}
