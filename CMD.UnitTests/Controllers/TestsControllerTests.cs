using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace CMD.APIService.Controllers.Tests
{
    [TestClass]
    public class TestsControllerTests
    {
        TestsController target = null;
        Mock<ITestService> mock = null;
        TestDTO testDTO = null;
        List<TestDTO> allTestDTOs = null;
        List<TestDTO> filteredTestDTOs = null;

        [TestInitialize]
        public void Initialize()
        {
            mock = new Mock<ITestService>();
            target = new TestsController(mock.Object);

            testDTO = new TestDTO()
            {
                id = 1,
                appointment_id = 2,
                test_name = "X-Ray"
            };
            allTestDTOs = new List<TestDTO>()
            {
                testDTO,
                new TestDTO
                {
                    id = 2,
                    appointment_id = 1,
                    test_name = "ECG"
                }
            };
            filteredTestDTOs = new List<TestDTO>()
            {
                testDTO
            };
        }

        [TestCleanup]
        public void UnInitialize()
        {
            target = null;
            mock = null;
            testDTO = null;
            allTestDTOs = null;
            filteredTestDTOs = null;
        }

        #region Create
        [TestMethod]
        public void PostTest_WithValidInput_ShouldReturnCreatedResponseWithTheCreatedTestDTO()
        {
            mock.Setup(service => service.SaveTestDTO(testDTO)).Returns(1);
            IHttpActionResult result = target.Post(testDTO);
            Assert.IsInstanceOfType(result, typeof(CreatedNegotiatedContentResult<TestDTO>));
            Assert.AreEqual((result as CreatedNegotiatedContentResult<TestDTO>).Content, testDTO);
        }

        [TestMethod]
        public void PostTest_WithValidInputAndNotAffectingDatabase_ShouldReturnInternalServerError()
        {
            mock.Setup(service => service.SaveTestDTO(testDTO)).Returns(0);
            IHttpActionResult result = target.Post(testDTO);
            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void PostTest_WithDuplicateTestData_ShouldReturnConflictResponse()
        {
            mock.Setup(service => service.SaveTestDTO(testDTO)).Throws(new DuplicateTestRecordException());
            IHttpActionResult result = target.Post(testDTO);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.Conflict);
        }

        [TestMethod]
        public void PostTest_WithInvalidAppointmentId_ShouldReturnBadRequestResponse()
        {
            testDTO.appointment_id = -1;
            mock.Setup(service => service.SaveTestDTO(testDTO)).Throws(new AppointmentNotFoundException());
            IHttpActionResult result = target.Post(testDTO);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void PostTest_WithValidAppointmentIdAndUnexpectedException_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.SaveTestDTO(testDTO)).Throws(new Exception());
            IHttpActionResult result = target.Post(testDTO);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Retrieve
        [TestMethod]
        public void GetTest_ShouldReturnOkResposeWithAllTests()
        {
            mock.Setup(service => service.GetTestDTOs()).Returns(allTestDTOs);
            IHttpActionResult result = target.Get();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<TestDTO>>));
            Assert.AreEqual((result as OkNegotiatedContentResult<List<TestDTO>>).Content, allTestDTOs);
        }

        [TestMethod]
        public void GetTest_WithValidTestId_ShouldReturnOkResposeWithCorrectTest()
        {
            mock.Setup(service => service.GetTestDTOById(1)).Returns(testDTO);
            IHttpActionResult result = target.Get(1);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<TestDTO>));
            Assert.AreEqual((result as OkNegotiatedContentResult<TestDTO>).Content, testDTO);
        }

        [TestMethod]
        public void GetTest_WithInValidTestId_ShouldReturnNotFoundRespose()
        {
            TestDTO nullResult = null;
            mock.Setup(service => service.GetTestDTOById(1000)).Returns(nullResult);
            IHttpActionResult result = target.Get(1000);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void GetTestsByAppointmentIdTest_WithValidAppointmentId_ShouldReturnOkResponseWithTestsHavingSameAppointmentId()
        {
            mock.Setup(service => service.GetTestDTOsByAppointmentId(2)).Returns(filteredTestDTOs);
            IHttpActionResult result = target.GetTestsByAppointmentId(2);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<TestDTO>>));
            Assert.AreEqual((result as OkNegotiatedContentResult<List<TestDTO>>).Content, filteredTestDTOs);
        }

        [TestMethod]
        public void GetTestsByAppointmentIdTest_WithInvalidAppointmentId_ShouldReturnBadRequestResponse()
        {
            mock.Setup(service => service.GetTestDTOsByAppointmentId(1000)).Throws(new AppointmentNotFoundException());
            IHttpActionResult result = target.GetTestsByAppointmentId(1000);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void GetTestsByAppointmentIdTest_WithValidAppointmentIdAndUnknownException_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.GetTestDTOsByAppointmentId(2)).Throws(new Exception());
            IHttpActionResult result = target.GetTestsByAppointmentId(2);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Delete
        [TestMethod]
        public void DeleteTest_WithValidTestId_ShouldReturnOkResponse()
        {
            mock.Setup(service => service.DeleteTestById(1)).Returns(1);
            mock.Setup(service => service.GetTestDTOById(1)).Returns(testDTO);
            IHttpActionResult result = target.Delete(1);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<TestDTO>));
            Assert.AreEqual((result as OkNegotiatedContentResult<TestDTO>).Content, testDTO);
        }

        [TestMethod]
        public void DeleteTest_WithValidTestIdAndNotAffectingDatabase_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.DeleteTestById(1)).Returns(0);
            mock.Setup(service => service.GetTestDTOById(1)).Returns(testDTO);
            IHttpActionResult result = target.Delete(1);
            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void DeleteTest_WithInvalidTestId_ShouldReturnNotFoundResponse()
        {
            mock.Setup(service => service.DeleteTestById(1000)).Throws(new TestNotFoundException());
            IHttpActionResult result = target.Delete(1000);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void DeleteTest_WithValidTestIdAndUnexpectedException_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.DeleteTestById(1)).Throws(new Exception());
            mock.Setup(service => service.GetTestDTOById(1)).Returns(testDTO);
            IHttpActionResult result = target.Delete(1);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }
        #endregion
    }
}
