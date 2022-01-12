using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.Converters
{
    public static class DoctorConverter
    {
        //static IAppointmentRepository repo = new AppointmentRepository();
        public static Doctor ToDoctor(this DoctorDTO doctorDTO, IDoctorRepository repo)
        {
            Doctor dr = new Doctor();
            dr.DoctorId = doctorDTO.id;
            dr.Name = doctorDTO.doctor_name;
            dr.Email = doctorDTO.doctor_email_id;
            dr.NpiNo = doctorDTO.doctor_npi_no;
            dr.PhoneNumber = doctorDTO.doctor_phone_number;
            dr.PracticeLocation = doctorDTO.doctor_practice_location;
            dr.ProfileImage = doctorDTO.doctor_profile_image;
            dr.Speciality = doctorDTO.doctor_speciality;
            dr.Clinic = repo.GetClinicById(doctorDTO.clinic_id);
            return dr;
        }
        public static DoctorDTO ToDoctorDTO(this Doctor doctor)
        {
            DoctorDTO doctorDTO = new DoctorDTO();

            doctorDTO.id = doctor.DoctorId;
            doctorDTO.doctor_name = doctor.Name;
            doctorDTO.doctor_email_id = doctor.Email;
            doctorDTO.doctor_npi_no = doctor.NpiNo;
            doctorDTO.doctor_phone_number = doctor.PhoneNumber;
            doctorDTO.doctor_practice_location = doctor.PracticeLocation;
            doctorDTO.doctor_profile_image = doctor.ProfileImage;
            doctorDTO.doctor_speciality = doctor.Speciality;
            doctorDTO.clinic_id = doctor.Clinic.ClinicId;

            return doctorDTO;
        }
    }
}
