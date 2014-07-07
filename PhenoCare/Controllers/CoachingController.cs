using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using PhenoCare.Models;
using PhenoCare.Repository;

namespace PhenoCare.Controllers
{
    public class CoachingController : Controller
    {
        private readonly ICourseRepository mCourseRepository;

        public CoachingController()
        {
            this.mCourseRepository =new CourseRepository();
        }

        public CoachingController(ICourseRepository mCourseRepository)
        {
            this.mCourseRepository = mCourseRepository;
        }

        //
        // GET: /Coaching/
        public ActionResult Index()
        {
            var tracks = mCourseRepository.GetTracks();
            return View(tracks);
        }

        public ActionResult CourseOfferingDetails(int trackId)
        {
            var courseOfferingList = mCourseRepository.GetCourseOfferings(trackId);

            var courseOfferingViewModel = new CourseOfferingViewModel(courseOfferingList);
            
            return View("CourseOfferingDetails", courseOfferingViewModel);
        }

        public ActionResult CourseDetails(int offeringId)
        {
            var courseList = mCourseRepository.GetCoursesByOffering(offeringId);

            return View("CourseDetails",courseList);
        }

        public ActionResult TopicDetails(int courseId)
        {
            var courseDetailViewModel = new CourseDetailViewModel();

            var course = mCourseRepository.GetCourse(courseId);

            if (course != null)
            {
                courseDetailViewModel.ID = course.ID;
                courseDetailViewModel.Name = course.Name;
                courseDetailViewModel.Hours = course.Hours;
                courseDetailViewModel.TrackId = course.TrackId;
                courseDetailViewModel.HasSubTopics = course.HasSubTopics;
                var courseTopics = mCourseRepository.GetTopics(courseId);

                foreach (var courseTopic in courseTopics)
                {
                    var topicViewModel = new TopicViewModel();
                    topicViewModel.ID = courseTopic.Id;
                    topicViewModel.Name = courseTopic.Name;

                    var subTopics = mCourseRepository.GetSubTopics(courseTopic.Id);
                    topicViewModel.SubTopics.AddRange(subTopics);

                    courseDetailViewModel.TopicList.Add(topicViewModel);

                }
            }
            else
            {
                courseDetailViewModel.Name = "Course not found";
            }

            return View("TopicDetails", courseDetailViewModel);
        }

        [HttpPost]
        public ActionResult CoursePost()
        {
            return RedirectToAction("TopicDetails");
        }
    }
}
