﻿using Microsoft.EntityFrameworkCore;
using ProjectNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectNotes.Data
{
     public class NoteContext:DbContext
    {
        public NoteContext()
        {

        }
        public NoteContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Note> Note { get; set; }
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
            modelBuilder.Entity<Note>().HasKey(x => x.Id).HasName("PK_Test");
            base.OnModelCreating(modelBuilder);
        }
    }
}
