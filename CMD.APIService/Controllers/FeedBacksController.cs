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
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMD.APIService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", PreflightMaxAge = 60)]
    public class FeedBacksController : ApiController
    {
        //IFeedBackRepository repo;
        //public FeedBacksController()
        //{
        //    this.repo = new FeedBackRepository();
        //}
        IFeedBackRepository repo = new FeedBackRepository();
        private IFeedbackService feedbackService;
        //public FeedBacksController()
        //{
        //    this.feedbackService = new FeedbackService();
        //}
        #region IOC Unity
        public FeedBacksController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }
        #endregion
        #region GetAllFeedback Endpoint
        // GET api/feedbacks
        public IHttpActionResult Get()
        {
            List<FeedbackDTO> list=feedbackService.GetFeedbackDTOs();

            if (list != null)
            {
                
                return Ok(list);
            }

            return NotFound();
        }
        #endregion
        #region GetFeedbackById
        // GET api/feedbacks/5
        public IHttpActionResult GetById(int id)
        {
            Feedback feedback = feedbackService.GetFeedbackById(id);
            
            if (feedback == null)
            {
                return NotFound();
            }

            else
            {
                FeedbackDTO fm = feedbackService.GetFeedbackByIdDTOs(id);
                return Ok(fm);
            }
        }
        #endregion
        #region UpdateFeedback endpoint
        [HttpPut]
        public IHttpActionResult PutFeedback(FeedbackDTO dto)
        {
            //Feedback feedback = dto.ToFeedback(repo);
            if (dto != null)
            {

                try
                {
                    int cnt = feedbackService.UpdateFeedbackDTO(dto);
                    if (cnt > 0)
                        return Created("api/feedbacks", dto);
                }

                catch(Exception ex)
                {
                    return BadRequest();
                }
                
            }
            return BadRequest();
        }
        #endregion

    }
}