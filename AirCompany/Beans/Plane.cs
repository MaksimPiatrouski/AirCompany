using System;
using System.Xml.Serialization;

namespace Beans
{
    [Serializable]
    [XmlType("Plane")]
    [XmlInclude(typeof(BusinessPlane)), XmlInclude(typeof(FreightPlane)), XmlInclude(typeof(PassengerPlane))]

    public class Plane
    {
        private string _name;
        private int _year;
        private double _price;
        private int _maxDistance;
        private int _maxSpeed;
        private double _capacity;
        private int _maxLoad;

        public Plane()
        {
        }

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

        [XmlElement("Name")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement("Year")]
        public int year
        {
            get { return _year; }
            set { _year = value; }
        }

        [XmlElement("Price")]
        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        [XmlElement("MaximumDistance")]
        public int maxDistance
        {
            get { return _maxDistance; }
            set { _maxDistance = value; }
        }

        [XmlElement("MaximumSpeed")]
        public int maxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }

        [XmlElement("Capacity")]
        public double capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        [XmlElement("MaximumLoad")]
        public int maxLoad
        {
            get { return _maxLoad; }
            set { _maxLoad = value; }
        }
    }
}
