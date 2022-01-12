using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IFeedbackService
    {
        /// <summary>
        /// This method accepts an int parameter 
        /// and returns Feedback object 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Feedback</returns>
        Feedback GetFeedbackById(int id);
        /// <summary>
        /// This method accepts an int parameter
        /// and returns FeedbackDTO object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FeedbackDTO</returns>
        FeedbackDTO GetFeedbackByIdDTOs(int id);
        /// <summary>
        /// This method returns a list of
        /// FeedbackDTO objects
        /// </summary>
        /// <returns></returns>
        List<FeedbackDTO> GetFeedbackDTOs();
        /// <summary>
        /// This method returns a list of
        /// Feedback objects
        /// </summary>
        /// <returns></returns>
        List<Feedback> GetFeedbacks();
        /// <summary>
        /// This method accepts a Feedback parameter
        /// and returns an integer value
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>int</returns>
        int UpdateFeedback(Feedback feedback);
        /// <summary>
        /// This method accepts a FeedbackDTO parameter
        /// and returns an integer value
        /// </summary>
        /// <param name="feedbackDTO"></param>
        /// <returns></returns>
        int UpdateFeedbackDTO(FeedbackDTO feedbackDTO);
    }
}
