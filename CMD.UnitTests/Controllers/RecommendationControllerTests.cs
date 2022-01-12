using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMD.APIService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMD.DTO.APIEntities;
using CMD.Business;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using CMD.Exceptions;

namespace CMD.APIService.Controllers.Tests
{
    [TestClass()]
    public class RecommendationControllerTests
    {
        RecommendationController target = null;
        Mock<IRecommendationService> mock = null;
        RecommendationDTO recommendationDTO = null;
        List<RecommendationDTO> allRecommendationDTOs = null;
        List<RecommendationDTO> filteredRecommendationDTOs = null;

        [TestInitialize]
        public void Initialize()
        {
            mock = new Mock<IRecommendationService>();
            target = new RecommendationController(mock.Object);

            recommendationDTO = new RecommendationDTO()
            {
                id = 1,
                appointment_id = 2,
                recommended_doctor_name="Dr.Brian weiss",
                recommended_doctor_id=1
            };
            allRecommendationDTOs = new List<RecommendationDTO>()
            {
               recommendationDTO,
                new RecommendationDTO
                {
                    id = 2,
                    appointment_id = 1,
                    recommended_doctor_name="Dr.Jame Ethic",
                    recommended_doctor_id=3
                }
            };
            filteredRecommendationDTOs = new List<RecommendationDTO>()
            {
                recommendationDTO
            };
        }

        [TestCleanup]
        public void UnInitialize()
        {
            mock = null;
            target = null;
            recommendationDTO = null;
            allRecommendationDTOs = null;
        }
        #region Retrive
        [TestMethod]
        public void GetRecommendation_ShouldReturnOkResposeWithAllRecommendations()
        {
            mock.Setup(service => service.GetRecommendationDTOs()).Returns(allRecommendationDTOs);
            IHttpActionResult result = target.Get();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<RecommendationDTO>>));
            Assert.AreEqual((result as OkNegotiatedContentResult<List<RecommendationDTO>>).Content, allRecommendationDTOs);
        }

        [TestMethod]
        public void GetRecommendation_WithInValidRecommendationId_ShouldReturnNotFoundRespose()
        {
            RecommendationDTO nullResult = null;
            mock.Setup(service => service.GetRecommendationDTOById(1000)).Returns(nullResult);
            IHttpActionResult result = target.Get(1000);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.NotFound);
        }
        [TestMethod]
        public void GetRecommendationsByAppointmentIdRecommendation_WithValidAppointmentId_ShouldReturnOkResponseWithRecommendationsHavingSameAppointmentId()
        {
            mock.Setup(service => service.GetRecommendationDTOsByAppointmentId(2)).Returns(filteredRecommendationDTOs);
            IHttpActionResult result = target.GetRecommendationsByAppointmentId(2);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<RecommendationDTO>>));
            Assert.AreEqual((result as OkNegotiatedContentResult<List<RecommendationDTO>>).Content, filteredRecommendationDTOs);
        }

        [TestMethod]
        public void GetRecommendationsByAppointmentIdRecommendation_WithInvalidAppointmentId_ShouldReturnBadRequestResponse()
        {
            mock.Setup(service => service.GetRecommendationDTOsByAppointmentId(1000)).Throws(new AppointmentNotFoundException());
            IHttpActionResult result = target.GetRecommendationsByAppointmentId(1000);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void GetRecommendationsByAppointmentIdRecommendation_WithValidAppointmentIdAndUnknownException_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.GetRecommendationDTOsByAppointmentId(2)).Throws(new Exception());
            IHttpActionResult result = target.GetRecommendationsByAppointmentId(2);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Delete

        [TestMethod]
        public void DeleteRecommendation_WithValidRecommendationId_ShouldReturnOkResponse()
        {
            mock.Setup(service => service.DeleteRecommendationById(1)).Returns(1);
            mock.Setup(service => service.GetRecommendationDTOById(1)).Returns(recommendationDTO);
            IHttpActionResult result = target.Delete(1);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<RecommendationDTO>));
            Assert.AreEqual((result as OkNegotiatedContentResult<RecommendationDTO>).Content, recommendationDTO);
        }
        [TestMethod]
        public void DeleteRecommendation_WithValidRecommendationIdAndNotAffectingDatabase_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.DeleteRecommendationById(1)).Returns(0);
            mock.Setup(service => service.GetRecommendationDTOById(1)).Returns(recommendationDTO);
            IHttpActionResult result = target.Delete(1);
            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
        [TestMethod]
        public void DeleteRecommendation_WithInvalidRecommendationId_ShouldReturnNotFoundResponse()
        {
            mock.Setup(service => service.DeleteRecommendationById(1000)).Throws(new RecommendationNotFoundException());
            IHttpActionResult result = target.Delete(1000);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.NotFound);
        }
        [TestMethod]
        public void DeleteRecommendation_WithValidRecommendationIdAndUnexpectedException_ShouldReturnInternalServerErrorResponse()
        {
            mock.Setup(service => service.DeleteRecommendationById(1)).Throws(new Exception());
            mock.Setup(service => service.GetRecommendationDTOById(1)).Returns(recommendationDTO);
            IHttpActionResult result = target.Delete(1);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<string>));
            Assert.AreEqual((result as NegotiatedContentResult<string>).StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }
        #endregion
    }
}