using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seceret_Sanata
{
    class Person
    {
        public String Name;
        public Person Spouse = null;
        public String Email;
        public Person recipcant;

        public Person(string name, String email)
        {
            Name = name;
            Email = email;
        }

    }
}
