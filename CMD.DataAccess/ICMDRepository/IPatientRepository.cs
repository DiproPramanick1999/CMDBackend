using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    public interface IPatientRepository
    {
        List<Patient> GetPatients();
        Patient GetPatientById(int id);
    }
}
