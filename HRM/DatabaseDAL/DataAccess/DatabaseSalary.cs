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
    public class DatabaseSalary
    {
        public static CResult InsertSalary(Salary salary)
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

                SqlParameter prmMoney = new SqlParameter("@Money", SqlDbType.BigInt);
                prmMoney.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmMoney);

                SqlParameter prmSalaryType = new SqlParameter("@SalaryType", SqlDbType.NVarChar, 50);
                prmSalaryType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSalaryType);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmEmpCode.Value = salary.EmpCode;
                prmMoney.Value = salary.Money;
                prmSalaryType.Value = salary.SalaryType;

                objSQL.ExecuteSP(CommonConstants.SP_INSERT_SALARY);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static CResult DeleteSalary(int id)
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
                
                objSQL.ExecuteSP(CommonConstants.SP_DELETE_SALARY);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static List<Salary> SearchSalary(Salary salary)
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

                SqlParameter prmSalaryType = new SqlParameter("@SalaryType", SqlDbType.NVarChar, 50);
                prmSalaryType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSalaryType);

                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 200);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                // set value param
                prmSalaryType.Value = salary.SalaryType;
                prmFullName.Value = salary.FullName;
                prmEmpCode.Value = salary.EmpCode;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_SALARY);

                var List = new List<Salary>();

                while (reader.Read())
                {
                    try
                    {
                        Salary salary2 = new Salary();

                        salary2.ID = Common.SafeGetInt(reader, "ID");
                        salary2.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        salary2.SalaryType = Common.SafeGetString(reader, "SalaryType");
                        salary2.Money = (double)Common.SafeGetDecimal(reader, "Money");
                        salary2.FullName = Common.SafeGetString(reader, "FullName");

                        List.Add(salary2);
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

            return new List<Salary>();
        }
    }
}
