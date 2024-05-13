using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.KNTC.Models.KNTC
{
    public class DonThuChiTietModel
    {
        public TiepDanInfo TiepDanInfo { get; set; }
        public DonThuInfo DonThu { get; set; }
        public NhomKNInfo NhomKN { get; set; }
        public DoiTuongBiKNInfo DoiTuongBiKN { get; set; }
        public List<DoiTuongBiKNInfo> DanhSachDoiTuongBiKN { get; set; }
        public KetQuaXuLyModel KetQuaXuLy { get; set; }
        public List<KetQuaInfo> ThongTinDonDoc { get; set; }
        public QuyetDinhInfo ThongTinQuyetDinhGQ { get; set; }
        public DonThuThiHanhInfo ThongTinThiHanh { get; set; }
        public KetQuaXacMinhModel KetQuaXacMinh { get; set; }
        public KetQuaTranhChapInfo KetQuaTranhChap { get; set; }
        public List<FileHoSoInfo> FileHoSo { get; set; }
        public List<TransitionHistoryInfo> TienTrinhXuLy { get; set; }
        public List<DanhSachHoSoTaiLieu> DanhSachHoSoTaiLieu { get; set; }

    }

    public class KetQuaXuLyModel
    {
        public int? XuLyDonID { get; set; }
        public string TrangThaiXuLy { get; set; }
        public string CoQuanXuLy { get; set; }
        public string CanBoXuLy { get; set; }
        public DateTime? NgayXuLy { get; set; }
        public string HuongXuLy { get; set; }
        public string NoiDungXuLy { get; set; }
        public string LanhDaoPheDuyet { get; set; }
        public string ChuyenChoCoQuan { get; set; }
        public List<DanhSachHoSoTaiLieu> DanhSachHoSoTaiLieu { get; set; }
    }
}
