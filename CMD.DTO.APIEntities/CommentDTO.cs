using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.APIEntities
{
    public class CommentDTO
    {
        public int id { get; set; }
        public string comment { get; set; }
        public int appointment_id { get; set; }
    }
}
