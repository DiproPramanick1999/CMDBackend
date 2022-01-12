using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    public interface IRecommendationRepository
    {
        #region Create
        /// <summary>
        /// Inserts the Recommendation object as a new record to the database
        /// if all the validations are met
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>Number of rows affected or inserted</returns>
        int SaveRecommendation(Recommendation recommendation);
        #endregion

        #region Retrieve
        /// <summary>
        /// Retrieves a recommendation record from the database with the same AppointmentId and DoctorId as the given recommendation. Returns null if not found.
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>A matching Recommendation object or null</returns>
        Recommendation GetRecommendationByAppointmentIdAndDoctorId(Recommendation recommendation);

        /// <summary>
        /// Retrieves the Recommendation record mathcing parameter id 
        /// </summary>
        /// <param name="recommendationId"></param>
        /// <returns>Recommendation object or null</returns>
        Recommendation GetRecommendationById(int recommendationId);

        /// <summary>
        /// Retrives all the Recommendation records from the database 
        /// </summary>
        /// <returns>A list of Recommendation records</returns>
        List<Recommendation> GetRecommendations();

        /// <summary>
        /// Retrives all the Recommendation records having the same appointment id 
        /// as parameter from the database. Throws NullReferenceException if the corresponding appointment id 
        /// is not found
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A list of Recommendation records</returns>
        /// <exception cref="NullReferenceException"></exception>
        List<Recommendation> GetRecommendationsByAppointmentId(int appointmentId);
        #endregion

        #region Update
        /// <summary>
        /// Updates the corresponding Recommendation record in the database
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>Number of rows affected or updated</returns>
        int UpdateRecommendation(Recommendation recommendation);
        #endregion

        #region Delete
        /// <summary>
        /// Deletes the corresponding Recommendationentry from the database
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>Number of rows affected or deleted</returns>
        int DeleteRecommendation(Recommendation recommendation);
        #endregion

        #region Temporary Workaround
        /// <summary>
        /// Retrieves the Appointment record having the same Appointment Id as the parameter.
        /// Returns null if not found
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>An Appointment object or null</returns>
        Appointment GetAppointmentById(int appointmentId);          // Temporary Workaround

        /// <summary>
        /// Retrives the doctor record having same appointment id as the parameter.
        /// Returns null if not found
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A Doctor object or null</returns>
        Doctor GetDoctorById(int appointmentId);                    // Temporary Workaround
        #endregion
    }
}