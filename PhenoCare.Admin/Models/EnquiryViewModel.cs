
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PhenoCare.Admin.Models
{
    public class EnquiryViewModel
    {
        public int EnquiryId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Institute { get; set; }
        [Required]
        [Display(Name="Intrested in")]
        public string IntrestedIn { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public string Status { get; set; }
        public IList<SelectListItem> EnquiryStatus { get; set; }

        public int StudentId { get; set; }
        public EnquiryViewModel()
        {
            EnquiryStatus = new List<SelectListItem>();
        }
    }
}