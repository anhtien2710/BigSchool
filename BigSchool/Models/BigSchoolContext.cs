using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigSchool.Models
{
    public partial class BigSchoolContext : DbContext
    {
        public BigSchoolContext()
            : base("name=BigSchoolContext")
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Catagory> Catagories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Catagory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);
        }
    }
}
