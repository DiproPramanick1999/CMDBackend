using CMD.DataAccess.CMDRepository;
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
    public static class AppointmentConverter
    {
        //static IAppointmentRepository repo = new AppointmentRepository();
        //static IDoctorRepository DoctorRepo = new DoctorRepository();
        //static IPatientRepository PatientRepo = new PatientRepository();

        /// <summary>
        /// Converts the Appointment to AppointmentDTO for further accessibility
        /// </summary>
        /// <param name="appointmentDTO"></param>
        /// <param name="repo"></param>
        /// <param name="DoctorRepo"></param>
        /// <param name="PatientRepo"></param>
        /// <returns>Appointment</returns>
        public static Appointment ToAppointment(this AppointmentDTO appointmentDTO,IAppointmentRepository repo,IDoctorRepository DoctorRepo,IPatientRepository PatientRepo)
        {
            Appointment appointment = new Appointment();
            appointment.AppointmentId = appointmentDTO.id;
            appointment.Date = appointmentDTO.appointment_date;
            appointment.Time = appointmentDTO.appointment_time;
            appointment.Status = appointmentDTO.appointment_status;
            appointment.Patient = repo.GetPatientById(appointmentDTO.patient_id);
            //appointment.Patient = PatientRepo.GetPatientById(appointmentDTO.patient_id);
            appointment.Doctor = repo.GetDoctor(appointmentDTO.doctor_id);
            //appointment.Doctor = DoctorRepo.GetDoctorById(appointmentDTO.doctor_id);
            //appointment.Doctor = doctor;
            return appointment;
        }
        /// <summary>
        /// Converts AppointmentDTO to Appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>AppointmentDTO</returns>
        public static AppointmentDTO ToAppointmentDTO(this Appointment appointment)
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            appointmentDTO.id = appointment.AppointmentId;
            appointmentDTO.patient_name = appointment.Patient.Name;
            appointmentDTO.patient_age = appointment.Patient.Age;
            appointmentDTO.patient_id = appointment.Patient.PatientId;
            appointmentDTO.doctor_id = appointment.Doctor.DoctorId;
            appointmentDTO.doctor_name = appointment.Doctor.Name;
            appointmentDTO.appointment_date = appointment.Date;
            appointmentDTO.appointment_time = appointment.Time;
            appointmentDTO.appointment_status = appointment.Status;
            appointmentDTO.patient_issue = appointment.Patient.ActiveIssues;
            return appointmentDTO;
        }
    }
}
