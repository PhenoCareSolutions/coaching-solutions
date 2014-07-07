using System.Collections.Generic;

namespace PhenoCare.Domain.Services
{
    public interface IEnquiryService
    {
        bool Create(Enquiry.Enquiry enquiry);
        Domain.Enquiry.Enquiry GetEnquiry(int id);
        IEnumerable<Enquiry.Enquiry> GetAllEnquiries();
        IEnumerable<string> GetAllStatus();
    }
}
