using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Models.ViewModels;
using CoreLib.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDAL.DataAccess
{
    public class DatabaseLogin
    {

        public static CResult UserLogin(LoginViewModel User)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                prmUserName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUserName);

                SqlParameter prmPassWord = new SqlParameter("@PassWord", SqlDbType.VarChar, 50);
                prmPassWord.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassWord);
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                //set value~
                prmUserName.Value = User.UserName;
                prmPassWord.Value = User.PassWord.HashMD5();                

                objSQL.ExecuteSP(CommonConstants.SP_LOGIN);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString()};
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
                
            }

            return objResult;
        }

        public static List<string> GetUserGroup(string userName)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");

                //input param
                SqlParameter prmUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                prmUserName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUserName);

                // set value param
                prmUserName.Value = userName;

                SqlDataReader reader = objSQL.GetDataReaderFromSP("");

                var ListGroup = new List<string>();
                string groupCode = "";

                while (reader.Read())
                {
                    try
                    {
                        groupCode = Common.SafeGetString(reader, "GroupCode");

                        ListGroup.Add(groupCode);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return ListGroup;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<string>();
        }
        
    }
}
