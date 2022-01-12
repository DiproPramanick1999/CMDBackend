using CMD.Business;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace CMD.UnitTests
{
    [TestClass]
    public class PatientsServiceUnitTest
    {
        [TestMethod]
        public void GetPatientDTOs_Oncall_ShouldreturnListOfObjectsOfType_patientDTO()
        {
            //Arrange
            var patientrepositoryemock = new Mock<IPatientRepository>();
            var patientservicemock= new Mock<Patient>();

            patientrepositoryemock.Setup(p => p.GetPatients()).Returns(Multiple());
            var Service = new PatientService(patientrepositoryemock.Object);
            //Act
            var Result= Service.GetPatientDTOs();
            //var contentResult = actionResult as OkNegotiatedContentResult<List<Patient>>;
            //Assert
            Assert.AreEqual(Result.Count, 2);
        }
        [TestMethod]
        public void GetpatientDTOById_OncallWithValidId_shouldreturnobjectOfType_patientDTO()
        {
            //Arrange
            var patientrepositoryemock = new Mock<IPatientRepository>();
            var patientservicemock = new Mock<Patient>();
            patientrepositoryemock.Setup(p => p.GetPatientById(1)).Returns(Single(1));
            var Service = new PatientService(patientrepositoryemock.Object);
            //Act
            var Result = Service.GetPatientDTOById(1);
            //var contentResult = actionResult as OkNegotiatedContentResult<List<Patient>>;
            //Assert
            Assert.IsInstanceOfType(Result, typeof(PatientDTO));
        }
        [TestMethod]
        public void GetpatientDTOById_OncallWithValidId_shouldreturnobjectOfDTOwithSameId()
        {

            //Arrange
            var patientrepositoryemock = new Mock<IPatientRepository>();
            var patientservicemock = new Mock<Patient>();
            patientrepositoryemock.Setup(p => p.GetPatientById(1)).Returns(Single(1));
            var Service = new PatientService(patientrepositoryemock.Object);
            //Act
            var Result = Service.GetPatientDTOById(1);
            //Assert
            Assert.AreEqual(Result.id, 1);

        }
        [TestMethod]
        public void GetpatientDTOById_OncallWithinValidId_shouldreturnnull()
        {
            //Arrange
            var patientrepositoryemock = new Mock<IPatientRepository>();
            var patientservicemock = new Mock<Patient>();
            patientrepositoryemock.Setup(p => p.GetPatientById(100)).Returns(Single(100));
            var Service = new PatientService(patientrepositoryemock.Object);
            //Act
            var Result = Service.GetPatientDTOById(100);
            //var contentResult = actionResult as OkNegotiatedContentResult<List<Patient>>;
            //Assert
            Assert.IsNull(Result);
        }
        public static List<Patient> Multiple()
        {
            return new List<Patient>()
            {
                new Patient()
                {
                    ActiveIssues="no",
                    PatientId=1,
                    PatientLocation="banglore",
                    Name="charan",
                    Email="charan@123",
                    PhoneNumber="9108330876",
                    ProfileImage="abcd",
                    Age=22,
                    Allergies="no",
                    Dob="1999",
                    BloodGroup="op",
                    Height="6.2",
                    Gender="male",
                    MedicalProblems="no"
                },
                new Patient()
                {
                    ActiveIssues="no",
                    PatientId=2,
                    PatientLocation="banglore",
                    Name="charan",
                    Email="charan@123",
                    PhoneNumber="9108330876",
                    ProfileImage="abcd",
                    Age=22,
                    Allergies="no",
                    Dob="1999",
                    BloodGroup="op",
                    Height="6.2",
                    Gender="male",
                    MedicalProblems="no"
                }
            };

        }
        public static Patient Single(int id)
        {
            List<Patient> patients = Multiple();
            return patients.Where(a => a.PatientId== id).FirstOrDefault();
        }
    }
}
