using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    public class DoctorDTO
    {
        public int id { get; set; }
        public string doctor_name { get; set; }
        public string doctor_email_id { get; set; }
        public string doctor_phone_number { get; set; }
        public string doctor_speciality { get; set; }
        public string doctor_npi_no { get; set; }
        public string doctor_practice_location { get; set; }
        public string doctor_profile_image { get; set; }
        public int clinic_id { get; set; }
    }
}
