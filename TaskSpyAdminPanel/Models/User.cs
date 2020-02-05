using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpyAdminPanel.Models
{
    class User
    {
        public string Name
        {
            get;
            set;
        }
        public string Pseudonym
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }
        public bool IsReal
        {
            get; set;
        }
        public User()
        {

        }
        public User(string name, string pseydonym, int id, bool isReal)
        {
            Name = name;
            Pseudonym = pseydonym;
            Id = id;
            IsReal = isReal;
        }
    }
}
