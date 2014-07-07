
namespace PhenoCare.Repository.DTOs
{
    public class StudentEnquiryDto
    {
        public int enquiry_id { get; set; }
        public string status { get; set; }
        public string notes { get; set; }
        public string enquiry_date { get; set; }

        public int Student_Id { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IntrestedIn { get; set; }
    }
}
