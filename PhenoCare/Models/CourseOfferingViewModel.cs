using System.Collections.Generic;
using System.Linq;

namespace PhenoCare.Models
{
    public class CourseOfferingViewModel
    {
        private IList<CourseOffering> mCourseOfferingList;

        public IList<CourseOffering> CourseOfferings {
            get { return mCourseOfferingList; }
        }

        public CourseOfferingViewModel()
        {
            mCourseOfferingList=new List<CourseOffering>();
        }

        public CourseOfferingViewModel(IEnumerable<CourseOffering> courseOfferings )
        {
            mCourseOfferingList = courseOfferings.ToList();
        }
    }
}