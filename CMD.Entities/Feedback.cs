using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        [Range(0,5)]
        public int Question1 { get; set; }
        [Range(0,5)]
        public int Question2 { get; set; }
        [Range(0,5)]
        public int Question3 { get; set; }
        [Range(0,5)]
        public int Question4 { get; set; }
        public string AddComment { get; set; }
        [Required]
        public virtual Appointment Appointment { get; set; }

    }
}
