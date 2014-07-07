using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Web;
using Insight.Database;
using PhenoCare.Models;
using System.Data.SqlClient;

namespace PhenoCare.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private IEnumerable<Course> GetCourses()
        {
            if (HttpContext.Current.Cache["Courses"] == null)
            {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                var dbCourses = connection.Query<Course>("sp_GetCourses");

                HttpContext.Current.Cache.Insert("Courses", dbCourses, null, DateTime.Now.AddDays(1),
                    new TimeSpan(0, 0, 0, 0));
            }

            return HttpContext.Current.Cache["Courses"] as IList<Course>;
        }

        public IEnumerable<Course> GetCourses(int trackId)
        {
            var courses = GetCourses();

            return courses.Where(c => c.TrackId == trackId);
        }

        public Course GetCourse(int courseId)
        {
            var courses = GetCourses();

            return courses.SingleOrDefault(c => c.ID == courseId);
        }

        public IEnumerable<Topic> GetTopics(int courseId)
        {
            if (HttpContext.Current.Cache["Topics"] == null)
            {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                var dbTopics = connection.Query<Topic>("sp_GetTopics");

                HttpContext.Current.Cache.Insert("Topics", dbTopics, null, DateTime.Now.AddDays(1),
                    new TimeSpan(0, 0, 0, 0));
            }
            var topics = HttpContext.Current.Cache["Topics"] as IList<Topic>;

            return topics.Where(t => t.CourseId == courseId).OrderBy(t=>t.SerialNumber);
        }

        public IEnumerable<SubTopic> GetSubTopics(int topicId)
        {
            if (HttpContext.Current.Cache["SubTopics"] == null)
            {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                var dbSubTopics = connection.Query<SubTopic>("sp_GetSubTopics");

                HttpContext.Current.Cache.Insert("SubTopics", dbSubTopics, null, DateTime.Now.AddDays(1),
                    new TimeSpan(0, 0, 0, 0));
            }

            var subTopics = HttpContext.Current.Cache["SubTopics"] as IList<SubTopic>;

            return subTopics.Where(st => st.TopicId == topicId).OrderBy(t => t.SerialNumber);
        }


        public IEnumerable<Track> GetTracks()
        {
            if (HttpContext.Current.Cache["Tracks"] == null)
            {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                var dbTracks= connection.Query<Track>("sp_GetTracks");

                HttpContext.Current.Cache.Insert("Tracks", dbTracks, null, DateTime.Now.AddDays(1), new TimeSpan(0, 0, 0, 0));
            }

            return HttpContext.Current.Cache["Tracks"] as IList<Track>;
        }


        public IEnumerable<CourseOffering> GetCourseOfferings(int trackId)
        {
            if (HttpContext.Current.Cache["CourseOffering"] == null)
            {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                var dbCourseOffering= connection.Query<CourseOffering>("sp_GetCourseOffering");

                HttpContext.Current.Cache.Insert("CourseOffering", dbCourseOffering, null, DateTime.Now.AddDays(1), new TimeSpan(0, 0, 0, 0));
            }

            var courseOffering = HttpContext.Current.Cache["CourseOffering"] as IList<CourseOffering>;

            return courseOffering.Where(co => co.TrackId == trackId);
        }

        public IEnumerable<Course> GetCoursesByOffering(int offeringId)
        {
            if (HttpContext.Current.Cache["CourseByOffering"] == null)
            {
                var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["PhenoCareDb"].ToString());

                var dbCourseByOffering= connection.Query<Course>("sp_GetCourseByOffering");

                HttpContext.Current.Cache.Insert("CourseByOffering", dbCourseByOffering, null, DateTime.Now.AddDays(1),
                    new TimeSpan(0, 0, 0, 0));
            }

            var courseByOffering = HttpContext.Current.Cache["CourseByOffering"] as IList<Course>;

            return courseByOffering.Where(cbo => cbo.OfferingId == offeringId);
        }
    }
}