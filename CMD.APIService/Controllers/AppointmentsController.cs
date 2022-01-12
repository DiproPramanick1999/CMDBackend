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
    /// <summary>
    /// Enabling Cross-Origin Resource Sharing
    /// </summary>
    [EnableCors(origins: "*", headers:"*",methods:"*",PreflightMaxAge =60)]
    public class AppointmentsController : ApiController
    {
        private IAppointmentService appointmentService = null;
        #region CTOR
        //public AppointmentsController()
        //{
        //    this.appointmentService = new AppointmentService();
        //}
        #endregion
        #region IOC Unity
        /// <summary>
        /// Dependency inversion principle
        /// </summary>

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        #endregion
        #region GetAllAppointments EndPoint
        /// <summary>
        /// GET api/Appointments
        /// Get All Appointments
        /// </summary>
        /// <returns>List of appointmentDTOs or 404NotFound</returns>

        public IHttpActionResult GetAllAppointments()
        {
            List<AppointmentDTO> appointmentDTOs = appointmentService.GetAllAppointmentDTOs();
            var AllAppointments = appointmentService.GetAllAppointments();
            if (AllAppointments.Count > 0 && appointmentDTOs!=null)
            {
                return Ok(appointmentDTOs);
            }
            else
            {
                //return NotFound();
                return Ok(AllAppointments);
            }
            
        }
        #endregion
        #region GetAppointmentById EndPoint
        /// <summary>
        /// GET api/Appointments/id
        /// Get specific appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object AppointmentDTOs or 404NotFound</returns>
        public IHttpActionResult GetAppointmentById(int id)
        {
            var appointment = appointmentService.GetAppointmentById(id);
            if (appointment != null)
            {
                AppointmentDTO appointmentData = appointmentService.GetAppointmentByIdDTOs(id);
                return Ok(appointmentData);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion
        #region PostAppointment EndPoint
        /// <summary>
        /// POST api/Appointments
        /// Post AppointmentDTO
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>Either 201Created() or 500Internal Server Error</returns>
        public IHttpActionResult Post(AppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (appointment != null)
            {
                try
                {
                    if (appointmentService.SaveAppointmentDTOs(appointment))
                    {
                        return Created($"api/appointments", appointment);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch(Exception ex)
                {
                    return Content(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
        #region UpdateAppointment
        /// <summary>
        /// PUT api/Appointments/id or api/appointments
        /// PUT AppointmentDTO
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>Either 200 or Internal Server Error</returns>

        public IHttpActionResult Put(AppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (appointment != null)
            {
                try
                {
                    if (appointmentService.UpdateAppointmentDTOs(appointment))
                    {
                        return Created($"api/appointments", appointment);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    //return Content(HttpStatusCode.BadRequest, ex.Message);
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

    }
}