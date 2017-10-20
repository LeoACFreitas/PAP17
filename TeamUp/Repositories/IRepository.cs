using System;
using System.Collections.Generic;

namespace TeamUp.Repositories
{
    interface IRepository<TEntity>
    {

        void Save(TEntity value);
        void Update(TEntity updated, int id);
        void Delete(int id);
        TEntity FindById(int id);
        List<TEntity> GetAll();
        List<TEntity> SimpleWhere(Func<TEntity, bool> where);

    }
}
