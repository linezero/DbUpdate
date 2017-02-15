using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DbUpdate.Common
{
    public class DapperHelper
    {
        private SqlConnection _connection;
        public DapperHelper(string connection)
        {
            _connection = new SqlConnection(connection);
        }

        public int ExecuteSQL(string sql)
        {
            return _connection.Execute(sql);
        }

        public IEnumerable<string> Query(string sql)
        {
            return _connection.Query<string>(sql);
        }
    }
}
