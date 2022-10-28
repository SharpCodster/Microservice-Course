﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Infrastructure
{
    // add-migration {name} -Context ApplicationDbContext
    // update-database -Context ApplicationDbContext
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Assembly ass = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(ass);
        }
    }
}