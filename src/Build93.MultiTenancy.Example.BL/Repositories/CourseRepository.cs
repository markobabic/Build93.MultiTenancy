using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Build93.MultiTenancy.Example.BL.Model;
using Build93.MultyTenancy.EntityFramework;

namespace Build93.MultiTenancy.Example.BL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Course> _dbSet;


        public CourseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = unitOfWork.GetDbSet<Course>();
        }

        public void Insert(Course entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(Course entityToDelete)
        {
            if (_unitOfWork.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Update(Course entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _unitOfWork.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void PartialUpdate(Course entity, params Expression<Func<Course, object>>[] propsToUpdate)
        {
            _dbSet.Attach(entity);
            var entry = _unitOfWork.Entry(entity);
            foreach (var prop in propsToUpdate)
                entry.Property(prop).IsModified = true;
        }

        public IEnumerable<Course> ListAll()
        {
            return _dbSet;
        }

    }

}
