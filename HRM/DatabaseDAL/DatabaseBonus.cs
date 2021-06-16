using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Utils;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDAL
{
    public class DatabaseBonus
    {
        public static CResult InsertBonus(Bonus bonus)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                SqlParameter prmType = new SqlParameter("@Type", SqlDbType.NVarChar, 50);
                prmType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmType);

                SqlParameter prmMoney = new SqlParameter("@Money", SqlDbType.Int);
                prmMoney.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmMoney);

                SqlParameter prmNote = new SqlParameter("@Note", SqlDbType.NVarChar, 1000);
                prmNote.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmNote);

                SqlParameter prmRewardType = new SqlParameter("@RewardType", SqlDbType.NVarChar, 50);
                prmRewardType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmRewardType);
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmEmpCode.Value = bonus.EmpCode;
                prmType.Value = bonus.Type;
                prmMoney.Value = bonus.Money;
                prmNote.Value = bonus.Note;
                prmRewardType.Value = bonus.RewardType;                

                objSQL.ExecuteSP(CommonConstants.SP_INSERT_BONUS);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static CResult DeleteBonus(int id)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmID = new SqlParameter("@Id", SqlDbType.Int);
                prmID.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmID);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.NVarChar, 100);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmID.Value = id;

                objSQL.ExecuteSP(CommonConstants.SP_DELETE_BONUS);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static List<Bonus> SearchBonus(Bonus Bonus)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");

                //input param
                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                // set value param                                
                prmEmpCode.Value = Bonus.EmpCode;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_BONUS);

                var List = new List<Bonus>();

                while (reader.Read())
                {
                    try
                    {
                        Bonus bonus2 = new Bonus();

                        bonus2.ID = Common.SafeGetInt(reader, "ID");
                        bonus2.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        bonus2.FullName = Common.SafeGetString(reader, "FullName");
                        bonus2.Type = Common.SafeGetString(reader, "Type");
                        bonus2.Money = (double)Common.SafeGetDecimal(reader, "Money");
                        bonus2.Note = Common.SafeGetString(reader, "Note");
                        bonus2.RewardType = Common.SafeGetString(reader, "RewardType");

                        List.Add(bonus2);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return List;
            }
            catch (Exception ex)
            {
                // Ghi thông tin ra file
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<Bonus>();
        }
    }
}
