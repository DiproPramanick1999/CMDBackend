using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    /// <summary>
    /// Backing Entity class for Vitals Table in ConnectMyDoc Database
    /// </summary>
    public class Vital
    {
        public int VitalId { get; set; }
        [Range(0, 160)]
        public float ECG { get; set; }
        [Range(0, 50)]
        public float Temperature { get; set; }
        [Range(0, 500)]
        public float Diabetes { get; set; }
        [Range(0, 30)]
        public float RespirationRate { get; set; }
        [Required]
        public virtual Appointment Appointment { get; set; }
    }
}
