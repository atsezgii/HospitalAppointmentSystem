using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class AppointmentSystemDbContext : DbContext
    {
        private IConfiguration _configuration;
        public AppointmentSystemDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Report> PatientReports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AdminAction> AdminActions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string db = _configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            optionsBuilder.UseSqlServer(db);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Admin>().ToTable("Admins");


            base.OnModelCreating(modelBuilder);
        }
    }
}