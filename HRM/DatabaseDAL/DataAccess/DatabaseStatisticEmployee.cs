using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDAL.DataAccess
{
    public class DatabaseStatisticEmployee
    {
        public static StatisticEmployee SearchStatisticEmployee()
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");
                
                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_STATISTIC_EMP);

                StatisticEmployee statisticEmployee = new StatisticEmployee();

                while (reader.Read())
                {
                    try
                    {
                        statisticEmployee.TotalEmp = Common.SafeGetInt(reader, "TotalEmp");
                        statisticEmployee.TotalFemale = Common.SafeGetInt(reader, "TotalMale");
                        statisticEmployee.TotalMale = Common.SafeGetInt(reader, "TotalFemale");
                        statisticEmployee.AverageAge = Common.SafeGetInt(reader, "AverageAge");
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return statisticEmployee;
            }
            catch (Exception ex)
            {
                // Ghi thông tin ra file
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new StatisticEmployee();
        }
    }
}
