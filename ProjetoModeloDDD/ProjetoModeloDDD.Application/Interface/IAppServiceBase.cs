using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
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
