using CoreLib.Commons;
using CoreLib.Models;
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
    public class DatabaseUserGroup
    {
        public static List<UserGroup> SearchUserGroup(string groupCode)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");

                //input param
                SqlParameter prmGroupCode = new SqlParameter("@GroupCode", SqlDbType.VarChar, 50);
                prmGroupCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmGroupCode);
                
                // set value param
                prmGroupCode.Value = groupCode;
                
                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_USER_GROUP);

                var userGroups = new List<UserGroup>();

                while (reader.Read())
                {
                    try
                    {
                        UserGroup userGroup = new UserGroup();

                        userGroup.Username = Common.SafeGetString(reader, "Username");
                        userGroup.FullName = Common.SafeGetString(reader, "FullName");
                        userGroup.InGroup = Common.SafeGetInt(reader, "IN_GROUP");
                        userGroup.CreateBy = Common.SafeGetString(reader, "CreateBy");
                        userGroup.CreateOnStr = Common.SafeGetDateTime(reader, "CreateOn").ToString("dd/MM/yyyy");

                        userGroups.Add(userGroup);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return userGroups;
            }
            catch (Exception ex)
            {
                // Ghi thông tin ra file
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<UserGroup>();
        }

        public static CResult InsertUserGroup(UserGroup userGroup)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmGroupCode = new SqlParameter("@GroupCode", SqlDbType.VarChar, 50);
                prmGroupCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmGroupCode);

                SqlParameter prmUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 200);
                prmUsername.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUsername);

                SqlParameter prmCreateBy = new SqlParameter("@CreateBy", SqlDbType.VarChar, 50);
                prmCreateBy.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCreateBy);
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmGroupCode.Value = userGroup.GroupCode;
                prmUsername.Value = userGroup.Username;
                prmCreateBy.Value = userGroup.CreateBy;

                objSQL.ExecuteSP(CommonConstants.SP_INSERT_USER_GROUP);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static CResult DeleteUserGroup(string groupCode, string username)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmGroupCode = new SqlParameter("@GroupCode", SqlDbType.VarChar, 50);
                prmGroupCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmGroupCode);

                SqlParameter prmUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 200);
                prmUsername.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUsername);
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmGroupCode.Value = groupCode;
                prmUsername.Value = username;
               
                objSQL.ExecuteSP(CommonConstants.SP_DELETE_USER_GROUP);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }
    }
}
