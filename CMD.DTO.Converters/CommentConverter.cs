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
    public static class CommentConverter
    {
      //  private static ICommentRepo repo = new CommentRepo();
        public static Comment ToComment(this CommentDTO commentDTO, ICommentRepository repo)
        {
            if (commentDTO == null)
            {
                return null;
            }
            Comment comment = new Comment();
            comment.CommentId = commentDTO.id;
            comment.CommentMessage = commentDTO.comment;
            comment.Appointment = repo.GetAppointmentById(commentDTO.appointment_id);
            //one more way
            //comment.Appointment.Comment = comment;
            //repo.UpdateAppointment(comment.Appointment);
            return comment;
        }

        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            if (comment == null || comment.Appointment==null)
            {
                return null;
            }
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.comment = comment.CommentMessage;
            commentDTO.id = comment.CommentId;
            commentDTO.appointment_id = comment.Appointment.AppointmentId;

            return commentDTO;
        }
    }
}
