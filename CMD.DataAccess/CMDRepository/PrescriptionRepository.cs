using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    /// <summary>
    /// Prescription Repository to perform CRUD operations on Prescription Object and Get Appointment by Apppointment ID
    /// </summary>
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private CMDDbContext db = new CMDDbContext();
        #region Prescription Functions Implementation
        /// <summary>
        /// Get List Of All Prescripitons
        /// </summary>
        /// <returns>List of Prescriptions existing in database</returns>
        public List<Prescription> GetPrescriptions()
        {
            return db.Prescriptions.ToList();
        }
        /// <summary>
        /// Get Prescription By Prescripiton Id
        /// </summary>
        /// <param name="id">Passing int id as parameter</param>
        /// <returns>Prescription if Prescription id matches an existing Prescription,else null</returns>
        public Prescription GetPrescriptionById(int id)
        {
            return db.Prescriptions.Find(id);
        }
        /// <summary>
        /// Adds the Prescription Object passed into the database
        /// </summary>
        /// <param name="prescription"> Accepts param of type Prescripiton </param>
        /// <returns>Prescripiton that is added to the database</returns>
        public Prescription SavePrescription(Prescription prescription)
        {
            try
            {
                Prescription p = db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return p;    
            }
            catch (DbEntityValidationException ex)
            {
                Exception exception = ex;
                string message = "";
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message += string.Format("{0}\n", validationError.ErrorMessage);

                        exception = new InvalidOperationException(message, exception);
                    }
                }
                throw exception;
            }
        }
        /// <summary>
        /// Updates the Prescription info for the Prescription object passed
        /// </summary>
        /// <param name="prescription"> Accepts param of type Prescription </param>
        /// <returns>number of rows affected upon database update</returns>
        public int EditPrescription(Prescription prescription)
        {
            db.Entry(prescription).State = System.Data.Entity.EntityState.Modified;
            try
            {
                return db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Exception exception = ex;
                string message = "";
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message += string.Format("{0}\n", validationError.ErrorMessage);

                        exception = new InvalidOperationException(message, exception);
                    }
                }
                throw exception;
            }
        }
        /// <summary>
        /// Deletes the Prescripiton info from the database
        /// </summary>
        /// <param name="id">Accepts int id as parameter</param>
        /// <returns>number of rows afcted after deletion operation</returns>
        public int DeletePrescription(int id)
        {
            int count = 0;
            Prescription prescriptionToDelete = db.Prescriptions.Find(id);
            if (prescriptionToDelete != null)
            {
                db.Prescriptions.Remove(prescriptionToDelete);
                count = db.SaveChanges();
            }
            return count;
        }
        #endregion

        #region Appointment Function Implementation
        /// <summary>
        /// Get Appointment By Appointment Id
        /// </summary>
        /// <param name="id">Passing int id as parameter</param>
        /// <returns>Appointment if Appointment id matches an existing Appointment,else null</returns>
        public Appointment GetAppointmentByAppointmentId(int id)
        {
            return db.Appointments.Find(id);
        }
        #endregion
    }
}
