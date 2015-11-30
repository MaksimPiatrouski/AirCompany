using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planes
{
    [Serializable]
    class FreightPlane : Plane
    {
        private int _numOfHatches;

        public FreightPlane(string name, int year, double price, int maxDistance, int maxSpeed, double capacity, int maxLoad, int numOfHatches) : base(name, year, price, maxDistance, maxSpeed, capacity, maxLoad)
        {
            this._numOfHatches = numOfHatches;
        }

        public int numOfHatches
        {
            get { return _numOfHatches; }
            set { _numOfHatches = value; }
        }
        public override string ToString()
        {
            return name + "\n\n. Type: " + GetType().Name + "\n. Year: " + year + "\n. Price, mln $: " + price + "\n. Max distance: " + maxDistance
                + "\n. Max speed, km/h: " + maxSpeed + "\n. Cargo capacity, m3: " + capacity + "\n. Max cargo load, kg: " + maxLoad
                + "\n. Number of hatches: " + numOfHatches + "\n";
        }
    }
}
