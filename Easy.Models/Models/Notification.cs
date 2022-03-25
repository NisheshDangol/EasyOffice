using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Notification
    {
        public string ComId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime PublishedDate { get; set; }
        public int UserId { get; set; }
        public string AcBtn { get; set; }
        public string RedUrl { get; set; }
        public int FiscalId { get; set; }
        public int Createdby { get; set; }
    }
    public class NotificationList
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PublishedDate { get; set; }
        public string CreatedBy { get; set; }
        public string AcBtn { get; set; }
        public string RedUrl { get; set; }
    }
    public class NotificationListDto:CommonResponse
    {
        public List<NotificationList> NotificationList { get; set; }
    }
}
