using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public interface IUserService
    {
        Doctor GetDoctor(string email);
        UserDTO GetDoctorDTO(string email);
    }
}
