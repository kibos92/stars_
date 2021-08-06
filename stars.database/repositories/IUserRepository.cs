using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stars.database.entities;

namespace stars.database.repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        public User GetByLoginAndPassword(string login, string password);
    }
}
