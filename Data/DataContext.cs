using APIConexao.Models;
using Microsoft.EntityFrameworkCore;

namespace APIConexao.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options){}

        public DbSet<Pessoa> pessoa {get;set;}

        public DbSet<Estado> tb_trancado {get;set;}

    }
}