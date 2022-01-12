using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();
        List<AppointmentDTO> GetAllAppointmentDTOs();
        Appointment GetAppointmentById(int appointment_id);
        AppointmentDTO GetAppointmentByIdDTOs(int appointment_id);
        bool SaveAppointment(Appointment appointment);
        bool SaveAppointmentDTOs(AppointmentDTO appointmentDTO);
        bool UpdateAppointment(Appointment appointment);
        bool UpdateAppointmentDTOs(AppointmentDTO appointmentDTO);
    }
}
