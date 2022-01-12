using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    /// <summary>
    /// Implementation of Vitals Service to Get and Update Vitals
    /// </summary>
    public class VitalsService : IVitalsService
    {
        IVitalRepository repo = null;
        //public VitalsService()
        //{
        //    this.repo = new VitalRepository();
        //}
        public VitalsService(IVitalRepository vitalRepository)
        {
            this.repo = vitalRepository;
        }

        #region Get Vital Service Methods



        #region Extra Methods Implementation
        /// <summary>
        ///                 To Get All Vitals of type VitalDTO
        /// </summary>
        /// <returns></returns>
        public List<VitalDTO> GetAllVitalsDTO()
        {
            List<Vital> vitals = repo.getAllVitals();
            List<VitalDTO> vitalsdto = new List<VitalDTO>();
            foreach (var v in vitals)
            {
                VitalDTO vital = v.ToVitalDTO();
                vitalsdto.Add(vital);
            }
            return vitalsdto;
        }
        public List<Vital> GetAllVitals()
        {
            return repo.getAllVitals();
        }
        #endregion

        /// <summary>
        /// To Get vital of type VitalDTO by Appointment Id as param
        /// </summary>
        /// <param name="appointment_id">Takes One of type Int </param>
        /// <returns>Vital object of type VitalDTO</returns>
        public VitalDTO GetVitalDTOByAppointmentId(int appointment_id)
        {
            VitalDTO vitaldto = null;
            Vital vital = repo.getVitalByAppointmentId(appointment_id);
            if(vital != null)
            {
                vitaldto = vital.ToVitalDTO();
            }
            
            return vitaldto;
        }

        /// <summary>
        ///     Returns Object of Type Vital for the corresponding Appointment Id
        /// </summary>
        /// <param name="appointment_id"></param>
        /// <returns>Oject of type Vital if found else null </returns>
        public Vital GetVitalByAppointmentId(int appointment_id)
        {
            Vital vital = repo.getVitalByAppointmentId(appointment_id);
            return vital;
        }


        #region Extra Method Implementation
        public VitalDTO GetVitalDTOByVitalId(int vital_id)
        {
            VitalDTO vitaldto = null;
            Vital vital = repo.getVitalById(vital_id);
            if (vital != null)
            {
                vitaldto = vital.ToVitalDTO();
            }
            return vitaldto;
        }

        public Vital GetVitalByVitalId(int vital_id)
        {
            return repo.getVitalById(vital_id);
        }
        #endregion

        #endregion



        #region Update Vital Service Method
        /// <summary>
        /// To Update an Existing Vital info in the database
        /// </summary>
        /// <param name="vital"></param>
        /// <returns>The Number of Rows Affected for Current Update </returns>
        public int UpdateVital(Vital vital)
        {
            return repo.updateVital(vital);
        }

        #endregion
    }
}
