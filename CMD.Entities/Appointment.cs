using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    /// <summary>
    /// Entity Class for Appointment
    /// </summary>
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        [MinLength(3)]
        public string Status { get; set; }
        [Required]
        public virtual Doctor Doctor { get; set; }
        [Required]
        public virtual Patient Patient { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }
        public virtual List<Test> Tests { get; set; }
        public virtual Vital Vital { get; set; }
        public virtual List<Recommendation> Recommendations { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Feedback Feedback { get; set; }
        public Appointment()
        {
            Prescriptions = new List<Prescription>();
            Recommendations = new List<Recommendation>();
            Tests = new List<Test>();
        }

    }
}
