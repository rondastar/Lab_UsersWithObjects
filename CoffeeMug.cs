using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWithObjects
{
    internal class CoffeeMug : Drinkware
    {
        string _handleType;
        bool _hasLid;

        public CoffeeMug(float sizeInOz, string material, double coolingCoefficient, string color, string handleType, bool hasLid) : base(sizeInOz, material, coolingCoefficient, color)
        {
            _handleType = handleType;
            _hasLid = hasLid;
        }

        public string HandleType { get => _handleType; set => _handleType = value; }
        public bool HasLid { get => _hasLid; set => _hasLid = value; }

        public override string ToString()
        {
            return base.ToString() + $"Handle: {HandleType} - Has lid? {HasLid}";
        }
    }
}
