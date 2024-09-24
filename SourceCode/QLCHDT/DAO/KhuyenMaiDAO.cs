using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    internal class KhuyenMaiDAO
    {
        SQLConnect connect;
        public KhuyenMaiDAO()
        {
            connect = new SQLConnect();
        }
        public DataTable getAll()
        {
            string query = "SELECT * FROM KhuyenMai";
            return connect.getDataTable(query);

        }
        public DataTable GetKhuyenMaiHopLe(int tongTien, DateTime ngayHienTai)
        {
            string query = string.Format($@"SELECT MaKhuyenMai, TenChuongTrinh 
                             FROM KhuyenMai 
                             WHERE '{ngayHienTai.ToString("yyyy-MM-dd")}' BETWEEN NgayBatDau AND NgayKetThuc 
                             AND GiaTriDonHangToiThieu <= {tongTien} OR MaKhuyenMai = 'KHONG'");

            return connect.getDataTable(query);
        }

        public float giaTriKhuyenMai(string maKhuyenMai)
        {
            float giaTriKhuyenMai = 0;

            string query = $"SELECT GiaTriKhuyenMai FROM KhuyenMai WHERE MaKhuyenMai = '{maKhuyenMai}'";
            object result = connect.GetData(query);
            if (result != null && result != DBNull.Value)
            {
                if (float.TryParse(result.ToString(), out giaTriKhuyenMai))
                {
                    return giaTriKhuyenMai;
                }
            }
            return giaTriKhuyenMai;
        }

        public string moTaKhuyenMai(string maKhuyenMai)
        {
            string query = $"SELECT MoTa FROM KhuyenMai WHERE MaKhuyenMai = '{maKhuyenMai}'";
            string kq = (string) connect.GetData(query);
            return kq;
        }

        public bool checkTrungMa(string maKhuyenMai)
        {
            string query = $"SELECT COUNT(*) FROM KhuyenMai WHERE MaKhuyenMai = '{maKhuyenMai}'";
            int kq = Convert.ToInt32(connect.GetData(query));
            return kq > 0;
        }
        public bool addKhuyenMai(string maKhuyenMai, string tenChuongTrinh, float giaTriKhuyenMai, string moTa, DateTime ngayBatDau, DateTime ngayKetThuc, string dieuKien, int giaTriToiThieu)
        {
            string query = $"INSERT INTO KhuyenMai (MaKhuyenMai, TenChuongTrinh, GiaTriKhuyenMai, MoTa, NgayBatDau, NgayKetThuc, DieuKienApDung, GiaTriDonHangToiThieu) VALUES (N'{maKhuyenMai}', N'{tenChuongTrinh}',{giaTriKhuyenMai},N'{moTa}','{ngayBatDau}','{ngayKetThuc}',N'{dieuKien}',{giaTriToiThieu})";
            return connect.ExecuteNonQuery(query);
        }
        public bool updatekhuyenMai(string maKhuyenMai, string tenChuongTrinh, float giaTriKhuyenMai, string moTa, DateTime ngayBatDau, DateTime ngayKetThuc, string dieuKien, int giaTriToiThieu)
        {
            string query = $"UPDATE KhuyenMai SET TenChuongTrinh = N'{tenChuongTrinh}', GiaTriKhuyenMai = {giaTriKhuyenMai}, MoTa = N'{moTa}', NgayBatDau = '{ngayBatDau}', NgayKetThuc = '{ngayKetThuc}', DieuKienApDung = N'{dieuKien}', GiaTriDonHangToiThieu = {giaTriToiThieu} WHERE MaKhuyenMai = '{maKhuyenMai}'";
            return connect.ExecuteNonQuery(query);
        }

        public bool deleteKhuyenMai(string maKhuyenMai)
        {
            string query = $"DELETE FROM KhuyenMai WHERE MaKhuyenMai = '{maKhuyenMai}'";
            return connect.ExecuteNonQuery(query);
        }
        public DataTable searchKhuyenMai(string key)
        {
            string query = "SELECT * FROM KhuyenMai WHERE MaKhuyenMai LIKE '%" + key + "%' OR TenChuongTrinh LIKE N'%" + key + "%'";
            return connect.getDataTable(query);
        }
        public DataTable thongKeKhuyenMai(int thang, int nam)
        {
            string query = $@"SELECT 
                    KM.MaKhuyenMai AS MaKhuyenMai,
                    KM.TenChuongTrinh AS TenChuongTrinh,
                    COUNT(HD.MaHoaDon) AS SoDonHangSuDung,
                    SUM(HD.TongTien) AS DoanhThuMangLai,
	                KM.NgayBatDau AS NgayBatDau,
	                KM.NgayKetThuc AS NgayKetThuc
                FROM 
                    HoaDon HD
                INNER JOIN 
                    KhuyenMai KM ON HD.MaKhuyenMai = KM.MaKhuyenMai
                WHERE 
                    MONTH(HD.NgayLapHoaDon) = {thang} AND YEAR(HD.NgayLapHoaDon) = {nam}
                GROUP BY 
                    KM.MaKhuyenMai, KM.TenChuongTrinh, KM.NgayBatDau, KM.NgayKetThuc";
            return connect.getDataTable(query);
        }
        public DataTable thongKeKhuyenMaiAll()
        {
            string query = $@"SELECT 
                    KM.MaKhuyenMai AS MaKhuyenMai,
                    KM.TenChuongTrinh AS TenChuongTrinh,
                    COUNT(HD.MaHoaDon) AS SoDonHangSuDung,
                    COALESCE(SUM(HD.TongTien), 0) AS DoanhThuMangLai,
                    KM.NgayBatDau AS NgayBatDau,
	                KM.NgayKetThuc AS NgayKetThuc
                FROM 
                    KhuyenMai KM
                LEFT JOIN 
                    HoaDon HD ON KM.MaKhuyenMai = HD.MaKhuyenMai
                GROUP BY 
                    KM.MaKhuyenMai, KM.TenChuongTrinh, KM.NgayBatDau, KM.NgayKetThuc;
                ";
            return connect.getDataTable(query);
        }
        public DataTable inThongKeKhuyenMai(int thang, int nam)
        {
            string query = $@"SELECT 
                    KM.MaKhuyenMai AS MaKhuyenMai,
                    KM.TenChuongTrinh AS TenChuongTrinh,
                    COUNT(HD.MaHoaDon) AS SoDonHangSuDung,
                    SUM(HD.TongTien) AS DoanhThuMangLai,
	                CAST(KM.NgayBatDau AS DATE) AS NgayBatDau,
                    CAST(KM.NgayKetThuc AS DATE) AS NgayKetThuc, 
					CAST({thang} AS VARCHAR(4)) AS Thang,
                    CAST({nam} AS VARCHAR(4)) AS Nam
                FROM 
                    HoaDon HD
                INNER JOIN 
                    KhuyenMai KM ON HD.MaKhuyenMai = KM.MaKhuyenMai
                WHERE 
                    MONTH(HD.NgayLapHoaDon) = {thang} AND YEAR(HD.NgayLapHoaDon) = {nam}
                GROUP BY 
                    KM.MaKhuyenMai, KM.TenChuongTrinh, KM.NgayBatDau, KM.NgayKetThuc";
            return connect.getDataTable(query);
        }
    }
}
