using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Patient 
    {
        public int PatientId { get; set; }
  
        public string Name { get; set; }
    
        public string Email { get; set; }
   
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
   
        public int Age { get; set; }
    
        public string Dob { get; set; }
 
        public string Gender { get; set; }

        public string Height { get; set; }
     
        public string BloodGroup { get; set; }
  
        public string Allergies { get; set; }
     
        public string ActiveIssues { get; set; }
  
        public string MedicalProblems { get; set; }
        public string PatientLocation { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        public Patient()
        {
            Appointments = new List<Appointment>();
        }

    }
}
