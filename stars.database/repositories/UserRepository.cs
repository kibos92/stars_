using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stars.database.entities;

namespace stars.database.repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        protected override DbSet<User> DbSet => _dbContext.Users;

        public UserRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
