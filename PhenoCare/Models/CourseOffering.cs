
namespace PhenoCare.Models
{
    public class CourseOffering
    {
        public int TrackId { get; set; }
        public int OfferingId { get; set; }
        public string OfferingTitle { get; set; }
        public int OfferingHrs { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int CourseHrs { get; set; }
        
        public bool HasSubCourses { get; set; }

        public string PdfLink { get; set; }
    }
}