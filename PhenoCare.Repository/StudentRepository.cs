using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Insight.Database;
using PhenoCare.Domain.Repositories;
using PhenoCare.Repository.DTOs;

namespace PhenoCare.Repository
{
    public class StudentRepository:IStudentRepository
    {
        public int SaveStudent(Domain.Enquiry.Student student)
        {
            var connection =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

            var studentDto = connection.Query<StudentDto>("sp_SaveStudent", new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Phone = student.Phone,
                Email = student.Email,
                Address = student.Address,
                Institute = student.Institute,
                IntrestedIn=student.IntrestedIn
            }).FirstOrDefault();

            if (studentDto == null)
                return 0;

            return studentDto.Id;
        }
    }
}
