using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWithObjects
{
    internal class User
    {
        string _firstName;
        string _lastName;
        List<Drinkware> _drinkwares;

        public User(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _drinkwares = new List<Drinkware>();
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        internal List<Drinkware> Drinkwares { get => _drinkwares; }

        public override string ToString()
        {
            return $"User: {FirstName} {LastName} - # of Drinkware: {Drinkwares.Count}";
        }
    }
}
