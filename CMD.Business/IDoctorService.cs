using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
   public interface IDoctorService
    {
        List<Doctor> GetDoctors();
        List<DoctorDTO> GetAllDoctorDTOs();
        Doctor GetDoctorById(int doctor_id);
        DoctorDTO GetDoctorByIdDTOs(int doctor_id);
        int UpdateDoctor(Doctor doctor);
        int UpdateDoctorDTOs(DoctorDTO doctorDTO);
        DoctorDTO GetDoctorByEmailDTO(string email);
    }
}
