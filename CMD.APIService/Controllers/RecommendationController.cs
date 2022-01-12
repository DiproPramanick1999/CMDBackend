using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.Entities;
using CMD.Exceptions;
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
    [RoutePrefix("api/recommendation")]
    public class RecommendationController : ApiController
    {
        private IRecommendationService recommendationService = null;
        //public RecommendationController()
        //{
        //    this.recommendationService = new RecommendationService();
        //}
        public RecommendationController(IRecommendationService recommendationService)
        {
            this.recommendationService = recommendationService;
        }

        #region Synchronous
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<RecommendationDTO> recommendationDTOs = recommendationService.GetRecommendationDTOs();
            return Ok(recommendationDTOs);
        }

        // GET api/<controller>/5
        [Route("{recommendationId:int}")]
        public IHttpActionResult Get(int recommendationId)
        {
            RecommendationDTO recommendationDTO = recommendationService.GetRecommendationDTOById(recommendationId);
            if (recommendationDTO == null)
            {
                return Content(HttpStatusCode.NotFound, "No recommendation with given recommendationId found.");
            }
            return Ok(recommendationDTO);
        }

        // GET api/<controller>/appointment/5
        [Route("appointment/{appointmentId:int}")]
        public IHttpActionResult GetRecommendationsByAppointmentId(int appointmentId)
        {
            try
            {
                List<RecommendationDTO> recommendationDTOs = recommendationService.GetRecommendationDTOsByAppointmentId(appointmentId);
                return Ok(recommendationDTOs);
            }
            catch (AppointmentNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post(RecommendationDTO recommendationDTO)
        {
            try
            {
                if (recommendationService.SaveRecommendationDTO(recommendationDTO) > 0)
                {
                    return Created("api/recommendation", recommendationDTO);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (DuplicateRecommendationRecordException e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            catch (AppointmentNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (DoctorNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }

        //// PUT api/<controller>/5
        //public IHttpActionResult Put(int id, [FromBody] string value)
        //{
        //    return StatusCode(HttpStatusCode.NotImplemented);
        //}

        // DELETE api/<controller>/5
        [Route("{recommendationId:int}")]
        public IHttpActionResult Delete(int recommendationId)
        {
            try
            {
                RecommendationDTO testDTO = recommendationService.GetRecommendationDTOById(recommendationId);
                if (testDTO == null)
                {
                    throw new RecommendationNotFoundException();
                }
                if (recommendationService.DeleteRecommendationById(recommendationId) > 0)
                {
                    return Ok(testDTO);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (RecommendationNotFoundException e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }
        #endregion
        #region Asynchronous
        #endregion
    }
}