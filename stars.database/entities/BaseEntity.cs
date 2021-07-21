using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stars.database.entities
{
    public abstract class BaseEntity<IdType>
    {
        public IdType Id { get; set; }
    }
}
