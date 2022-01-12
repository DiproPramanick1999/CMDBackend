using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private CMDDbContext db = new CMDDbContext();
        //private CMDDbContextSingleton db;
        //public RecommendationRepository()
        //{
        //    this.db = CMDDbContextSingleton.CMDDbContextInstance;
        //}

        #region Create
        /// <inheritdoc/>
        public int SaveRecommendation(Recommendation recommendation)
        {
            db.Recommendations.Add(recommendation);
            return db.SaveChanges();
        }
        #endregion

        #region Retrieve
        public Recommendation GetRecommendationByAppointmentIdAndDoctorId(Recommendation recommendation)
        {
            var result = (from r in db.Appointments.Find(recommendation.Appointment.AppointmentId).Recommendations
                          where r.RecommendedDoctor.DoctorId == recommendation.RecommendedDoctor.DoctorId
                          select r).FirstOrDefault();

            return result;
        }

        /// <inheritdoc/>
        public Recommendation GetRecommendationById(int recommendationId)
        {
            return db.Recommendations.Find(recommendationId);
        }
      
        /// <inheritdoc/>
        public List<Recommendation> GetRecommendations()
        {
            return db.Recommendations.ToList();
        }
      
        /// <inheritdoc/>
        public List<Recommendation> GetRecommendationsByAppointmentId(int appointmentId)
        {
            return db.Appointments.Find(appointmentId).Recommendations.ToList();
        }
        #endregion

        #region Update
        /// <inheritdoc/>
        public int UpdateRecommendation(Recommendation recommendation)
        {
            db.Entry(recommendation).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        #endregion

        #region Delete
        /// <inheritdoc/>
        public int DeleteRecommendation(Recommendation recommendation)
        {
            db.Recommendations.Remove(recommendation);
            return db.SaveChanges();
        }
        #endregion

        #region Temporary Workaround
        /// <inheritdoc/>
        public Appointment GetAppointmentById(int appointmentId)          // Temporary Workaround
        {
            return db.Appointments.Find(appointmentId);
        }

        /// <inheritdoc/>
        public Doctor GetDoctorById(int doctorId)          // Temporary Workaround
        {
            return db.Doctors.Find(doctorId);
        }
        #endregion
    }
}
