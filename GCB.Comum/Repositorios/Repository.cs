using GCB.Comum.Entidades;
using GCB.Comum.Excecoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCB.Comum.Repositorios
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext Context)
        {
            this.Context = Context ?? throw new ArgumentNullException(nameof(Context)); ;
            dbSet = this.Context.Set<T>();
        }

        private static void EntityValid(T Entity)
        {
            if (Entity.Invalid)
                throw new ValidationException(Entity.Notifications);
        }

        public T Add(T Entity)
        {
            EntityValid(Entity);
            return dbSet.Add(Entity).Entity;
        }

        public T Update(T Entity)
        {
            EntityValid(Entity);
            return dbSet.Update(Entity).Entity;
        }

        public T Delete(Guid id)
        {
            T Entity = GetSingle(id);
            EntityValid(Entity);
            return Delete(Entity);
        }

        public T Delete(T Entity)
        {
            EntityValid(Entity);
            return dbSet.Remove(Entity).Entity;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public virtual T GetSingle(Guid? id)
        {
            return dbSet.Find(id) ?? throw new NotFoundException(typeof(T).Name, id);
        }

        public T GetSingleOrDefault(Guid? id)
        {
            return dbSet.Find(id);
        }

        public T GetLast()
        {
            return GetAll().LastOrDefault() ?? throw new NotFoundException(typeof(T).Name);
        }

        public T GetLastOrDefault()
        {
            return GetAll().LastOrDefault();
        }
    }
}
