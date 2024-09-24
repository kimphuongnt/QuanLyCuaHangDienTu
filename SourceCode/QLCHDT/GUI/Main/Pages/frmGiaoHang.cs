﻿using QLCHDT.BUS;
using QLCHDT.GUI.Report;
using QLCHDT.DAO;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using QLCHDT.Model;

namespace QLCHDT.GUI.Main.Pages
{
    public partial class frmGiaoHang : UIPage
    {
        GiaoHangBUS giaoHangBUS;
        NhanVienBUS nhanVienBUS;
        MaHoaDonBUS maHoaDonBUS;
        InPhieuGiaoBUS inPhieuGiaoBUS;
        public frmGiaoHang()
        {
            InitializeComponent();
            giaoHangBUS = new GiaoHangBUS();
            nhanVienBUS = new NhanVienBUS();
            maHoaDonBUS = new MaHoaDonBUS();
            inPhieuGiaoBUS = new InPhieuGiaoBUS();
            LoadDataDanhMuc();
            loadComboMaHoaDOn();
        }

        private void loadComboNhanVien()
        {
            DataTable dtNhanVien = nhanVienBUS.getAll();
            cmbnvgiao.DataSource = dtNhanVien;
            cmbnvgiao.DisplayMember = "TenNhanVien";
            cmbnvgiao.ValueMember = "MaNhanVien";

        }

        private void loadComboMaHoaDOn()
        {

            DataTable dtMaHoaDon = maHoaDonBUS.getAll();
            cmbmahd.DataSource = dtMaHoaDon;
            cmbmahd.ValueMember = "MaHoaDon";
            cmbmahd.DisplayMember = "MaHoaDon";

        }

        private void LoadDataDanhMuc()
        {
            try
            {
                DataTable dtDanhMuc = giaoHangBUS.getAll();
                dgvgiaohang.DataSource = dtDanhMuc;




                if (dgvgiaohang.Columns.Count > 0)
                {
                    dgvgiaohang.Columns[0].HeaderText = "Mã giao hàng";
                    dgvgiaohang.Columns[1].HeaderText = "Mã hóa đơn";
                    dgvgiaohang.Columns[2].HeaderText = "Tên nhân viên giao";
                    dgvgiaohang.Columns[3].HeaderText = "Ngày giao";
                    dgvgiaohang.Columns[4].HeaderText = "Địa chỉ";
                    dgvgiaohang.Columns[5].HeaderText = "Tình trạng";
                    dgvgiaohang.Columns[6].HeaderText = "Tên sản phẩm";
                    dgvgiaohang.Columns[7].HeaderText = "Số lượng";

                }
                dgvgiaohang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvgiaohang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvgiaohang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvgiaohang.SelectedRows[0];
                txtmagiaohang.Text = selectedRow.Cells["MaGiaoHang"].Value.ToString();
                txtsanpham.Text = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtdiachi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtsoluong.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                dtpngaygiao.Text = selectedRow.Cells["NgayGiao"].Value.ToString();
                string nhanVienGiao = selectedRow.Cells["TenNhanVien"].Value.ToString();
                string tinhTrang = selectedRow.Cells["TinhTrang"].Value.ToString();

                cmbtinhtrang.Text = tinhTrang;
                cmbnvgiao.Text = nhanVienGiao;
            }
        }

