using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    public class PatientRepository : IPatientRepository
    {
        private CMDDbContext db = new CMDDbContext();
        public Patient GetPatientById(int id)
        {
            return db.Patients.Find(id);
        }

        public List<Patient> GetPatients()
        {
            return db.Patients.ToList();
        }
    }
}
