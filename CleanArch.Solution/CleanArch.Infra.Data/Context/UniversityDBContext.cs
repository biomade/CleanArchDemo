using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Context
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions options): base(options)
        {
            //constructor
        }

        //domain entities
        public DbSet<Course> Courses { get; set; }
    }
}
