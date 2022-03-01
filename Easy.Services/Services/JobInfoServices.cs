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
        public async Task<JobReturn> jobinfo(string Comid, string EmpId)
        {
            var job = new JobReturn();
            if (Comid == "")
            {
                job.jobinfo = null;
                job.Status_Code = 201;
                job.Message = "comId is null";
            }
            else if (EmpId == "")
            {
                job.jobinfo = null;
                job.Status_Code = 201;
                job.Message = "EmpId is null";
            }
            else
            {
                string sql = "sp_jobinfo @comId='" + Comid + "'";
                sql += ",@empId = '" + EmpId + "'";
                var data = await DBHelper.RunQuery<Jobinfo>(sql);
                job.jobinfo = data.ToList();
                job.Status_Code = 200;
                job.Message = "Success";
            }
            return job;
                
        }
    }
}
