using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Jobinfo
    {
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string Grade { get; set; }
        public string Manager { get; set; }
        public string WorkingStatus { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class JobReturn : CommonResponse
    {
        public List<Jobinfo> Jobinfo { get; set; }
    }
}
