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
    public class DoctorsController : ApiController
    {
        private IDoctorService doctorService = null;
        public DoctorsController(IDoctorService doctorService)
        {
            this.doctorService =doctorService;
        }

        public DoctorsController()
        {
            this.doctorService = new DoctorService();
        }

        public IHttpActionResult Get()
        {
            List<DoctorDTO> doctorDTOs = doctorService.GetAllDoctorDTOs();

            if (doctorDTOs != null)
            {
                return Ok(doctorDTOs);
            }
            else
            {
                return NotFound();
            }
        }



        [Route("api/doctors/{id:int}/")]
        public IHttpActionResult GetDoctorById(int id)
        {
            DoctorDTO doctorData = doctorService.GetDoctorByIdDTOs(id);
            if (doctorData != null)
            {

                return Ok(doctorData);
            }
            else
            {
                return NotFound();
            }



        }

        [Route("api/doctors/{email}/")]
        public IHttpActionResult GetDoctorByEmail(string email)
        {
            var doctor = doctorService.GetDoctorByEmailDTO(email);
            if (doctor != null)
            {
                return Ok(doctor);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult PutDoctor(DoctorDTO doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            int count = doctorService.UpdateDoctorDTOs(doctor);
            if (count > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}