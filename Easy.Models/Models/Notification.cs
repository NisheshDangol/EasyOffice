﻿using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Notification
    {
        public string ComID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PublishedDate { get; set; }
        public int UserID { get; set; }
        public string AcBtn { get; set; }
        public string RedUrl { get; set; }
        public int FiscalID { get; set; }
        public int CreatedBy { get; set; }
    }
    //public class NotificationList
    //{
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public string Image { get; set; }
    //    public string PublishedDate { get; set; }
    //    public string CreatedBy { get; set; }
    //    public string AcBtn { get; set; }
    //    public string RedUrl { get; set; }
    //}
    public class NotificationListDto:CommonResponse
    {
        public List<dynamic> NotificationList { get; set; }
    }

    public class PushNotification
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PushNotificationByTopic : PushNotification
    {
        public string Topic { get; set; }
    }

    public class PushNotificationByDeviceId : PushNotification
    {
        public string DeviceID { get; set; }
    }

    public class NotificationAdminReq
    {
        public string ComID { get; set; }
        public string Flag { get; set; }
        public int StaffID { get; set; }
        public string NFlag { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string AcBtn { get; set; }
        public string AcUrl { get; set; }
        public string PublishedDate { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        public int SubDepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int NotificationID { get; set; }        
    }
}
