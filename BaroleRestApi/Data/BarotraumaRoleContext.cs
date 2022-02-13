using System;
using BaroleRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaroleRestApi.Data
{
    public class BarotraumaRoleContext : DbContext
    {
        public BarotraumaRoleContext(DbContextOptions<BarotraumaRoleContext> options) : base(options)
        {
        }

        public DbSet<BarotraumaRole> BarotraumaRoles => Set<BarotraumaRole>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarotraumaRole>()
                .Property(r => r.Id)
                .HasDefaultValue(Guid.NewGuid());
        }
    }
}