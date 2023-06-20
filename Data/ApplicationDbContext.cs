﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReptileAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReptileAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Link DB Table to Model
            modelBuilder.Entity<Animal>().ToTable("Animals");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Animal> Animals { get; set; }
    }
}