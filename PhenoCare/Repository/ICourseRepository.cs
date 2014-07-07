using System.Collections.Generic;
using PhenoCare.Models;

namespace PhenoCare.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses(int trackId);
        
        IEnumerable<CourseOffering> GetCourseOfferings(int trackId);

        IEnumerable<Course> GetCoursesByOffering(int offeringId);

        Course GetCourse(int courseId);

        IEnumerable<Track> GetTracks();

        IEnumerable<Topic> GetTopics(int courseId);

        IEnumerable<SubTopic> GetSubTopics(int topicId);
    }
}
