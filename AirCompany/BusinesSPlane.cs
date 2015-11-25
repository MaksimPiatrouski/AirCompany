using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planes
{
    class BusinessPlane : Plane
    {
        private int _numOfVipPassengers;

        public BusinessPlane(string name, int year, double price, int numOfVipPassengers, int maxDistance, int maxSpeed, double capacity, int maxLoad) : base(name, year, price, maxDistance, maxSpeed, capacity, maxLoad)
        {
            this._numOfVipPassengers = numOfVipPassengers;
        }

        public int numOfVipPassengers
        {
            get { return _numOfVipPassengers; }
            set { _numOfVipPassengers = value; }
        }

        public override string ToString()
        {
            return "Type: " + GetType().Name + "\n\n. Year: " + year + "\n. Name: " + name + "\n. Price, mln $: " + price
                + "\n. Number of VIP passengers: " + numOfVipPassengers + "\n. Max distance, km: " + maxDistance + "\n. Max speed, km/h: " + maxSpeed
                + "\n. Cargo capacity, m3: " + capacity + "\n. Max cargo load, kg: " + maxLoad + "\n";
        }
    }
}
