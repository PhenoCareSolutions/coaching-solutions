
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhenoCare.Controllers
{
    public class EnrollmentViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Company/College Name")]
        public string Institute { get; set; }

        public string Comment { get; set; }
        public bool Submitted { get; set; }
    }
}