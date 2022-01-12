using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using CMD.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public class RecommendationService : IRecommendationService
    {
        private IRecommendationRepository recommendationRepo = null;
        public RecommendationService()
        {
            this.recommendationRepo = new RecommendationRepository();
        }
        public RecommendationService(IRecommendationRepository recommendationRepo)
        {
            this.recommendationRepo = recommendationRepo;
        }

        #region Create
        /// <inheritdoc/>
        public int SaveRecommendation(Recommendation recommendation)
        {
            try
            {
                if (recommendationRepo.GetRecommendationByAppointmentIdAndDoctorId(recommendation) == null)
                {
                    return recommendationRepo.SaveRecommendation(recommendation);
                }
                else
                {
                    throw new DuplicateRecommendationRecordException();
                }
            }
            catch (NullReferenceException e)
            {
                if (recommendation.Appointment == null)
                {
                    throw new AppointmentNotFoundException();
                }
                if (recommendation.RecommendedDoctor == null)
                {
                    throw new DoctorNotFoundException();
                }
                else
                {
                    throw e;
                }
            }
        }
        /// <inheritdoc/>
        public int SaveRecommendationDTO(RecommendationDTO recommendationDTO)
        {
            Recommendation recommendation = recommendationDTO.ToRecommendation(recommendationRepo);
            int count = SaveRecommendation(recommendation);
            recommendationDTO.id = recommendation.RecommendationId;
            return count;
        }
        #endregion

        #region Retrieve
        #region Recommendation
        /// <inheritdoc/>
        public Recommendation GetRecommendationById(int recommendationId)
        {
            return recommendationRepo.GetRecommendationById(recommendationId);
        }
        /// <inheritdoc/>
        public List<Recommendation> GetRecommendations()
        {
            return recommendationRepo.GetRecommendations();
        }
        /// <inheritdoc/>
        public List<Recommendation> GetRecommendationsByAppointmentId(int appointmentId)
        {
            try
            {
                return recommendationRepo.GetRecommendationsByAppointmentId(appointmentId);
            }
            catch (NullReferenceException e)
            {
                throw new AppointmentNotFoundException();
            }
        }
        #endregion

        #region RecommendationDTO
        /// <inheritdoc/>
        public RecommendationDTO GetRecommendationDTOById(int recommendationId)
        {
            return recommendationRepo.GetRecommendationById(recommendationId).ToRecommendationDTO();
        }
        /// <inheritdoc/>
        public List<RecommendationDTO> GetRecommendationDTOs()
        {
            return recommendationRepo.GetRecommendations().ToRecommendationDTOList();
        }
        /// <inheritdoc/>
        public List<RecommendationDTO> GetRecommendationDTOsByAppointmentId(int appointmentId)
        {
            return GetRecommendationsByAppointmentId(appointmentId).ToRecommendationDTOList();
        }
        #endregion
        #endregion

        #region Delete
        /// <inheritdoc/>
        public int DeleteRecommendation(Recommendation recommendation)
        {
            return recommendationRepo.DeleteRecommendation(recommendation);
        }
        /// <inheritdoc/>
        public int DeleteRecommendationById(int recommendationId)
        {
            try
            {
                return DeleteRecommendation(GetRecommendationById(recommendationId));
            }
            catch (ArgumentNullException e)
            {
                throw new RecommendationNotFoundException();
            }
        }
        #endregion
    }
}
