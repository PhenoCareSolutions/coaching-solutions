using System.Collections.Generic;
using System.Linq;
using PhenoCare.Domain.Repositories;

namespace PhenoCare.Domain.Services
{
    public class EnquiryService:IEnquiryService
    {
        private IEnquiryRepository mEnquiryRepository;

        public EnquiryService(IEnquiryRepository enquiryRepository)
        {
            mEnquiryRepository = enquiryRepository;
        }

        public bool Create(Enquiry.Enquiry enquiry)
        {
            return mEnquiryRepository.Create(enquiry);
        }

        public IEnumerable<Enquiry.Enquiry> GetAllEnquiries()
        {
            return mEnquiryRepository.GetAllEnquiries();
        }

        public IEnumerable<string> GetAllStatus()
        {
            return new List<string>
            {
                "New",
                "FollowUp",
                "Not Intrested",
                "Intrested"
            };
        }


        public Enquiry.Enquiry GetEnquiry(int id)
        {
            var enquiries = GetAllEnquiries();

            return enquiries.SingleOrDefault(e => e.Id == id);
        }
    }
}
