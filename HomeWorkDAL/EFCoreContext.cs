using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using HomeWorkDAL.Entities;

namespace HomeWorkDAL
{
    public class EFCoreContext : DbContext
    {
        public DbSet<LaptopDTO> Laptops { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
