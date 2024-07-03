using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.KNTC.Models.KNTC
{
    public class RutDon_V2Model
    {
        public int XuLyDonID { get; set; }
        public string LyDoRutDon { get; set; }
        public string TenHoSo { get; set; }
        public List<IFormFile> ListFileRutDons { get; set; } = new List<IFormFile>();
    }
    public class ChiTietRutDon 
    {
        public ChiTietRutDon() 
        {
            ListFileRutDons = new List<FileRutDon>();
        }
        public int RutDonID { get; set; }
        public string LyDoRutDon { get; set; }
        public string TenHoSo { get; set; }
        public int CanBoID { get; set; }
        public string TenCanBo { get; set; }
        public DateTime? NgayCapNhap { get; set; }
        public List<FileRutDon> ListFileRutDons { get; set; }
    }
    public class FileRutDon
    {
        public string UrlFile { get; set; }
        public string TenFileGoc { get; set; }
    }

}
