using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    public class PatientDTO
    {
        public int id { get; set; }
        public string patient_name { get; set; }
        public string patient_phone_number { get; set; }
        public int patient_age { get; set; }
        public string patient_gender { get; set; }
        public string patient_dob { get; set; }
        public string patient_height { get; set; }
        public string patient_blood_group { get; set; }
        public string patient_allergies { get; set; }
        public string patient_active_issues { get; set; }
        public string patient_medical_problems { get; set; }
        public string patient_email_id { get; set; }
        public string patient_profile_image { get; set; }
        public string patient_state { get; set; }
    }
}
