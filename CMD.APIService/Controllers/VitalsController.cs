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
    [EnableCors(origins:"*",headers:"*", methods:"*",PreflightMaxAge =60)]
    public class VitalsController : ApiController
    {
        IVitalsService service = null;
        //public VitalsController()
        //{
        //    service = new VitalsService();
        //}

        #region IOC Unity
        public VitalsController(IVitalsService vitalsService)
        {
            service = vitalsService;
        }
        #endregion

        #region Extra Endpoint
        // GET: /api/vitals
        public List<VitalDTO> GetAllVitals()
        {
            return service.GetAllVitalsDTO();
        }
        #endregion

        #region Endpoint for GET Vital By ID
        // GET : /api/vitals/id
        public IHttpActionResult GetVitalsById(int id)
        {
            //repo.getVitalByAppointmentId(id);
            VitalDTO vital = service.GetVitalDTOByAppointmentId(id);

            if(vital != null)
            {
                return Ok(vital);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, $"No Vital Info found for Appointment Id = {id}");
            }
        }
        #endregion


        #region Endpoint for PUT
        // PUT : api/vitals
        [HttpPut]
        public IHttpActionResult UpdateVitals(VitalDTO vital)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }
            else
            {
                Vital v = service.GetVitalByAppointmentId(vital.appointment_id); 
               if(v != null)
                {
                    if(v.VitalId == vital.id)
                    {
                        v = vital.ToVital(v);
                       
                        int count = 0;
                        try
                        {
                            count = service.UpdateVital(v);
                        }
                        catch(Exception ex)
                        {
                            return Content(HttpStatusCode.BadRequest, ex.Message);
                        }
                        
                        if (count > 0)
                        {
                            return Created("api/vitals", vital);
                        }
                        else
                        {
                            //return Content(HttpStatusCode.BadRequest, $"Invalid Vitals Data"); ------  CHANGED------------------
                            return InternalServerError();
                        }
                    }
                    else
                    {
                        return Content(HttpStatusCode.Conflict, $"Vital Id  = {vital.id} don't match for Appointment Id = {vital.appointment_id}");
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"No Vital Info found for Appointment Id = {vital.appointment_id}");
                }
            }


        }
        #endregion
    }
}
