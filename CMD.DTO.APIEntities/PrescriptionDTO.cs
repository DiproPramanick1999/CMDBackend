using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    /// <summary>
    /// Data Transfer Object Class To Map the Prescription Table in the Database to the PrescriptionDTO Class
    /// </summary>
    public class PrescriptionDTO
    {
        public int id { get; set; }
        public string medicine_name { get; set; }
        [Range(1,30)]
        public int medicine_duration { get; set; }
        [MinLength(5),MaxLength(5)]
        public string medicine_cycle { get; set; }
        public bool medicine_after_food { get; set; }
        [MinLength(1), MaxLength(100)]
        public string medicine_description { get; set; }
        public int appointment_id { get; set; }
    }
}
