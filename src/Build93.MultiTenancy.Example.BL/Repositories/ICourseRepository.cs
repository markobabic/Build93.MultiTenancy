using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Build93.MultiTenancy.Example.BL.Model;

namespace Build93.MultiTenancy.Example.BL.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> ListAll();
        void Insert(Course entity);
        void Delete(object id);
        void Delete(Course entityToDelete);
        void Update(Course entityToUpdate);
        void PartialUpdate(Course entity, params Expression<Func<Course, object>>[] propsToUpdate);
    }
}