using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
 
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
   
        public string Speciality { get; set; }
  
        [MaxLength(10)]
        public string NpiNo { get; set; }
 
        public string PracticeLocation { get; set; }
        //[Required]
        public virtual Clinic Clinic { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
    }
}
