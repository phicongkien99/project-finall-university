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
    public class DatabaseEmployee
    {
        public static List<EmployeeModelView> GetEmployees(EmployeeViewModel employeeViewModel)
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
                
                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 250);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 250);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);

                SqlParameter prmClientStatus = new SqlParameter("@Status", SqlDbType.Bit);
                prmClientStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmClientStatus);

                SqlParameter prmAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 250);
                prmAddress.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmAddress);

                SqlParameter prmDepartment = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
                prmDepartment.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmDepartment);

                SqlParameter prmDOB = new SqlParameter("@DOB", SqlDbType.NVarChar, 50);
                prmDOB.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmDOB);

                // set value param
                prmEmpCode.Value = employeeViewModel.EmpCode;                
                prmFullName.Value = employeeViewModel.FullName;
                prmEmail.Value = employeeViewModel.Email;
                prmClientStatus.Value = employeeViewModel.EmpStatus;
                prmAddress.Value = employeeViewModel.Address;
                prmDepartment.Value = employeeViewModel.DepartmentCode;
                prmDOB.Value = employeeViewModel.BOD?.ToString("yyyy-MM-dd") ?? null;

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_EMPLOYEE);

                var users = new List<EmployeeModelView>();

                while (reader.Read())
                {
                    try
                    {
                        EmployeeModelView empModelView = new EmployeeModelView();

                        empModelView.ID = Common.SafeGetInt(reader, "ID");
                        empModelView.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        empModelView.BOD = Common.SafeGetDateTimeWithNull(reader, "BOD");
                        empModelView.BODString = Common.SafeGetDateTime(reader, "BOD").ToString("dd/MM/yyyy") ?? "";
                        empModelView.Sex = Common.SafeGetBool(reader, "Sex");
                        empModelView.Address = Common.SafeGetString(reader, "Address");
                        empModelView.Phone = Common.SafeGetString(reader, "Phone");
                        empModelView.Email = Common.SafeGetString(reader, "Email");
                        empModelView.FullName = Common.SafeGetString(reader, "FullName");
                        empModelView.DepartmentCode = Common.SafeGetString(reader, "DepartmentCode");
                        empModelView.OfficeTile = Common.SafeGetString(reader, "OfficeTitle");
                        empModelView.OfficePosition = Common.SafeGetString(reader, "OfficePosition");
                        empModelView.TaxNumber = Common.SafeGetString(reader, "TaxNumber");
                        empModelView.EmpStatus = Common.SafeGetBool(reader, "EmpStatus");
                        empModelView.ActiveDate = Common.SafeGetDateTimeWithNull(reader, "ActiveDate");
                        empModelView.EduLevel = Common.SafeGetString(reader, "EduLevel");
                        empModelView.EduLevel = Common.SafeGetString(reader, "EduLevel"); 
                        empModelView.PassportNumber = Common.SafeGetString(reader, "PassportNumber");
                        empModelView.PassportDate = Common.SafeGetDateTimeWithNull(reader, "PassportDate");
                        empModelView.PassportPlace = Common.SafeGetString(reader, "PassportPlace");
                        empModelView.Height = Common.SafeGetInt(reader, "Height");
                        empModelView.Weight = Common.SafeGetInt(reader, "Weight");
                        empModelView.OrtheInfo = Common.SafeGetString(reader, "OrtheInfo");
                        empModelView.VacationNumber = Common.SafeGetInt(reader, "VacationNumber");
                        empModelView.DepartmentName = Common.SafeGetString(reader, "DepartmentName");
                        empModelView.CreateBy = Common.SafeGetString(reader, "CreateBy");
                        empModelView.CreateOn = Common.SafeGetDateTimeWithNull(reader, "CreateOn");
                        empModelView.ModifiedBy = Common.SafeGetString(reader, "ModifiedBy");
                        empModelView.ModifiedOn = Common.SafeGetDateTimeWithNull(reader, "ModifiedOn");                        

                        users.Add(empModelView);
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

            return new List<EmployeeModelView>();
        }

        public static CResult InsertEmployee(EmployeeViewModel employeeViewModel)
        {

            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);
            CResult objResult;

            try
            {
                if (objSQL._OpenConnection() == false)
                    return objResult = new CResult { ErrorCode = -1, ErrorMessage = "Open Connection False!", Data = null };

                // input param
                SqlParameter prmBOD = new SqlParameter("@BOD", SqlDbType.NVarChar, 50);
                prmBOD.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmBOD);

                SqlParameter prmSex = new SqlParameter("@Sex", SqlDbType.Bit);
                prmSex.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSex);

                SqlParameter prmAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 250);
                prmAddress.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmAddress);

                SqlParameter prmPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                prmPhone.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPhone);

                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);

                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 50);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                SqlParameter prmDepartmentCode = new SqlParameter("@DepartmentCode", SqlDbType.NVarChar, 50);
                prmDepartmentCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmDepartmentCode);

                SqlParameter prmOfficeTile = new SqlParameter("@OfficeTile", SqlDbType.NVarChar, 250);
                prmOfficeTile.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmOfficeTile);

                SqlParameter prmOfficePosition = new SqlParameter("@OfficePosition", SqlDbType.NVarChar, 250);
                prmOfficePosition.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmOfficePosition);

                SqlParameter prmTaxNumber = new SqlParameter("@TaxNumber", SqlDbType.NVarChar, 50);
                prmTaxNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmTaxNumber);

                SqlParameter prmEmpStatus = new SqlParameter("@EmpStatus", SqlDbType.Bit);
                prmEmpStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpStatus);

                SqlParameter prmActiveDate = new SqlParameter("@ActiveDate", SqlDbType.NVarChar, 50);
                prmActiveDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmActiveDate);

                SqlParameter prmEduLevel = new SqlParameter("@EduLevel", SqlDbType.NVarChar, 250);
                prmEduLevel.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEduLevel);

                SqlParameter prmPassportNumber = new SqlParameter("@PassportNumber", SqlDbType.NVarChar, 50);
                prmPassportNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassportNumber);

                SqlParameter prmPassportDate = new SqlParameter("@PassportDate", SqlDbType.NVarChar, 50);
                prmPassportDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassportDate);

                SqlParameter prmPassportPlace = new SqlParameter("@PassportPlace", SqlDbType.NVarChar, 50);
                prmPassportPlace.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassportPlace);

                SqlParameter prmHeight = new SqlParameter("@Height", SqlDbType.Int);
                prmHeight.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmHeight);

                SqlParameter prmWeight = new SqlParameter("@Weight", SqlDbType.Int);
                prmWeight.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmWeight);

                SqlParameter prmOrtheInfo = new SqlParameter("@OrtheInfo", SqlDbType.NVarChar, 50);
                prmOrtheInfo.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmOrtheInfo);

                SqlParameter prmVacationNumber = new SqlParameter("@VacationNumber", SqlDbType.Int);
                prmVacationNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmVacationNumber);

                SqlParameter prmCreateBy = new SqlParameter("@CreateBy", SqlDbType.NVarChar, 50);
                prmCreateBy.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmCreateBy);

                SqlParameter prmCreateOn = new SqlParameter("@CreateOn", SqlDbType.NVarChar, 50);
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
                prmBOD.Value = employeeViewModel.BOD?.ToString("yyyy-MM-dd");
                prmSex.Value = employeeViewModel.Sex;
                prmAddress.Value = employeeViewModel.Address;
                prmPhone.Value = employeeViewModel.Phone;
                prmEmail.Value = employeeViewModel.Email;
                prmFullName.Value = employeeViewModel.FullName;
                prmDepartmentCode.Value = employeeViewModel.DepartmentCode;
                prmOfficeTile.Value = employeeViewModel.OfficeTile;
                prmOfficePosition.Value = employeeViewModel.OfficePosition;
                prmTaxNumber.Value = employeeViewModel.TaxNumber;
                prmEmpStatus.Value = employeeViewModel.EmpStatus;
                prmActiveDate.Value = employeeViewModel.ActiveDate?.ToString("yyyy-MM-dd");
                prmEduLevel.Value = employeeViewModel.EduLevel;
                prmPassportNumber.Value = employeeViewModel.PassportNumber;
                prmPassportDate.Value = employeeViewModel.PassportDate?.ToString("yyyy-MM-dd");
                prmPassportPlace.Value = employeeViewModel.PassportPlace;
                prmHeight.Value = employeeViewModel.Height;
                prmWeight.Value = employeeViewModel.Weight;
                prmOrtheInfo.Value = employeeViewModel.OrtheInfo;
                prmVacationNumber.Value = employeeViewModel.VacationNumber;
                prmCreateBy.Value = employeeViewModel.CreateBy;
                prmCreateOn.Value = employeeViewModel.CreateOn?.ToString("yyyy-MM-dd");

                objSQL.ExecuteSP(CommonConstants.SP_INSERT_EMPLOYEE);

                var errCode = int.Parse(ErrCode.Value.ToString());
                return objResult = new CResult { ErrorCode = errCode, ErrorMessage = Message.Value.ToString(), Data = null };
            }
            catch (Exception ex)
            {
                objResult = new CResult { ErrorCode = -1, ErrorMessage = ex.Message, Data = null };
            }

            return objResult;
        }

        public static CResult UpdateEmployee(EmployeeViewModel employeeViewModel)
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

                SqlParameter prmBOD = new SqlParameter("@BOD", SqlDbType.NVarChar, 50);
                prmBOD.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmBOD);

                SqlParameter prmSex = new SqlParameter("@Sex", SqlDbType.Bit);
                prmSex.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmSex);

                SqlParameter prmAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 250);
                prmAddress.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmAddress);

                SqlParameter prmPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                prmPhone.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPhone);

                SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                prmEmail.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmail);

                SqlParameter prmFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 50);
                prmFullName.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmFullName);

                SqlParameter prmDepartmentCode = new SqlParameter("@DepartmentCode", SqlDbType.NVarChar, 50);
                prmDepartmentCode.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmDepartmentCode);

                SqlParameter prmOfficeTile = new SqlParameter("@OfficeTile", SqlDbType.NVarChar, 250);
                prmOfficeTile.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmOfficeTile);

                SqlParameter prmOfficePosition = new SqlParameter("@OfficePosition", SqlDbType.NVarChar, 250);
                prmOfficePosition.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmOfficePosition);

                SqlParameter prmTaxNumber = new SqlParameter("@TaxNumber", SqlDbType.NVarChar, 50);
                prmTaxNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmTaxNumber);

                SqlParameter prmEmpStatus = new SqlParameter("@EmpStatus", SqlDbType.Bit);
                prmEmpStatus.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEmpStatus);

                SqlParameter prmActiveDate = new SqlParameter("@ActiveDate", SqlDbType.NVarChar, 50);
                prmActiveDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmActiveDate);

                SqlParameter prmEduLevel = new SqlParameter("@EduLevel", SqlDbType.NVarChar, 250);
                prmEduLevel.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmEduLevel);

                SqlParameter prmPassportNumber = new SqlParameter("@PassportNumber", SqlDbType.NVarChar, 50);
                prmPassportNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassportNumber);

                SqlParameter prmPassportDate = new SqlParameter("@PassportDate", SqlDbType.NVarChar, 50);
                prmPassportDate.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassportDate);

                SqlParameter prmPassportPlace = new SqlParameter("@PassportPlace", SqlDbType.NVarChar, 50);
                prmPassportPlace.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmPassportPlace);

                SqlParameter prmHeight = new SqlParameter("@Height", SqlDbType.Int);
                prmHeight.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmHeight);

                SqlParameter prmWeight = new SqlParameter("@Weight", SqlDbType.Int);
                prmWeight.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmWeight);

                SqlParameter prmOrtheInfo = new SqlParameter("@OrtheInfo", SqlDbType.NVarChar, 50);
                prmOrtheInfo.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmOrtheInfo);

                SqlParameter prmVacationNumber = new SqlParameter("@VacationNumber", SqlDbType.Int);
                prmVacationNumber.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmVacationNumber);

                SqlParameter prmModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50);
                prmModifiedBy.Direction = ParameterDirection.Input;
                objSQL.Command.Parameters.Add(prmModifiedBy);

                SqlParameter prmModifiedOn = new SqlParameter("@ModifiedOn", SqlDbType.NVarChar, 50);
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
                prmEmpCode.Value = employeeViewModel.EmpCode;
                prmBOD.Value = employeeViewModel.BOD?.ToString("yyyy-MM-dd");
                prmSex.Value = employeeViewModel.Sex;
                prmAddress.Value = employeeViewModel.Address;
                prmPhone.Value = employeeViewModel.Phone;
                prmEmail.Value = employeeViewModel.Email;
                prmFullName.Value = employeeViewModel.FullName;
                prmDepartmentCode.Value = employeeViewModel.DepartmentCode;
                prmOfficeTile.Value = employeeViewModel.OfficeTile;
                prmOfficePosition.Value = employeeViewModel.OfficePosition;
                prmTaxNumber.Value = employeeViewModel.TaxNumber;
                prmEmpStatus.Value = employeeViewModel.EmpStatus;
                prmActiveDate.Value = employeeViewModel.ActiveDate?.ToString("yyyy-MM-dd");
                prmEduLevel.Value = employeeViewModel.EduLevel;
                prmPassportNumber.Value = employeeViewModel.PassportNumber;
                prmPassportDate.Value = employeeViewModel.PassportDate?.ToString("yyyy-MM-dd");
                prmPassportPlace.Value = employeeViewModel.PassportPlace;
                prmHeight.Value = employeeViewModel.Height;
                prmWeight.Value = employeeViewModel.Weight;
                prmOrtheInfo.Value = employeeViewModel.OrtheInfo;
                prmVacationNumber.Value = employeeViewModel.VacationNumber;
                prmModifiedBy.Value = employeeViewModel.ModifiedBy;
                prmModifiedOn.Value = employeeViewModel.ModifiedOn?.ToString("yyyy-MM-dd");

                objSQL.ExecuteSP(CommonConstants.SP_UPDATE_EMPLOYEE);

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
