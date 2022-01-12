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
    public class DoctorServiceUnitTest
    {
        Mock<IDoctorRepository> doctorRepoMock;
        [TestInitialize]
        public void Initialize()
        {
            doctorRepoMock = new Mock<IDoctorRepository>();
        }

        [TestCleanup]
        public void UnInitialize()
        {
            doctorRepoMock = null;
        }

        [TestMethod]
        public void GetAllDoctorDTOs_ShouldReturnDoctorDTOs()
        {
            doctorRepoMock.Setup(repo => repo.GetDoctor()).Returns(new List<Doctor> { new Doctor { DoctorId = 1, Name = "abc",Clinic= new Clinic { ClinicId=1} } });

            var service = new DoctorService(doctorRepoMock.Object);

            var res = service.GetAllDoctorDTOs();

            Assert.IsInstanceOfType(res, typeof(List<DoctorDTO>));
        }

        [TestMethod]
        public void GetDoctorByIdDTOs_ShouldReturnDoctorDTO()
        {
            doctorRepoMock.Setup(repo => repo.GetDoctorById(It.IsAny<int>())).Returns(new Doctor { DoctorId = 1, Name = "abc", Clinic = new Clinic { ClinicId = 1 } } );

            var service = new DoctorService(doctorRepoMock.Object);

            var res = service.GetDoctorByIdDTOs(1);

            Assert.IsInstanceOfType(res, typeof(DoctorDTO));
        }

        [TestMethod]
        public void GetDoctorByEmailDTO_ShouldReturnDoctorDTO()
        {
            doctorRepoMock.Setup(repo => repo.GetDoctorByEmail(It.IsAny<string>())).Returns(new Doctor { DoctorId = 1, Name = "abc", Clinic = new Clinic { ClinicId = 1 } });

            var service = new DoctorService(doctorRepoMock.Object);

            var res = service.GetDoctorByEmailDTO("sbc");

            Assert.IsInstanceOfType(res, typeof(DoctorDTO));
        }

        [TestMethod]
        public void UpdateDoctorDTOs_ShouldReturnInt()
        {
            doctorRepoMock.Setup(repo => repo.EditDoctor(It.IsAny<Doctor>())).Returns(1);

            var service = new DoctorService(doctorRepoMock.Object);

            DoctorDTO dTO = new DoctorDTO { id = 1, clinic_id = 1 };

            var res = service.UpdateDoctorDTOs(dTO);

            Assert.IsInstanceOfType(res, typeof(int));
        }
    }
}