        private void frmGiaoHang_Load(object sender, EventArgs e)
        {
            loadComboNhanVien();
            loadComboMaHoaDOn();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttim.Text))
            {
                DataTable dt = giaoHangBUS.getAll();
                dgvgiaohang.DataSource = dt;
            }
            else
            {
                string keyword = txttim.Text.Trim();
                DataTable result = giaoHangBUS.timGiaoHang(keyword);
                dgvgiaohang.DataSource = result;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvgiaohang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvgiaohang.SelectedRows[0];
                string magh = txtmagiaohang.Text.Trim();
                string nhanVienGiao = cmbnvgiao.SelectedValue.ToString();
                string dateTime = dtpngaygiao.Text.ToString();
                string tinhtrang = cmbtinhtrang.Text.ToString();
                if (!DateTime.TryParse(dateTime, out DateTime ngayGiao))
                {
                    MessageBox.Show("Lỗi chuyển đổi ngày giao.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbnvgiao.Text))
                {
                    MessageBox.Show("Vui lòng cập nhật nhân viên giao hàng.");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn sửa giao hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (giaoHangBUS.suaGiaoHang(nhanVienGiao, dateTime, tinhtrang, magh))
                    {
                        MessageBox.Show("Sửa giao hàng thành công!");
                        LoadDataDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Sửa giao hàng thất bại!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giao hàng cần sửa.");
            }
        }
        private void frmGiaoHang_Initialize(object sender, EventArgs e)
        {

        }
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            LoadDataDanhMuc();
            txtmagiaohang.Text = txtdiachi.Text = txtsanpham.Text = txtsoluong.Text = txttim.Text = "";
            cmbmahd.Text = cmbnvgiao.Text = "";
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = "GiaoHangFile";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;

                    try
                    {
                        ExportToExcelGiaoHang(filePath);
                        MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK);
                    }
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ExportToExcelGiaoHang(string filePath)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Giao Hàng");

            IRow headerRow = sheet.CreateRow(0);
            for (int i = 0; i < dgvgiaohang.Columns.Count; i++)
            {
                headerRow.CreateCell(i).SetCellValue(dgvgiaohang.Columns[i].HeaderText);
            }

            for (int i = 0; i < dgvgiaohang.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < dgvgiaohang.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(dgvgiaohang.Rows[i].Cells[j].Value?.ToString() ?? "");
                }
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            inPhieuGiao(txtmagiaohang.Text.Trim());
        }
        private void inPhieuGiao(string maGiao)
        {
            string maDonGia = txtmagiaohang.Text;
            DataTable dt = inPhieuGiaoBUS.inPhieuGiao(maDonGia);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in hóa đơn.");
                return;
            }
            else
            {
                rptGiaoHang giaoHang = new rptGiaoHang();
                giaoHang.SetDataSource(dt);

                frmInPhieuGiao inPhieuGiao = new frmInPhieuGiao();

                // Gán report vào CrystalReportViewer
                inPhieuGiao.reportGiaoHang.ReportSource = giaoHang;

                // Hiển thị form in phiếu giao
                inPhieuGiao.ShowDialog(); // Sử dụng ShowDialog() để hiển thị modal form
            }
        }
        private void dgvgiaohang_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string[] mergeColumns = { "MaGiaoHang", "MaHoaDon"};

            // Kiểm tra xem cột có phải là cột cần gộp không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < dgvgiaohang.Columns.Count && mergeColumns.Contains(dgvgiaohang.Columns[e.ColumnIndex].Name))
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                int rowIndex = e.RowIndex;
                int cellHeight = e.CellBounds.Height;
                int mergeCount = 1;

                while (rowIndex < dgvgiaohang.Rows.Count - 1 &&
                       dgvgiaohang[e.ColumnIndex, rowIndex].Value != null &&
                       dgvgiaohang[e.ColumnIndex, rowIndex + 1].Value != null &&
                       dgvgiaohang[e.ColumnIndex, rowIndex].Value.ToString() == dgvgiaohang[e.ColumnIndex, rowIndex + 1].Value.ToString())
                {
                    cellHeight += dgvgiaohang.Rows[rowIndex + 1].Height;
                    mergeCount++;
                    rowIndex++;
                }

                // Vẽ giá trị hợp nhất ở giữa
                Rectangle cellBounds = e.CellBounds;
                cellBounds.Height = cellHeight;
                e.Graphics.DrawString(e.Value?.ToString(), e.CellStyle.Font, Brushes.Black, cellBounds, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });

                // Bỏ qua các ô phía dưới thuộc về nhóm đã hợp nhất
                for (int i = 1; i < mergeCount; i++)
                {
                    if (e.RowIndex + i < dgvgiaohang.Rows.Count && dgvgiaohang[e.ColumnIndex, e.RowIndex + i].Value != null)
                    {
                        dgvgiaohang[e.ColumnIndex, e.RowIndex + i].Value = "";
                    }
                }

                // Loại bỏ đường viền giữa các ô đã hợp nhất
                if (rowIndex < dgvgiaohang.Rows.Count - 1 &&
                    dgvgiaohang[e.ColumnIndex, rowIndex].Value != null &&
                    dgvgiaohang[e.ColumnIndex, rowIndex + 1].Value != null &&
                    dgvgiaohang[e.ColumnIndex, rowIndex].Value.ToString() == dgvgiaohang[e.ColumnIndex, rowIndex + 1].Value.ToString())
                {
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Bottom = dgvgiaohang.AdvancedCellBorderStyle.Bottom;
                }
            }
        }


    }
}
