using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.Converters
{
    public static class TestConverter
    {
        //static IAppointmentRepository appointmentRepo = null;
        //static TestConverter()
        //{
        //    appointmentRepo = new AppointmentRepository();
        //}

        /// <summary>
        /// Converts the testDTO to Test entity.
        /// </summary>
        /// <param name="testDTO"></param>
        /// <param name="testRepo"></param>
        /// <returns>The converted Test object or null if the testDTO is null.</returns>
        public static Test ToTest(this TestDTO testDTO, ITestRepository appointmentRepo)
        {
            if (testDTO == null)
            {
                return null;
            }
            Test test = new Test
            {
                TestId = testDTO.id,
                Appointment = appointmentRepo.GetAppointmentById(testDTO.appointment_id),
                Name = testDTO.test_name
            };

            return test;
        }

        /// <summary>
        /// Converts the test entity to TestDTO entity.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>The converted TestDTO object or null if the test is null.</returns>
        public static TestDTO ToTestDTO(this Test test)
        {
            if (test == null)
            {
                return null;
            }
            TestDTO testDTO = new TestDTO
            {
                id = test.TestId,
                appointment_id = test.Appointment.AppointmentId,
                test_name = test.Name
            };
            return testDTO;
        }

        /// <summary>
        /// Converts the List of test entities to List of TestDTO entities.
        /// </summary>
        /// <param name="tests"></param>
        /// <returns>The converted List<TestDTO> object or null if the tests is null.</returns>
        public static List<TestDTO> ToTestDTOList(this List<Test> tests)
        {
            if (tests == null)
            {
                return null;
            }
            List<TestDTO> testDTOs = new List<TestDTO>();
            foreach (Test test in tests)
            {
                testDTOs.Add(test.ToTestDTO());
            }
            return testDTOs;
        }
    }
}
