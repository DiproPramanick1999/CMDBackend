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
    public class CommentService : ICommentService
    {
        ICommentRepository repo;

        //public CommentService()
        //{
        //    this.repo = new CommentRepository();
        //}

       // public CommentService() { }
        public CommentService(ICommentRepository repo)
        {
            this.repo = repo;
        }
 
        /// <inheritdoc/>
        public Comment GetCommentByAppointmentId(int id)
        {
            return repo.GetCommentByAppointmentId(id);
        }
        /// <inheritdoc/>
        public async Task<Comment> GetCommentByAppointmentIdAsync(int id)
        {
           return await repo.GetCommentByAppointmentIdAsync(id);
        }

        /// <inheritdoc/>
        public CommentDTO GetCommentDTOByAppointmentId(int id)
        {
           return GetCommentByAppointmentId(id).ToCommentDTO();
        }
        /// <inheritdoc/>
        public async Task<CommentDTO> GetCommentDTOByAppointmentIdAsync(int id)
        {
            return (await GetCommentByAppointmentIdAsync(id)).ToCommentDTO();
        }
        /// <inheritdoc/>
        public List<CommentDTO> GetCommentDTOs()
        {
            List<CommentDTO> dtos = new List<CommentDTO>();
            foreach (var item in GetComments())
            {
                CommentDTO dto = item.ToCommentDTO();
                dtos.Add(dto);
            }
            return dtos;
        }
        /// <inheritdoc/>
        public async Task<List<CommentDTO>> GetCommentDTOsAsync()
        {
            List<CommentDTO> dtos = new List<CommentDTO>();
            foreach (var item in await GetCommentsAsync())
            {
                CommentDTO dto = item.ToCommentDTO();
                dtos.Add(dto);
            }
            return dtos;
        }
        /// <inheritdoc/>
        public List<Comment> GetComments()
        {
            List<Comment> comments = repo.GetComments();
            return comments;
        }
        /// <inheritdoc/>
        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await repo.GetCommentsAsync();
        }

        /// <inheritdoc/>
        public int UpdateComment(Comment comment)
        {
            if(comment.Appointment == null)
            {
                return 0;
            }
            else {
                return repo.UpdateComment(comment);
            }
           
        }
        /// <inheritdoc/>
        public async Task<int> UpdateCommentAsync(Comment comment)
        {
            if (comment.Appointment == null)
            {
                return 0;
            }
            else
            {
                return await repo.UpdateCommentAsync(comment);
            }
        }

        /// <inheritdoc/>
        public int UpdateCommentDTO(CommentDTO commentDTO)
        {
            return UpdateComment(commentDTO.ToComment(repo));
        }

        /// <inheritdoc/>
        public async Task<int> UpdateCommentDTOAsync(CommentDTO commentDTO)
        {
            return await UpdateCommentAsync(commentDTO.ToComment(repo));
        }

    }
}
