using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stars.database.entities;

namespace stars.database.repositories
{
    public abstract class BaseRepository<EntityType, IdType> : IBaseRepository<EntityType, IdType>
        where EntityType : BaseEntity<IdType>
    {
        protected AppDbContext _dbContext;

        protected abstract DbSet<EntityType> DbSet { get; }

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(EntityType entity, bool saveChanges = true)
        {
            try
            {
                DbSet.Add(entity);
                if (saveChanges)
                {
                    return _dbContext.SaveChanges() > 0;
                }
            }
            catch (Exception exception)
            {
                return false;
            }

            return false;
        }
        public bool Delete(EntityType entity, bool saveChanges = true)
        {
            try
            {
                DbSet.Remove(entity);
                if (saveChanges)
                {
                    return _dbContext.SaveChanges() > 0;
                }
            }
            catch (Exception exception)
            {
                return false;
            }

            return false;
        }
        public EntityType GetById(IdType id) => DbSet.Find(id);
    }
}
