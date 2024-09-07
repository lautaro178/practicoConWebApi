using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{

    public class DBContext : DbContext
    {
        private string _connectionString = "Server=sqlserver,1433;Database=Practico4;User Id=sa;Password=231002lib;Encrypt=False;";

        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<Vehiculos> Vehiculos { get; set; }

    }
}
