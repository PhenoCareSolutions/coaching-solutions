using PhenoCare.Controllers;

namespace PhenoCare.Repository
{
    public interface IEnrollmentRepository
    {
        void SaveEnrollmentEnquiry(EnrollmentViewModel enrollmentEnquiry);
    }
}
