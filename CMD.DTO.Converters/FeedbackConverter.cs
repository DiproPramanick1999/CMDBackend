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
    public static class FeedbackConverter
    {
        public static Feedback ToFeedback(this FeedbackDTO feedbackDTO, IFeedBackRepository repo)
        {
            Feedback feedback = new Feedback();
            feedback.FeedbackId = feedbackDTO.id;
            feedback.AddComment = feedbackDTO.AddComment;
            feedback.Question1 = feedbackDTO.Question1;
            feedback.Question2 = feedbackDTO.Question2;
            feedback.Question3 = feedbackDTO.Question3;
            feedback.Question4 = feedbackDTO.Question4;
            feedback.Appointment = repo.GetAppointmentById(feedbackDTO.appointment_id);
            return feedback;
        }
        public static FeedbackDTO ToFeedbackDTO(this Feedback feedback)
        {
            if (feedback == null)
            {
                return null;
            }
            FeedbackDTO dto = new FeedbackDTO();
            dto.id = feedback.FeedbackId;
            dto.Question1 = feedback.Question1;
            dto.Question2 = feedback.Question2;
            dto.Question3 = feedback.Question3;
            dto.Question4 = feedback.Question4;
            dto.AddComment = feedback.AddComment;
            dto.appointment_id = feedback.Appointment.AppointmentId;
            return dto;
        }
    }
}
