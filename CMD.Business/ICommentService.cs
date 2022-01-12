using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface ICommentService
    {
        /// <summary>
        /// Retrives the Comment object based on the appointment id from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Comment object or null</returns>
        Comment GetCommentByAppointmentId(int id);
        /// <summary>
        /// Retrives the Comment object based on the appointment id from database
        /// asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Comment object or null</returns>
        Task<Comment> GetCommentByAppointmentIdAsync(int id);
        /// <summary>
        /// Updates the corresponding Comment record in the database 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Number of rows affected or updated in the database</returns>
        int UpdateComment(Comment comment);
        /// <summary>
        /// Updates the corresponding Comment record in the database asynchronously
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Number of rows affected or updated in the database</returns>
        Task<int> UpdateCommentAsync(Comment comment);
        //Appointment GetAppointmentById(int id);
        /// <summary>
        /// Retrives the list of Comment records from the database
        /// </summary>
        /// <returns>A list of Comment records</returns>
        List<Comment> GetComments();
        //Appointment GetAppointmentById(int id);
        /// <summary>
        /// Retrives the list of Comment records from the database asynchronously
        /// </summary>
        /// <returns>A list of Comment records</returns>
        Task<List<Comment>> GetCommentsAsync();
        /// <summary>
        /// Retrieves the list of Comment records from database 
        ///  
        /// </summary>
        /// <returns>A list of Comments</returns>
        List<CommentDTO> GetCommentDTOs();
        /// <summary>
        /// Retrieves the list of Comment records from database asynchronously and 
        /// converts them into a Comment Data Transfer Object 
        /// </summary>
        /// <returns>A list of Comment Data Transfer Object</returns>
        Task<List<CommentDTO>> GetCommentDTOsAsync();
        /// <summary>
        /// Updates the corresponding comment record in the database
        /// </summary>
        /// <param name="commentDTO"></param>
        /// <returns>Number of rows affected or updated</returns>
        int UpdateCommentDTO(CommentDTO commentDTO);
        /// <summary>
        /// Updates the corresponding comment record in the database asynchronously
        /// </summary>
        /// <param name="commentDTO"></param>
        /// <returns>Number of rows affected or updated</returns>
        Task<int> UpdateCommentDTOAsync(CommentDTO commentDTO);
        /// <summary>
        /// Retrives the corresponing Comment record having appointment id same as
        /// the parameter from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Comment Data Transfer Object</returns>
        CommentDTO GetCommentDTOByAppointmentId(int id);
        /// <summary>
        /// Retrives the corresponing Comment record having appointment id same as
        /// the parameter from the database asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Comment Data Transfer Object</returns>
        Task<CommentDTO> GetCommentDTOByAppointmentIdAsync(int id);
    }
}
