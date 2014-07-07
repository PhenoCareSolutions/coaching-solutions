using System;

namespace PhenoCare.Domain.Enquiry
{
    public class Enquiry
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }

        public Enquiry()
        {
            Student=new Student();
        }
    }
}
