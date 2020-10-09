using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
    }
}

