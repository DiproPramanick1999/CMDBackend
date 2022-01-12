using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
   public class DoctorService:IDoctorService
    {
        private IDoctorRepository doctorRepo = null;
        public DoctorService()
        {
            this.doctorRepo = new DoctorRepository();
        }
        public DoctorService(IDoctorRepository repo)
        {
            this.doctorRepo = repo;
        }
        public List<DoctorDTO> GetAllDoctorDTOs()
        {
            List<DoctorDTO> doctorDTOs = new List<DoctorDTO>();
            foreach (Doctor doctor in doctorRepo.GetDoctor())
            {
                doctorDTOs.Add(doctor.ToDoctorDTO());
            }
            return doctorDTOs;
        }
        public List<Doctor> GetDoctors()
        {
            return doctorRepo.GetDoctor();
        }

        public Doctor GetDoctorById(int doctor_id)
        {
            return doctorRepo.GetDoctorById(doctor_id);
        }

        public DoctorDTO GetDoctorByIdDTOs(int doctor_id)
        {
            var doctor = doctorRepo.GetDoctorById(doctor_id);
            DoctorDTO doctorDTO = doctor.ToDoctorDTO();
            return doctorDTO;

        }


        public int UpdateDoctor(Doctor doctor)
        {
            return doctorRepo.EditDoctor(doctor);
        }

        public int UpdateDoctorDTOs(DoctorDTO doctorDTO)
        {
            return doctorRepo.EditDoctor(doctorDTO.ToDoctor(doctorRepo));
        }
        public DoctorDTO GetDoctorByEmailDTO(string email)
        {
            DoctorDTO doctorDTO = null;
            var doc = doctorRepo.GetDoctorByEmail(email);
            if (doc != null)
                doctorDTO = doc.ToDoctorDTO();
            return doctorDTO;
        }
    }
}
