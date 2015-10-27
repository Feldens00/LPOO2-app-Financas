using System.Collections.Generic;

namespace Repositorys.Contracts
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {

        void Create(TEntity pEntity);
        void Update(TEntity pEntity);
        void Delete(int pId);
        IEnumerable<TEntity> getAll();
        TEntity getOne(int pId);
        
    }
}