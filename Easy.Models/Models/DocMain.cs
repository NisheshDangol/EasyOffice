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
}
