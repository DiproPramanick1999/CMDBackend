using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    public class FeedbackDTO
    {
        public int id { get; set; }
        public int Question1 { get; set; }
        public int Question2 { get; set; }
        public int Question3 { get; set; }
        public int Question4 { get; set; }
        public string AddComment { get; set; }
        public int appointment_id { get; set; }
    }
}
