using Com.Gosol.KNTC.DAL.KNTC;
using Com.Gosol.KNTC.Models.KNTC;
using Com.Gosol.KNTC.Models;
using Com.Gosol.KNTC.Models.BaoCao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Gosol.KNTC.Ultilities;
using Com.Gosol.KNTC.DAL.BaoCao;
using DocumentFormat.OpenXml.Wordprocessing;
using TableHeader = Com.Gosol.KNTC.Models.BaoCao.TableHeader;
using System.Data;
using DataTable = Com.Gosol.KNTC.Models.BaoCao.DataTable;
using OfficeOpenXml;
using System.IO;

namespace Com.Gosol.KNTC.BUS.KNTC
{
    public class QuanLyNhapLieuBUS
    {
        public BaoCaoModel GetBySearch(ref int TotalRow, BasePagingParamsForFilter p)
        {
            var coQuanList = new ThongKeNhapLieu().GetByTime(p.TuNgay ?? DateTime.Now, p.DenNgay ?? DateTime.Now);
            if(p.CoQuanID > 0)
            {
                coQuanList = coQuanList.Where(x => x.CoQuanID == p.CoQuanID).ToList();
            }
            //chua nhap lieu
            if (p.TrangThai == 1)
            {
                coQuanList = coQuanList.Where(x => x.SLTiepDan == 0 && x.SLDonThu == 0 && x.SLXuLyDon == 0 && x.SLGiaiQuyetDon == 0).ToList();
            }
            else if (p.TrangThai == 2)
            {
                coQuanList = coQuanList.Where(x => x.SLTiepDan != 0 || x.SLDonThu != 0 || x.SLXuLyDon != 0 || x.SLGiaiQuyetDon != 0).ToList();
            }

            BaoCaoModel BaoCaoModel = new BaoCaoModel();
            BaoCaoModel.BieuSo = "";
            BaoCaoModel.ThongTinSoLieu = "Từ ngày " + (p.TuNgay ?? DateTime.Now).ToString("dd/MM/yyyy") + " đến ngày " + (p.DenNgay ?? DateTime.Now).ToString("dd/MM/yyyy");
            BaoCaoModel.TuNgay = (p.TuNgay ?? DateTime.Now).ToString("dd/MM/yyyy");
            BaoCaoModel.DenNgay = (p.DenNgay ?? DateTime.Now).ToString("dd/MM/yyyy");
            BaoCaoModel.Title = "QUẢN LÝ NHẬP LIỆU";
            BaoCaoModel.DataTable = new DataTable();
            BaoCaoModel.DataTable.TableHeader = new List<TableHeader>();
            BaoCaoModel.DataTable.TableData = new List<TableData>();

            #region Header
            var listTableHeader = new List<TableHeader>();
            TableHeader HeaderCol1 = new TableHeader(1, 0, "STT", "width: 50px", ref listTableHeader);
            TableHeader HeaderCol2 = new TableHeader(2, 0, "Đơn vị", "", ref listTableHeader);
            TableHeader HeaderCol3 = new TableHeader(3, 0, "Tiếp công dân", "", ref listTableHeader);
            TableHeader HeaderCol4 = new TableHeader(3, 0, "Tiếp nhận đơn", "", ref listTableHeader);
            TableHeader HeaderCol5 = new TableHeader(4, 0, "Xử lý đơn", "", ref listTableHeader);
            TableHeader HeaderCol6 = new TableHeader(5, 0, "Giải quyết đơn", "", ref listTableHeader);
            BaoCaoModel.DataTable.TableHeader = listTableHeader;
            #endregion
            #region TableData 
            //Row1.ID = 1;
            //Row1.isClick = false;          
            List<TableData> data = new List<TableData>();
            int stt = 0;
            foreach (ThongKeNhapLieuInfo cq in coQuanList)
            {
                TableData tableData = new TableData();
                tableData.ID = stt++;
                var DataArr = new List<RowItem>();
                RowItem RowItem1 = new RowItem(1, stt.ToString(), "", "", null, "text-align: center;width: 50px", ref DataArr);
                RowItem RowItem2 = new RowItem(2, cq.TenDonVi, "", "", null, "text-align: left;", ref DataArr);
                RowItem RowItem3 = new RowItem(3, cq.SLTiepDan.ToString(), "", "", null, "text-align: center;", ref DataArr);
                RowItem RowItem4 = new RowItem(4, cq.SLDonThu.ToString(), "", "", null, "text-align: center;", ref DataArr);
                RowItem RowItem5 = new RowItem(5, cq.SLXuLyDon.ToString(), "", "", null, "text-align: center;", ref DataArr);
                RowItem RowItem6 = new RowItem(6, cq.SLGiaiQuyetDon.ToString(), "", "", null, "text-align: center;", ref DataArr);
              
                tableData.DataArr = DataArr;
                data.Add(tableData);
            }
            
            BaoCaoModel.DataTable.TableData.AddRange(data);

            #endregion
            return BaoCaoModel;
        }

