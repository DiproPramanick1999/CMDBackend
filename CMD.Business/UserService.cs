using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    public class UserService : IUserService
    {
        IUsersRepository repo;

        public UserService()
        {
            this.repo = new UsersRepository();
        }
        public Doctor GetDoctor(string email)
        {
            return repo.GetDoctor(email);
        }

        public UserDTO GetDoctorDTO(string email)
        {
            var user = GetDoctor(email);
            UserDTO userDTO = user.ToUserDTO();
            return userDTO;
        }
    }
}
