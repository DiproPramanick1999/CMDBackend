using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedBackRepository feedbackRepo = null;
        //public FeedbackService()
        //{
        //    this.feedbackRepo = new FeedBackRepository();
        //}

        public FeedbackService(IFeedBackRepository repo)
        {
            this.feedbackRepo = repo;
        }
        ///<inheritdoc/>
        public Feedback GetFeedbackById(int id)
        {
            return feedbackRepo.GetFeedbackById(id);
        }
        ///<inheritdoc/>
        public FeedbackDTO GetFeedbackByIdDTOs(int id)
        {
            FeedbackDTO feedbackDTO = GetFeedbackById(id).ToFeedbackDTO();

            return feedbackDTO;
        }
        ///<inheritdoc/>
        public List<FeedbackDTO> GetFeedbackDTOs()
        {
            List<FeedbackDTO> list =new List<FeedbackDTO>();
            List<Feedback> feedbacks = GetFeedbacks();
            if (feedbacks != null)
            {
                foreach (var item in feedbacks)
                {
                    list.Add(item.ToFeedbackDTO());
                }
            }
            return list;
        }
        ///<inheritdoc/>
        public List<Feedback> GetFeedbacks()
        {
            return feedbackRepo.GetAllFeedbacks();
        }
        ///<inheritdoc/>
        public int UpdateFeedback(Feedback feedback)
        {
            if (feedback.Appointment == null)
                return 0;
            return feedbackRepo.UpdateFeedback(feedback);


        }
        ///<inheritdoc/>
        public int UpdateFeedbackDTO(FeedbackDTO feedbackDTO)
        {
            return UpdateFeedback(feedbackDTO.ToFeedback(feedbackRepo));
        }
    }
}
