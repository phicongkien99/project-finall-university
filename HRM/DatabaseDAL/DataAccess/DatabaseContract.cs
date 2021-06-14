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
    public class DatabaseContract
    {
        public static List<Contract> GetEmployees(Contract contract)
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

                SqlParameter prmContractType = new SqlParameter("@ContractType", SqlDbType.NVarChar, 50);
                prmContractType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmContractType);

                SqlParameter prmContractNumber = new SqlParameter("@ContractNumber", SqlDbType.NVarChar, 50);
                prmContractNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmContractNumber);

                SqlParameter prmEffecttiveDate = new SqlParameter("@EffecttiveDate", SqlDbType.NVarChar, 50);
                prmEffecttiveDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEffecttiveDate);

                SqlParameter prmExpireDate = new SqlParameter("@ExpireDate", SqlDbType.NVarChar, 50);
                prmExpireDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmExpireDate);

                SqlParameter prmSignDate = new SqlParameter("@SignDate", SqlDbType.NVarChar, 50);
                prmSignDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSignDate);

                SqlParameter prmSignEmp = new SqlParameter("@SignEmp", SqlDbType.NVarChar, 50);
                prmSignEmp.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSignEmp);

                SqlParameter prmManageEmp = new SqlParameter("@ManageEmp", SqlDbType.NVarChar, 50);
                prmManageEmp.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmManageEmp);

                SqlParameter prmPosition = new SqlParameter("@Position", SqlDbType.NVarChar, 50);
                prmPosition.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPosition);

                // set value param
                prmEmpCode.Value = contract.EmpCode;
                prmContractType.Value = contract.ContractType;
                prmContractNumber.Value = contract.ContractNumber;
                prmEffecttiveDate.Value = contract.EffecttiveDate?.ToString("yyyy-MM-dd");
                prmExpireDate.Value = contract.ExpireDate?.ToString("yyyy-MM-dd");
                prmSignDate.Value = contract.SignDate?.ToString("yyyy-MM-dd");
                prmSignEmp.Value = contract.SignEmp;
                prmManageEmp.Value = contract.ManageEmp;
                prmPosition.Value = contract.Position;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_CONTRACT);

                var contracts = new List<Contract>();

                while (reader.Read())
                {
                    try
                    {
                        Contract contract2 = new Contract();

                        contract2.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        contract2.FullName = Common.SafeGetString(reader, "FullName");
                        contract2.ID = Common.SafeGetInt(reader, "ID");
                        contract2.ContractType = Common.SafeGetString(reader, "ContractType");
                        contract2.ContractNumber = Common.SafeGetString(reader, "ContractNumber");
                        contract2.EffecttiveDate = Common.SafeGetDateTimeWithNull(reader, "EffecttiveDate");
                        contract2.ExpireDate = Common.SafeGetDateTimeWithNull(reader, "ExpireDate");
                        contract2.SignDate = Common.SafeGetDateTimeWithNull(reader, "SignDate");
                        contract2.SignEmp = Common.SafeGetString(reader, "SignEmp");
                        contract2.ManageEmp = Common.SafeGetString(reader, "ManageEmp");
                        contract2.Position = Common.SafeGetString(reader, "Position");

                        contract2.EffecttiveDateStr = Common.SafeGetDateTimeWithNull(reader, "EffecttiveDate")?.ToString("dd/MM/yyyy");
                        contract2.ExpireDateStr = Common.SafeGetDateTimeWithNull(reader, "ExpireDate")?.ToString("dd/MM/yyyy");
                        contract2.SignDateStr = Common.SafeGetDateTimeWithNull(reader, "SignDate")?.ToString("dd/MM/yyyy");


                        contracts.Add(contract2);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return contracts;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<Contract>();
        }

        public static CResult InsertContract(Contract contract)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                //input param
                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                SqlParameter prmContractType = new SqlParameter("@ContractType", SqlDbType.NVarChar, 50);
                prmContractType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmContractType);

                SqlParameter prmContractNumber = new SqlParameter("@ContractNumber", SqlDbType.NVarChar, 50);
                prmContractNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmContractNumber);

                SqlParameter prmEffecttiveDate = new SqlParameter("@EffecttiveDate", SqlDbType.NVarChar, 50);
                prmEffecttiveDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEffecttiveDate);

                SqlParameter prmExpireDate = new SqlParameter("@ExpireDate", SqlDbType.NVarChar, 50);
                prmExpireDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmExpireDate);

                SqlParameter prmSignDate = new SqlParameter("@SignDate", SqlDbType.NVarChar, 50);
                prmSignDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSignDate);

                SqlParameter prmSignEmp = new SqlParameter("@SignEmp", SqlDbType.NVarChar, 50);
                prmSignEmp.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSignEmp);

                SqlParameter prmManageEmp = new SqlParameter("@ManageEmp", SqlDbType.NVarChar, 50);
                prmManageEmp.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmManageEmp);

                SqlParameter prmPosition = new SqlParameter("@Position", SqlDbType.NVarChar, 50);
                prmPosition.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPosition);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value param
                prmEmpCode.Value = contract.EmpCode;
                prmContractType.Value = contract.ContractType;
                prmContractNumber.Value = contract.ContractNumber;
                prmEffecttiveDate.Value = contract.EffecttiveDate?.ToString("yyyy-MM-dd");
                prmExpireDate.Value = contract.ExpireDate?.ToString("yyyy-MM-dd");
                prmSignDate.Value = contract.SignDate?.ToString("yyyy-MM-dd");
                prmSignEmp.Value = contract.SignEmp;
                prmManageEmp.Value = contract.ManageEmp;
                prmPosition.Value = contract.Position;
                
                objSQL.ExecuteSP(CommonConstants.SP_INSERT_CONTRACT);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
            }

            return objResult;
        }

        public static CResult UpdateContract(Contract contract)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                //input param
                SqlParameter prmEmpCode = new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50);
                prmEmpCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpCode);

                SqlParameter prmContractType = new SqlParameter("@ContractType", SqlDbType.NVarChar, 50);
                prmContractType.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmContractType);

                SqlParameter prmContractNumber = new SqlParameter("@ContractNumber", SqlDbType.NVarChar, 50);
                prmContractNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmContractNumber);

                SqlParameter prmEffecttiveDate = new SqlParameter("@EffecttiveDate", SqlDbType.NVarChar, 50);
                prmEffecttiveDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEffecttiveDate);

                SqlParameter prmExpireDate = new SqlParameter("@ExpireDate", SqlDbType.NVarChar, 50);
                prmExpireDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmExpireDate);

                SqlParameter prmSignDate = new SqlParameter("@SignDate", SqlDbType.NVarChar, 50);
                prmSignDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSignDate);

                SqlParameter prmSignEmp = new SqlParameter("@SignEmp", SqlDbType.NVarChar, 50);
                prmSignEmp.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSignEmp);

                SqlParameter prmManageEmp = new SqlParameter("@ManageEmp", SqlDbType.NVarChar, 50);
                prmManageEmp.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmManageEmp);

                SqlParameter prmPosition = new SqlParameter("@Position", SqlDbType.NVarChar, 50);
                prmPosition.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPosition);

                // output param
                SqlParameter Message = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                Message.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(Message);

                SqlParameter ErrCode = new SqlParameter("@ErrCode", SqlDbType.Int);
                ErrCode.Direction = ParameterDirection.Output;
                objSQL.Command.Parameters.Add(ErrCode);

                // set value param
                prmEmpCode.Value = contract.EmpCode;
                prmContractType.Value = contract.ContractType;
                prmContractNumber.Value = contract.ContractNumber;
                prmEffecttiveDate.Value = contract.EffecttiveDate?.ToString("yyyy-MM-dd");
                prmExpireDate.Value = contract.ExpireDate?.ToString("yyyy-MM-dd");
                prmSignDate.Value = contract.SignDate?.ToString("yyyy-MM-dd");
                prmSignEmp.Value = contract.SignEmp;
                prmManageEmp.Value = contract.ManageEmp;
                prmPosition.Value = contract.Position;

                objSQL.ExecuteSP(CommonConstants.SP_UPDATE_CONTRACT);

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
