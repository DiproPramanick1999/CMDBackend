using CMD.Business;
using CMD.DTO.APIEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMD.APIService.Controllers
{
    [RoutePrefix("api/commentsAsync/")]
    [EnableCors(origins: "*", headers: "*", methods: "*", PreflightMaxAge = 60)]
    public class CommentsAsyncController : ApiController
    {
        private ICommentService service;
        //public CommentsAsyncController()
        //{
        //    this.service = new CommentService();
        //}
        public CommentsAsyncController(ICommentService service)
        {
            this.service = service; 
        }
        public async Task<IHttpActionResult> Get()
        {
            List<CommentDTO> comments =await service.GetCommentDTOsAsync();
            return Ok(comments);
        }

        //get/api/comments/id
        public async Task<IHttpActionResult> GetCommentByAppointmentId(int id)
        {
            CommentDTO comment = await service.GetCommentDTOByAppointmentIdAsync(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutComment(CommentDTO dto)
        {
            if (dto != null)
            {
                try
                {
                    int cnt = await service.UpdateCommentDTOAsync(dto);
                    if (cnt > 0)
                        return Created("api/comments", dto);

                }
                catch (Exception e)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }
    }
}
