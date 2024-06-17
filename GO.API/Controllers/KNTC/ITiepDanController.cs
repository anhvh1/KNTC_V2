using Com.Gosol.KNTC.Models;
using Com.Gosol.KNTC.Models.KNTC;
using Microsoft.AspNetCore.Mvc;

namespace GO.API.Controllers.KNTC
{
    public interface ITiepDanController
    {
        IActionResult CheckSoDonTrung([FromQuery] string? hoTen, string? cmnd, string? diaChi, string? noiDung);
        IActionResult CTDonKhieuToLan2([FromQuery] int? DonThuID);
        IActionResult CTDonTrung([FromQuery] int? DonThuID);
        IActionResult DanhMucChucVu();
        IActionResult DanhMucDanToc();
        IActionResult DanhMucHuyen(int? TinhID);
        IActionResult DanhMucLoaiKhieuTo(int? LoaiKhieuToID);
        IActionResult DanhMucQuocTich();
        IActionResult DanhMucTenFile();
        IActionResult DanhMucTinh();
        IActionResult DanhMucXa(int? HuyenID);
        IActionResult DanhSachBieuMau();
        IActionResult DanhSachDonThuDaTiepNhan([FromQuery] TiepDanParamsForFilter p);
        IActionResult Delete(List<TiepDanKhongDonInfo> p);
        IActionResult DeleteDanKhongDen(BaseDeleteParams p);
        IActionResult DeleteTiepDanDinhKy(BaseDeleteParams p);
        IActionResult DeleteVuViec(List<TiepDanDinhKyModel> p);
        IActionResult GetAllCanBo();
        IActionResult GetAllCap();
        IActionResult GetAllCoQuan();
        IActionResult GetAllHuongXuLy();
        IActionResult GetByID(int TiepDanID);
        IActionResult GetCanBoXuLy();
        IActionResult GetDanhSachLanhDao(int? CoQuanID);
        IActionResult GetDonTrung([FromQuery] string? hoTen, string? cmnd, string? diaChi, string? noiDung);
        IActionResult GetListPaging([FromQuery] TiepDanParamsForFilter p);
        IActionResult GetPhongXuLy();
        IActionResult GetSTT(int? namTiepNhan);
        IActionResult HinhThucDaGiaiQuyet();
        IActionResult InPhieu([FromQuery] string? MaPhieuIn, int? XuLyDonID, int? DonThuID, int? TiepDanKhongDonID);
        IActionResult InPhieuPDF([FromQuery] string? MaPhieuIn, int? XuLyDonID, int? DonThuID, int? TiepDanKhongDonID);
        IActionResult Insert(TiepDanInfo TiepDanInfo);
        IActionResult KiemTraKhieuToLan2([FromQuery] string? hoTen, string? cmnd, string? diaChi, string? noiDung);
        IActionResult SaveTiepCongDan_DanKhongDen(TiepCongDan_DanKhongDenInfo TiepDanInfo);
        IActionResult SaveTiepDanDinhKy_New(TiepDanDinhKyModel TiepDanInfo);
        IActionResult TiepDanDinhKy_GetByID(int TiepDinhKyID);
        IActionResult TiepDanDinhKy_GetListPaging([FromQuery] TiepDanParamsForFilter p);
        IActionResult TiepDan_DanKhongDen_GetByID(int DanKhongDenID);
    }
}