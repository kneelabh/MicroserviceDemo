using MicroserviceDemo.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroserviceDemo.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly MovieContext _movieContext;

        public Repository(MovieContext movieContext)
        {
            _movieContext = movieContext;   
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                if(entity == null)
                {
                    throw new Exception("Could not add empty object to database");
                }

                await _movieContext.AddAsync(entity);
                int result = await _movieContext.SaveChangesAsync();
                
                return (result>0)?true:false;
            }
            catch (System.Exception)
            {
                throw new Exception("Could not save objects to database");
            }
        }

        public IEnumerable<TEntity> FindAll()
        {
            try
            {
                return _movieContext.Set<TEntity>();
            }
            catch (System.Exception)
            {
               throw new Exception("Could not retrive objects from database");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                if(entity == null)
                {
                    throw new Exception("Could not update empty object to database");
                }

                 _movieContext.Update(entity);
                await _movieContext.SaveChangesAsync();
                
                return entity;
            }
            catch (System.Exception)
            {
                throw new Exception("Could not update objects in database");
            }
        }

    }
}