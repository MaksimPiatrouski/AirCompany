using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planes
{
    [Serializable]
    class Plane
    {
        private string _name;
        private int _year;
        private double _price;
        private int _maxDistance;
        private int _maxSpeed;
        private double _capacity;
        private int _maxLoad;

        public Plane(string name, int year, double price, int maxDistance, int maxSpeed, double capacity, int maxLoad)
        {
            this._name = name;
            this._year = year;
            this._price = price;
            this._maxDistance = maxDistance;
            this._maxSpeed = maxSpeed;
            this._capacity = capacity;
            this._maxLoad = maxLoad;
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int year
        {
            get { return _year; }
            set { _year = value; }
        }

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int maxDistance
        {
            get { return _maxDistance; }
            set { _maxDistance = value; }
        }

        public int maxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }

        public double capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public int maxLoad
        {
            get { return _maxLoad; }
            set { _maxLoad = value; }
        }
    }
}
