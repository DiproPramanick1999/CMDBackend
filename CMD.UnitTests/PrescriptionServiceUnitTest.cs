using CMD.Business;
using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CMD.UnitTests
{
    [TestClass]
    public class PrescriptionServiceUnitTest
    {
        PrescriptionService service;
        Mock<IPrescriptionRepository> mockRepo;
        IPrescriptionRepository r = new PrescriptionRepository();
        [TestInitialize]
        public void Initialize()
        {
            service = new PrescriptionService();
            mockRepo= new Mock<IPrescriptionRepository>();
        }
        [TestMethod]
        public void GetAllPrescriptions_WithValidPrescription_ReturnsListOfPrescriptions()
        {
            List <Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription
            {
                PrescriptionId = 20,
                MedicineName = "Citezene",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }
            });
            mockRepo.Setup(repo=>repo.GetPrescriptions()).Returns(prescriptions);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.GetPrescriptions();
            Assert.AreEqual(1, response.Count);
            Assert.AreEqual(response, prescriptions);
        }
        [TestMethod]
        public void GetPrescriptionbyID_WithValidPrescriptionID_ReturnsPrescriptionsHavingPrescriptionID()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 7,
                MedicineName = "Citezene",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }
            };
            mockRepo.Setup(repo => repo.GetPrescriptionById(7)).Returns(prescription);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.GetPrescriptionById(7);
            Assert.AreEqual(response, prescription);
        }
        [TestMethod]
        public void GetAllPrescriptionDTOs_WithValidPrescriptionDTO_ReturnsListofPrescriptionDTO()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription
            {
                PrescriptionId = 20,
                MedicineName = "Citezene",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }
            });
            mockRepo.Setup(repo => repo.GetPrescriptions()).Returns(prescriptions);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.GetPrescriptionDTOs();
            foreach(Prescription prescription in mockRepo.Object.GetPrescriptions())
            {
                response.Add(prescription.ToPrescriptionDTO());
            }
            Assert.AreEqual(20, response[0].id);
            //Assert.AreEqual(response, prescriptions);
        }
        [TestMethod]
        public void GetPrescriptionDTOsById_WithValidPrescriptionDTO_ReturnsListOfPrescriptionDTO()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 9,
                MedicineName = "Citrizene",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }

            };
            
            mockRepo.Setup(repo=>repo.GetPrescriptionById(9)).Returns(prescription);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.GetPrescriptionDTOById(9);
            var dto = response.ToPrescription(r);
            //Assert.AreEqual(dto.GetType(),typeof(Prescription));
            Assert.AreEqual(dto.MedicineName, prescription.MedicineName);
        }
        [TestMethod]
        public void SavePrescription_WithValidPrescription_ReturnsSavedPrescription()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 9,
                MedicineName = "Citrizene",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }

            };
            mockRepo.Setup(repo=>repo.SavePrescription(It.IsAny<Prescription>())).Returns(prescription);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.SavePrescription(prescription);
            Assert.AreEqual(response.GetType(),typeof(Prescription));
            Assert.AreEqual(response, prescription);
        }
        [TestMethod]
        public void SavePrescriptionDTO_WithValidPrescriptionDTO_ReturnsSavedPrescriptionDTO()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 9,
                MedicineName = "Citrizene",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }

            };
            mockRepo.Setup(repo => repo.SavePrescription(It.IsAny<Prescription>())).Returns(prescription);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.SavePrescriptionDTO(prescription.ToPrescriptionDTO());
            Assert.AreEqual(response.GetType(), typeof(PrescriptionDTO));
            Assert.AreEqual(response.medicine_name, prescription.ToPrescriptionDTO().medicine_name);
        }
        [TestMethod]
        public void EditPrescription_WithValidPrescription_ShouldReturnNumberOfAffectedRows()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 9,
                MedicineName = "Citrizene Cold",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }

            };
            mockRepo.Setup(repo=>repo.EditPrescription(It.IsAny<Prescription>())).Returns(1);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.EditPrescription(prescription);
            Assert.AreEqual(1, response);
        }
        [TestMethod]
        public void EditPrescriptionDTO_WithValidPrescriptionDTO_ShouldReturnNumberOfAffectedRows()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 9,
                MedicineName = "Citrizene Cold",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }

            };
            mockRepo.Setup(repo => repo.EditPrescription(It.IsAny<Prescription>())).Returns(1);
            var service = new PrescriptionService(mockRepo.Object);
            var response = service.EditPrescriptionDTO(prescription.ToPrescriptionDTO());
            Assert.AreEqual(1, response);
        }
        [TestMethod]
        public void DeletePrescription_WithValidPrescriptionId_ReturnsTheNumberOfRowsAffected()
        {
            Prescription prescription = new Prescription
            {
                PrescriptionId = 9,
                MedicineName = "Citrizene Cold",
                MedicineDuration = 3,
                MedicineCycle = "M-A-N",
                MedicineAfterFood = true,
                MedicineInstruction = "Need to take adequate rest after taking medicine",
                Appointment = new Appointment { AppointmentId = 2 }

            };
            mockRepo.Setup(repo => repo.DeletePrescription(9)).Returns(1);
            var service= new PrescriptionService(mockRepo.Object);
            var response= service.DeletePrescription(9);
            Assert.AreEqual(1, response);
        }
        [TestMethod]
        public void GetAppointment_ByValidAppointmentId_ReturnsAppointmentMatchingTheAppoinmentId()
        {
            Appointment appointment = new Appointment
            {
                AppointmentId = 2,
                Date = "23/4/2021"
            };
            mockRepo.Setup(repo=>repo.GetAppointmentByAppointmentId(2)).Returns(appointment);
            var service = new PrescriptionService(mockRepo.Object);
            var response=service.GetAppointmentByAppointmentId(2);
            Assert.AreEqual(response,appointment);
            Assert.AreEqual(response.AppointmentId, 2);
        }




    }
}
