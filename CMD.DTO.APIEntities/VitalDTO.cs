using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    /// <summary>
    /// Data Transfer Object Class To Map the Data base vitals table to VitalDTO class
    /// </summary>
    public class VitalDTO
    {
        public int id { get; set; }
        public int appointment_id { get; set; }
        public float ecg { get; set; }
        public float temperature { get; set; }
        public float diabetes { get; set; }
        public float respiration_rate { get; set; }
    }
}
