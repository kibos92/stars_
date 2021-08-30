using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stars.database.entities
{
    public class User : BaseEntity<int>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Stock { get; set; } = 13;
        public int Fleet { get; set; }
        public int Building { get; set; } = 1;
        public int ReqBuild { get; set; } = 10;
        public int ReqFleet { get; set; } = 10;
    }
}
