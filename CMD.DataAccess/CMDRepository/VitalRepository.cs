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
    /// Vitals Class Repository to Get All Vitals, Get Vitals By Vital Id, Get Vital By Appointment Id and Update Vital
    /// </summary>
    public class VitalRepository : IVitalRepository
    {
        CMDDbContext db = new CMDDbContext();

        /// <summary>
        /// Get List Of All Vitals
        /// </summary>
        /// <returns>List of Vitals Length can vary from 0 to N </returns>
        public List<Vital> getAllVitals()
        {
            return db.Vitals.ToList();
        }

        /// <summary>
        ///     Get Vitals By Appointment Id
        /// </summary>
        /// <param name="id"> Appointment Id of Int Type</param>
        /// <returns>Vital if appointment id is found else return null </returns>
        public Vital getVitalByAppointmentId(int id)
        {
            Vital vital = (from v in db.Vitals
                       where v.Appointment.AppointmentId == id
                       select v).FirstOrDefault();
            return vital;
        }

        /// <summary>
        ///     To get the vital info by vital id
        /// </summary>
        /// <param name="id">Accepts vital id of int type </param>
        /// <returns>vital info for particular vital id if found else return null </returns>
        public Vital getVitalById(int id)
        {
            return db.Vitals.Find(id);
        }

        /// <summary>
        /// Updates the Vital info for the Vital object passed
        /// </summary>
        /// <param name="v"> Accepts param of type Vital </param>
        /// <returns> integer or the number of rows affected upon database update </returns>
        public int updateVital(Vital v)
        {
            db.Entry(v).State = System.Data.Entity.EntityState.Modified;
            try
            {
                return db.SaveChanges();
            }
            catch(DbEntityValidationException ex)
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
            
    
        }
    }
}
