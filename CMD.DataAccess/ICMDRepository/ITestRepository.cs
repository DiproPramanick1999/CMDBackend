using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    /// <summary>
    /// Data Access Layer Interface to define contract for Test module.
    /// </summary>
    public interface ITestRepository
    {
        #region Create
        /// <summary>
        /// Inserts the data in the given test as a record to the database.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int that represenst the number of state entries written to the underlying database.</returns>
        int SaveTest(Test test);

        /// <summary>
        /// Inserts the data in the given test as a record to the database asynchronously.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int that represents the number of state entries written to the underlying database.</returns>
        Task<int> SaveTestAsync(Test test);
        #endregion

        #region Retrieve
        #region Synchronous
        /// <summary>
        /// Retrieves all the unique test names from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="string"/> which correspond to all the unique test names retrieved from the database.</returns>
        List<string> GetAllUniqueTests();

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
        /// Retrieves all the test records which have the given appointmentId from the database. Throws NullReferenceException if an Appointment with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Test"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="NullReferenceException"></exception>
        List<Test> GetTestsByAppointmentId(int appointmentId);
        #endregion

        #region Asynchronous
        /// <summary>
        /// Retrieves all the unique test names from the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="string"/> which correspond to all the unique test names retrieved from the database.</returns>
        Task<List<string>> GetAllUniqueTestsAsync();

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
        /// Retrieves all the test records which have the given appointmentId from the database asynchronously. Throws NullReferenceException if an Appointment with given appointmentId doesn't exist.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="List{T}"/> of <see cref="Test"/> which correspond to the records retrieved from the database.</returns>
        /// <exception cref="NullReferenceException"></exception>
        Task<List<Test>> GetTestsByAppointmentIdAsync(int appointmentId);
        #endregion
        #endregion

        #region Update
        /// <summary>
        /// Updates the database record corresponding to the given test with the data in test.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        int UpdateTest(Test test);

        /// <summary>
        /// Updates the database record corresponding to the given test with the data in test asynchronously.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int representing the number of state entries written to the underlying database.</returns>
        Task<int> UpdateTestAsync(Test test);
        #endregion

        #region Delete
        /// <summary>
        /// Deletes the database record corresponding to the given test.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>An int representing the number of state entries written to the underlying database.</returns>
        int DeleteTest(Test test);

        /// <summary>
        /// Deletes the database record corresponding to the given test asynchronously.
        /// </summary>
        /// <param name="test"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an int representing the number of state entries written to the underlying database.</returns>
        Task<int> DeleteTestAsync(Test test);
        #endregion

        #region Temporary Workaround
        Appointment GetAppointmentById(int appointmentId);          // Temporary Workaround
        #endregion
    }
}
