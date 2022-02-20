using Microsoft.EntityFrameworkCore;
using Sqlite_CRUD_Copy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite_CRUD_Copy.Core.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UserData.db");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
