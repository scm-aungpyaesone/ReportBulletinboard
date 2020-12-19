﻿using System.Configuration;
using System.Data.OracleClient;

namespace ReportBulletinboard
{
    public class DBTranManager
    {
        public static OracleConnection GetDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
            return new OracleConnection(connectionString);
        }
    }
}