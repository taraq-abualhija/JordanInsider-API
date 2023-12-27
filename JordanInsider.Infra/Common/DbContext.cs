using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JordanInsider.Core.Common;

namespace JordanInsider.Infra.Common
{
    public class DbContext : IDbContext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // 1- open 
        // 2- close -- open 
        // 3- no connection --> creat connection --> open 
        public DbConnection Connection
        {
            get
            {

                if (_connection == null)
                {
                    //create 
                    _connection = new OracleConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                    //open 
                    _connection.Open();
                }


                // close -->open 
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                // open --> return connection 
                return _connection;

            }
        }




    }
}
