﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P1.Models;

namespace P1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<P1.Models.Project> Project { get; set; }
        public DbSet<P1.Models.Feedback> Feedback { get; set; }
        public DbSet<P1.Models.Bug> Bug { get; set; }
    }
}
