using CMD.DTO.APIEntities;
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
    /// Business Logic Layer Interface to define contract for Test module.
    /// </summary>
    public interface ITestService
    {
        #region Create
        #region Synchronous
        /// <summary>
        /// Inserts the data in the given test as a record to the database. Throws <see cref="DuplicateTestRecordException"/> if combination of appointmentId and name is already present in the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="DuplicateTestRecordException"></exception>
        /// <exception cref="AppointmentNotFoundException"></exception>
        int SaveTest(Test test);

        /// <summary>
        /// Inserts the data in the given testDTO as a record to the database. Throws <see cref="DuplicateTestRecordException"/> if combination of appointmentId and name is already present in the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="DuplicateTestRecordException"></exception>
        /// <exception cref="AppointmentNotFoundException"></exception>
        int SaveTestDTO(TestDTO testDTO);
        #endregion

        #region Asynchronous
        /// <summary>
        /// Inserts the data in the given test as a record to the database asynchronously. Throws <see cref="DuplicateTestRecordException"/> if combination of appointmentId and name is already present in the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="DuplicateTestRecordException"></exception>
        /// <exception cref="AppointmentNotFoundException"></exception>
        Task<int> SaveTestAsync(Test test);

        /// <summary>
        /// Inserts the data in the given testDTO as a record to the database asynchronously. Throws <see cref="DuplicateTestRecordException"/> if combination of appointmentId and name is already present in the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="DuplicateTestRecordException"></exception>
        /// <exception cref="AppointmentNotFoundException"></exception>
        Task<int> SaveTestDTOAsync(TestDTO testDTO);
        #endregion
        #endregion

        #region Retrieve
        #region Synchronous
        /// <summary>
        /// Retrieves all the unique test names from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="string"/> which correspond to all the unique test names retrieved from the database.</returns>
        List<string> GetAllUniqueTests();

        #region Test
        /// <summary>
        /// Retrieves a test record from the database with the same Name and AppointmentId as the given test. Returns null if not found.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A matching <see cref="Test"/> or null</returns>
        Test GetTestByAppointmentIdAndTestName(Test test);

        /// <summary>
        /// Retrieves the test record which has primary key equal to the given testId. Returns null if not found.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>A <see cref="Test"/> which represents retrieved record or null.</returns>
        Test GetTestById(int testId);

        /// <summary>
        /// Retrieves all the test records from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Test"/> which correspond to all the records retrieved from the database.</returns>
        List<Test> GetTests();

        /// <summary>
        /// Retrieves all the test records which have the given appointmentId from the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Test"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="AppointmentNotFoundException"></exception>
        List<Test> GetTestsByAppointmentId(int appointmentId);
        #endregion

        #region TestDTO
        /// <summary>
        /// Retrieves a test record from the database with the same Name and AppointmentId as the given testDTO. Returns null if not found.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A matching <see cref="TestDTO"/> or null</returns>
        TestDTO GetTestDTOByAppointmentIdAndTestName(TestDTO testDTO);

        /// <summary>
        /// Retrieves the test record which has primary key equal to the given testId. Returns null if not found.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>A <see cref="TestDTO"/> which represents retrieved record or null.</returns>
        TestDTO GetTestDTOById(int testId);

        /// <summary>
        /// Retrieves all the test records from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="TestDTO"/> which correspond to all the records retrieved from the database.</returns>
        List<TestDTO> GetTestDTOs();

        /// <summary>
        /// Retrieves all the test records which have the given appointmentId from the database. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A <see cref="List{T}"/> of <see cref="TestDTO"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="AppointmentNotFoundException"></exception>
        List<TestDTO> GetTestDTOsByAppointmentId(int appointmentId);
        #endregion
        #endregion

        #region Asynchronous
        /// <summary>
        /// Retrieves all the unique test names from the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="string"/> which correspond to all the unique test names retrieved from the database.</returns>
        Task<List<string>> GetAllUniqueTestsAsync();

        #region Test
        /// <summary>
        /// Retrieves a test record from the database with the same Name and AppointmentId as the given test asynchronously. Returns null if not found.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a matching <see cref="Test"/> or null</returns>
        Task<Test> GetTestByAppointmentIdAndTestNameAsync(Test test);

        /// <summary>
        /// Retrieves the test record which has primary key equal to the given testId asynchronously. Returns null if not found.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Test"/> which represents retrieved record or null.</returns>
        Task<Test> GetTestByIdAsync(int testId);

        /// <summary>
        /// Retrieves all the test records from the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="Test"/> which correspond to all the records retrieved from the database.</returns>
        Task<List<Test>> GetTestsAsync();

        /// <summary>
        /// Retrieves all the test records which have the given appointmentId from the database asynchronously. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="Test"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="AppointmentNotFoundException"></exception>
        Task<List<Test>> GetTestsByAppointmentIdAsync(int appointmentId);
        #endregion

        #region TestDTO
        /// <summary>
        /// Retrieves a test record from the database with the same Name and AppointmentId as the given testDTO asynchronously. Returns null if not found.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a matching <see cref="TestDTO"/> or null</returns>
        Task<TestDTO> GetTestDTOByAppointmentIdAndTestNameAsync(TestDTO testDTO);

        /// <summary>
        /// Retrieves the test record which has primary key equal to the given testId asynchronously. Returns null if not found.
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="TestDTO"/> which represents retrieved record or null.</returns>
        Task<TestDTO> GetTestDTOByIdAsync(int testId);

        /// <summary>
        /// Retrieves all the test records from the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="TestDTO"/> which correspond to all the records retrieved from the database.</returns>
        Task<List<TestDTO>> GetTestDTOsAsync();

        /// <summary>
        /// Retrieves all the test records which have the given appointmentId from the database asynchronously. Throws <see cref="AppointmentNotFoundException"/> if an <see cref="Appointment"/> with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="TestDTO"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="AppointmentNotFoundException"></exception>
        Task<List<TestDTO>> GetTestDTOsByAppointmentIdAsync(int appointmentId);
        #endregion
        #endregion
        #endregion

        #region Delete
        #region Synchronous
        /// <summary>
        /// Deletes the database record corresponding to the given test.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        int DeleteTest(Test test);

        /// <summary>
        /// Deletes the database record corresponding to the given testId. Throws <see cref="TestNotFoundException"/> if given testId doesn't exist in the database.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="TestNotFoundException"></exception>
        int DeleteTestById(int testId);
        #endregion

        #region Asynchronous
        /// <summary>
        /// Deletes the database record corresponding to the given test asynchronously.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int representing the number of state entries written to the underlying database.</returns>
        Task<int> DeleteTestAsync(Test test);

        /// <summary>
        /// Deletes the database record corresponding to the given testId asynchronously. Throws <see cref="TestNotFoundException"/> if given testId doesn't exist in the database.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int representing the number of state entries written to the underlying database.</returns>
        /// <exception cref="TestNotFoundException"></exception>
        Task<int> DeleteTestByIdAsync(int testId);
        #endregion
        #endregion
    }
}
