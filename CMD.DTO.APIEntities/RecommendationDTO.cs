using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    public class RecommendationDTO
    {
        public int id { get; set; }
        public int appointment_id { get; set; }
        public int recommended_doctor_id { get; set; }
        public string recommended_doctor_name { get; set; }
    }
}
