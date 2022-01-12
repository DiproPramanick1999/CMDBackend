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
    public class FeedbackServiceTest
    {
        IFeedbackService service;
        Mock<IFeedBackRepository> serviceMock;
        Feedback feedback;
        FeedbackDTO feedbackDTO;
        List<FeedbackDTO> list;
        List<Feedback> list2;
        Appointment appointment;
        [TestInitialize]
        public void Initialize()
        {
            
            serviceMock = new Mock<IFeedBackRepository>();
            service = new FeedbackService(serviceMock.Object);
            appointment = new Appointment() { AppointmentId = 1 };
            list = new List<FeedbackDTO>();
            list2 = new List<Feedback>();
            feedback = new Feedback()
            {
                FeedbackId = 1,
                Question1 = 5,
                Question2 = 4,
                Question3 = 4,
                Question4 = 5,
                AddComment = "Good Doctor",
                Appointment = appointment

            };
             feedbackDTO = new FeedbackDTO()
            {
                appointment_id = 1,
                id = 1,
                Question1 = 4,
                Question2 = 5,
                Question3 = 5,
                Question4 = 4,
                AddComment = "Excellent Doctor"
            };
        }

        [TestMethod]
        public void GetFeedbackByIdWith_ValidAppointmentIdReturns_FeedbackObject()
        {
            

            serviceMock.Setup(s => s.GetFeedbackById(1)).Returns(feedback);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.GetFeedbackById(1);
            Assert.AreEqual(result, feedback);
        }
        [TestMethod]
        public void GetFeedbackByIdDTOsTest_WithValidAppointmentId_ReturnsFeedbackDTOObject()
        {
            serviceMock.Setup(s => s.GetFeedbackById(1)).Returns(feedback);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.GetFeedbackByIdDTOs(1);
            Assert.IsInstanceOfType(result, typeof(FeedbackDTO));
        }

        [TestMethod]
        public void GetFeedbackDTOsTest_ReturnsListOfFeedbackDTOs()
        {
                        
            list.Add(feedbackDTO);             
            list2.Add(feedback);
            serviceMock.Setup(s => s.GetAllFeedbacks()).Returns(list2);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.GetFeedbackDTOs();
            Assert.AreEqual(result.Count,list.Count);
        }

        [TestMethod]

        public void GetFeedbackByIdDTOsTest_WithInValidAppointmentId_ReturnsNoFeedbackDTOObject()
        {
            Feedback feedback = null;
            serviceMock.Setup(s => s.GetFeedbackById(11)).Returns(feedback);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.GetFeedbackByIdDTOs(11);
            Assert.IsNull(result);
        }
        [TestMethod]

        public void GetInvalidFeedbackDTOsTest_ReturnsNull()
        {
            list = null;
            list2 = null;
            serviceMock.Setup(s => s.GetAllFeedbacks()).Returns(list2);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.GetFeedbackDTOs();
            Assert.IsTrue(result.Count==0);
        }

        [TestMethod]

        public void UpdateFeedbackDTOTest_WithInValidFeedbackDTOObjectShould_ReturnZero()
        {
            Feedback feedback = new Feedback()
            {
                FeedbackId=1
            };
            serviceMock.Setup(s => s.UpdateFeedback(feedback)).Returns(0);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.UpdateFeedbackDTO(feedbackDTO);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]

        public void UpdateFeedback_WithValidFeedbackObjectShould_ReturnMoreThanZero()
        {
            serviceMock.Setup(s => s.UpdateFeedback(feedback)).Returns(1);
            var target = new FeedbackService(serviceMock.Object);
            var result = target.UpdateFeedback(feedback);
            Assert.AreEqual(result, 1);

        }
    }
}
