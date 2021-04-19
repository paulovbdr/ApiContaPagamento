using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<ContaEntity> Contas { get; set; }

        public DbSet<LancamentoEntity> Lancamentos { get; set; }
    }
}
