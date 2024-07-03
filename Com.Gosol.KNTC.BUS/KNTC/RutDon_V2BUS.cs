using Com.Gosol.KNTC.DAL.KNTC;
using Com.Gosol.KNTC.Models;
using Com.Gosol.KNTC.Models.KNTC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.KNTC.BUS.KNTC
{
    public class RutDon_V2BUS
    {
        private RutDon_V2DAL _rutDonV2;
        public RutDon_V2BUS() 
        {
            _rutDonV2 = new RutDon_V2DAL();
        }
        public BaseResultModel Insert(RutDon_V2Model rutDon, int canBoID)
        {
            var result = new BaseResultModel();
            try
            {
                if(rutDon.XuLyDonID <= 0)
                {
                    result.Status = 0;
                    result.Message = "Xử lý đơn id không được để trống";
                    return result;
                }
                if (string.IsNullOrEmpty(rutDon.LyDoRutDon))
                {
                    result.Status = 0;
                    result.Message = "lý do rút đơn không được để trống";
                    return result;
                }
                else
                {
                    result = _rutDonV2.Insert(rutDon, canBoID);
                }
            }
            catch (Exception ex)
            {
                result.Status= -1;
                result.Message = ex.Message;    
                throw;
            }
            return result;
        }
        public ChiTietRutDon GetByXuLyDonID(int xuLyDonID)
        {
            return _rutDonV2.GetByXuLyDonID(xuLyDonID);
        }
    }
}
