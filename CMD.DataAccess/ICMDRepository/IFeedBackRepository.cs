using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    public interface IFeedBackRepository
    {
        /// <summary>
        /// This method accepts an integer parameter
        /// and returns Feedback object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Feedback</returns>
        Feedback GetFeedbackById(int id);
        /// <summary>
        /// This method accepts Feedback object and
        /// returns an integer value
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>int</returns>
        int UpdateFeedback(Feedback feedback);
        /// <summary>
        /// This method returns a list of Feedback objects
        /// </summary>
        /// <returns></returns>
        List<Feedback> GetAllFeedbacks();

        //Temporarily used
        Appointment GetAppointmentById(int id);
    }
}
