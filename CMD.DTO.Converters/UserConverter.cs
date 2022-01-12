using CMD.DTO.APIEntities;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.Converters
{
    public static class UserConverter
    {
        public static UserDTO ToUserDTO(this Doctor doctor)
        {
            UserDTO user = null;
            if (doctor != null)
            {
                user = new UserDTO();
                user.id = doctor.DoctorId;
                user.doctor_name = doctor.Name;
                user.doctor_profile_image = doctor.ProfileImage;
            }

         
            return user;
        }
    }
}
