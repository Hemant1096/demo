using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Data.Entity.Infrastructure;
using System.Configuration;

namespace Test.test.Models
{
    public partial class adventureContext : DbContext
    {
        public adventureContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if(!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["adventureconnectionstring"].ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.employee_id).HasColumnName("employee_id");
                entity.Property(e => e.firstName).HasColumnName("first_name");
                entity.Property(e => e.lastName).HasColumnName("last_name");
                entity.Property(e => e.email).HasColumnName("email");
                entity.Property(e => e.phone).HasColumnName("phone_number");
                entity.Property(e => e.hireDate).HasColumnName("hire_date");
                entity.Property(e => e.job_id).HasColumnName("job_id");
                entity.Property(e => e.salary).HasColumnName("salary");
                entity.Property(e => e.managerid).HasColumnName("manager_id");
                entity.Property(e => e.departmentid).HasColumnName("department_id");
            }            
            );
        }
        public void save()
        {
            this.SaveChanges();
        }
    }
}
