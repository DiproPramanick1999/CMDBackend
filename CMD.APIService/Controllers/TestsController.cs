using CMD.Business;
using CMD.DTO.APIEntities;
using CMD.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMD.APIService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", PreflightMaxAge = 60)]
    [RoutePrefix("api/tests")]
    public class TestsController : ApiController
    {
        private ITestService testService = null;
        //public TestsController()
        //{
        //    this.testService = new TestService();
        //}
        public TestsController(ITestService testService)
        {
            this.testService = testService;
        }

        #region Synchronous
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<TestDTO> testDTOs = testService.GetTestDTOs();
            return Ok(testDTOs);
        }

        // GET api/<controller>/unique_names
        [Route("unique_names")]
        public IHttpActionResult GetAllUniqueTests()
        {
            List<string> uniqueTestNames = testService.GetAllUniqueTests();
            return Ok(uniqueTestNames);
        }

        // GET api/<controller>/5
        [Route("{testId:int}")]
        public IHttpActionResult Get(int testId)
        {
            TestDTO testDTO = testService.GetTestDTOById(testId);
            if (testDTO == null)
            {
                return Content(HttpStatusCode.NotFound, "No test with given testId found.");
            }
            return Ok(testDTO);
        }

        // GET api/<controller>/appointment/5
        [Route("appointment/{appointmentId:int}")]
        public IHttpActionResult GetTestsByAppointmentId(int appointmentId)
        {
            try
            {
                List<TestDTO> testDTOs = testService.GetTestDTOsByAppointmentId(appointmentId);
                return Ok(testDTOs);
            }
            catch (AppointmentNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post(TestDTO testDTO)
        {
            try
            {
                if (testService.SaveTestDTO(testDTO) > 0)
                {
                    return Created("api/tests", testDTO);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (DuplicateTestRecordException e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            catch (AppointmentNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }

        //// PUT api/<controller>/5
        //public IHttpActionResult Put(int id, [FromBody] string value)
        //{
        //    return StatusCode(HttpStatusCode.NotImplemented);
        //}

        // DELETE api/<controller>/5
        [Route("{testId:int}")]
        public IHttpActionResult Delete(int testId)
        {
            try
            {
                TestDTO testDTO = testService.GetTestDTOById(testId);
                if (testDTO == null)
                {
                    throw new TestNotFoundException();
                }
                if (testService.DeleteTestById(testId) > 0)
                {
                    return Ok(testDTO);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch(TestNotFoundException e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }
        #endregion

        #region Asynchronous
        // GET api/<controller>/async
        [Route("async")]
        async public Task<IHttpActionResult> GetAsync()
        {
            List<TestDTO> testDTOs = await testService.GetTestDTOsAsync();
            return Ok(testDTOs);
        }

        // GET api/<controller>/async/unique_names
        [Route("async/unique_names")]
        async public Task<IHttpActionResult> GetAllUniqueTestsAsync()
        {
            List<string> uniqueTestNames = await testService.GetAllUniqueTestsAsync();
            return Ok(uniqueTestNames);
        }

        // GET api/<controller>/async/5
        [Route("async/{testId:int}")]
        async public Task<IHttpActionResult> GetAsync(int testId)
        {
            TestDTO testDTO = await testService.GetTestDTOByIdAsync(testId);
            if (testDTO == null)
            {
                return Content(HttpStatusCode.NotFound, "No test with given testId found.");
            }
            return Ok(testDTO);
        }

        // GET api/<controller>/async/appointment/5
        [Route("async/appointment/{appointmentId:int}")]
        async public Task<IHttpActionResult> GetTestsByAppointmentIdAsync(int appointmentId)
        {
            try
            {
                List<TestDTO> testDTOs = await testService.GetTestDTOsByAppointmentIdAsync(appointmentId);
                return Ok(testDTOs);
            }
            catch (AppointmentNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }

        // POST api/<controller>/async
        [Route("async")]
        async public Task<IHttpActionResult> PostAsync(TestDTO testDTO)
        {
            try
            {
                if (await testService.SaveTestDTOAsync(testDTO) > 0)
                {
                    return Created("api/tests/async", testDTO);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (DuplicateTestRecordException e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            catch (AppointmentNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }

        //// PUT api/<controller>/async/5
        //[Route("async")]
        //public Task<IHttpActionResult> PutAsync(int id, [FromBody] string value)
        //{
        //    return StatusCode(HttpStatusCode.NotImplemented);
        //}

        // DELETE api/<controller>/async/5
        [Route("async/{testId:int}")]
        async public Task<IHttpActionResult> DeleteAsync(int testId)
        {
            try
            {
                if (await testService.DeleteTestByIdAsync(testId) > 0)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (TestNotFoundException e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, "Unknown error. Contact Server owner.");
            }
        }
        #endregion
    }
}