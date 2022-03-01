using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Connection.Dapper
{
    public static class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            var sqlconnection =new SqlConnection(DBCon.ConnectionString);
            sqlconnection.Open();
            return sqlconnection;
        }
        public async static Task<IEnumerable<T>> RunProc<T>(string sql,object param=null)
        {
            using (var conn = GetConnection())
            {
                var data= await conn.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
                return data;

            }
        }
        public async static Task<IEnumerable<T>> RunQuery<T>(string sql,object param=null)
        {
            using (var conn = GetConnection())
            {
                var data = await conn.QueryAsync<T>(sql, param);
                return data;
            }
        }
        public async static Task<dynamic> RunQueryWithoutModel(string sql,object param=null)
        {
            using (var conn = GetConnection())
            {
                var data = await conn.QueryAsync(sql, param);
                return data;
            }
        }
    }
}
