﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Models
{
    public class SaleManagerContext : IdentityDbContext
    {
        public SaleManagerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(c => new { c.ID });
            modelBuilder.Entity<Order>().HasKey(d => new { d.ID });
            modelBuilder.Entity<OrderDetail>().HasKey(d => new { d.OrderID });
            //IdentityUserLogin<string>
        }
    }
}
