using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    /// <summary>
    /// Data Transfer Object Class to Map the Appointment table in database to AppointmentDTO class
    /// </summary>
    public class AppointmentDTO
    {
        public int id { get; set; }
        public string patient_name { get; set; }
        public int patient_age { get; set; }
        public int patient_id { get; set; }
        public int doctor_id { get; set; }
        public string doctor_name { get; set; }
        public string appointment_date { get; set; }
        public string appointment_time { get; set; }
        public string appointment_status { get; set; }
        public string patient_issue { get; set; }
    }
}
