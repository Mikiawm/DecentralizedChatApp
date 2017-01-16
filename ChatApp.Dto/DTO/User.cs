using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Dto.DTO
{
    [Serializable()]
    public partial class User
    {
        public Int32 Id { get; set; }

        public String Email { get; set; }

        public String Name { get; set; }

        public String LastName { get; set; }

        public String Login { get; set; }

        public Boolean Active { get; set; }
    }
}
