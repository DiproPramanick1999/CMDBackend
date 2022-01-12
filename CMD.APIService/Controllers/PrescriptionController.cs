using CMD.Business;
using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
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
    //Enabling Cors to avoid server error when integrated with front-end
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/prescription")]
    public class PrescriptionController : ApiController
    {
        //By using DIP
        private IPrescriptionService service = null;
        public PrescriptionController()
        {
            this.service = new PrescriptionService();
        }
        public PrescriptionController(IPrescriptionService service)
        {
            this.service = service;
        }
        // GET: api/prescription
        /// <summary>
        /// Api call returns all the prescriptionDTOs available in the database
        /// </summary>
        /// <returns>
        /// Returns Ok result if all the prescriptionDTOs are fetched
        /// IF the prescriptionDTO object is null, Not Found Result is returned
        /// </returns>
        public IHttpActionResult GetPrescriptions()
        {
            List<PrescriptionDTO> prescriptionsDTO = service.GetPrescriptionDTOs();
            if (prescriptionsDTO == null)
            {
                return NotFound();
            }
            return Ok(prescriptionsDTO);
        }

        // GET api/prescription/id
        /// <summary>
        /// Finds the prescription of a particular prescriptionDTO id
        /// </summary>
        /// <param name="id">int id is sent as a paramter</param>
        /// <returns>
        /// Returns Ok result if prescriptionDTO matches the integer prescriptionId
        /// If there is no prescriptionDTO of the following id is found, then a Not Found result is returned.
        /// </returns>
        public IHttpActionResult GetPrescriptionById(int id)
        {
            PrescriptionDTO p = service.GetPrescriptionDTOById(id);
            if (p != null)
            {
                return Ok(p);    
            }
            else
            { 
                return NotFound();
            }
        }


        // POST api/prescription
        /// <summary>
        /// Adds a prescriptionDTO which has a valid model state and has existing appointment id
        /// <param name="prescriptionDTO">Object PrescriptionDTO is passed as parameter</param>
        /// <returns>
        /// If model state is not valid, it returns a Bad Request result
        /// If appointment id does not exist, it returns a Not Found result
        /// If prescriptionDTO is null, it returns a Bad Request result
        /// </returns>
        [HttpPost]
        public IHttpActionResult AddPrescription(PrescriptionDTO prescriptionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (prescriptionDTO != null)
            {
                if (service.GetAppointmentByAppointmentId(prescriptionDTO.appointment_id) == null)
                {
                    return NotFound();
                }
                else
                {
                    PrescriptionDTO dtoResponse = service.SavePrescriptionDTO(prescriptionDTO);
                    if ( dtoResponse!= null)
                    {
                        return Created($"api/prescription",dtoResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return BadRequest();
            }
            

        }
        // PUT api/prescription
        /// <summary>
        /// Updates the values of the existing prescriptionDTOs by passing the prescriptionDTO object as parameter
        /// </summary>
        /// <param name="prescriptionDTO">Accepts Object PrescriptionDTO as parameter</param>
        ///<returns>
        /// If model state is not valid, it returns a Bad Request result
        /// If appointment id or prescriptionDTO id does not exist, it returns a Not Found result
        /// If edit prescriptionDTO method returns 0, we get a Internal Server result.
        /// If prescriptionDTO is null, it returns a Bad Request result
        /// </returns>

        [HttpPut]
        public IHttpActionResult UpdatePrescription(PrescriptionDTO prescriptionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (prescriptionDTO != null)
            {
                if (service.GetAppointmentByAppointmentId(prescriptionDTO.appointment_id) == null || service.GetPrescriptionDTOById(prescriptionDTO.id)==null)
                {
                    return NotFound();
                }

                else
                {
                    if (service.EditPrescriptionDTO(prescriptionDTO) > 0)
                    {
                        return Created($"api/prescription", prescriptionDTO);
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
            }
            else
            {
                return BadRequest();
            }
            
        }

        // DELETE api/prescription/id
        /// <summary>
        /// Deletes the prescriptionDTO by accesing it from the prescriptionDTO id that is sent as parameter
        /// </summary>
        /// <param name="id">Accept int id as parameter</param>
        /// <returns>
        /// If prescriptionDTO id exists, it returns a Ok Result with a message saying "Successfully Deleted!"
        /// If prescriptionDTO id does not exist, it returns a Not Found result
        /// </returns>

        [HttpDelete]
        public IHttpActionResult DeletePrescription(int id)
        {
            int count = service.DeletePrescription(id);
            if (count > 0)

                return Ok("Successfully Deleted!");
            else
                return NotFound();
        }
    }
}