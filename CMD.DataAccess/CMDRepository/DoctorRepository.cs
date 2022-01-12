using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    public class DoctorRepository : IDoctorRepository
    {
        CMDDbContext db = new CMDDbContext();
        public int EditDoctor(Doctor doctor)
        {
            // var doctor = (from d in db.Doctors where d.DoctorId == id select d).FirstOrDefault();
            db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public List<Doctor> GetDoctor()
        {
            return db.Doctors.ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            var doc = (from d in db.Doctors where d.DoctorId == id select d).FirstOrDefault();
            return doc;
        }
        public Doctor GetDoctorByEmail(string email)
        {
            return db.Doctors.Where(doc => doc.Email == email).FirstOrDefault();
        }
        public Clinic GetClinicById(int id)
        {
            return db.Clinics.Find(id);
        }
    }
}
