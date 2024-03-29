﻿using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    //public class OrganizationList
    //{
    //    public int OrgId { get; set; }
    //    public string OrgName { get; set; }
    //    public string OrgType { get; set; }
    //    public string Address { get; set; }
    //    public string District { get; set; }
    //    public string Phone { get; set; }
    //    public string AssignedTo { get; set; }
    //    public string StaffName { get; set; }
    //    public string ContectPerson { get; set; }
    //    public string LeadCount { get; set; }
    //    public string FollowCount { get; set; }
    //    public string SupportCount { get; set; }
    //}
    public class OrganizationDto : CommonResponse
    {
        public List<dynamic> OrgList { get; set; }
    }
    //public class AllOrganizationList
    //{
    //    public string OrgId { get; set; }
    //    public string OrgName { get; set; }
    //    public string OrgTypeID { get; set; }
    //    public string Address { get; set; }
    //    public string District { get; set; }
    //    public string Source { get; set; }
    //    public string Email { get; set; }
    //    public string Phone { get; set; }
    //    public string Website { get; set; }
    //    public string AssignedTo { get; set; }
    //    public string LeadCount { get; set; }
    //    public string FollowCount { get; set; }
    //    public string SupportCount { get; set; }
    //}
    public class AllOrganizationDto : CommonResponse
    {
        public List<dynamic> OrgList { get; set; }
    }

    //public class OrganizationType
    //{
    //    public int OrgTypeID { get; set;}
    //    public string OrgTypeName { get; set;}
    //    public string OrgCount { get; set;}
    //}
    public class OrganizationTypeDto : CommonResponse
    {
        public List<dynamic> OrganizationTypes { get; set; }
    }


    //public class OrganizationProduct
    //{
    //    public int ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public string LeadCount { get; set; }
    //    public string FollowCount { get; set; }
    //    public string SupportCount { get; set; }
    //}
    public class OrganizationProductDto : CommonResponse
    {
        public List<dynamic> OrganizationProducts { get; set; }
    }
    public class OrganizationStaff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string DesignationName { get; set; }
    }
    public class OrgnizationStaffDto : CommonResponse
    {
        public List<OrganizationStaff> OrganizationStaffs { get; set; }
    }


    public class OrgType
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public string Name { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int OrgTypeID { get; set; }
        public int Status { get; set; }
    }

    public class OrgTypeRes : CommonResponse
    {
        public List<dynamic> OrgTypeLst { get; set; }
    }

}
