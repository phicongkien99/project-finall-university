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
        // user
        public const string SP_GET_USER = "SP_GET_USER";
        // group
        public const string SP_GET_GROUP = "SP_GET_GROUP";        
        public const string SP_UPDATE_GROUP = "SP_UPDATE_GROUP";
        public const string SP_DELETE_GROUP = "SP_DELETE_GROUP";
        public const string SP_INSERT_GROUP  = "SP_INSERT_GROUP";
        // user group
        public const string SP_GET_USER_GROUP = "SP_GET_USER_GROUP";

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
