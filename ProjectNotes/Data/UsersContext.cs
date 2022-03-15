using Microsoft.EntityFrameworkCore;
using ProjectNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectNotes.Data
{
     public class UserContext:DbContext
    {
        public UserContext()
        {

        }
        public UserContext(DbContextOptions options) : base(options)
        {

        }

       
        internal DbSet<User> User { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.IdUser).HasName("PK_Test");
            base.OnModelCreating(modelBuilder);
        }
    }
}
