using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laboratorio3.Models;

    public class Laboratorio3ApiContext : DbContext
    {
        public Laboratorio3ApiContext (DbContextOptions<Laboratorio3ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Laboratorio3.Models.Classroom> Classroom { get; set; } = default!;
       
        public DbSet<Laboratorio3.Models.Course> Course { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // Relación 1 a 1 entre Classroom y Course
        modelBuilder.Entity<Course>()
        .HasOne(c => c.Aula)
        .WithOne()
        .HasForeignKey<Course>(c => c.AulaId);
    }
}

    
