using System.Collections.Generic;

namespace PhenoCare.Domain.Repositories
{
    public interface IEnquiryRepository
    {
        bool Create(Enquiry.Enquiry enquiry);
        IEnumerable<Enquiry.Enquiry> GetAllEnquiries();
    }
}
