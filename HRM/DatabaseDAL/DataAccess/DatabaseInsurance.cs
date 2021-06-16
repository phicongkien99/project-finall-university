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
    public class DatabaseInsurance
    {
        public static CResult InsertInsurance(InsuranceSocial insuranceSocial)
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

                SqlParameter prmCodeNumber = new SqlParameter("@CodeNumber", SqlDbType.NVarChar, 50);
                prmCodeNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCodeNumber);

                SqlParameter prmFromDate = new SqlParameter("@FromDate", SqlDbType.Date);
                prmFromDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFromDate);

                SqlParameter prmToDate = new SqlParameter("@ToDate", SqlDbType.Date);
                prmToDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmToDate);

                SqlParameter prmStatus = new SqlParameter("@Status", SqlDbType.Bit);
                prmStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmStatus);

                SqlParameter prmCompany = new SqlParameter("@Company", SqlDbType.NVarChar, 50);
                prmCompany.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCompany);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value
                prmEmpCode.Value = insuranceSocial.EmpCode;
                prmCodeNumber.Value = insuranceSocial.CodeNumber;
                prmCompany.Value = insuranceSocial.Company;
                prmFromDate.Value = insuranceSocial.FromDate?.ToString("yyyy-MM-dd");
                prmToDate.Value = insuranceSocial.ToDate?.ToString("yyyy-MM-dd");
                prmStatus.Value = insuranceSocial.Status;

                objSQL.ExecuteSP(CommonConstants.SP_INSERT_INSURANCE);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static CResult DeleteInsurance(int id)
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

                objSQL.ExecuteSP(CommonConstants.SP_DELETE_INSURANCE);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };

            }

            return objResult;
        }

        public static List<InsuranceSocial> SearchInsurance(InsuranceSocial insuranceSocial)
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

                SqlParameter prmCodeNumber = new SqlParameter("@CodeNumber", SqlDbType.NVarChar, 50);
                prmCodeNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCodeNumber);
                
                // set value param                
                prmCodeNumber.Value = insuranceSocial.CodeNumber;
                prmEmpCode.Value = insuranceSocial.EmpCode;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_INSURANCE);

                var List = new List<InsuranceSocial>();

                while (reader.Read())
                {
                    try
                    {
                        InsuranceSocial insuranceSocial2 = new InsuranceSocial();

                        insuranceSocial2.ID = Common.SafeGetInt(reader, "ID");
                        insuranceSocial2.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        insuranceSocial2.CodeNumber = Common.SafeGetString(reader, "CodeNumber");
                        insuranceSocial2.Company = Common.SafeGetString(reader, "Company");
                        insuranceSocial2.Status = Common.SafeGetBool(reader, "Status");
                        insuranceSocial2.FullName = Common.SafeGetString(reader, "FullName");
                        insuranceSocial2.FromDate = Common.SafeGetDateTimeWithNull(reader, "FromDate");
                        insuranceSocial2.ToDate = Common.SafeGetDateTimeWithNull(reader, "ToDate");
                        insuranceSocial2.ToDateStr = Common.SafeGetDateTimeWithNull(reader, "ToDate")?.ToString("dd/MM/yyyy");
                        insuranceSocial2.FromDateStr = Common.SafeGetDateTimeWithNull(reader, "FromDate")?.ToString("dd/MM/yyyy");

                        List.Add(insuranceSocial2);
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

            return new List<InsuranceSocial>();
        }
    }
}
