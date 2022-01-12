using CMD.Business;
using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace CMD.APIService.Controllers
{
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController()
        {
            this.userService = new UserService();
        }
        [Authorize]
        public IHttpActionResult Get()
        {
            var identityClaims = User.Identity;
            var doc = userService.GetDoctorDTO(identityClaims.Name);
            if (doc != null)
                return Ok(doc);
            else
                return NotFound();
        }
    }
}
