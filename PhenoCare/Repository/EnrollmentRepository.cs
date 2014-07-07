using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using Insight.Database;

namespace PhenoCare.Repository
{
    public class EnrollmentRepository:IEnrollmentRepository
    {
        public void SaveEnrollmentEnquiry(Controllers.EnrollmentViewModel enrollmentEnquiry)
        {
            var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

            connection.Execute("sp_SaveEnrollmentEnquiry"
                , new
                {
                    name = enrollmentEnquiry.Name,
                    email = enrollmentEnquiry.Email,
                    phone = enrollmentEnquiry.Phone,
                    course = enrollmentEnquiry.Course,
                    institute = enrollmentEnquiry.Institute,
                    comment = enrollmentEnquiry.Comment
                });
        }

        public void SendEmail(Controllers.EnrollmentViewModel enrollmentEnquiry)
        {
            var message = new MailMessage();
            message.From = new MailAddress("chinchwad@phenocare.com");
            message.To.Add(new MailAddress("chinchwad@phenocare.com"));
            message.Subject = "test";
            message.Body = "This is test";

            using (var smtp = new SmtpClient("smtpout.asia.secureserver.net"))
            {
                smtp.Credentials = new System.Net.NetworkCredential("vishal18_gupta", "VGmar2014");
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.Send(message);
            }
        }
    }
}