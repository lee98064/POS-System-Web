#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using POSSystemApi.Models;

    public class POSSystemApiContext : DbContext
    {
        public POSSystemApiContext (DbContextOptions<POSSystemApiContext> options)
            : base(options)
        {
        }

        public DbSet<POSSystemApi.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name).ToTable(entity.Name + "s");
                modelBuilder.Entity<User>().HasIndex(p => new { p.email, p.account }).IsUnique();
            }
        }
    }


    