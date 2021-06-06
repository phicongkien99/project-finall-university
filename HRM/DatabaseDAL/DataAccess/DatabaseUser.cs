using CoreLib.Commons;
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
    }
}
