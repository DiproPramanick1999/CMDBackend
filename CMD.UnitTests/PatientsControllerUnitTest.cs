using CMD.APIService.Controllers;
using CMD.Business;
using CMD.DTO.APIEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CMD.UnitTests
{
    [TestClass]
    public class PatientsControllerUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            PatientsController patientsController = new PatientsController();
            //return patientsController;
        }

        [TestMethod]
        public void GetPatientDetails_ShouldReturn_AllthePatientDetails()
        {
            //Arrange
            var patientservicemock = new Mock<IPatientService>();
            var patientcontrolermock = new Mock<PatientDTO>();

        
            patientservicemock.Setup(p => p.GetPatientDTOs()).Returns(Multiple());
            var controller = new PatientsController(patientservicemock.Object);
            //Act
            var actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<PatientDTO>>;
            //Assert
            Assert.AreEqual(contentResult.Content.Count, 2);
        }
        [TestMethod]
        public void GetbyId_IfNotFound_Shouldreturn_Statuscode404()
        {

            //Arrange
            var patientservicemock = new Mock<IPatientService>();
            var patientcontrolermock = new Mock<PatientDTO>();
            patientservicemock.Setup(p => p.GetPatientDTOById(100)).Returns(Single(100));
            var controller = new PatientsController(patientservicemock.Object);
            //Act
            var actionResult = controller.Get(100);
           // var contentResult = actionResult as OkNegotiatedContentResult<PatientDTO>;
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            //Assert.AreEqual(contentResult.Content,null);
        }
        [TestMethod]
        public void GetbyId_IfFound_Shouldreturn_Statuscode200()
        {

            //Arrange
            var patientservicemock = new Mock<IPatientService>();
            var patientcontrolermock = new Mock<PatientDTO>();
            PatientDTO patientDTO = new PatientDTO()
            {
                id = 1,
                patient_active_issues = "no",
                patient_age = 21,
                patient_allergies = "no"
                            ,
                patient_blood_group = "op",
                patient_dob = "1999",
                patient_email_id = "abcd@123",
                patient_gender = "male",
                patient_height = "6.1",
                patient_medical_problems = "no",
                patient_name = "akash",
                patient_phone_number = "9108330564",
                patient_profile_image = "dsy",
                patient_state = "banglore"
            };
            patientservicemock.Setup(p => p.GetPatientDTOById(1)).Returns(patientDTO);
            var controller = new PatientsController(patientservicemock.Object);
            //Act
            var actionResult = controller.Get(1);
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<PatientDTO>));
        }
        [TestMethod]
        public void GetbyId_PassingvalidId_ShouldReturnPatientobjectOfThatPatient()
        {

            //Arrange
            var patientservicemock = new Mock<IPatientService>();
            var patientcontrolermock = new Mock<PatientDTO>();
            PatientDTO patientDTO = new PatientDTO()
            {
                id = 1,
                patient_active_issues = "no",
                patient_age = 21,
                patient_allergies = "no"
                            ,
                patient_blood_group = "op",
                patient_dob = "1999",
                patient_email_id = "abcd@123",
                patient_gender = "male",
                patient_height = "6.1",
                patient_medical_problems = "no",
                patient_name = "akash",
                patient_phone_number = "9108330564",
                patient_profile_image = "dsy",
                patient_state = "banglore"
            };
            patientservicemock.Setup(p => p.GetPatientDTOById(1)).Returns(patientDTO);
            var controller = new PatientsController(patientservicemock.Object);
            //Act
            var actionResult = controller.Get(1);
            var contentResult = actionResult as OkNegotiatedContentResult<PatientDTO>;
            //Assert
            Assert.AreEqual(contentResult.Content.id, 1);
        }
        [TestMethod]
        public void Getallpatients_IfFound_Shouldreturn_Statuscode200()
        {
            //Arrange
            var patientservicemock = new Mock<IPatientService>();
            var patientcontrolermock = new Mock<PatientDTO>();

            List<PatientDTO> patientDTOs = Multiple();

            patientservicemock.Setup(p => p.GetPatientDTOs()).Returns(patientDTOs);
            var controller = new PatientsController(patientservicemock.Object);
            //Act
            var actionResult = controller.Get();
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<List<PatientDTO>>));
        }
        [TestMethod]
        public void Getallpatients_IfEmpty_Shouldreturn_Statuscode400()
        {
            //Arrange
            var patientservicemock = new Mock<IPatientService>();
            var patientcontrolermock = new Mock<PatientDTO>();

            List<PatientDTO> patientDTOs = new List<PatientDTO>();

            patientservicemock.Setup(p => p.GetPatientDTOs()).Returns(patientDTOs);
            var controller = new PatientsController(patientservicemock.Object);
            //Act
            var actionResult = controller.Get();
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        public static PatientDTO Single(int id)
        {
            List<PatientDTO> patientDTOs = Multiple();
            return patientDTOs.Where(a => a.id == id).FirstOrDefault();
        }
        public static List<PatientDTO> Multiple()
        {
            return new List<PatientDTO>(){new PatientDTO()
            {
                id = 1,
                patient_active_issues = "no",
                patient_age = 21,
                patient_allergies = "no"
                ,
                patient_blood_group = "op",
                patient_dob = "1999",
                patient_email_id = "abcd@123",
                patient_gender = "male",
                patient_height = "6.1",
                patient_medical_problems = "no",
                patient_name = "akash",
                patient_phone_number = "9108330564",
                patient_profile_image = "dsy",
                patient_state = "banglore"
            }, new PatientDTO()
            {
                id = 1,
                patient_active_issues = "no",
                patient_age = 21,
                patient_allergies = "no"
                ,
                patient_blood_group = "op",
                patient_dob = "1999",
                patient_email_id = "abcd@123",
                patient_gender = "male",
                patient_height = "6.1",
                patient_medical_problems = "no",
                patient_name = "akash",
                patient_phone_number = "9108330564",
                patient_profile_image = "dsy",
                patient_state = "banglore"
            } };

        }

    }
}
