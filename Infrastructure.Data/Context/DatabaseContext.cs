using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Entities;

namespace Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {        
        public DatabaseContext() : base("sql")
        {
        }

        public DatabaseContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));
        }
    }
}
