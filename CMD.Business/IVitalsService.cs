using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    /// <summary>
    /// Contract to Perform Retrieve and Update Operations on Vitals Table
    /// </summary>
    public interface IVitalsService
    {
        #region Extra Methods
        List<Vital> GetAllVitals();
        List<VitalDTO> GetAllVitalsDTO();
        #endregion

        #region Get Vital Service Methods
        VitalDTO GetVitalDTOByAppointmentId(int appointment_id);
        Vital GetVitalByAppointmentId(int appointment_id);

        #endregion
        
        #region Extra Methods
        VitalDTO GetVitalDTOByVitalId(int vital_id);
       
        Vital GetVitalByVitalId(int vital_id);
        #endregion


        #region Update Vital Service Method
        int UpdateVital(Vital vital);
        #endregion 
    }
}
