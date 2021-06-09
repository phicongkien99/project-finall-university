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
    public static class DatabaseGroup
    {
        public static CResult InsertGroup(Group group)
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

                SqlParameter prmGroupName = new SqlParameter("@GroupName", SqlDbType.NVarChar, 200);
                prmGroupName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmGroupName);
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmGroupCode.Value = group.GroupCode;
                prmGroupName.Value = group.GroupName;
                
                objSQL.ExecuteSP(CommonConstants.SP_INSERT_GROUP);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
                
            }

            return objResult;
        }

        public static CResult UpdateGroup(Group group)
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

                SqlParameter prmGroupName = new SqlParameter("@GroupName", SqlDbType.NVarChar, 200);
                prmGroupName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmGroupName);
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.NVarChar, 100);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmGroupCode.Value = group.GroupCode;
                prmGroupName.Value = group.GroupName;               

                objSQL.ExecuteSP(CommonConstants.SP_UPDATE_GROUP);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
                
            }

            return objResult;
        }

        public static CResult DeleteGroup(string groupCode)
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
                
                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.NVarChar, 100);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmGroupCode.Value = groupCode;
                
                objSQL.ExecuteSP(CommonConstants.SP_DELETE_GROUP);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
                
            }

            return objResult;
        }

        public static List<Group> SearchGroup(string groupCode, string groupName)
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

                SqlParameter prmGroupName = new SqlParameter("@GroupName", SqlDbType.NVarChar, 200);
                prmGroupName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmGroupName);
                
                // set value param
                prmGroupCode.Value = groupCode;
                prmGroupName.Value = groupName;
                
                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_GROUP);

                var ListGroup = new List<Group>();
                 
                while (reader.Read())
                {
                    try
                    {
                        Group group = new Group();

                        group.GroupCode = Common.SafeGetString(reader, "GroupCode");
                        group.GroupName = Common.SafeGetString(reader, "GroupName");

                        ListGroup.Add(group);
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
                   // Ghi thông tin ra file
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<Group>();
        }
    }
}
