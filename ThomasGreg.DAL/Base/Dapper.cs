using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ThomasGreg.DAL.Base
{
    public class Dapper
    {
        public IDbConnection Connection => new SqlConnection(ConfigurationManager
                                .ConnectionStrings["stringConnection"].ConnectionString);


        private string _configuration;

        private string ConnectionString(string configuration)
        {
            _configuration = configuration;

            return _configuration;
        }

    }


}

