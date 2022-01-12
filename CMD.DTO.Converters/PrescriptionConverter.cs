using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.Converters
{
    /// <summary>
    /// To Map Prescription to PrescriptionDTO
    /// To Map PrescriptionDTO to Prescription
    /// </summary>
    public static class PrescriptionConverter
    {
        /// <summary>
        /// Maps the PrescriptionDTO to Prescription
        /// </summary>
        /// <param name="prescriptionDTO">Passing PrescriptionDTO object as parameter</param>
        /// <returns>Object of type Prescription</returns>
        public static Prescription ToPrescription(this PrescriptionDTO prescriptionDTO, IPrescriptionRepository repo)
        {
            Prescription prescription = repo.GetPrescriptionById(prescriptionDTO.id);
            if (prescription == null)
            {
                prescription = new Prescription();
                //prescription.PrescriptionId = prescriptionDTO.id;      
                prescription.Appointment = repo.GetAppointmentByAppointmentId(prescriptionDTO.appointment_id);
            }
            prescription.MedicineAfterFood = prescriptionDTO.medicine_after_food;
            prescription.MedicineCycle = prescriptionDTO.medicine_cycle;
            prescription.MedicineDuration = prescriptionDTO.medicine_duration;
            prescription.MedicineInstruction = prescriptionDTO.medicine_description;
            prescription.MedicineName = prescriptionDTO.medicine_name;
            return prescription;
        }
        /// <summary>
        /// Maps the Prescription to PrescriptionDTO
        /// </summary>
        /// <param name="prescription">Passing Prescription object as parameter</param>
        /// <returns>Object of type PrescriptionDTO</returns>
        public static PrescriptionDTO ToPrescriptionDTO(this Prescription prescription)
        {
            if (prescription == null)
            {
                return null;
            }
            PrescriptionDTO dto = new PrescriptionDTO();
            dto.id = prescription.PrescriptionId;
            dto.appointment_id = prescription.Appointment.AppointmentId;
            dto.medicine_after_food = prescription.MedicineAfterFood;
            dto.medicine_cycle = prescription.MedicineCycle;
            dto.medicine_description = prescription.MedicineInstruction;
            dto.medicine_name = prescription.MedicineName;
            dto.medicine_duration = prescription.MedicineDuration;
            return dto;
        }
    }
}
