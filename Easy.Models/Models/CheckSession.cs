using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class CheckSession
    {
        public string ComID { get; set; }
        public int UID { get; set; }
        public string NotificationToken { get; set; }
        public string DeviceID { get; set; }
    }
}
