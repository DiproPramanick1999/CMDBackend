using CMD.Business;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CMD.UnitTests
{
    [TestClass]
    public class VitalsServiceUnitTest
    {
        [TestMethod]
        public void GetVitalDTOByAppointmentId_ForExistentId_ShouldReturnResultAsNotNull()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.getVitalByAppointmentId(1)).Returns(new Vital() {  Appointment = new Appointment() { AppointmentId = 1 }, VitalId=1 ,ECG=100, Diabetes=120, RespirationRate=16, Temperature=36.4f});

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.GetVitalDTOByAppointmentId(1);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetVitalDTOByAppointmentId_ForExistentId_ShouldReturnResultAndIdSholdMatch()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.getVitalByAppointmentId(It.IsAny<int>())).Returns(new Vital() { Appointment = new Appointment() { AppointmentId = 1 }, VitalId = 1, ECG = 100, Diabetes = 120, RespirationRate = 16, Temperature = 36.4f });

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.GetVitalByAppointmentId(It.IsAny<int>());

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Appointment.AppointmentId, 1);
        }


        [TestMethod]
        public void UpdateVital_ForExistentVital_ShouldUpdateAndReturnTheCount()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.updateVital(It.IsAny<Vital>())).Returns(1);

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.UpdateVital(new Vital());
            Assert.IsNotNull(result);
            Assert.AreEqual(result,1);
        }

        [TestMethod]
        public void GetVitalById_ForExistentVitalId_ShouldReturnVital()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.getVitalById(It.IsAny<int>())).Returns(new Vital() { Appointment = new Appointment() { AppointmentId = 1 }, VitalId = 1, ECG = 100, Diabetes = 120, RespirationRate = 16, Temperature = 36.4f });

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.GetVitalByVitalId(It.IsAny<int>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(Vital));
        }

        [TestMethod]
        public void GetVitalDTOById_ForExistentVitalId_ShouldReturnVital()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.getVitalById(It.IsAny<int>())).Returns(new Vital() { Appointment = new Appointment() { AppointmentId = 1 }, VitalId = 1, ECG = 100, Diabetes = 120, RespirationRate = 16, Temperature = 36.4f });

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.GetVitalDTOByVitalId(It.IsAny<int>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(VitalDTO));


        }

        [TestMethod]
        public void GetAllVitals_ShouldReturnListOfVitalsType()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.getAllVitals()).Returns(new List<Vital>());

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.GetAllVitals();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Vital>));
        }

        [TestMethod]
        public void GetAllVitalsDTO_ShouldReturnListOfVitalDTOType()
        {
            var vitalRepoMock = new Mock<IVitalRepository>();
            vitalRepoMock.Setup(service => service.getAllVitals()).Returns(new List<Vital>() { new Vital() { Appointment = new Appointment() { AppointmentId = 1 }, Diabetes = 120, ECG = 72, RespirationRate = 16, Temperature = 36.4f, VitalId = 1 } }) ;

            var vitalsService = new VitalsService(vitalRepoMock.Object);

            var result = vitalsService.GetAllVitalsDTO();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<VitalDTO>));
        }


    }
}
