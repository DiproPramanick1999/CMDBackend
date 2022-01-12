using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IPrescriptionService
    {
        /// <summary>
        /// Depicts all the CRUD operations performed on Prescription Table
        /// Fetches the Appointment by Appointment ID from the Appointment Table
        /// </summary>
        #region PrescriptionDTO functions
        List<PrescriptionDTO> GetPrescriptionDTOs();
        PrescriptionDTO GetPrescriptionDTOById(int id);
        PrescriptionDTO SavePrescriptionDTO(PrescriptionDTO prescriptionDTO);
        int EditPrescriptionDTO(PrescriptionDTO prescriptionDTO);
        #endregion

        #region Prescription functions
        List<Prescription> GetPrescriptions();
        Prescription GetPrescriptionById(int id);
        Prescription SavePrescription(Prescription prescription);
        int EditPrescription(Prescription prescription);
        int DeletePrescription(int id);
        #endregion

        #region Appointment function
        Appointment GetAppointmentByAppointmentId(int id);
        #endregion
    }
}
