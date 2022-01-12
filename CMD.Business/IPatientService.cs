using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IPatientService
    {
        //List<Patient> GetPatients();
        List<PatientDTO> GetPatientDTOs();
       // Patient GetPatientById(int id);
        PatientDTO GetPatientDTOById(int id);
        
    }
}
