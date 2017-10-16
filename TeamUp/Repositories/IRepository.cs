using System;

namespace TeamUp.Repositories
{
    interface IRepository<TEntity>
    {

        void Save(TEntity value);
        void Update(TEntity updated, int id);
        void Delete(int id);
        TEntity FindById(int id);

    }
}
