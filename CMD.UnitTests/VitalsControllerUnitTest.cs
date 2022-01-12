using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace CMD.UnitTests
{
    [TestClass]
    public class VitalsControllerUnitTest
    {
        [TestMethod]
        public void GetAllVitals_ShouldReturnTheListOfVitalsInfo()
        {
            // Arrange

            List<VitalDTO> vitalDTO = new List<VitalDTO>();
            VitalDTO vital = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };
            vitalDTO.Add(vital);
            var vitalServiceMock = new Mock<IVitalsService>();
            vitalServiceMock.Setup(service => service.GetAllVitalsDTO()).Returns(vitalDTO);
            var controller = new VitalsController(vitalServiceMock.Object);
            //Act
            var result = controller.GetAllVitals() as List<VitalDTO>;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(vitalDTO, result);

        }
        [TestMethod]
        public void GetVitalByExistentAppointmentId_ShouldReturnOkWithVitalInfo()
        {
            // Arrange
            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };
            var vitalServiceMock = new Mock<IVitalsService>();
            vitalServiceMock.Setup(service => service.GetVitalDTOByAppointmentId(It.IsAny<int>())).Returns(vitalDTO);
            var controller = new VitalsController(vitalServiceMock.Object);
            //Act
            var result = controller.GetVitalsById(1) as OkNegotiatedContentResult<VitalDTO>;
            //Assert
            Assert.IsNotNull(result);
            
            Assert.AreEqual(vitalDTO, result.Content);

        }

        [TestMethod]
        public void GetVitalByNonExistentAppointmentId_ShouldReturnNotFound()
        {
            // Arrange
            var vitalServiceMock = new Mock<IVitalsService>();
            vitalServiceMock.Setup(service => service.GetVitalDTOByAppointmentId(It.IsAny<int>())).Returns((VitalDTO)null);
            var controller = new VitalsController(vitalServiceMock.Object);
            //Act
            var result = controller.GetVitalsById(1) as NegotiatedContentResult<string>;
            //Assert
             Assert.IsNotNull(result);
             Assert.AreEqual(HttpStatusCode.NotFound,result.StatusCode);
            Assert.AreEqual("No Vital Info found for Appointment Id = 1", result.Content);

        }

        [TestMethod]
        public void UpdateVitals_ForAllInvalidVitalData_ShouldNotUpdateTheVitalInfo()
        {
            
            // Arrange
            var vitalServiceMock = new Mock<IVitalsService>();
            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = -1, diabetes = 0, respiration_rate = 0, temperature = 0 };
            vitalServiceMock.Setup(service => service.UpdateVital(It.IsAny<Vital>())).Throws(new Exception());
            vitalServiceMock.Setup(service => service.GetVitalByAppointmentId(It.IsAny<int>())).Returns(new Vital() { VitalId = 1, ECG = 72, Diabetes = 120, RespirationRate = 18, Temperature = 37.6f });
            //Act
            var controller = new VitalsController(vitalServiceMock.Object);
            var actionResult = controller.UpdateVitals(vitalDTO) as NegotiatedContentResult<string>;
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, actionResult.StatusCode);

        }
        [TestMethod]
        public void TestForInavlidModelState_ShouldNotUpdateTheVitalInfo()
        {
            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };
            var controller = new VitalsController(null);
            controller.ModelState.AddModelError("Test", "Invalid Vital Model State");
            var actionresult = controller.UpdateVitals(vitalDTO) as BadRequestResult;
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(controller.ModelState.IsValid, false);
        }
        [TestMethod]
        public void UpdateVitals_WithCorrectValues_ShouldUpdateTheVitals()
        {
            // Arrange
            var vitalServiceMock = new Mock<IVitalsService>();
            vitalServiceMock.Setup(service => service.UpdateVital(It.IsAny<Vital>())).Returns(1);
            vitalServiceMock.Setup(service => service.GetVitalByAppointmentId(It.IsAny<int>())).Returns(new Vital() { VitalId = 1, Diabetes=100, ECG=67, RespirationRate=16, Temperature=36.4f });
      
            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };
            var vitalsController = new VitalsController(vitalServiceMock.Object);
            // Act
            var actionResult = vitalsController.UpdateVitals(vitalDTO) as CreatedNegotiatedContentResult<VitalDTO>;
            var updatedVital = actionResult.Content;
            // Assert:
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(1, updatedVital.id);
            Assert.AreEqual(72, updatedVital.ecg);
            Assert.AreEqual(120, updatedVital.diabetes);
        }

        [TestMethod]
        public void TestForUpdateVitals_WhenDbReturnsCountAs0_ShouldGiveInternalServerError()
        {
            // Arrange
            var vitalServiceMock = new Mock<IVitalsService>();
            vitalServiceMock.Setup(service => service.UpdateVital(It.IsAny<Vital>())).Returns(0);
            vitalServiceMock.Setup(service => service.GetVitalByAppointmentId(1)).Returns(new Vital() { VitalId = 1, Diabetes = 100, ECG = 67, RespirationRate = 16, Temperature = 36.4f });

            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };
            var vitalsController = new VitalsController(vitalServiceMock.Object);
            // Act
            var actionResult = vitalsController.UpdateVitals(vitalDTO) as InternalServerErrorResult;
            // Assert:
            Assert.IsNotNull(actionResult);
           
        }
        
        [TestMethod]
        public void UpdateVitals_ForNonMatchingVitalId_ShouldNotUpdateTheVitalInfo()
        {
            // Arrange
            var vitalServiceMock = new Mock<IVitalsService>();
            vitalServiceMock.Setup(service => service.UpdateVital(It.IsAny<Vital>())).Returns(0);
            vitalServiceMock.Setup(service => service.GetVitalByAppointmentId(It.IsAny<int>())).Returns(new Vital() { VitalId = 2, Diabetes = 100, ECG = 67, RespirationRate = 16, Temperature = 36.4f });

            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };

            //ACT
            
            var controller = new VitalsController(vitalServiceMock.Object);
            IHttpActionResult result = controller.UpdateVitals(vitalDTO);
            var actionResult = result as NegotiatedContentResult<string>;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Conflict, actionResult.StatusCode);
            Assert.AreEqual("Vital Id  = 1 don't match for Appointment Id = 1", actionResult.Content);

        }

        [TestMethod]
        public void UpdateVitals_ForNonExistentAppointmentId_ShouldNotUpdateTheVitalInfo()
        {
            // Arrange
            var vitalServiceMock = new Mock<IVitalsService>();
            VitalDTO vitalDTO = new VitalDTO { id = 1, appointment_id = 1, ecg = 72, diabetes = 120, respiration_rate = 18, temperature = 37.6f };
            vitalServiceMock.Setup(service => service.GetVitalByAppointmentId(It.IsAny<int>())).Returns((Vital)null);
            // ACT
            var controller = new VitalsController(vitalServiceMock.Object);
            var actionResult = controller.UpdateVitals(vitalDTO) as NegotiatedContentResult<string>;
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.NotFound, actionResult.StatusCode);
            Assert.AreEqual("No Vital Info found for Appointment Id = 1", actionResult.Content);

        }
    }
}
