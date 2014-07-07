using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhenoCare.Domain.Enquiry;
using PhenoCare.Domain.Repositories;
using PhenoCare.Domain.Services;
using PhenoCare.Repository;
using PhenoCare.Repository.DTOs;
using Rhino.Mocks;

namespace PhenoCare.Tests.Enquiry
{
    [TestClass]
    public class UT_EnquiryService
    {
        private IEnquiryService mEnquiryService;
        private IEnquiryRepository mockEnquiryRepository;

        [TestInitialize]
        public void Initialize()
        {
            mockEnquiryRepository = MockRepository.GenerateMock<IEnquiryRepository>();
            mEnquiryService = new EnquiryService(mockEnquiryRepository);
        }

        [TestMethod]
        public void Should_CreateEnquiry()
        {
            WhenCreateEnquiry();
            ThenShouldCreateEnquiry();
        }

        private void ThenShouldCreateEnquiry()
        {
            mockEnquiryRepository.AssertWasCalled(m => m.Create(Arg<Domain.Enquiry.Enquiry>.Is.Anything));
        }

        private void WhenCreateEnquiry()
        {
            var enquiry = new Domain.Enquiry.Enquiry
            {
                Status="New",
                Student =
                {
                    Name = "Curious Jeorge",
                    Phone = "9999999999",
                    Email = "curious.george@phenocare.com",
                    Institute = "The Intresting College",
                    Address = "Pune"
                },
                Notes="Enquiry for MVC",
                DateTime=DateTime.Now
            };

            enquiry.Status = "New";
            mEnquiryService.Create(enquiry);
        }
    }
}
