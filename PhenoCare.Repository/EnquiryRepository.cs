using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Insight.Database;
using PhenoCare.Domain.Enquiry;
using PhenoCare.Domain.Repositories;
using System;
using System.Collections.Generic;
using PhenoCare.Repository.DTOs;

namespace PhenoCare.Repository
{
    public class EnquiryRepository:IEnquiryRepository
    {
        private readonly IStudentRepository mStudentRepository;

        public EnquiryRepository(IStudentRepository studentRepository)
        {
            mStudentRepository = studentRepository;
        }

        public bool Create(Enquiry enquiry)
        {
            var studentId = mStudentRepository.SaveStudent(enquiry.Student);

            var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

            var enquiryDto = connection.Query<EnquiryDto>("sp_SaveEnquiry", new EnquiryDto
            {
                id = enquiry.Id,
                student_id = studentId,
                status = enquiry.Status,
                notes = enquiry.Notes
            }).FirstOrDefault();

            if (enquiryDto == null)
                return false;

            return true;
        }

        public IEnumerable<Enquiry> GetAllEnquiries()
        {
             var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

            var studentEnquiries = connection.Query<StudentEnquiryDto>("sp_GetEnquiries");

            return studentEnquiries.Select(studentEnquiryDto => new Enquiry
            {
                Id = studentEnquiryDto.enquiry_id, 
                Status = studentEnquiryDto.status, 
                Notes = studentEnquiryDto.notes, 
                DateTime = Convert.ToDateTime(studentEnquiryDto.enquiry_date), 
                Student = new Student
                {
                    Id = studentEnquiryDto.Student_Id, 
                    Name = studentEnquiryDto.Name, 
                    Phone = studentEnquiryDto.Phone, 
                    Email = studentEnquiryDto.Email, 
                    Institute = studentEnquiryDto.Institute, 
                    IntrestedIn = studentEnquiryDto.IntrestedIn
                }
            }).ToList();
        }
    }
}
