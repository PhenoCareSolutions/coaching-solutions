using System;
using System.Web.Mvc;
using PhenoCare.Models;
using PhenoCare.Repository;

namespace PhenoCare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";
            var contact = new Contact();
           
            return View(contact);
        }

        [HttpGet]
        public ActionResult Contact(string isSubmitted)
        {
            ViewBag.Message = "Contact page.";
            var contact = new Contact();
            if (!string.IsNullOrEmpty(isSubmitted))
            {
                contact.Submitted = true;
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contactRepository = new ContactRepository();

                    contactRepository.SaveContact(contact);

                    contact.Submitted = true;

                    return RedirectToAction("Contact","Home",new {isSubmitted="true"});
                }
            }
            catch(Exception ex)
            {
               
            }
            return View(contact);
        }
    }
}
