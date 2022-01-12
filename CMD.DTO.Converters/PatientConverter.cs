using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.Converters
{
    public static class PatientConverter
    {
        /// <summary>
        /// Converts the patient object to patientDTO object
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>Returns PatientDTO</returns>
        public static PatientDTO ToPatientDTO(this Patient patient)
        {
            PatientDTO patientDTO = new PatientDTO();
            patientDTO.id = patient.PatientId;
            patientDTO.patient_name = patient.Name;
            patientDTO.patient_phone_number = patient.PhoneNumber;
            patientDTO.patient_age = patient.Age;
            patientDTO.patient_gender = patient.Gender;
            patientDTO.patient_dob = patient.Dob;
            patientDTO.patient_height = patient.Height;
            patientDTO.patient_blood_group = patient.BloodGroup;
            patientDTO.patient_allergies = patient.Allergies;
            patientDTO.patient_active_issues = patient.ActiveIssues;
            patientDTO.patient_medical_problems = patient.MedicalProblems;
            patientDTO.patient_email_id = patient.Email;
            patientDTO.patient_profile_image = patient.ProfileImage;
            patientDTO.patient_state = patient.PatientLocation;
            return patientDTO;
        }
    }
}
