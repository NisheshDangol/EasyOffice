using Dapper;
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
        public async Task<JobReturn> Jobinfo(string ComId, int EmpId)
        {
            var job = new JobReturn();
            if (ComId == "")
            {
                job.Jobinfo = null;
                job.StatusCode = 400;
                job.Message = "ComId is null";
            }
            else if (EmpId == 0)
            {
                job.Jobinfo = null;
                job.StatusCode = 400;
                job.Message = "EmpId is null";
            }
            else
            {
                string sql = "sp_userinfo";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ComId", ComId);
                parameters.Add("@EmpId", EmpId);
                parameters.Add("@flag", "jobinfo");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() !=0 && data.FirstOrDefault().StatusCode ==null )
                {
                    job.Jobinfo = data.ToList();
                    job.StatusCode = 200;
                    job.Message = "success";
                }
                else
                {
                    job.Jobinfo = null;
                    job.StatusCode = data.FirstOrDefault().StatusCode;
                    job.Message = data.FirstOrDefault().Message;
                }
                
            }
            return job;
                
        }
    }
}
