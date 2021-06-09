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

                var result = objSQL.GetDatasetFromSP(CommonConstants.SP_GET_USER_GROUP);

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_USER_GROUP);

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
