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
    /// To Map Vital to VitalDTO and vice-versa
    /// </summary>
    public static class VitalConverters
    {
        /// <summary>
        /// Returns an Object of Type VitalDTO for the current Instance
        /// </summary>
        /// <param name="vital">Accepts object of type Vital</param>
        /// <returns>Object of type VitalDTO</returns>
        public static VitalDTO ToVitalDTO(this Vital vital)
        {
            VitalDTO vitaldto = new VitalDTO
            {
                id = vital.VitalId,
                appointment_id = vital.Appointment.AppointmentId,
                ecg = vital.ECG,
                temperature = vital.Temperature,
                diabetes = vital.Diabetes,
                respiration_rate = vital.RespirationRate
            };
            return vitaldto;
        }
        /// <summary>
        ///  Returns an Object of Type Vital for the current Instance
        /// </summary>
        /// <param name="vitaldto">Accepts Object of type Vitaldto</param>
        /// <param name="vital"></param>
        /// <returns></returns>
        public static Vital ToVital(this VitalDTO vitaldto, Vital vital)
        {
            vital.ECG = vitaldto.ecg;
            vital.Diabetes = vitaldto.diabetes;
            vital.Temperature = vitaldto.temperature;
            vital.RespirationRate = vitaldto.respiration_rate;
            return vital;
        }
    }
}
