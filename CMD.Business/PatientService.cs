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
    public class PatientService:IPatientService
    {
        IPatientRepository PatientRepo = null;
        public PatientService()
        {
            PatientRepo = new PatientRepository();
        }
        public PatientService(IPatientRepository patientRepository)
        {
            PatientRepo=patientRepository;
        }
        /// <summary>
        /// Returns all the patients objects
        /// </summary>
        /// <returns>Returns list of patients</returns>
        public List<PatientDTO> GetPatientDTOs()
        {
            List<PatientDTO> patientDTOs = new List<PatientDTO>();
            var patients = PatientRepo.GetPatients();
            foreach(var item in patients)
            {
                PatientDTO patientDTO = item.ToPatientDTO();
                patientDTOs.Add(patientDTO);
            }

            return patientDTOs;
        }
        /// <summary>
        /// Returns the patient with the sent id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns patientDTO Object matching id</returns>
        public PatientDTO GetPatientDTOById(int id)
        {
            var patient = PatientRepo.GetPatientById(id);
            if (patient == null)
            {
                return null;
            }
            PatientDTO patientDTO = patient.ToPatientDTO();
            return patientDTO;
        }
    }
}
