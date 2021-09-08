﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LineChart.Models;

namespace LineChart.Context
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
