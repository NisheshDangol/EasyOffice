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
        public string designationname { get; set; }
        public string departmentname { get; set; }
        public string subdepartmentname { get; set; }
        public string grade { get; set; }
        public string manager { get; set; }
        public string workingstatus { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }
    public class JobReturn : CommonResponse
    {
        public List<Jobinfo> jobinfo { get; set; }
    }
}
