using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    public class FeedBackRepository : IFeedBackRepository
    {
        CMDDbContext db = new CMDDbContext();
        /// <inheritdoc/>
        public List<Feedback> GetAllFeedbacks()
        {
            return db.Feedbacks.ToList();
        }
        
        public Appointment GetAppointmentById(int id)
        {
            return db.Appointments.Find(id);
        }
        /// <inheritdoc/>
        public Feedback GetFeedbackById(int id)
        {
            return db.Feedbacks.Find(id);
        }
        /// <inheritdoc/>
        public int UpdateFeedback(Feedback feedback)
        {
           db.Entry(feedback).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() ;
        }
    }
}
