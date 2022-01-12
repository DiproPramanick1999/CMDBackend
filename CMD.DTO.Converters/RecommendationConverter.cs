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
    public static class RecommendationConverter
    {
        //private static IAppointmentRepository appointmentRepo;
        //private static IDoctorRepository doctorRepo;

        //static RecommendationConverter()
        //{
        //    appointmentRepo = new AppointmentRepository();
        //    doctorRepo = new DoctorRepository();
        //}

        /// <summary>
        /// Converts the recommendationDTO to Recommedation entity.
        /// </summary>
        /// <param name="recommendationDTO"></param>
        /// <param name="recommendationRepo"></param>
        /// <returns>The converted Recommedation object or null if the recommendationDTO is null.</returns>
        public static Recommendation ToRecommendation(this RecommendationDTO recommendationDTO, IRecommendationRepository recommendationRepo)
        {
            if (recommendationDTO == null)
            {
                return null;
            }
            Recommendation recommendation = new Recommendation()
            {
                RecommendationId = recommendationDTO.id,
                Appointment = recommendationRepo.GetAppointmentById(recommendationDTO.appointment_id),
                RecommendedDoctor = recommendationRepo.GetDoctorById(recommendationDTO.recommended_doctor_id)
            };
            return recommendation;
        }

        /// <summary>
        /// Converts the recommendation entity to RecommendationDTO entity.
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>The converted RecommendationDTO object or null if the recommendation is null.</returns>
        public static RecommendationDTO ToRecommendationDTO(this Recommendation recommendation)
        {
            if (recommendation == null)
            {
                return null;
            }
            RecommendationDTO recommendationDTO = new RecommendationDTO()
            {
                id = recommendation.RecommendationId,
                appointment_id = recommendation.Appointment.AppointmentId,
                recommended_doctor_id = recommendation.RecommendedDoctor.DoctorId,
                recommended_doctor_name = recommendation.RecommendedDoctor.Name
            };
            return recommendationDTO;
        }

        /// <summary>
        /// Converts the List of recommendation entities to List of RecommendationDTO entities.
        /// </summary>
        /// <param name="recommendations"></param>
        /// <returns>The converted List<RecommendationDTO> object or null if the recommendations is null.</returns>
        public static List<RecommendationDTO> ToRecommendationDTOList(this List<Recommendation> recommendations)
        {
            if (recommendations == null)
            {
                return null;
            }
            List<RecommendationDTO> recommendationDTOs = new List<RecommendationDTO>();
            foreach (Recommendation recommendation in recommendations)
            {
                recommendationDTOs.Add(recommendation.ToRecommendationDTO());
            }
            return recommendationDTOs;
        }
    }
}
