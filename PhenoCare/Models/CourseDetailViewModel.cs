using System.Collections.Generic;

namespace PhenoCare.Models
{
    public class CourseDetailViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int TrackId { get; set; }
        public bool HasSubTopics { get; set; }

        private IList<TopicViewModel> topicList;

        public CourseDetailViewModel()
        {
            topicList=new List<TopicViewModel>();
        }

        public IList<TopicViewModel> TopicList {
            get { return topicList; }
        }
    }
}