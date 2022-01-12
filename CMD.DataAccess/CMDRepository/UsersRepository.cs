using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{

    public class UsersRepository : IUsersRepository
    {
        private CMDDbContext db = new CMDDbContext();
        public Doctor GetDoctor(string email)
        {
            return db.Doctors.Where(doc => doc.Email == email).FirstOrDefault();
            
        }
    }
}
