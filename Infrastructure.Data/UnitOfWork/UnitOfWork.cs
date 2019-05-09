using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DatabaseContext _contexto;

        public IUsuarioRepository UsuarioRepository { get; set; }

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _contexto = databaseContext;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}