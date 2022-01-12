using CMD.Business;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMD.UnitTests
{
    /// <summary>
    /// Summary description for AppointmentsServiceUnitTest
    /// </summary>
    [TestClass]
    public class AppointmentsServiceUnitTest
    {
        IAppointmentService service = null;
        Mock<IAppointmentRepository> appRepoMock;
        List<Appointment> appointments;
        List<AppointmentDTO> appointmentDTOs;
        AppointmentDTO appDTO;
        Appointment app;
        [TestInitialize]
        public void Initialize()
        {
            
            appRepoMock = new Mock<IAppointmentRepository>();
            service = new AppointmentService(appRepoMock.Object);
            appointments = new List<Appointment>();
            appointments.Add(
                new Appointment
                {
                    AppointmentId = 1,
                    Status = "Pending",
                    Date = "12:34",
                    Doctor = new Doctor { Name = "D1" },
                    Patient = new Patient { Name = "P1" },
                    Time = "12:12"
                });
            appointmentDTOs = new List<AppointmentDTO>();
            appointmentDTOs.Add(
                new AppointmentDTO
                {
                    id = 1,
                    appointment_status = "new status",
                    appointment_date = "new date",
                    doctor_id = 1,
                    patient_id = 1,
                    appointment_time = "12:12",
                    patient_issue = "jshdhiw",
                    doctor_name = "d1",
                    patient_age = 22,
                    patient_name = "p1"
                });
            appDTO = new AppointmentDTO
            {
                id = 1,
                appointment_status = "new status",
                appointment_date = "new date",
                doctor_id = 1,
                patient_id = 1,
                appointment_time = "12:12",
                patient_issue = "jshdhiw",
                doctor_name = "d1",
                patient_age = 22,
                patient_name = "p1"

            };

            app = new Appointment()
            {
                AppointmentId = 1,
                Status = "Pending",
                Date = "12:34",

                Doctor = new Doctor { Name = "d1", DoctorId = 1 },
                Patient = new Patient { Name = "p1", PatientId = 1 },
            };
        }
        [TestCleanup]
        public void Uninitialize()
        {
            service = null;
            appRepoMock = null;
            appointments = null;
            appointmentDTOs = null;
            app = null;
            appDTO = null;
        }

        [TestMethod]
        public void GetTest_GetAllAppointmentDTOs_ShouldReturnDTOs()
        {
            //Arrange
            appRepoMock.Setup(s => s.GetAllAppointments()).Returns(appointments);
            var appointmentService = new AppointmentService(appRepoMock.Object);
            //Act
            var res = service.GetAllAppointmentDTOs();
            //Assert
            Assert.IsInstanceOfType(res,typeof(List<AppointmentDTO>));
        }
        [TestMethod]
        public void getTest_WithAppointmentId_ShouldReturnAppointmentDTOObject()
        {
            //Arrange
            appRepoMock.Setup(s => s.GetAppointmentById(1)).Returns(app);
            var AppService = new AppointmentService(appRepoMock.Object);
            //Act
            var result = AppService.GetAppointmentByIdDTOs(1);
            //Assert
            Assert.IsInstanceOfType(result, typeof(AppointmentDTO));
        }
        [TestMethod]
        public void putTest_WithValidAppointment_ShouldReturntrue()
        {
            appRepoMock.Setup(s => s.UpdateAppointment(It.IsAny<Appointment>())).Returns(true);
            var AppService = new AppointmentService(appRepoMock.Object);
            var result = AppService.UpdateAppointmentDTOs(appDTO);
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void putTest_WithInvalidAppointment_ShouldReturnBadRequest()
        {
            appRepoMock.Setup(s => s.UpdateAppointment(It.IsAny<Appointment>())).Returns(false);
            var AppService = new AppointmentService(appRepoMock.Object);
            var result = AppService.UpdateAppointmentDTOs(appDTO);
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void postTest_WithValidAppointment_ShouldReturntrue()
        {
            //Arrange
            appRepoMock.Setup(s => s.SaveAppointment(It.IsAny<Appointment>())).Returns(true);
            var AppService = new AppointmentService(appRepoMock.Object);
            //Act
            var result = AppService.SaveAppointmentDTOs(appDTO);
            //Assert
            Assert.AreEqual(result, true);
        }

    }
}
