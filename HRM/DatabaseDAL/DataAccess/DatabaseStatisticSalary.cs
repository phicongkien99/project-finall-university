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
    public class DatabaseStatisticSalary
    {
        public static List<StatisticMoney> SearchStatisticEmployee()
        {
            CSQL objSQL = new CSQL(CommonConstants.CONNECTION_STRING);

            try
            {
                if (objSQL._OpenConnection() == false)
                    throw new Exception("Không thể kết nối");

                SqlDataReader reader = objSQL.GetDataReaderFromSP(CommonConstants.SP_GET_STATISTIC_SALARY);

                var statisticMoneys = new List<StatisticMoney>();

                while (reader.Read())
                {
                    try
                    {
                        StatisticMoney statisticMoney = new StatisticMoney();

                        statisticMoney.EmpCode = Common.SafeGetString(reader, "EmpCode");
                        statisticMoney.FullName = Common.SafeGetString(reader, "FullName");
                        statisticMoney.Email = Common.SafeGetString(reader, "Email");
                        statisticMoney.Phone = Common.SafeGetString(reader, "Phone");
                        statisticMoney.DepartmentName = Common.SafeGetString(reader, "DepartmentName");
                        statisticMoney.TotalMoney = Common.SafeGetDecimal(reader, "TotalMoney");
                        statisticMoney.TotalMoneyMonth = Common.SafeGetDecimal(reader, "TotalMoneyMonth");
                        statisticMoney.TotalMoneyYear = Common.SafeGetDecimal(reader, "TotalMoneyYear");

                        statisticMoneys.Add(statisticMoney);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                return statisticMoneys;
            }
            catch (Exception ex)
            {
                // Ghi thông tin ra file
            }
            finally
            {
                objSQL._CloseConnection();
            }

            return new List<StatisticMoney>();
        }
    }
}
