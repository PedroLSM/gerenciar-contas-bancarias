using GCB.Comum.Entidades;
using System;
using System.Collections.Generic;

namespace GCB.Comum.Repositorios
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        T GetSingle(Guid? id);
        T GetSingleOrDefault(Guid? id);
        T GetLast();
        T GetLastOrDefault();
        T Add(T Entity);
        T Update(T Entity);
        T Delete(T Entity);
        T Delete(Guid id);
    }
}
