using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    /// <summary>
    /// Depicts all the CRUD operations performed on Prescription Table
    /// Fetches the Appointment by Appointment ID from the Appointment Table
    /// </summary>
    public interface IPrescriptionRepository
    {
        #region Prescription Functions
        List<Prescription> GetPrescriptions();
        Prescription GetPrescriptionById(int id);
        Prescription SavePrescription(Prescription prescription);
        int EditPrescription(Prescription prescription);
        int DeletePrescription(int id);
        #endregion

        #region Appointment Function
        Appointment GetAppointmentByAppointmentId(int id);
        #endregion
    }
}
