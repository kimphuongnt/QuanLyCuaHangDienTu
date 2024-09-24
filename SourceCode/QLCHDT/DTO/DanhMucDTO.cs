using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangDienTu.DTO
{
    public class DanhMucDTO
    {
        int maDanhMuc;
        string tenDanhMuc;
        string moTa;

        public int MaDanhMuc { get => maDanhMuc; set => maDanhMuc = value; }
        public string TenDanhMuc { get => tenDanhMuc; set => tenDanhMuc = value; }
        public string MoTa { get => moTa; set => moTa = value; }

        public DanhMucDTO()
        {
            maDanhMuc = 0;
            tenDanhMuc = "";
            moTa = "";
        }
        public DanhMucDTO(int maDanhMuc, string tenDanhMuc, string moTa)
        {
            this.maDanhMuc = maDanhMuc;
            this.tenDanhMuc = tenDanhMuc;
            this.moTa = moTa;
        }
    }
}
