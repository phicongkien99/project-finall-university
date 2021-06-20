using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Commons
{
    public static class CommonConstants
    {
        // link server api
        public const string API_LINK = "http://localhost:52765/";

        // connection string
        public const string CONNECTION_STRING = "Server=DESKTOP-D003HGN\\SQLEXPRESS;Database=HRM;User Id=admin;Password=admin;";

        // store procedure
        // login
        public const string SP_LOGIN = "SP_LOGIN";
        // change password
        public const string SP_CHANGE_PASSWORD = "SP_CHANGE_PASSWORD";
        // user
        public const string SP_GET_USER = "SP_GET_USER";
        public const string SP_GET_USER_EMPLOYEE = "SP_GET_USER_EMPLOYEE";
        public const string SP_INSERT_USER = "SP_INSERT_USER";
        public const string SP_UPDATE_USER = "SP_UPDATE_USER";
        // group
        public const string SP_GET_GROUP = "SP_GET_GROUP";        
        public const string SP_UPDATE_GROUP = "SP_UPDATE_GROUP";
        public const string SP_DELETE_GROUP = "SP_DELETE_GROUP";
        public const string SP_INSERT_GROUP  = "SP_INSERT_GROUP";
        // user group
        public const string SP_GET_USER_GROUP = "SP_GET_USER_GROUP";
        public const string SP_INSERT_USER_GROUP = "SP_INSERT_USER_GROUP";
        public const string SP_DELETE_USER_GROUP = "SP_DELETE_USER_GROUP";
        // employee
        public const string SP_GET_EMPLOYEE = "SP_GET_EMPLOYEE";
        public const string SP_INSERT_EMPLOYEE = "SP_INSERT_EMPLOYEE";
        public const string SP_UPDATE_EMPLOYEE = "SP_UPDATE_EMPLOYEE";
        // contract
        public const string SP_INSERT_CONTRACT = "SP_INSERT_CONTRACT";
        public const string SP_GET_CONTRACT = "SP_GET_CONTRACT";
        public const string SP_UPDATE_CONTRACT = "SP_UPDATE_CONTRACT";
        // salary 
        public const string SP_GET_SALARY = "SP_GET_SALARY";
        public const string SP_INSERT_SALARY = "SP_INSERT_SALARY";       
        public const string SP_DELETE_SALARY = "SP_DELETE_SALARY";
        // insurance
        public const string SP_GET_INSURANCE = "SP_GET_INSURANCE";
        public const string SP_INSERT_INSURANCE = "SP_INSERT_INSURANCE";
        public const string SP_DELETE_INSURANCE = "SP_DELETE_INSURANCE";
        // bonus
        public const string SP_GET_BONUS = "SP_GET_BONUS";
        public const string SP_INSERT_BONUS = "SP_INSERT_BONUS";
        public const string SP_DELETE_BONUS = "SP_DELETE_BONUS";
        // statistic emp
        public const string SP_GET_STATISTIC_EMP = "SP_GET_STATISTIC_EMP";
        // statistic salary
        public const string SP_GET_STATISTIC_SALARY = "SP_GET_STATISTIC_SALARY";


        // route api
        // login
        public const string API_LOGIN = "api/login";
        // user
        public const string API_GET_USER = "api/get-user";
        // group
        public const string API_GET_GROUP = "api/get-group";
        public const string API_INSERT_GROUP = "api/insert-group";
        public const string API_UPDATE_GROUP = "api/update-group";
        public const string API_DELETE_GROUP = "api/delete-group";
        // user group
        
    }
}
