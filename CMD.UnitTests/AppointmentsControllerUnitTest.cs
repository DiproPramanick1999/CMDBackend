using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CMD.Entities;
using Moq;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using CMD.DTO.Converters;
using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;

namespace CMD.UnitTests
{
    /// <summary>
    /// Summary description for AppointmentsControllerUnitTest
    /// </summary>
    [TestClass]
    public class AppointmentsControllerUnitTest
    {
        AppointmentsController controller = null;
        Mock<IAppointmentService> appMock;
        AppointmentDTO appDTO;
        Appointment app;
        AppointmentDTO appDTOInvalid;
        List<AppointmentDTO> appointments;
        List<Appointment> apps;
        [TestInitialize]
        public void Initialize()
        {
            appMock = new Mock<IAppointmentService>();
            controller = new AppointmentsController(appMock.Object);
            
            appDTO = new AppointmentDTO
            {
                id=2,
                appointment_status = "accepted",
                appointment_date = "12:23",
                doctor_id = 1,
                patient_id = 1,
                appointment_time = "12:30",
                patient_issue = "jshdhiw",
                doctor_name = "d1",
                patient_age = 22,
                patient_name = "p1"
            };
            appDTOInvalid = new AppointmentDTO
            {
                id=4,
                appointment_status = "accepted",
                appointment_date = null,
                doctor_id = 1,
                patient_id = 1,
                appointment_time = "12:30",
                patient_issue = "jshdhiw",
                doctor_name = "d1",
                patient_age = 22,
                patient_name = "p1"

            };
            app = new Appointment()
            {
                AppointmentId = 1,
                Status = "Pending",
                Date = "12:34"
            };
            appointments = new List<AppointmentDTO>();
            appointments.Add(
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
            apps = new List<Appointment>();
            apps.Add(
                new Appointment
                {
                    AppointmentId = 1,
                    Status = "Pending",
                    Date = "12:34",
                    Doctor = new Doctor { Name = "D1" },
                    Patient = new Patient { Name = "P1" },
                    Time = "12:12"
                });
        }
        [TestCleanup]
        public void Uninitialize()
        {
            controller = null;
            appMock = null;
            appDTO = null;
            app = null;
            apps = null;
            appointments = null;
            appDTOInvalid = null;

        }

        [TestMethod]
        public void GetTest_WithExistingId_ShouldReturnAppointmentObject()
        {  
            //Arrange
            appMock.Setup(service => service.GetAppointmentByIdDTOs(1)).Returns(appDTO);
            appMock.Setup(service => service.GetAppointmentById(1)).Returns(app);
            //var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.GetAppointmentById(1) as OkNegotiatedContentResult<AppointmentDTO>;
            //Assert
            Assert.IsNotNull(res);
        }
        [TestMethod]

        public void GetTest_WithInvalidId_ShouldReturnBadRequest()
        {
            //Arrange
            appMock.Setup(service => service.GetAppointmentByIdDTOs(1)).Returns(appDTO);
            appMock.Setup(service => service.GetAppointmentById(1)).Returns(app);
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.GetAppointmentById(100);
            //Assert
            Assert.IsInstanceOfType(res, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostTest_WithInValidAppointmentData_ShouldReturnBadRequest()
        {
            //Arrange
            AppointmentDTO app = null;
            appMock.Setup(service => service.UpdateAppointmentDTOs(It.IsAny<AppointmentDTO>())).Returns(true);
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Post(app);
            //Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PostTest_WithValidAppointmentData_ShouldAdd()
        {
            //Arrange
            appMock.Setup(service => service.SaveAppointmentDTOs(It.IsAny<AppointmentDTO>())).Returns(true);
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Post(appDTO) as CreatedNegotiatedContentResult<AppointmentDTO>;
            var addedAppointment = res.Content;
            //Assert
            Assert.AreEqual("accepted", addedAppointment.appointment_status);

        }
        [TestMethod]
        public void PostTest_WithInValidAppointmentData_ShouldNotAdd()
        {
            //Arrange
            appMock.Setup(service => service.SaveAppointmentDTOs(It.IsAny<AppointmentDTO>())).Returns(false);
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Post(appDTOInvalid);
            //Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }
        [TestMethod]
        public void PutTest_WithValidAppointmentData_ShouldUpdateAppointment()
        {
            //Arrange
            appMock.Setup(service => service.UpdateAppointmentDTOs(It.IsAny<AppointmentDTO>())).Returns(true);
            //var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Put(appDTO) as CreatedNegotiatedContentResult<AppointmentDTO>;
            var updatedAppointment = res.Content;
            //Assert
            Assert.AreEqual(2, updatedAppointment.id);
            Assert.AreEqual("accepted", updatedAppointment.appointment_status);
        }
        [TestMethod]
        public void PutTest_WithNullAppointmentData_ShouldReturnBadRequest()
        {
            //Arrange
            AppointmentDTO app = null;
            appMock.Setup(service => service.UpdateAppointmentDTOs(It.IsAny<AppointmentDTO>())).Returns(true);
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Put(app);
            //Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }
        [TestMethod]
        public void PutTest_WithInValidAppointmentData_ShouldReturnBadRequest()
        {
            //Arrange
            appMock.Setup(service => service.UpdateAppointmentDTOs(It.IsAny<AppointmentDTO>())).Returns(false);
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Put(appDTOInvalid);
            //Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetTest_WithAppointments_ShouldReturnListofAppointments()
        {
            //Arrange
            appMock.Setup(s => s.GetAllAppointmentDTOs()).Returns(appointments);
            appMock.Setup(s => s.GetAllAppointments()).Returns(apps);
            controller = new AppointmentsController(appMock.Object);
            //Act
            var result = controller.GetAllAppointments() as OkNegotiatedContentResult<List<AppointmentDTO>>;
            //Assert
            Assert.AreEqual(result.Content, appointments);
        }
        [TestMethod]
        public void GetTest_WithNoAppointments_ShouldReturnZeroCount()
        {
            //Arrange
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            List<Appointment> apps = new List<Appointment>();
            appMock.Setup(s => s.GetAllAppointmentDTOs()).Returns(appointments);
            appMock.Setup(s => s.GetAllAppointments()).Returns(apps);

            controller = new AppointmentsController(appMock.Object);
            //Act
            var result = controller.GetAllAppointments() as OkNegotiatedContentResult<List<Appointment>>;
            //Assert
            Assert.AreEqual(result.Content.Count, 0);
            //Assert.IsInstanceOfType(result, typeof(List<Appointment>));
        }
        [TestMethod]
        public void PostTest_WithInValidModelState()
        {
            //Arrange
            //var controller = new AppointmentsController();
            controller.ModelState.AddModelError("Error", "DateField Should not be null");
            //Act
            var res = controller.Post(appDTOInvalid) as BadRequestResult;
            //Assert
            Assert.AreEqual(false, controller.ModelState.IsValid);
        }
        [TestMethod]
        public void PutTest_WithInValidModelState()
        {
            //Arrange
            //var controller = new AppointmentsController();
            controller.ModelState.AddModelError("Error", "DateField Should not be null");
            //Act
            var res = controller.Put(appDTOInvalid) as BadRequestResult;
            //Assert
            Assert.AreEqual(false, controller.ModelState.IsValid);
        }
        [TestMethod]
        public void PostTest_WithException()
        {
            //Arrange
            appMock.Setup(service => service.SaveAppointmentDTOs(It.IsAny<AppointmentDTO>())).Throws(new Exception());
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Post(appDTOInvalid) as NegotiatedContentResult<string>;
            //Assert
            Assert.AreEqual(res.StatusCode, HttpStatusCode.BadRequest);
        }
        [TestMethod]
        public void PutTest_WithException()
        {
            //Arrange
            appMock.Setup(service => service.UpdateAppointmentDTOs(It.IsAny<AppointmentDTO>())).Throws(new Exception());
            var controller = new AppointmentsController(appMock.Object);
            //Act
            var res = controller.Put(appDTOInvalid);
            //Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }
    }
}
