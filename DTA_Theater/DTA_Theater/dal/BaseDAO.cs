using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DTA_Theater.dal
{
    public class BaseDAO
    {
        public static String cnnString;
        private static BaseDAO instance;

        public static string CnnString { get => cnnString; set => cnnString = value; }

        public static BaseDAO getInstance()
        {
            if (instance == null)
            {
                instance = new BaseDAO();
            }

            return instance;
        }

        BaseDAO()
        {
            CnnString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
        }
    }
}
