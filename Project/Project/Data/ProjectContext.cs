﻿using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ProjectContext: DbContext 
    {
        public DbSet<User> Users { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
