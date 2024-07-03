using Com.Gosol.KNTC.Models;
using Com.Gosol.KNTC.Models.KNTC;
using Com.Gosol.KNTC.Ultilities;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.KNTC.DAL.KNTC
{
    public class RutDon_V2DAL
    {
        public BaseResultModel Insert(RutDon_V2Model rutDon, int canBoID)
        {
            var result = new BaseResultModel();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LyDoRutDon",SqlDbType.NVarChar),
                new SqlParameter("@CanBoID",SqlDbType.Int),
                new SqlParameter("@FileQD",SqlDbType.NVarChar),
                new SqlParameter("@XuLyDonID",SqlDbType.Int),
                new SqlParameter("@NgayRutDon",SqlDbType.Date),
            };
            parameters[0].Value = rutDon.LyDoRutDon;
            parameters[1].Value = canBoID;
            parameters[2].Value = rutDon.TenHoSo;
            parameters[3].Value = rutDon.XuLyDonID;
            parameters[4].Value = DateTime.Now;
            using (var connection = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        var query = Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "V2_NV_RutDon_Insert", parameters).ToString(), 0);
                        result.Status = 1;
                        result.Data = query;
                        result.Message = "Rút đơn thành công";
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            if (result.Status == 1)
            {
                UpdateDocument_By_XuLyDonID(rutDon.XuLyDonID);
            }
            return result;
        }
        public ChiTietRutDon GetByXuLyDonID(int xuLyDonID)
        {
            var Result = new BaseResultModel();
            ChiTietRutDon item = new ChiTietRutDon();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@XuLyDonID",SqlDbType.Int),
            };
            parameters[0].Value = xuLyDonID;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "V2_NV_RutDon_GetByXuLyDonID", parameters))
                {
                    while (dr.Read())
                    {
                        item.RutDonID = Utils.ConvertToInt32(dr["RutDonID"], 0);
                        item.LyDoRutDon = Utils.ConvertToString(dr["LyDo"], string.Empty);
                        item.CanBoID = Utils.ConvertToInt32(dr["CanBoID"], 0);
                        item.TenCanBo = Utils.ConvertToString(dr["TenCanBo"], string.Empty);
                        item.TenHoSo = Utils.ConvertToString(dr["FileQD"], string.Empty);
                        item.NgayCapNhap = dr["NgayRutDon"] != DBNull.Value ? Convert.ToDateTime(dr["NgayRutDon"]) : (DateTime?)null;
                    }
                    dr.Close();
                }
                Result.Status = 1;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = ex.ToString();
            }
            return item;
        }
        public BaseResultModel UpdateDocument_By_XuLyDonID(int xuLyDonID)
        {
            var result = new BaseResultModel();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@XuLyDonID",SqlDbType.Int),
                };
                parameters[0].Value = xuLyDonID;
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "V2_NV_Document_UpdateByXuLyDonID", parameters);
                            trans.Commit();
                            result.Status = 1;
                            result.Message = "Cập nhật thành công!";
                            result.Data = result.Status;
                        }
                        catch (Exception ex)
                        {
                            result.Status = -1;
                            result.Message = Constant.ERR_UPDATE;
                            trans.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }
    }
}
