using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    /// <summary>
    /// Helper class/interface which allows to have various operation on Appointment table
    /// </summary>
    public interface IAppointmentRepository
    {
        /// <summary>
        /// To get all the appointments from database
        /// </summary>
        /// <returns></returns>
        List<Appointment> GetAllAppointments();
        /// <summary>
        /// To get the specific appointment from database
        /// </summary>
        /// <param name="appointment_id"></param>
        /// <returns></returns>

        Appointment GetAppointmentById(int appointment_id);
        /// <summary>
        /// To Post/Save the appointment into the database
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        bool SaveAppointment(Appointment appointment);
        /// <summary>
        /// To Update the database with appointment table
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        bool UpdateAppointment(Appointment appointment);



        //delete afterwards
        Patient GetPatientById(int patient);
        Doctor GetDoctor(int id);
        bool SaveComment(Comment comment);
    }
}
