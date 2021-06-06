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

        // route api
        public const string API_LOGIN = "api/login";
        public const string API_GET_USER = "api/get-user";
    }
}
