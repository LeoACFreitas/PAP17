using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamUp.Models;
using TeamUp.Util;

namespace TeamUp.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        protected TeamUpContext context;


        public BaseRepository(TeamUpContext context) {
            this.context = context;
        }


        public void Save(TEntity value)
        {
            context.Set(typeof(TEntity)).Add(value);
            context.SaveChanges();
        }


        public void Update(TEntity updated)
        {
            var entity = context.Set(typeof(TEntity)).Find(updated.Id);
            context.Entry(entity).CurrentValues.SetValues(updated);

            context.SaveChanges();            
        }


        public void Delete(int id)
        {
            var entity = context.Set(typeof(TEntity)).Find(id);
            context.Entry(entity).State = EntityState.Deleted;

            context.SaveChanges();
        }


        public TEntity FindById(int id)
        {
            return (TEntity)context.Set(typeof(TEntity)).Find(id);
        }


        public List<TEntity> GetAll()
        {
            return (List<TEntity>)context.Set(typeof(TEntity)).Find(null);
        }


        public List<TEntity> SimpleWhere(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>().Where(where).ToList();
        }

    }
}