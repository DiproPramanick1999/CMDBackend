using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using CMD.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    /// <summary>
    /// Implementation of Business Logic Layer Interface for Test module.
    /// </summary>
    public class TestService : ITestService
    {
        private ITestRepository testRepo = null;
        public TestService()
        {
            this.testRepo = new TestRepository();
        }
        public TestService(ITestRepository testRepo)
        {
            this.testRepo = testRepo;
        }

        #region Create
        #region Synchronous
        /// <inheritdoc/>
        public int SaveTest(Test test)
        {
            try
            {
                if (testRepo.GetTestByAppointmentIdAndTestName(test) == null)
                {
                    return testRepo.SaveTest(test);
                }
                else
                {
                    throw new DuplicateTestRecordException();
                }
            }
            catch (NullReferenceException e)
            {
                if (test.Appointment == null)
                {
                    throw new AppointmentNotFoundException();
                }
                else
                {
                    throw e;
                }
            }
        }

        /// <inheritdoc/>
        public int SaveTestDTO(TestDTO testDTO)
        {
            Test test = testDTO.ToTest(testRepo);
            int count = SaveTest(test);
            testDTO.id = test.TestId;
            return count;
        }
        #endregion

        #region Asynchronous
        /// <inheritdoc/>
        async public Task<int> SaveTestAsync(Test test)
        {
            try
            {
                if (testRepo.GetTestByAppointmentIdAndTestName(test) == null)
                {
                    return await testRepo.SaveTestAsync(test);
                }
                else
                {
                    throw new DuplicateTestRecordException();
                }
            }
            catch (NullReferenceException e)
            {
                if (test.Appointment == null)
                {
                    throw new AppointmentNotFoundException();
                }
                else
                {
                    throw e;
                }
            }
        }

        /// <inheritdoc/>
        async public Task<int> SaveTestDTOAsync(TestDTO testDTO)
        {
            Test test = testDTO.ToTest(testRepo);
            int count = await SaveTestAsync(testDTO.ToTest(testRepo));
            testDTO.id = test.TestId;
            return count;
        }
        #endregion
        #endregion

        #region Retrieve
        #region Synchronous
        public List<string> GetAllUniqueTests()
        {
            return testRepo.GetAllUniqueTests();
        }

        #region Test
        /// <inheritdoc/>
        public Test GetTestByAppointmentIdAndTestName(Test test)
        {
            return testRepo.GetTestByAppointmentIdAndTestName(test);
        }

        /// <inheritdoc/>
        public Test GetTestById(int testId)
        {
            return testRepo.GetTestById(testId);
        }

        /// <inheritdoc/>
        public List<Test> GetTests()
        {
            return testRepo.GetTests();
        }

        /// <inheritdoc/>
        public List<Test> GetTestsByAppointmentId(int appointmentId)
        {
            try
            {
                return testRepo.GetTestsByAppointmentId(appointmentId);
            }
            catch (NullReferenceException e)
            {
                throw new AppointmentNotFoundException();
            }
        }
        #endregion

        #region TestDTO
        /// <inheritdoc/>
        public TestDTO GetTestDTOByAppointmentIdAndTestName(TestDTO testDTO)
        {
            return GetTestByAppointmentIdAndTestName(testDTO.ToTest(testRepo)).ToTestDTO();
        }

        /// <inheritdoc/>
        public TestDTO GetTestDTOById(int testId)
        {
            return GetTestById(testId).ToTestDTO();
        }

        /// <inheritdoc/>
        public List<TestDTO> GetTestDTOs()
        {
            return GetTests().ToTestDTOList();
        }

        /// <inheritdoc/>
        public List<TestDTO> GetTestDTOsByAppointmentId(int appointmentId)
        {
            return GetTestsByAppointmentId(appointmentId).ToTestDTOList();
        }
        #endregion
        #endregion

        #region Asynchronous
        async public Task<List<string>> GetAllUniqueTestsAsync()
        {
            return await testRepo.GetAllUniqueTestsAsync();
        }

        #region Test
        /// <inheritdoc/>
        async public Task<Test> GetTestByAppointmentIdAndTestNameAsync(Test test)
        {
            return await testRepo.GetTestByAppointmentIdAndTestNameAsync(test);
        }

        /// <inheritdoc/>
        async public Task<Test> GetTestByIdAsync(int testId)
        {
            return await testRepo.GetTestByIdAsync(testId);
        }

        /// <inheritdoc/>
        async public Task<List<Test>> GetTestsAsync()
        {
            return await testRepo.GetTestsAsync();
        }

        /// <inheritdoc/>
        async public Task<List<Test>> GetTestsByAppointmentIdAsync(int appointmentId)
        {
            try
            {
                return await testRepo.GetTestsByAppointmentIdAsync(appointmentId);
            }
            catch (NullReferenceException e)
            {
                throw new AppointmentNotFoundException();
            }
        }
        #endregion

        #region TestDTO
        /// <inheritdoc/>
        async public Task<TestDTO> GetTestDTOByAppointmentIdAndTestNameAsync(TestDTO testDTO)
        {
            return (await GetTestByAppointmentIdAndTestNameAsync(testDTO.ToTest(testRepo))).ToTestDTO();
        }

        /// <inheritdoc/>
        async public Task<TestDTO> GetTestDTOByIdAsync(int testId)
        {
            return (await GetTestByIdAsync(testId)).ToTestDTO();
        }

        /// <inheritdoc/>
        async public Task<List<TestDTO>> GetTestDTOsAsync()
        {
            return (await GetTestsAsync()).ToTestDTOList();
        }

        /// <inheritdoc/>
        async public Task<List<TestDTO>> GetTestDTOsByAppointmentIdAsync(int appointmentId)
        {
            return (await GetTestsByAppointmentIdAsync(appointmentId)).ToTestDTOList();
        }
        #endregion
        #endregion
        #endregion

        #region Delete
        #region Synchronous
        /// <inheritdoc/>
        public int DeleteTest(Test test)
        {
            return testRepo.DeleteTest(test);
        }

        /// <inheritdoc/>
        public int DeleteTestById(int testId)
        {
            try
            {
                return testRepo.DeleteTest(GetTestById(testId));
            }
            catch (ArgumentNullException e)
            {

                throw new TestNotFoundException();
            }
        }
        #endregion

        #region Asynchronous
        /// <inheritdoc/>
        async public Task<int> DeleteTestAsync(Test test)
        {
            return await testRepo.DeleteTestAsync(test);
        }

        /// <inheritdoc/>
        async public Task<int> DeleteTestByIdAsync(int testId)
        {
            try
            {
                return await DeleteTestAsync(await GetTestByIdAsync(testId));
            }
            catch (ArgumentNullException e)
            {

                throw new TestNotFoundException();
            }
        }
        #endregion
        #endregion
    }
}
