using System;

namespace Beans
{
    [Serializable]
    class PassengerPlane : Plane
    {
        private int _numOfPassengers;
        private int _numOfClasses;

        public PassengerPlane(string name, int year, double price, int numOfPassengers, int maxDistance, int maxSpeed, double capacity, int maxLoad, int numOfClasses) : base(name, year, price, maxDistance, maxSpeed, capacity, maxLoad)
        {
            this._numOfPassengers = numOfPassengers;
            this._numOfClasses = numOfClasses;
        }

        public int numOfPassengers
        {
            get { return _numOfPassengers; }
            set { _numOfPassengers = value; }
        }

        public int numOfClasses
        {
            get { return _numOfClasses; }
            set { _numOfClasses = value; }
        }
        public override string ToString()
        {
            return name + "\n\n. Type: " + GetType().Name + "\n. Year: " + year + "\n. Price, mln $: " + price + "\n. Number of Passengers: " + numOfPassengers
                + "\n. Max distance, km: " + maxDistance + "\n. Max speed, km/h: " + maxSpeed + "\n. Cargo capacity, m3: " + capacity
                + "\n. Max cargo load, kg: " + maxLoad + "\n. Number of classes: " + numOfClasses + "\n";
        }
    }
}
