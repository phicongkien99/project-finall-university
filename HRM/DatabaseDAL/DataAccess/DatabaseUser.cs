using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Models.ModelView;
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
    public class DatabaseUser
    {
        public static List<UserModelView> GetUsers(UserViewModel userViewModel)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");

                //input param
                SqlParameter prmUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                prmUserName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUserName);

                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 250);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 250);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);

                SqlParameter prmClientStatus = new SqlParameter("@ClientStatus", SqlDbType.Bit);
                prmClientStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmClientStatus);

                // set value param
                prmUserName.Value = userViewModel.Username;
                prmEmpCode.Value = userViewModel.EmpCode;
                prmFullName.Value = userViewModel.FullName;
                prmEmail.Value = userViewModel.Email;
                prmClientStatus.Value = userViewModel.ClientStatus;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_USER);

                var users = new List<UserModelView>();
                
                while (reader.Read())
                {
                    try
                    {
                        UserModelView userModelView = new UserModelView();

                        userModelView.Username = Common.SafeGetString(reader, "Username");
                        userModelView.Password = Common.SafeGetString(reader, "Password");
                        userModelView.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        userModelView.FullName = Common.SafeGetString(reader, "FullName");
                        userModelView.Email= Common.SafeGetString(reader, "Email");
                        userModelView.ClientStatus = Common.SafeGetBool(reader, "ClientStatus");
                        userModelView.CreateBy = Common.SafeGetString(reader, "CreateBy");
                        userModelView.CreateOn = Common.SafeGetDateTimeWithNull(reader, "CreateOn");
                        userModelView.ModifiedBy = Common.SafeGetString(reader, "ModifiedBy");
                        userModelView.ModifiedOn = Common.SafeGetDateTimeWithNull(reader, "ModifiedOn");
                        userModelView.GroupCode = Common.SafeGetString(reader, "GroupCode");

                        users.Add(userModelView);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return users;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<UserModelView>();
        }

        public static List<User> GetUserEmployees(User user)
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");

                //input param
                SqlParameter prmUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                prmUserName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUserName);

                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                SqlParameter prmEmployeeCode = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar, 50);
                prmEmployeeCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmployeeCode);

                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 250);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 250);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);

                SqlParameter prmClientStatus = new SqlParameter("@ClientStatus", SqlDbType.Bit);
                prmClientStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmClientStatus);

                // set value param
                prmUserName.Value = user.Username;
                prmEmpCode.Value = user.EmpCode;
                prmEmployeeCode.Value = user.EmployeeCode;
                prmFullName.Value = user.FullName;
                prmEmail.Value = user.Email;
                prmClientStatus.Value = user.ClientStatus;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_USER_EMPLOYEE);

                var users = new List<User>();

                while (reader.Read())
                {
                    try
                    {
                        User user2 = new User();

                        user2.Username = Common.SafeGetString(reader, "Username");
                        user2.Password = Common.SafeGetString(reader, "Password");
                        user2.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        user2.EmployeeCode = Common.SafeGetString(reader, "EmployeeCode");
                        user2.FullName = Common.SafeGetString(reader, "FullName");
                        user2.Email = Common.SafeGetString(reader, "Email");
                        user2.ClientStatus = Common.SafeGetBool(reader, "ClientStatus");
                        user2.CreateBy = Common.SafeGetString(reader, "CreateBy");
                        user2.CreateOn = Common.SafeGetDateTimeWithNull(reader, "CreateOn");
                        user2.ModifiedBy = Common.SafeGetString(reader, "ModifiedBy");
                        user2.ModifiedOn = Common.SafeGetDateTimeWithNull(reader, "ModifiedOn");
                        
                        users.Add(user2);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return users;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<User>();
        }

        public static CResult InsertUser(User user)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                prmUsername.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUsername);

                SqlParameter prmPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                prmPassword.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassword);

                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 250);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                SqlParameter prmClientStatus = new SqlParameter("@ClientStatus", SqlDbType.Bit);
                prmClientStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmClientStatus);

                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 50);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);
                
                SqlParameter prmCreateBy = new SqlParameter("@CreateBy", SqlDbType.NVarChar, 50);
                prmCreateBy.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCreateBy);

                SqlParameter prmCreateOn = new SqlParameter("@CreateOn", SqlDbType.DateTime);
                prmCreateOn.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCreateOn);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmUsername.Value = user.Username;
                prmPassword.Value = user.Password.HashMD5();
                prmEmpCode.Value = user.EmpCode;
                prmClientStatus.Value = user.ClientStatus;
                prmFullName.Value = user.FullName;
                prmEmail.Value = user.Email;
                prmCreateBy.Value = user.CreateBy;
                prmCreateOn.Value = user.CreateOn?.ToString("yyyy-MM-dd");

                objSQL.ExecuteSP(CommonConstants.SP_INSERT_USER);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
            }

            return objResult;
        }

        public static CResult UpdateUser(User user)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                prmUsername.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmUsername);

                SqlParameter prmPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                prmPassword.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassword);
                
                SqlParameter prmClientStatus = new SqlParameter("@ClientStatus", SqlDbType.Bit);
                prmClientStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmClientStatus);
                
                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);

                SqlParameter prmModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50);
                prmModifiedBy.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmModifiedBy);

                SqlParameter prmModifiedOn = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
                prmModifiedOn.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmModifiedOn);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmUsername.Value = user.Username;
                //prmPassword.Value = user.Password.HashMD5();                
                prmClientStatus.Value = user.ClientStatus;                
                prmEmail.Value = user.Email;
                prmModifiedBy.Value = user.CreateBy;
                prmModifiedOn.Value = user.CreateOn?.ToString("yyyy-MM-dd");

                objSQL.ExecuteSP(CommonConstants.SP_UPDATE_USER);

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
