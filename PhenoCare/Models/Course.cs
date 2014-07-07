
namespace PhenoCare.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int OfferingId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int TrackId { get; set; }
        public bool HasTopics { get; set; }
        public bool HasSubTopics { get; set; }
    }
}
