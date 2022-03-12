using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class LeadSource
    {
        public int SourceId { get;set; }
        public string SourceName { get;set; }
        public int OrganzationCount { get;set; }
        public int LeadCount { get;set; }
    }
    public class LeadSourceDto:CommonResponse
    {
        public List<LeadSource> LeadSources { get;set; }
    }
}
