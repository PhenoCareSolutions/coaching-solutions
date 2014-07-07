using System;
using System.Linq;
using System.Web.Mvc;
using PhenoCare.Admin.Models;
using PhenoCare.Domain.Enquiry;
using PhenoCare.Domain.Repositories;
using PhenoCare.Domain.Services;
using PhenoCare.Repository;

namespace PhenoCare.Admin.Controllers
{
    public class EnquiryController : Controller
    {
        private IStudentRepository mStudentRepository;
        private IEnquiryRepository mEnquiryRepository;
        private IEnquiryService mEnquiryService;

        public EnquiryController()
        {
            mStudentRepository=new StudentRepository();
            mEnquiryRepository=new EnquiryRepository(mStudentRepository);
            mEnquiryService = new EnquiryService(mEnquiryRepository);
        }

        public ActionResult Index()
        {
            var enquiries = mEnquiryService.GetAllEnquiries();
            var enquiriesViewModel = enquiries.Select(enquiry => new EnquiryViewModel
            {
                EnquiryId=enquiry.Id,
                Name = enquiry.Student.Name, 
                Email = enquiry.Student.Email, 
                Phone = enquiry.Student.Phone,
                Status=enquiry.Status
            }).ToList();

            return View(enquiriesViewModel);
        }

        [AllowAnonymous]
        public ActionResult CreateEnquiry()
        {
            var enquiryViewModel = new EnquiryViewModel();

            var allEnquiryStatus = mEnquiryService.GetAllStatus();
            foreach (var enquiryStatus in allEnquiryStatus)
            {
                enquiryViewModel.EnquiryStatus.Add(new SelectListItem {Text = enquiryStatus, Value = enquiryStatus});
            }
            
            return View(enquiryViewModel);
        }

        [AllowAnonymous]
        public ActionResult EditEnquiry(int id)
        {
            var enquiryViewModel = new EnquiryViewModel();

            var enquiry = mEnquiryService.GetEnquiry(id);

            enquiryViewModel.EnquiryId = enquiry.Id;
            enquiryViewModel.Status = enquiry.Status;
            enquiryViewModel.Notes = enquiry.Notes;
            enquiryViewModel.StudentId = enquiry.Student.Id;
            enquiryViewModel.Name = enquiry.Student.Name;
            enquiryViewModel.Phone = enquiry.Student.Phone;
            enquiryViewModel.Email = enquiry.Student.Email;
            enquiryViewModel.Institute = enquiry.Student.Institute;
            enquiryViewModel.IntrestedIn = enquiry.Student.IntrestedIn;

            var allEnquiryStatus = mEnquiryService.GetAllStatus();
            foreach (var enquiryStatus in allEnquiryStatus)
            {
                enquiryViewModel.EnquiryStatus.Add(new SelectListItem { Text = enquiryStatus, Value = enquiryStatus });
            }

            return View("CreateEnquiry",enquiryViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEnquiry(EnquiryViewModel enquiryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mEnquiryService.Create(new Enquiry
                    {
                        Id=enquiryViewModel.EnquiryId,
                        Notes=enquiryViewModel.Notes,
                        Status=enquiryViewModel.Status,
                        Student=new Student
                        {
                            Id=enquiryViewModel.StudentId,
                            Name=enquiryViewModel.Name,
                            Phone = enquiryViewModel.Phone,
                            Email=enquiryViewModel.Email,
                            Institute=enquiryViewModel.Institute,
                            IntrestedIn=enquiryViewModel.IntrestedIn
                        }
                    });
                    return RedirectToAction("Index", "Enquiry");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            var allEnquiryStatus = mEnquiryService.GetAllStatus();
            foreach (var enquiryStatus in allEnquiryStatus)
            {
                enquiryViewModel.EnquiryStatus.Add(new SelectListItem { Text = enquiryStatus, Value = enquiryStatus });
            }

            return View(enquiryViewModel);
        }

    }
}
