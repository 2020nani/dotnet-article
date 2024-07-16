﻿using FirstApi.Domain.Entities;
using FirstApi.Infrastructure.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Infrastructure.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employer> Employers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
