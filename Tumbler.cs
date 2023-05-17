using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWithObjects
{
    internal class Tumbler : Drinkware
    {
        public Tumbler(float sizeInOz, string material, double coolingCoefficient, string color) : base(sizeInOz, material, coolingCoefficient, color)
        {

        }
    }
}
