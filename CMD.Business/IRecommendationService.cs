using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IRecommendationService
    {
        #region Create
        #region Synchronous
        /// <summary>
        /// Inserts the data in the given Recommendation as a record to the database. Throws <see cref="DuplicateRecommendationRecordException"/> if combination of appointmentId and name is already present in the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="DuplicateRecommendationRecordException"></exception>
        /// <exception cref="AppointmentNotFoundException"></exception>
        int SaveRecommendation(Recommendation recommendation);
        /// <summary>
        /// Inserts the data in the given recommendationDTO as a record to the database. Throws <see cref="DuplicateRecommendationRecordException"/> if combination of appointmentId and name is already present in the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="DuplicateRecommendationRecordException"></exception>
        /// <exception cref="AppointmentNotFoundException"></exception>
        int SaveRecommendationDTO(RecommendationDTO recommendationDTO);
        #endregion
        #region Asynchronous
        #endregion
        #endregion

        #region Retrieve
        #region Synchronous
        #region Recommendation
        /// <summary>
        /// Retrieves the recommendation record which has primary key equal to the given recommendationId. Returns null if not found.
        /// </summary>
        /// <param name="recommendationId"></param>
        /// <returns>A <see cref="Recommendation"/> which represents retrieved record or null.</returns>
        Recommendation GetRecommendationById(int recommendationId);

        /// <summary>
        /// Retrieves all the recommendation records from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="recommendation"/> which correspond to all the records retrieved from the database.</returns>
        List<Recommendation> GetRecommendations();
        /// <summary>
        /// Retrieves all the Recommendation records which have the given appointmentId from the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Recommendation"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="AppointmentNotFoundException"></exception>
        List<Recommendation> GetRecommendationsByAppointmentId(int appointmentId);
        #endregion
        #region RecommendationDTO
        /// <summary>
        /// Retrieves the recommendation record which has primary key equal to the given recommendationId. Returns null if not found.
        /// </summary>
        /// <param name="recommendationId"></param>
        /// <returns>A <see cref="RecommendationDTO"/> which represents retrieved record or null.</returns>
        RecommendationDTO GetRecommendationDTOById(int recommendationId);
        /// <summary>
        /// Retrieves all the recommendation records from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="RecommendationDTO"/> which correspond to all the records retrieved from the database.</returns>
        List<RecommendationDTO> GetRecommendationDTOs();
        /// <summary>
        /// Retrieves all the recommendation records which have the given appointmentId from the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RecommendationDTO"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="AppointmentNotFoundException"></exception>

        List<RecommendationDTO> GetRecommendationDTOsByAppointmentId(int appointmentId);
        #endregion
        #endregion
        #region Asynchronous
        #endregion
        #endregion

        #region Delete
        #region Synchronous
        /// <summary>
        /// Deletes the database record corresponding to the given recommendation.
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        int DeleteRecommendation(Recommendation recommendation);
        /// <summary>
        /// Deletes the database record corresponding to the given recommendationId. Throws <see cref="RecommendationNotFoundException"/> if given recommendationId doesn't exist in the database.
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="RecommendationNotFoundException"></exception>
        int DeleteRecommendationById(int recommendationId);
        #endregion
        #region Asynchronous
        #endregion
        #endregion
    }
}
