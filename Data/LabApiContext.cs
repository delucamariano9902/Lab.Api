using Lab.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Api.Data
{
    public class LabApiContext : DbContext
    {
        public LabApiContext(DbContextOptions<LabApiContext> options) : base(options) {}

        public DbSet<LabItem> Items { get; set; }
    }
}