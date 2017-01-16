using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Dal.DBModel
{
    public partial class UserEF
    {
        public UserEF()
        {

        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public bool Active { get; set; }

        public string Password { get; set; }
    }
}
