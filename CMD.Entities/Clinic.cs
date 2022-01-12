using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public Clinic()
        {
            Doctors = new List<Doctor>();
        }
    }
}
