using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace CMD.UnitTests
{
    [TestClass]
    public class PrescriptionControllerUnitTest
    {
        PrescriptionController controller;
        Mock<IPrescriptionService> mockService;
        
        [TestInitialize]
        public void Initialize()
        {
            controller = new PrescriptionController();
            mockService = new Mock<IPrescriptionService>();
        }
        [TestMethod]
        public void GetAllValidPrescriptions_ShouldReturnOkResult()
        {
            List<PrescriptionDTO> prescriptions = new List<PrescriptionDTO>();
            prescriptions.Add(new PrescriptionDTO
            {
                id = 20,
                medicine_name = "Citezene",
                medicine_duration = 0,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 2
            });
            mockService.Setup(service => service.GetPrescriptionDTOs()).Returns(prescriptions);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.GetPrescriptions() as OkNegotiatedContentResult<List<PrescriptionDTO>>;
            Assert.AreEqual(response.Content, prescriptions);
        }
        [TestMethod]
        public void GetAllInvalidPrescriptions_ShouldReturnNotFoundResult()
        {
            List<PrescriptionDTO> prescriptions = null;
            mockService.Setup(service => service.GetPrescriptionDTOs()).Returns(prescriptions);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.GetPrescriptions() as NotFoundResult;
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }
        [TestMethod]
        public void GetPrescriptionById_WithValidId_ShouldReturnOkResult()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citezene",
                medicine_duration = 2,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 2
            };
            mockService.Setup(service => service.GetPrescriptionDTOById(16)).Returns(prescription);
            var controller = new PrescriptionController(mockService.Object);
            var response= controller.GetPrescriptionById(16) as OkNegotiatedContentResult<PrescriptionDTO>;
            Assert.AreEqual(response.GetType(), typeof(OkNegotiatedContentResult<PrescriptionDTO>));
            Assert.AreEqual(response.Content, prescription);
        }
        [TestMethod]
        public void GetPrescriptionById_WithInvalidId_ShouldReturnNotFoundResult()
        {
            PrescriptionDTO prescription = null;
            mockService.Setup(service => service.GetPrescriptionDTOById(100)).Returns(prescription);
            var controller= new PrescriptionController(mockService.Object);
            var response=controller.GetPrescriptionById(100) as NotFoundResult;
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }
        [TestMethod]
        public void AddPrescription_ByPOSTApiCall_ShouldReturnCreatedResult()
        {
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO
            {
                //id = 20,
                medicine_name = "Citrizene",
                medicine_duration = 3,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 1
            };
            mockService.Setup(service=>service.GetAppointmentByAppointmentId(1)).Returns(new Appointment());
            mockService.Setup(service => service.SavePrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(prescriptionDTO);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.AddPrescription(prescriptionDTO);
            Assert.AreEqual(response.GetType(), typeof(CreatedNegotiatedContentResult<PrescriptionDTO>));
        }
        [TestMethod]
        public void AddPrescription_WithInvalidModelState_ShouldReturnBadRequestResponse()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citezene",
                medicine_duration = 0,
                medicine_cycle = "M-A-N-p-o",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 1
            };
            mockService.Setup(service => service.SavePrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(prescription);
            var controller = new PrescriptionController(mockService.Object);
            controller.ModelState.AddModelError("test", "test");
            var response = controller.AddPrescription(prescription);
            Assert.AreEqual(response.GetType(), typeof(BadRequestResult));
        }
        [TestMethod]
        public void AddPrescription_WithInvalidAppointmentId_ShouldReturnNotFoundResult()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citezene",
                medicine_duration = 2,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 20
            };
            mockService.Setup(service => service.SavePrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(prescription);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.AddPrescription(prescription) as NotFoundResult;
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }
        [TestMethod]
        public void AddPrescription_WithInvalidSaveResponse_ShouldReturnNotFound()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citezene",
                medicine_duration = 2,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 2
            };
            PrescriptionDTO dto = null;
            mockService.Setup(service => service.GetAppointmentByAppointmentId(2)).Returns(new Appointment());
            mockService.Setup(service => service.SavePrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(dto);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.AddPrescription(prescription);
            Assert.AreEqual(response.GetType(),typeof(NotFoundResult));
        }
        [TestMethod]
        public void AddPrescription_WithEmptyPrescription_ShouldReturnBadResponse()
        {
            PrescriptionDTO prescription = null;
            mockService.Setup(service => service.SavePrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(prescription);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.AddPrescription(prescription) as BadRequestResult;
            Assert.AreEqual(response.GetType(), typeof(BadRequestResult));
        }
        [TestMethod]
        public void UpdatePrescription_WithValidPrescription_ShouldReturnCreatedResult()
        {
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citrizene",
                medicine_duration = 4,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 2
            };
            mockService.Setup(service => service.GetAppointmentByAppointmentId(2)).Returns(new Appointment());
            mockService.Setup(service => service.GetPrescriptionDTOById(16)).Returns(prescriptionDTO);
            mockService.Setup(service => service.EditPrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(1);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.UpdatePrescription(prescriptionDTO) as CreatedNegotiatedContentResult<PrescriptionDTO>;
            Assert.AreEqual(response.GetType(),typeof(CreatedNegotiatedContentResult<PrescriptionDTO>));
        } 
        [TestMethod]
        public void UpdatePrescription_WithInvalidModelState_ShouldReturnBadRequestResponse()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citezene",
                medicine_duration = 0,
                medicine_cycle = "M-A-N-p-o",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 1
            };
            mockService.Setup(service => service.EditPrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(0);
            var controller = new PrescriptionController(mockService.Object);
            controller.ModelState.AddModelError("test", "test");
            var response = controller.UpdatePrescription(prescription);
            Assert.AreEqual(response.GetType(), typeof(BadRequestResult));
        }
        [TestMethod]
        public void UpdatePrescription_WithInvalidAppointmentId_ShouldReturnNotFoundResult()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citezene",
                medicine_duration = 2,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 20
            };
            mockService.Setup(service => service.EditPrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(0);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.UpdatePrescription(prescription) as NotFoundResult;
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }
        [TestMethod]
        public void UpdatePrescription_WithInvalidPrescriptionId_ShouldReturnNotFoundResult()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 342,
                medicine_name = "Citezene",
                medicine_duration = 2,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 20
            };
            mockService.Setup(service => service.EditPrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(0);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.UpdatePrescription(prescription) as NotFoundResult;
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }
        [TestMethod]
        public void UpdatePrescription_WithInValidEditResponse_ShouldReturnInternalServerError()
        {
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citrizene",
                medicine_duration = 4,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 2
            };
            mockService.Setup(service => service.GetAppointmentByAppointmentId(2)).Returns(new Appointment());
            mockService.Setup(service => service.GetPrescriptionDTOById(16)).Returns(prescriptionDTO);
            mockService.Setup(service => service.EditPrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(0);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.UpdatePrescription(prescriptionDTO) as InternalServerErrorResult;
            Assert.AreEqual(response.GetType(), typeof(InternalServerErrorResult));
        }
        [TestMethod]
        public void UpdatePrescription_WithEmptyPrescription_ShouldReturnInternalServerError()
        {
            PrescriptionDTO prescriptionDTO = null;
            mockService.Setup(service => service.EditPrescriptionDTO(It.IsAny<PrescriptionDTO>())).Returns(0);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.UpdatePrescription(prescriptionDTO) as BadRequestResult;
            Assert.AreEqual(response.GetType(), typeof(BadRequestResult));
        }
        [TestMethod]
        public void DeletePrescription_WithValidPrescriptionID_ShouldReturnOkResult()
        {
            PrescriptionDTO prescription = new PrescriptionDTO
            {
                id = 16,
                medicine_name = "Citrizene",
                medicine_duration = 4,
                medicine_cycle = "M-A-N",
                medicine_after_food = true,
                medicine_description = "Need to take adequate rest after taking medicine",
                appointment_id = 2
            };
            mockService.Setup(service => service.DeletePrescription(16)).Returns(1);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.DeletePrescription(16) as OkNegotiatedContentResult<string>;
            Assert.AreEqual(response.GetType(), typeof(OkNegotiatedContentResult<string>));
            Assert.AreEqual(response.Content, "Successfully Deleted!");
        }
        [TestMethod]
        public void DeletePrescription_WithInvalidPrescriptionID_ShouldReturnNotFoundResult()
        {
            mockService.Setup(service => service.DeletePrescription(100)).Returns(0);
            var controller = new PrescriptionController(mockService.Object);
            var response = controller.DeletePrescription(100) as NotFoundResult;
            Assert.AreEqual(response.GetType(), typeof(NotFoundResult));
        }
    }
}
