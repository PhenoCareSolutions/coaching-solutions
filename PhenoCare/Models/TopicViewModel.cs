using System.Collections.Generic;

namespace PhenoCare.Models
{
    public class TopicViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        private IList<SubTopic> subTopicList;

        public TopicViewModel()
        {
            subTopicList=new List<SubTopic>();
        }

        public IList<SubTopic> SubTopics { get { return subTopicList; } }
    }
}