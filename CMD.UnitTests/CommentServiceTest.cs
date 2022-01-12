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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.UnitTests
{
    [TestClass]
    public class CommentServiceTest
    {
        CommentDTO commentDTO;
        Mock<ICommentRepository> mock;
        Comment comment;
        ICommentService service;
        List<CommentDTO> dTOs;
        List<Comment> comments;
        Appointment appointment;


        [TestInitialize]
        public void Initialize()
        {
            mock = new Mock<ICommentRepository>();
            service = new CommentService(mock.Object);

            appointment = new Appointment() { AppointmentId = 1 };
            comment = new Comment
            {
                CommentId = 11,
                CommentMessage = "Needs Rest.Maintain Sleep cycle",
                Appointment = appointment
            };
            commentDTO = new CommentDTO
            {
                id = 11,
                comment = "Needs Rest.Maintain Sleep cycle",
                appointment_id = 1
            };

            dTOs = new List<CommentDTO> { commentDTO };
            comments = new List<Comment> { comment };

        }

        [TestCleanup]
        public void UnInitialize()
        {
            commentDTO = null;
            mock = null;
        }

        [TestMethod]
        public void GetCommentDTOByAppointmentId_WithValidInputId_ShouldReturnCommentDTO()
        {
            mock.Setup((r) => r.GetCommentByAppointmentId(1)).Returns(comment);
            CommentDTO result = service.GetCommentDTOByAppointmentId(1);
            Assert.IsInstanceOfType(result,typeof(CommentDTO));
        }

        [TestMethod]
        public void GetCommentDTOByAppointmentId_WithInValidInputId_ShouldReturnNull()
        {
            Comment comment = null;
            mock.Setup((r) => r.GetCommentByAppointmentId(2)).Returns(comment);
            CommentDTO result = service.GetCommentDTOByAppointmentId(2);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCommentDTOsTest_ShouldReturnListOfCommentDTO()
        {
            mock.Setup(r => r.GetComments()).Returns(comments);
            var result = service.GetCommentDTOs();
            Assert.AreEqual(result.Count,dTOs.Count);
        }

        [TestMethod]
        public void UpdateCommentDTOTest_WithInputCommentDTOHavingNullAppointment_ShouldReturnZero()
        {
            Comment comment = new Comment()
            {
                CommentId=1,
                CommentMessage="Diet Control"
            };
            mock.Setup(r => r.UpdateComment(comment)).Returns(0);
            int result = service.UpdateCommentDTO(commentDTO);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void UpdateCommentDTOTest_WithValidInputCommentDTO_ShouldReturnMoreThanZero()
        {
            mock.Setup(r => r.UpdateComment(comment)).Returns(1);
          //  mock.Setup(repo => repo.GetAppointmentById(commentDTO.appointment_id)).Returns(appointment);
            int result = service.UpdateComment(comment);
            Assert.AreNotEqual(result, typeof(int));
        }

    }
}
