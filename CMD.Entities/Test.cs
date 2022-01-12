using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Test
    {
        public int TestId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual Appointment Appointment { get; set; }
    }
}
