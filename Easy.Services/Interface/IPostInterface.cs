using Easy.Connection;
using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface IPostInterface
    {
        Task<CommonResponse> CreateCompany(OrgnizationGet orgnization);
        Task<CommonResponse> CreateLeads(Lead lead);
        Task<CommonResponse> CreateFollowUp(Followup followup);
        Task<CommonResponse> CreateContact(ContactCreate contact);
        Task<CommonResponse> CustomerSupport(CustomerSupport customerSupport);
        Task<CommonResponse> ContactUpdate(UpdateContact contact);
        Task<CommonResponse> CreateNotification(Notification notifi);
        Task<CommonResponse> CreateLeave(Leave leave);
        Task<CommonResponse> UpdateLeaveStatus(string ComID, int UserID, int LeaveID, int Status);
    }
}
