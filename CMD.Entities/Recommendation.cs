using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Doctor RecommendedDoctor { get; set; }
    }
}
