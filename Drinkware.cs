using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWithObjects
{
    internal class Drinkware
    {
        float _sizeInOz;
        string _material;
        double _coolingCoefficient;
        string _color;
        double _heatLost;

        public Drinkware(float sizeInOz, string material, double coolingCoefficient, string color)
        {
            _sizeInOz = sizeInOz;
            _material = material;
            _coolingCoefficient = coolingCoefficient;
            _color = color;
            _heatLost = 0;
        }

        public float SizeInOz { get => _sizeInOz; set => _sizeInOz = value; }
        public string Material { get => _material; set => _material = value; }
        public double CoolingCoefficient { get => _coolingCoefficient; set => _coolingCoefficient = value; }
        public string Color { get => _color; set => _color = value; }
        public double HeatLost { get => _heatLost; }

        protected void Heatloss()
        {
            // this is a fake formula, standing in for calculating the rate of cooling
            _heatLost -= CoolingCoefficient;
        }

        public override string ToString()
        {
            return $"{GetType().Name} - {SizeInOz} oz. {Color} {Material} - Cooling Coefficient: {CoolingCoefficient} - Current Heat Loss: {HeatLost}";
        }
    }
}
