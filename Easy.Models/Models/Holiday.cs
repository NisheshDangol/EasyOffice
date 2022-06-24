using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Holiday:CommonResponse
    {
        public List<dynamic> Holidays { get; set; }
    }
}
