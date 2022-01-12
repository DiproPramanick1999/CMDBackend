using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CMD.UnitTests
{
    [TestClass]
    public class FeedbackTest
    {
        FeedBacksController controller;
        Mock<IFeedbackService> serviceMock;
        [TestInitialize]
        public void Initialize()
        {
            serviceMock = new Mock<IFeedbackService>();
            controller = new FeedBacksController(serviceMock.Object);
        }
        [TestMethod]

        public void GetAllValidFeedbacks()
        {
            List<FeedbackDTO> list = new List<FeedbackDTO>();
            list.Add(new FeedbackDTO
            {
                id = 2,
                Question1 = 5,
                Question2 = 5,
                Question3 = 4,
                Question4 = 4,
                AddComment = "Halo",
                appointment_id = 2
            });

            serviceMock.Setup(s => s.GetFeedbackDTOs()).Returns(list);
            //var controller = new FeedBacksController(serviceMock.Object);
            var result = controller.Get() as OkNegotiatedContentResult<List<FeedbackDTO>>;
            //Assert.IsNotNull(result);
            Assert.AreEqual(result.Content,list);
        }

        [TestMethod]

        public void GetByIdWith_ValidIdShouldReturn_Feedback()
        {
            
            FeedbackDTO feedbackDTO = new FeedbackDTO
            {
                id = 2,
                Question1 = 5,
                Question2 = 4,
                Question3 = 4,
                Question4 = 3,
                AddComment = "Good Diagnosis",
                appointment_id = 2
            };

            serviceMock.Setup(service => service.GetFeedbackByIdDTOs(2)).Returns(feedbackDTO);
            serviceMock.Setup(service => service.GetFeedbackById(2)).Returns(new Feedback()
            {
                FeedbackId = 1,
                Question1 = 5,
                Question2 = 5,
                Question3 = 5,
                Question4 = 5,
                AddComment = "Hello"
                

            });
            //var controller = new FeedBacksController(serviceMock.Object);
            var result = controller.GetById(2) as OkNegotiatedContentResult<FeedbackDTO>;
            //Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, feedbackDTO);
           
          

        }

        [TestMethod]
        public void PutFeedbackWith_ValidAppointmentIdShouldReturn_OkResponse()
        {
            FeedbackDTO feedDTO = new FeedbackDTO
            { id=1,Question1=5,Question2=5,Question3=4,Question4=4,AddComment="Hello Doctor",appointment_id=2 };
            serviceMock.Setup(service => service.UpdateFeedbackDTO(It.IsAny<FeedbackDTO>())).Returns(1);
            
            //var feedbackController = new FeedBacksController(serviceMock.Object);
            
            var actionResult = controller.PutFeedback(feedDTO) as CreatedNegotiatedContentResult<FeedbackDTO>;
            var updatedFeedback = actionResult.Content;
            
            
            Assert.AreEqual(2, updatedFeedback.appointment_id);
            


        }
        [TestMethod]

        public void GetAllInValidFeedbacks()
        {
            List<FeedbackDTO> list = null;
            

            serviceMock.Setup(s => s.GetFeedbackDTOs()).Returns(list);
            //var controller = new FeedBacksController(serviceMock.Object);
            var result = controller.Get(); 
            //Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType(), typeof(NotFoundResult));
        }

        [TestMethod]

        public void GetByIdWith_InvalidAppoinmetnIdShouldReturn_NotFound()
        {
            FeedbackDTO feedDTO = null;

            serviceMock.Setup(s => s.GetFeedbackByIdDTOs(1)).Returns(feedDTO);
            //var controller = new FeedBacksController(serviceMock.Object);
            var actionResult = controller.GetById(1);
            Assert.AreEqual(actionResult.GetType(), typeof(NotFoundResult));
        }

        [TestMethod]
       public void PutFeedbackWith_InvalidAppointmentIdShould_ReturnBadRequest()
        {
            FeedbackDTO feedbackDTO = new FeedbackDTO()
            {
                appointment_id = 100000,
                Question1 = 5,
                Question2 = 5,
                Question3 = 4,
                Question4 = 4,
                AddComment = "Thank you Doctor!",
                id = 1
            };

            serviceMock.Setup(s => s.UpdateFeedbackDTO(feedbackDTO)).Returns(0);
            //var controller = new FeedBacksController(serviceMock.Object);
            var actionResult = controller.PutFeedback(feedbackDTO) ;
            Assert.AreEqual(actionResult.GetType(), typeof(BadRequestResult));
        }


        [TestMethod]

        public void PutFeedBackWith_EmptyObjectShould_ReturnBadRequest()
        {
            FeedbackDTO feedbackDTO = null;
            serviceMock.Setup(s => s.UpdateFeedbackDTO(feedbackDTO)).Returns(0);
            //var controller = new FeedBacksController(serviceMock.Object);
            var actionResult = controller.PutFeedback(feedbackDTO) ;
            Assert.AreEqual(actionResult.GetType(), typeof(BadRequestResult));
        }


        [TestMethod]
        public void PutFeedbackWith_Exception()
        {
            FeedbackDTO feedbackDTO = new FeedbackDTO()
            {
                appointment_id = 100000,
                Question1 = 5,
                Question2 = 5,
                Question3 = 4,
                Question4 = 4,
                AddComment = "Thank you Doctor!",
                id = 1
            };

            serviceMock.Setup(s => s.UpdateFeedbackDTO(feedbackDTO)).Throws(new Exception());
            //var controller = new FeedBacksController(serviceMock.Object);
            var actionResult = controller.PutFeedback(feedbackDTO);
            Assert.AreEqual(actionResult.GetType(), typeof(BadRequestResult));
        }


    }
}