        public BaseResultModel ExportExcel(BasePagingParamsForFilter p, int CanBoDangNhapID, string ContentRootPath)
        {
            var Result = new BaseResultModel();
            try
            {
                var coQuanList = new ThongKeNhapLieu().GetByTime(p.TuNgay ?? DateTime.Now, p.DenNgay ?? DateTime.Now);
                if (p.CoQuanID > 0)
                {
                    coQuanList = coQuanList.Where(x => x.CoQuanID == p.CoQuanID).ToList();
                }
                //chua nhap lieu
                if (p.TrangThai == 0)
                {
                    coQuanList = coQuanList.Where(x => x.SLTiepDan == 0 && x.SLDonThu == 0 && x.SLXuLyDon == 0 && x.SLGiaiQuyetDon == 0).ToList();
                }
                else if (p.TrangThai == 1)
                {
                    coQuanList = coQuanList.Where(x => x.SLTiepDan != 0 || x.SLDonThu!= 0 || x.SLXuLyDon != 0 || x.SLGiaiQuyetDon != 0).ToList();
                }
                List<TableData> data = new List<TableData>();
                int stt = 0;
                foreach (ThongKeNhapLieuInfo cq in coQuanList)
                {
                    TableData tableData = new TableData();
                    tableData.ID = stt++;
                    var DataArr = new List<RowItem>();
                    RowItem RowItem1 = new RowItem(1, stt.ToString(), "", "", null, "width: 15px", ref DataArr);
                    RowItem RowItem2 = new RowItem(2, cq.TenDonVi, "", "", null, "text-align: left;", ref DataArr);
                    RowItem RowItem3 = new RowItem(3, cq.SLTiepDan.ToString(), "", "", null, "text-align: center;", ref DataArr);
                    RowItem RowItem4 = new RowItem(4, cq.SLXuLyDon.ToString(), "", "", null, "text-align: center;", ref DataArr);
                    RowItem RowItem5 = new RowItem(4, cq.SLDonThu.ToString(), "", "", null, "text-align: center;", ref DataArr);
                    RowItem RowItem6 = new RowItem(5, cq.SLGiaiQuyetDon.ToString(), "", "", null, "text-align: center;", ref DataArr);

                    tableData.DataArr = DataArr;
                    data.Add(tableData);
                }
              
                string path = @"Templates\FileTam\ThongKeNhapLieu_" + CanBoDangNhapID + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xlsx";
                string urlExcel = ThongKeNhapLieu_Excel(ContentRootPath, path, data, p.TuNgay ?? DateTime.Now, p.DenNgay ?? DateTime.Now);
                Result.Status = 1;
                Result.Data = urlExcel;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = ex.ToString();
                Result.Data = null;
            }

            return Result;
        }

        public string ThongKeNhapLieu_Excel(string rootPath, string pathFile, List<TableData> data, DateTime tuNgay, DateTime denNgay)
        {
            // path to your excel file
            string path = rootPath + @"\Templates\BaoCao\ThongKeNhapLieu.xlsx";
            FileInfo fileInfo = new FileInfo(path);
            FileInfo file = new FileInfo(rootPath + "\\" + pathFile);

            ExcelPackage package = new ExcelPackage(fileInfo);
            if (package.Workbook.Worksheets != null)
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // get number of rows in the sheet
                int rows = worksheet.Dimension.Rows;
                int cols = worksheet.Dimension.Columns;

                string TuNgayDenNgay = "SO_LIEU_TINH_TU_NGAY_DEN_NGAY";

                // loop through the worksheet rows
                for (int i = 1; i <= rows; i++)
                {
                    for (int j = 1; j <= cols; j++)
                    {
                        if (worksheet.Cells[i, j].Value != null && TuNgayDenNgay.Contains(worksheet.Cells[i, j].Value.ToString()))
                        {
                            worksheet.Cells[i, j].Value = "Từ ngày " + tuNgay.ToString("dd/MM/yyyy") + " đến ngày " + denNgay.ToString("dd/MM/yyyy");
                        }
                    }
                }
                if (data.Count > 0)
                {
                    worksheet.InsertRow(6, data.Count - 1, 5);
                    //worksheet.DeleteRow(data.Count);
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].DataArr != null && data[i].DataArr.Count > 0)
                        {
                            for (int j = 0; j < data[i].DataArr.Count; j++)
                            {
                                //if (data[i].DataArr[j].Content != "0")
                                //{
                                    worksheet.Cells[i + 5, j + 1].Value = data[i].DataArr[j].Content;
                                    if (data[i].DataArr[j].Style.Contains("bold")) worksheet.Cells[i + 5, j + 1].Style.Font.Bold = true;
                                //}
                            }
                        }

                    }

                }

                // save changes
                package.SaveAs(file);
            }

            return pathFile;
        }
    }
}
