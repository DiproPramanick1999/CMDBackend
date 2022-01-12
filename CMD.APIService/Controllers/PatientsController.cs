using CMD.DataAccess.ICMDRepository;
using CMD.DataAccess.CMDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMD.Entities;
using CMD.APIService.Models;
using CMD.DTO.APIEntities;
using CMD.Business;
using System.Web.Http.Cors;

namespace CMD.APIService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", PreflightMaxAge = 60)]
    public class PatientsController : ApiController
    {
        private IPatientService service = null;//new PatientService();
        public PatientsController(IPatientService patient)
        {
            service = patient;
        }
        public PatientsController()
        {
            service = new PatientService();
        }
        /// <summary>
        /// Returns all the patients if no patient found then returns not found
        /// GET /api/patients
        /// </summary>
        /// <returns>list of patientDTO </returns>
        public IHttpActionResult Get()
        {
            List<PatientDTO> patients = service.GetPatientDTOs();
            if(patients.Count>0)
            {
                return Ok(patients);
            }
            else
            {
                return NotFound();
            }
            
        }
        /// <summary>
        /// GET /api/patients/id.gets the patient of the sent id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>patientDTO object or 404 notfound</returns>
        public IHttpActionResult Get(int id)
        {
            PatientDTO patient = service.GetPatientDTOById(id);
            if (patient != null)
            {
                
                return Ok(patient);
            }
            else
            {
                return NotFound();
            }
            
        }

    }
}
