using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    //repositorio/interface generico (TEntity) -> irá realiza crud
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //método/chamadas genéricas
        void Add(TEntity obj);

        TEntity GetById(int id);    //selecionar

        IEnumerable<TEntity> GetAll();  //selecionar tudo

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

    }
}
