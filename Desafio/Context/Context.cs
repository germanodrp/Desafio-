using Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Context
{
    public class Context : DbContext
    {

        public Context()
        {
        
        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }


        public virtual DbSet<Cliente> Clientes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
