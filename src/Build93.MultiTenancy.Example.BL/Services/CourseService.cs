using System.Collections.Generic;
using System.Linq;
using Build93.MultiTenancy.Example.BL.Model;
using Build93.MultiTenancy.Example.BL.Repositories;

namespace Build93.MultiTenancy.Example.BL.Services
{
    public interface ICourseService
    {
        IList<Course> ListAllActiveCourses();
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IList<Course> ListAllActiveCourses()
        {
            return _courseRepository.ListAll().Where(c => c.IsActive).ToList();
        }
    }
}
