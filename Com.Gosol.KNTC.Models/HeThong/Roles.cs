using Com.Gosol.KNTC.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.KNTC.Models.HeThong
{
    public class Roles
    {
        public bool step1_XLD_HuongXuLy { get; set; }
        public bool step2_XLD_TrinhLan1 { get; set; }

        public bool step3_PDKQXL_DuyetLan1 { get; set; }
        public bool step4_PDKQXL_TrinhLan2 { get; set; }
        public bool step5_PDKQXL_DuyetLan2 { get; set; }


        public bool step6_BanHanh_QDGXM { get; set; }
        public bool step7_CapNhap_GXM { get; set; }


        public bool step8_GQD_GXMLan1 { get; set; }
        public bool step9_GQD_GXMLan2 { get; set; }
        public bool step10_GQD_XM { get; set; }
        public bool step11_GQD_DuyetXM { get; set; }
        public bool step12_GQD_BanHanhQDGQ { get; set; }
        public bool step13_CapNhap_BCKLQD { get; set; }
        public bool step14_ThucThi_BCKLQD { get; set; }



        public Roles(NguoiDungModel model)
        {
            if (model != null && (model.SuDungQuyTrinhPhucTap ?? false))
            {
                GetRolesByUser(model);
            }
        }

        private void GetRolesByUser(NguoiDungModel model)
        {
            switch (model?.CapHanhChinh)
            {
                case ((int)EnumCapHanhChinh.CapUBNDTinh):
                    if (model?.RoleID == RoleEnum.LanhDao.GetHashCode() && model?.ChuTichUBND == 1)
                    {
                        step6_BanHanh_QDGXM = true;
                        step12_GQD_BanHanhQDGQ = true;
                        break;
                    }
                    if ((model?.BanTiepDan ?? false))
                    {
                        if (model?.RoleID == RoleEnum.LanhDao.GetHashCode())
                        {
                            step3_PDKQXL_DuyetLan1 = true;
                            step4_PDKQXL_TrinhLan2 = true;

                            step7_CapNhap_GXM = true;

                            step13_CapNhap_BCKLQD = true;
                        }
                        if (model?.RoleID == RoleEnum.ChuyenVien.GetHashCode())
                        {
                            step1_XLD_HuongXuLy = true;
                            step2_XLD_TrinhLan1 = true;
                        }
                    }
                    break;

                case ((int)EnumCapHanhChinh.CapSoNganh):
                    if (model?.RoleID == RoleEnum.LanhDao.GetHashCode())
                    {
                        step5_PDKQXL_DuyetLan2 = true;

                        step8_GQD_GXMLan1 = true;
                        step11_GQD_DuyetXM = true;

                        step13_CapNhap_BCKLQD = true;
                    }

                    if (model?.RoleID == RoleEnum.LanhDaoPhong.GetHashCode())
                    {
                        step3_PDKQXL_DuyetLan1 = true;
                        step4_PDKQXL_TrinhLan2 = true;

                        step9_GQD_GXMLan2 = true;
                        step11_GQD_DuyetXM = true;

                    }

                    if (model?.RoleID == RoleEnum.ChuyenVien.GetHashCode())
                    {
                        step1_XLD_HuongXuLy = true;
                        step2_XLD_TrinhLan1 = true;

                        step10_GQD_XM = true;

                        step14_ThucThi_BCKLQD = true;
                    }
                    break;

                case ((int)EnumCapHanhChinh.CapPhongThuocSo):
                    if (model?.RoleID == RoleEnum.LanhDaoPhong.GetHashCode())
                    {
                        step3_PDKQXL_DuyetLan1 = true;
                        step4_PDKQXL_TrinhLan2 = true;

                        step9_GQD_GXMLan2 = true;
                        step11_GQD_DuyetXM = true;

                    }

                    if (model?.RoleID == RoleEnum.ChuyenVien.GetHashCode())
                    {
                        step1_XLD_HuongXuLy = true;
                        step2_XLD_TrinhLan1 = true;

                        step10_GQD_XM = true;
                        step14_ThucThi_BCKLQD = true;
                    }
                    break;

                case ((int)EnumCapHanhChinh.CapUBNDHuyen):
                    if (model?.RoleID == RoleEnum.LanhDao.GetHashCode() && model?.ChuTichUBND == 1)
                    {
                        step5_PDKQXL_DuyetLan2 = true;
                        step6_BanHanh_QDGXM = true;
                        step12_GQD_BanHanhQDGQ = true;

                    }
                    break;

                case ((int)EnumCapHanhChinh.CapPhongThuocHuyen):
                    if ((model?.BanTiepDan ?? false))
                    {
                        if (model?.RoleID == RoleEnum.LanhDao.GetHashCode())
                        {
                            step3_PDKQXL_DuyetLan1 = true;
                            step4_PDKQXL_TrinhLan2 = true;

                        }
                        if (model?.RoleID == RoleEnum.ChuyenVien.GetHashCode())
                        {
                            step1_XLD_HuongXuLy = true;
                            step2_XLD_TrinhLan1 = true;
                        }
                    }
                    else
                    {
                        if (model?.RoleID == RoleEnum.LanhDao.GetHashCode())
                        {
                            step5_PDKQXL_DuyetLan2 = true;

                            step9_GQD_GXMLan2 = true;
                            step11_GQD_DuyetXM = true;
                        }
                        

                        if (model?.RoleID == RoleEnum.ChuyenVien.GetHashCode())
                        {
                            step1_XLD_HuongXuLy = true;
                            step2_XLD_TrinhLan1 = true;

                            step10_GQD_XM = true;

                            step13_CapNhap_BCKLQD = true;
                            step14_ThucThi_BCKLQD = true;
                        }
                    }
                    break;

                case ((int)EnumCapHanhChinh.CapUBNDXa):

                    if (model?.RoleID == RoleEnum.LanhDao.GetHashCode())
                    {
                        step3_PDKQXL_DuyetLan1 = true;

                        step9_GQD_GXMLan2 = true;
                        step11_GQD_DuyetXM = true;


                    }
                    if (model?.RoleID == RoleEnum.ChuyenVien.GetHashCode())
                    {
                        step1_XLD_HuongXuLy = true;
                        step2_XLD_TrinhLan1 = true;

                        step13_CapNhap_BCKLQD = true;
                        step14_ThucThi_BCKLQD = true;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
