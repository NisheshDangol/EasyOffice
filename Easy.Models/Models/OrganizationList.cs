﻿using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class OrganizationList
    {
        public string OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgType { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string ContectPerson { get; set; }
        public string LeadCount { get; set; }
        public string FollowCount { get; set; }
        public string SupportCount { get; set; }
    }
    public class OrganizationDto:CommonResponse
    {
        public List<OrganizationList> OrgList { get; set; }
    }
    public class AllOrganizationList
    {
        public string OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgType { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Source { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string AssignedTo { get; set; }
        public string LeadCount { get; set; }
        public string FollowCount { get; set; }
        public string SupportCount { get; set; }
    }
    public class AllOrganizationDto : CommonResponse
    {
        public List<AllOrganizationList> OrgList { get; set; }
    }
    public class OrganizationType
    {
        public string OrgTypeID { get; set;}
        public string OrgTypeName { get; set;}
    }
    public class OrganizationTypeDto:CommonResponse
    {
        public List<OrganizationType> organizationTypes { get; set; }
    }
}