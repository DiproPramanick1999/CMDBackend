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
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository appointmentRepo = null;
        private IDoctorRepository DoctorRepo = null;
        private IPatientRepository PatientRepo = null;
        /// <summary>
        /// Service to provide SRP and additional security
        /// </summary>
        //public AppointmentService()
        //{
        //    this.appointmentRepo = new AppointmentRepository();
        //    this.DoctorRepo = new DoctorRepository();
        //    this.PatientRepo = new PatientRepository();
        //    this.CommentRepo = new CommentRepository();
        //}
        public AppointmentService(IAppointmentRepository appointmentRepo)//,IDoctorRepository doctorRepository,IPatientRepository patientRepository)
        {
            this.appointmentRepo = appointmentRepo;
            this.DoctorRepo = new DoctorRepository();
            this.PatientRepo = new PatientRepository();
        }
        /// <summary>
        /// To Get All Appointments and convert appointment to appointmentDTO
        /// </summary>
        /// <returns>AppointmentDTO</returns>
        public List<AppointmentDTO> GetAllAppointmentDTOs()
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (Appointment appointment in GetAllAppointments())
            {
                appointmentDTOs.Add(appointment.ToAppointmentDTO());
            }
            return appointmentDTOs;
        }
        /// <summary>
        /// To Get All Appointments
        /// </summary>
        /// <returns>List of Appointment</returns>
        public List<Appointment> GetAllAppointments()
        {
            return appointmentRepo.GetAllAppointments();
        }
        /// <summary>
        /// To Get specific appointment by id passed as parameter
        /// </summary>
        /// <param name="appointment_id"></param>
        /// <returns></returns>
        public Appointment GetAppointmentById(int appointment_id)
        {
            return appointmentRepo.GetAppointmentById(appointment_id);
        }
        /// <summary>
        /// To Get specific appointment and convert from appointment to appointmentDTO
        /// </summary>
        /// <param name="appointment_id"></param>
        /// <returns></returns>
        public AppointmentDTO GetAppointmentByIdDTOs(int appointment_id)
        {
            var appointment = GetAppointmentById(appointment_id);
            AppointmentDTO appointmentDTO = appointment.ToAppointmentDTO();
            return appointmentDTO;

        }
        /// <summary>
        /// To Save/Post appointment into the database
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public bool SaveAppointment(Appointment appointment)
        {
            return appointmentRepo.SaveAppointment(appointment);
        }
        /// <summary>
        /// To Save/Post appointment into the database after converting the appointmentDTO to appointment
        /// </summary>
        /// <param name="appointmentDTO"></param>
        /// <returns></returns>
        public bool SaveAppointmentDTOs(AppointmentDTO appointmentDTO)
        {
            //to check
            //appointment_id == comment_id
            //Comment comment = new Comment { Appointment = appointmentDTO.ToAppointment(appointmentRepo, DoctorRepo, PatientRepo) };
            //appointmentRepo.SaveComment(comment);
            //Doctor d1 = DoctorRepo.GetDoctorById(appointmentDTO.doctor_id);
            Appointment ap = appointmentDTO.ToAppointment(appointmentRepo, DoctorRepo, PatientRepo);
            //check without writing this
            ap.Comment = new Comment();
            ap.Feedback = new Feedback();
            ap.Prescriptions = new List<Prescription>();
            ap.Tests = new List<Test>();
            ap.Recommendations = new List<Recommendation>();
            ap.Vital = new Vital();

            //return appointmentRepo.SaveAppointment(appointmentDTO.ToAppointment(appointmentRepo,DoctorRepo,PatientRepo));
            return SaveAppointment(ap);
        }
        /// <summary>
        /// To Update appointment into the database
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public bool UpdateAppointment(Appointment appointment)
        {
            return appointmentRepo.UpdateAppointment(appointment);
        }
        /// <summary>
        /// To Update appointment into the database after converting the appointmentDTO to appointment
        /// </summary>
        /// <param name="appointmentDTO"></param>
        /// <returns></returns>
        public bool UpdateAppointmentDTOs(AppointmentDTO appointmentDTO)
        {
            return UpdateAppointment(appointmentDTO.ToAppointment(appointmentRepo,DoctorRepo,PatientRepo));
        }
    }
}
