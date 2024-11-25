using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class GenericDao<TEntity> where TEntity : class
    {
        //private dynamic dbContext;
        private readonly DbContext _dbContext;
        private static GenericDao<TEntity> instance;
        public GenericDao(DbContext dbContext) 
        {
            _dbContext = dbContext;
            //this.dbContext = new CandidateManagementContext();
            //this.dbContext = new CandidateManagementContext();
        }

        public TEntity GetById(string id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return _dbContext.Set<TEntity>().ToList();
        //}

        //public static GenericDao<TEntity> Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new GenericDao<TEntity>();
        //        }
        //        return instance;
        //    }
        //}

        public List<TEntity> GetAllWithInclude(Expression<Func<TEntity, object>> include)
        {
            return _dbContext.Set<TEntity>()
                .Include(include)
                .ToList();
        }


        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            //bool isSuccess = false;

            //return isSuccess;

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }

    }
}
