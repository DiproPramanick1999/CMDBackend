using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        [IntegerValidator(MinValue =1)]
        public int MedicineDuration { get; set; }
        public bool MedicineAfterFood { get; set; }
        [MinLength(5),MaxLength(5)]
        public string MedicineCycle { get; set; }
        [MaxLength(100)]
        public string MedicineInstruction { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
