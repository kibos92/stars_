using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stars.database.entities;

namespace stars.database.repositories
{
    public interface IBaseRepository<EntityType, IdType> where EntityType : BaseEntity<IdType>
    {
        bool Add(EntityType entity, bool saveChanges = true);
        bool Delete(EntityType entity, bool saveChanges = true);
        EntityType GetById(IdType id);
    }
}
