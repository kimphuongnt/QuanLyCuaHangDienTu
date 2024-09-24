using QuanLyBanHangDienTu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DAO
{
    internal class TraHangDAO
    {
        public string strHoaDon = "select *form HoaDon";
        SQLConnect db = new SQLConnect();
        DataTable dtChiTietSP = new DataTable();
        DataTable dtTraHang = new DataTable();
        public bool timHoaDon(string hoadon)
        {
            string query = $"SELECT COUNT(*) FROM HoaDon WHERE MaHoaDon = '{hoadon}'";
            int check = (int)db.GetData(query);
            return check > 0;
        }
        public string layTenKhachHangTrongHoaDon(string hoadon)
        {
            string query = $"select TenKhachHang from HoaDon hd, KhachHang kh where kh.MaKhachHang = hd.MaKhachHang and hd.MaHoaDon = '{hoadon}'";
            string tenKH = (string)db.GetData(query);
            return tenKH;
        }
        public string laySDTKhachHangTrongHoaDon(string hoadon)
        {
            string query = $"select SoDienThoai from HoaDon hd, KhachHang kh where kh.MaKhachHang = hd.MaKhachHang and hd.MaHoaDon = '{hoadon}'";
            string sdt = (string)db.GetData(query);
            return sdt;
        }
        public DataTable layChiTietSanPham(string hoadon)
        {
            string query = $"select sp.MaSanPham, sp.TenSanPham, ct.SoLuong, ct.DonGia, ct.ThanhTien from SanPham sp, ChiTietHoaDon ct where ct.MaSanPham = sp.MaSanPham and ct.MaHoaDon = '{hoadon}'";
            dtChiTietSP = db.getDataTable(query);
            return dtChiTietSP;
        }
        public bool themHDTraHang(string mahoadon, DateTime ngaytra)
        {
            string query = $"Insert into TraHang (MaHoaDon, NgayTra) values ('{mahoadon}', '{ngaytra}')";
            return db.ExecuteNonQuery(query);
        }
        public DataTable allHDTraHang()
        {
            string query = $"select th.MaTraHang, th.MaHoaDon, th.NgayTra, sp.TenSanPham, ct.SoLuong, ct.LyDo from TraHang th, ChiTietTraHang ct, SanPham sp where th.MaTraHang = ct.MaTraHang and ct.MaSanPham = sp.MaSanPham";
            dtTraHang = db.getDataTable(query);
            return dtTraHang;
        }
        public string layMaTraHang(string mahoadon, DateTime time)
        {
            string query = $"select MaTraHang from TraHang where MaHoaDon = '{mahoadon}' and NgayTra = '{time}'";
            string kq = (string)db.GetData(query);
            return kq;
        }
        public string layMaPhieuMoiNhat()
        {
            string query = "SELECT TOP 1 MaTraHang FROM TraHang ORDER BY CAST(SUBSTRING(MaTraHang, 3, LEN(MaTraHang) - 2) AS INT) DESC";
            string kq = (string) db.GetData(query);
            return kq;
        }
        public bool themChiTietTraHang(string maHD, DateTime time, string maSP, int soLuong, string lydo)
        {
            
            string matrahang = layMaPhieuMoiNhat();
            string query = $"Insert into ChiTietTraHang values('{matrahang}', '{maSP}', '{soLuong}', N'{lydo}')";
            return db.ExecuteNonQuery (query);
        }
        public bool kiemTraHangTrong30Ngay(string hoadon)
        {
            bool check = false;
            DateTime today = DateTime.Now;
            string query = $"select NgayLapHoaDon from HoaDon where MaHoaDon = '{hoadon}'";
            DateTime ngaylap = (DateTime) db.GetData(query);
            if ((today - ngaylap).TotalDays <= 30)
            {
                check = true;
            }
            return check;
        }
        public bool capnhatTongTien(decimal tongTien, string mahd, DateTime time)
        {
            string matrahang = layMaTraHang(mahd, time);
            string query = $"update TraHang set TongTien = '{tongTien}' Where MaTraHang = '{matrahang}'";
            return db.ExecuteNonQuery (query);
        }
        public DataTable timHDTraHang(string matrahang)
        {
            string query = $"select th.MaTraHang, th.MaHoaDon, th.NgayTra, sp.TenSanPham, ct.SoLuong, ct.LyDo from TraHang th, ChiTietTraHang ct, SanPham sp where th.MaTraHang = ct.MaTraHang and ct.MaSanPham = sp.MaSanPham and th.MaTraHang like N'%{matrahang}'";
            dtTraHang = db.getDataTable(query);
            return dtTraHang;
        }
        public bool suaHDTraHang(string matrahang, string lydo)
        {
            string query = $"update ChiTietTraHang set LyDo = N'{lydo}' where MaTraHang = '{matrahang}'";
            return db.ExecuteNonQuery(query);
        }
        
        public bool xoaHDTraHang(string matrahang)
        {
            string query = $"delete from TraHang where MaTraHang = '{matrahang}'";
            return db.ExecuteNonQuery(query);
        }
    }
}
