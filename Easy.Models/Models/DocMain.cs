using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    //public class DocMain
    //{
    //    public string FileName { get; set; }
    //    public string FileType { get; set; }
    //    public string FilePath { get; set; }
    //}
    public class DocInfo:CommonResponse
    {
        public List<dynamic> Docs { get; set; }
    }

    public class DocumentRes : CommonResponse
    {
        public List<dynamic> Doclst { get; set; }
    }

    public class DocumentReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public string Flag { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileMedium { get; set; }
        public string FilePath { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int DocID { get; set; }
    }
}
