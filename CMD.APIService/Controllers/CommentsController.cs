using CMD.APIService.Models;
using CMD.Business;
using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
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
    [RoutePrefix("api/comments/")]
    [EnableCors(origins:"*",headers:"*",methods:"*",PreflightMaxAge =60)]
    public class CommentsController : ApiController
    {
        private ICommentService service;
        //public CommentsController()
        //{
        //    this.service = new CommentService();
        //}

        public CommentsController(ICommentService service)
        {
            this.service = service;
        }

        public IHttpActionResult Get()
        {
            List<CommentDTO> comments = service.GetCommentDTOs();
            return Ok(comments);
        }

        //get/api/comments/id
        public IHttpActionResult GetCommentByAppointmentId(int id)
        {
            CommentDTO comment = service.GetCommentDTOByAppointmentId(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound();
        }
        
        [HttpPut]
        public IHttpActionResult PutComment(CommentDTO dto)
        {
            if(dto != null)
            {
                try
                {
                    int cnt = service.UpdateCommentDTO(dto);
                    if (cnt > 0)
                        return Created("api/comments", dto);

                }
                catch(Exception e)
                {
                    return BadRequest();
                }
               
               
            }
            return BadRequest();
        }
    }
}
