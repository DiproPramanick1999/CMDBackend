using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    /// <summary>
    /// Appointment Class that implements the IAppointmentRepository for various functionalities
    /// </summary>
    public class AppointmentRepository:IAppointmentRepository
    {
        private CMDDbContext db = new CMDDbContext();
        //private CMDDbContextSingleton db;
        //public AppointmentRepository()
        //{
        //    db = CMDDbContextSingleton.CMDDbContextInstance;
        //}
        /// <summary>
        /// Get List of all Appointment
        /// </summary>
        /// <returns>List of all Appointments</returns>

        public List<Appointment> GetAllAppointments()
        {
            return db.Appointments.ToList();
        }
        /// <summary>
        /// Get particular Appointment by id
        /// </summary>
        /// <param name="appointment_id"></param>
        /// <returns> Specific Appointment</returns>
        public Appointment GetAppointmentById(int appointment_id)
        {
            return db.Appointments.Find(appointment_id);
        }
        //Dependent Functionality
        public Doctor GetDoctor(int id)
        {
            return db.Doctors.Find(id);
        }
        //Dependent Functionality
        public Patient GetPatientById(int patient)
        {
            return db.Patients.Find(patient);
        }
        /// <summary>
        /// Post/Save the apppointment into the database
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>True/False depending on the table got the saved changes</returns>
        public bool SaveAppointment(Appointment appointment)
        {
            db.Appointments.Add(appointment);
            try
            {
                return db.SaveChanges()>0;
            }
            catch (DbEntityValidationException ex)
            {
                Exception raise = ex;
                string message = "";
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message += string.Format("{0}\n", validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            //return db.SaveChanges() > 0;
        }
        /// <summary>
        /// Update the Appointment table
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>True/False depending on the table got the saved changes</returns>
        public bool UpdateAppointment(Appointment appointment)
        {
            if(appointment.Doctor==null || appointment.Patient == null)
            {
                return false;
            }
            else
            {
                db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }   
        }
        //Dependent functionality
        public bool SaveComment(Comment comment)
        {
            db.Comments.Add(comment);
            return db.SaveChanges() > 0;
        }
    }
}
