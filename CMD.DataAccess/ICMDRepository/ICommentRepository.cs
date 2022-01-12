using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Retrives the comment having same appointment id as the parameter from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Comment object or null</returns>
        Comment GetCommentByAppointmentId(int id);
        /// <summary>
        /// Retrives the comment having same appointment id as the parameter from the database asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Comment object or null</returns>
        Task<Comment> GetCommentByAppointmentIdAsync(int id);
        /// <summary>
        /// Inserts the comment object as a new record into the database. Returns true if it is successfully
        /// inserted otherwise false.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>true or false</returns>
        bool SaveComment(Comment comment);
        /// <summary>
        /// Inserts the comment object as a new record into the database asynchronously. Returns true if it is successfully 
        /// inserted otherwise false.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>true or false</returns>
        Task<bool> SaveCommentAsync(Comment comment);
        /// <summary>
        /// Updates the corresponding comment record in the database
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Number of rows affected</returns>
        int UpdateComment(Comment comment);
        /// <summary>
        /// Updates the corresponding comment record in the database asynchronously
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Number of rows affected</returns>
        Task<int> UpdateCommentAsync(Comment comment);
        /// <summary>
        ///  Updates the corresponding appointment record in the database
        ///  
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>True if successfully updated otherwise false</returns>
        bool UpdateAppointment(Appointment appointment);
        /// <summary>
        ///  Updates the corresponding appointment record in the database asynchronously
        ///  
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>True if successfully updated otherwise false</returns>
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        /// <summary>
        /// Retrieves the appointment object based on the id from the database
        /// If not found , it returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Appointment object or null</returns>
        Appointment GetAppointmentById(int id);
        /// <summary>
        /// Retrieves the appointment object based on the id from the database asychronously,
        /// If not found , it returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Appointment object or null</returns>
        Task<Appointment> GetAppointmentByIdAsync(int id);
        /// <summary>
        /// Retrives the list of Comments from database asynchronously
        /// </summary>
        /// <returns>A list of comments</returns>
        Task<List<Comment>> GetCommentsAsync();
        /// <summary>
        /// Retrives the list of Comments from database 
        /// </summary>
        /// <returns>A list of comments</returns>
        List<Comment> GetComments();
    }
}
