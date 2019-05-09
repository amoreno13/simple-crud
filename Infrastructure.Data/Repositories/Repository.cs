using Domain.Interfaces;
using Domain.Shared;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected DatabaseContext _context { get; private set; }

        public Repository(DatabaseContext context)
        {
            this._context = context;
        }

        public void Add(TEntity obj)
        {
            this._context.Set<TEntity>().Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return this._context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            this._context.Set<TEntity>().Remove(obj);
            this._context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            this._context.Entry(obj).State = EntityState.Modified;
            this._context.SaveChanges();
        }

    }
}
