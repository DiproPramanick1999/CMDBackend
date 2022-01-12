using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    public interface IDoctorRepository
    {
        List<Doctor> GetDoctor();
        Doctor GetDoctorById(int id);
        int EditDoctor(Doctor doctor);
        Clinic GetClinicById(int id);
        Doctor GetDoctorByEmail(string email);
    }
}
