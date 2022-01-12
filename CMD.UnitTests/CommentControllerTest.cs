using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DataAccess;
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
    public class CommentControllerTest
    {
        CommentsController controller = null;
        Mock<ICommentService> serviceMock;
        CommentDTO commentDTO;

       [TestInitialize]
        public void Initiliaze()
        {
            serviceMock = new Mock<ICommentService>();
            controller = new CommentsController(serviceMock.Object);
            commentDTO = new CommentDTO
            {
                id = 1,
                appointment_id = 6,
                comment = "Needs more Medication"
            };
        }

        [TestCleanup]
        public void UnInitialize()
        {
            controller  =null;
            serviceMock =null;
            commentDTO = null;
        }

        [TestMethod]
        public void GetCommentByAppointmentIdTest_WithValidAppointmentId_ShouldReturnComment()
        {
            serviceMock.Setup(service => service.GetCommentDTOByAppointmentId(6)).Returns(commentDTO);
            var result = controller.GetCommentByAppointmentId(6) as OkNegotiatedContentResult<CommentDTO>;
            Assert.AreEqual(result.Content, commentDTO);
        }
        [TestMethod]
        public void GetTest_ShouldReturnCommentList()
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            comments.Add(new CommentDTO
            {
                appointment_id = 1,
                comment = "Hello",
                id = 2
            });
            // Arrange
            serviceMock.Setup(service => service.GetCommentDTOs()).Returns(comments);
            var result = controller.Get() as OkNegotiatedContentResult<List<CommentDTO>>;
            Assert.AreEqual(result.Content, comments);
        }

        [TestMethod]
        public void PutCommmentTest_WithValidAppointmentId_ShouldReturnOkResponse()
        {
            serviceMock.Setup(service => service.UpdateCommentDTO(It.IsAny<CommentDTO>())).Returns(1);     
            var result = controller.PutComment(commentDTO) as CreatedNegotiatedContentResult<CommentDTO>;
            Assert.AreEqual(result.Content,commentDTO);
        }

        [TestMethod]
        public void GetCommentByAppointmentIdTest_WithInvalidId_ShouldReturnNotFound()
        {
            CommentDTO commentDTO = null;
            serviceMock.Setup(service => service.GetCommentDTOByAppointmentId(2)).Returns(commentDTO);
            var result = controller.GetCommentByAppointmentId(2);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutCommmentTest_WithInValidAppointmentId_ShouldReturnBadRequest()
        {
            serviceMock.Setup(service => service.UpdateCommentDTO(commentDTO)).Returns(0);
            var result = controller.PutComment(commentDTO);
            Assert.AreEqual(result.GetType(),typeof(BadRequestResult));
        }

        [TestMethod]
        public void PutCommentTest_WithEmptyComment_ShouldReturnBadrequest()
        {
            CommentDTO commentDTO = null;
            serviceMock.Setup(service => service.UpdateCommentDTO(commentDTO)).Returns(0);
            var result = controller.PutComment(commentDTO);
            Assert.AreEqual(result.GetType(),typeof(BadRequestResult));
        }
        [TestMethod]
        public void PutCommentTest_WithCommentUpdatedKey_ShouldReturnBadRequest()
        {
            serviceMock.Setup(service => service.UpdateCommentDTO(commentDTO)).Throws(new Exception());
            var result = controller.PutComment(commentDTO);
            Assert.AreEqual(result.GetType(), typeof(BadRequestResult));
        }
    }
}
