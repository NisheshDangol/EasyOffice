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
    public class JobInfoServices : IJobInfoInterface
    {
        public async Task<JobReturn> Jobinfo(string ComId, string EmpId)
        {
            var job = new JobReturn();
            if (ComId == "")
            {
                job.Jobinfo = null;
                job.StatusCode = 201;
                job.Message = "comId is null";
            }
            else if (EmpId == "")
            {
                job.Jobinfo = null;
                job.StatusCode = 201;
                job.Message = "EmpId is null";
            }
            else
            {
                string sql = "sp_jobinfo @comId='" + ComId + "'";
                sql += ",@empId = '" + EmpId + "'";
                var data = await DBHelper.RunQuery<Jobinfo>(sql);
                if(data.Count() !=0)
                {
                    job.Jobinfo = null;
                    job.StatusCode = 201;
                    job.Message = "data not found.";
                }
                else
                {
                    job.Jobinfo = data.ToList();
                    job.StatusCode = 200;
                    job.Message = "Success";
                }
                
            }
            return job;
                
        }
    }
}
