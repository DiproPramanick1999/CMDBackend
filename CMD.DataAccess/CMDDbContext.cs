using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess
{
    public class CMDDbContext : DbContext
    {
        public CMDDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Vital> Vitals { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
    
