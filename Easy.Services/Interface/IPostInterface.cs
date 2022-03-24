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
        Task<CommonResponse> CreateContact(Contact contact);
        Task<CommonResponse> CustomerSupport(CustomerSupport customerSupport);
        Task<CommonResponse> ContactUpdate(UpdateContect contact);
        Task<CommonResponse> CreateNotification(Notification notifi);
    }
}
