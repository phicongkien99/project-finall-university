using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CoreLib.Utils
{
    public static class Common
    {
        private static byte[] encryptData(string data)
        {
            try
            {
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] hashedBytes;
                UTF8Encoding encoder = new UTF8Encoding();
                hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
                return hashedBytes;
            }
            catch (Exception)
            {                
                return null;
            }
        }

        public static string HashMD5(this string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        public static string formatComNumber(string str)
        {
            if (string.IsNullOrEmpty(str)) return "0";
            int lenght = str.Length;
            if (lenght < 4) return str;
            string strReturn = "###";
            for (int i = 0; i < lenght / 3; i++)
            {
                strReturn += ",###";
            }
            string frm = string.Format("{0:" + strReturn + "}", double.Parse(str));
            return frm.Replace(",", ".");

        }
        
        // SafeGet dùng ColummIndex
        public static long SafeGetInt64(SqlDataReader reader, int colName)
        {
            if (!reader.IsDBNull(colName))
                return (long)reader.GetInt64(colName);
            return 0;
        }

        public static int SafeGetInt(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return (int)Convert.ToInt32(reader.GetInt32(colIndex));
            return 0;
        }

        public static float SafeGetFloat(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return (float)reader.GetDouble(colIndex);
            return 0;
        }

        public static decimal SafeGetDecimal(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDecimal(colIndex);
            return 0;
        }

        public static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public static bool SafeGetBool(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetBoolean(colIndex);
            return false;
        }

        public static DateTime SafeGetDateTime(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return DateTime.MinValue;
        }

        // SafeGet dùng ColummName
        public static int SafeGetInt(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetInt32(reader.GetOrdinal(colName));
            return 0;
        }

        public static long SafeGetInt64(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetInt64(reader.GetOrdinal(colName));
            return 0;
        }

        public static long SafeGetLong(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetInt64(reader.GetOrdinal(colName));
            return 0;
        }

        public static float SafeGetFloat(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return (float)reader.GetDouble(reader.GetOrdinal(colName));
            return 0;
        }

        public static double SafeGetDouble(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return (double)reader.GetDouble(reader.GetOrdinal(colName));
            return 0;
        }

        public static decimal SafeGetDecimal(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDecimal(reader.GetOrdinal(colName));
            return 0;
        }

        public static string SafeGetString(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetString(reader.GetOrdinal(colName));
            return string.Empty;
        }

        public static bool SafeGetBool(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetBoolean(reader.GetOrdinal(colName));
            return false;
        }

        public static DateTime SafeGetDateTime(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDateTime(reader.GetOrdinal(colName));
            return DateTime.MinValue;
        }

        public static DateTime? SafeGetDateTimeWithNull(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDateTime(reader.GetOrdinal(colName));
            return null;
        }

        public static string ConvertDateToString(DateTime date, string format)
        {
            return date.ToString(format);
        }

        public static string ConvertDateToString(DateTime? date, string format)
        {
            return date?.ToString(format);
        }        
    }
}
