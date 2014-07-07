using System;
using System.Web.Mvc;
using PhenoCare.Repository;

namespace PhenoCare.Controllers
{
    public class EnrollmentController : Controller
    {
        //
        // GET: /Enrollment/
        public ActionResult Index(string course,string isSubmitted)
        {
            var enrollmentViewModel = new EnrollmentViewModel();
            enrollmentViewModel.Course = course;
            if (!string.IsNullOrEmpty(isSubmitted))
            {
                enrollmentViewModel.Submitted = true;
            }
            return View(enrollmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostEnrollment(EnrollmentViewModel enrollmentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var enrollmentRepository = new EnrollmentRepository();

                    enrollmentRepository.SaveEnrollmentEnquiry(enrollmentViewModel);
                    //enrollmentRepository.SendEmail(enrollmentViewModel);

                    return RedirectToAction("Index", "Enrollment", new {course=string.Empty, isSubmitted = "true" });
                }
            }
            catch (Exception ex)
            {

            }
            return View("Index",enrollmentViewModel);
        }
    }
}
