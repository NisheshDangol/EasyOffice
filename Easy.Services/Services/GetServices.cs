using Easy.Connection.Dapper;
using Easy.Models.Models;
using Easy.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Services
{
    public class GetServices : IGetInterface
    {
        public async Task<DocInfo> listdoc(string ComId, int EmpId)
        {
            string sql = "sp_doc @ComId '" + ComId + "'";
            sql += ",@EmpId '" + EmpId + "'";
            var data= await DBHelper.RunProc<DocMain>(sql);
            if(data.Count()==0)
            {
                return new DocInfo
                {
                    docs = data.ToList(),
                    Message = "Success.",
                    StatusCode = 200
                };
            }
            else
            {
                return new DocInfo
                {
                    docs = null,
                    Message = "No data Found.",
                    StatusCode = 400
                };

            }

        }
    }
}
