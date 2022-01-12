using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    /// <summary>
    /// Implementation of Data Access Layer Interface for Test module.
    /// </summary>
    public class TestRepository : ITestRepository
    {
        private CMDDbContext db = new CMDDbContext();
        //private CMDDbContextSingleton db;
        //public TestRepository()
        //{
        //    db = CMDDbContextSingleton.CMDDbContextInstance;
        //}

        #region Create
        /// <inheritdoc/>
        public int SaveTest(Test test)
        {
            db.Tests.Add(test);
            return db.SaveChanges();
        }

        async public Task<int> SaveTestAsync(Test test)
        {
            db.Tests.Add(test);
            return await db.SaveChangesAsync();
        }
        #endregion

        #region Retrieve
        #region Synchronous
        /// <inheritdoc/>
        public List<string> GetAllUniqueTests()
        {
            return db.Tests.Select(t => t.Name).Distinct().ToList();
        }

        /// <inheritdoc/>
        public Test GetTestByAppointmentIdAndTestName(Test test)
        {
            var result = (from t in db.Appointments.Find(test.Appointment.AppointmentId).Tests
                          where t.Name == test.Name
                          select t).FirstOrDefault();

            return result;
        }

        /// <inheritdoc/>
        public Test GetTestById(int testId)
        {
            return db.Tests.Find(testId);
        }

        /// <inheritdoc/>
        public List<Test> GetTests()
        {
            return db.Tests.ToList();
        }

        /// <inheritdoc/>
        public List<Test> GetTestsByAppointmentId(int appointmentId)
        {
            return db.Appointments.Find(appointmentId).Tests;
        }
        #endregion

        #region Asynchronous
        /// <inheritdoc/>
        async public Task<List<string>> GetAllUniqueTestsAsync()
        {
            return await db.Tests.Select(t => t.Name).Distinct().ToListAsync();
        }

        /// <inheritdoc/>
        async public Task<Test> GetTestByAppointmentIdAndTestNameAsync(Test test)
        {
            var result = (from t in (await db.Appointments.FindAsync(test.Appointment.AppointmentId)).Tests
                          where t.Name == test.Name
                          select t).FirstOrDefault();

            return result;
        }

        /// <inheritdoc/>
        async public Task<Test> GetTestByIdAsync(int testId)
        {
            return await db.Tests.FindAsync(testId);
        }

        /// <inheritdoc/>
        async public Task<List<Test>> GetTestsAsync()
        {
            return await db.Tests.ToListAsync();
        }

        /// <inheritdoc/>
        async public Task<List<Test>> GetTestsByAppointmentIdAsync(int appointmentId)
        {
            return (await db.Appointments.FindAsync(appointmentId)).Tests;
        }
        #endregion
        #endregion

        #region Update
        /// <inheritdoc/>
        public int UpdateTest(Test test)
        {
            db.Entry(test).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        /// <inheritdoc/>
        async public Task<int> UpdateTestAsync(Test test)
        {
            db.Entry(test).State = System.Data.Entity.EntityState.Modified;
            return await db.SaveChangesAsync();
        }
        #endregion

        #region Delete
        /// <inheritdoc/>
        public int DeleteTest(Test test)
        {
            db.Tests.Remove(test);
            return db.SaveChanges();
        }

        /// <inheritdoc/>
        async public Task<int> DeleteTestAsync(Test test)
        {
            db.Tests.Remove(test);
            return await db.SaveChangesAsync();
        }
        #endregion

        #region Temporary Workaround
        /// <inheritdoc/>
        public Appointment GetAppointmentById(int appointmentId)          // Temporary Workaround
        {
            return db.Appointments.Find(appointmentId);
        }
        #endregion
    }
}
