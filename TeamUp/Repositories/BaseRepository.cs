using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamUp.Models;
using TeamUp.Util;

namespace TeamUp.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
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


        public void Update(TEntity updated, int id)
        {
            var existing = context.Set(typeof(TEntity)).Find(id);

            if (existing == null)
                throw new InternalException("Registro não encontrado para atualização.");

            context.Entry(existing).CurrentValues.SetValues(updated);
            context.SaveChanges();            
        }


        public void Delete(int id)
        {
            context.Set(typeof(TEntity)).Remove(id);
        }


        public TEntity FindById(int id)
        {
            return (TEntity)context.Set(typeof(TEntity)).Find(id);
        }


        public List<TEntity> GetAll()
        {
            return (List<TEntity>)context.Set(typeof(TEntity)).Find(null);
        }


        public abstract List<TEntity> SimpleWhere(Func<TEntity, bool> where);

    }
}