using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace CMD.UnitTests
{
    [TestClass]
    public class DoctorTesting
    {
        [TestMethod]
        public void Get_IfPresent_ShouldReturnAllDoctorDetails()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.GetAllDoctorDTOs()).Returns(new List<DoctorDTO> { new DoctorDTO { id = 1, doctor_name = "abc" } });
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            IHttpActionResult actionResult = dr.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<DoctorDTO>>;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void Get_IfNotFound_ShouldReturn404()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.GetAllDoctorDTOs()).Returns((List<DoctorDTO>)null);
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            IHttpActionResult actionResult = dr.Get();
            //var contentResult = actionResult as OkNegotiatedContentResult<List<DoctorDTO>>;

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void GetDoctorById_IfNotExistingId_ShouldReturns404()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.GetDoctorByIdDTOs(It.IsAny<int>())).Returns((DoctorDTO)null);
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            IHttpActionResult actionResult = dr.GetDoctorById(10);
            //var contentResult = actionResult as OkNegotiatedContentResult<DoctorDTO>;
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

        }
        [TestMethod]
        public void GetDoctorById_ForExistingId_ShouldReturnsOK()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.GetDoctorByIdDTOs(It.IsAny<int>())).Returns(new DoctorDTO { id = 1, doctor_name = "abc" });
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            IHttpActionResult actionResult = dr.GetDoctorById(2);
            var contentResult = actionResult as OkNegotiatedContentResult<DoctorDTO>;
            Assert.IsNotNull(contentResult);
        }
        [TestMethod]
        public void PutDoctorById_ForExistingId_ShouldReturnOk()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.UpdateDoctorDTOs(It.IsAny<DoctorDTO>())).Returns(1);
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            DoctorDTO d = new DoctorDTO() { id = 2, doctor_name = "Jill", doctor_phone_number = "6565656565", doctor_npi_no = "1234567890", clinic_id = 1 };
            var cr = dr.PutDoctor(d); //as OkNegotiatedContentResult<int>;
            Assert.IsInstanceOfType(cr, typeof(OkResult));
        }
        [TestMethod]
        public void GetDoctorByEmail_ForExistingDoctor_ShouldReturnOK()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.GetDoctorByEmailDTO(It.IsAny<String>())).Returns(new DoctorDTO { id = 1, doctor_name = "abc",doctor_email_id="abc" });
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            IHttpActionResult actionResult = dr.GetDoctorByEmail("abc");
            var contentResult = actionResult as OkNegotiatedContentResult<DoctorDTO>;
            Assert.IsNotNull(contentResult);
        }



        [TestMethod]
        public void GetDoctorByEmail_ForNotExistingDoctor_ShouldReturn404()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.GetDoctorByEmailDTO(It.IsAny<String>())).Returns((DoctorDTO)null);
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            IHttpActionResult actionResult = dr.GetDoctorByEmail("abc");
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutDoctorById_ForNotExistingId_ShouldReturn404()
        {
            var doctorServiceMock = new Mock<IDoctorService>();
            doctorServiceMock.Setup(service => service.UpdateDoctorDTOs(It.IsAny<DoctorDTO>())).Returns(null);
            DoctorsController dr = new DoctorsController(doctorServiceMock.Object);
            DoctorDTO d = new DoctorDTO() { id = 2, doctor_name = "Jill", doctor_phone_number = "6565656565", doctor_npi_no = "1234567890", clinic_id = 1 };
            var cr = dr.PutDoctor(d); //as OkNegotiatedContentResult<int>;
                                      //Assert.AreEqual(1, cr.Content);
            Assert.IsInstanceOfType(cr, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutDoctorById_WithInValidModelState_ShouldReturnModelInvalid()
        {
            var controller = new DoctorsController();
            controller.ModelState.AddModelError("Error", "NPI Number should be of 10 digits");
            DoctorDTO d = new DoctorDTO() { id = 2, doctor_name = "Jill", doctor_phone_number = "6565656565", doctor_npi_no = "12345678", clinic_id = 1 };
            var res = controller.PutDoctor(d) as BadRequestResult;
            Assert.AreEqual(false, controller.ModelState.IsValid);
        }
    }
}