using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class Company
    {
        private string _companyName;
        private int _numberOfPlanes;
        private double _summaryPrice;

        public Company(string companyName, int numberOfPlanes, double summaryPrice)
        {
            this._companyName = companyName;
            this._numberOfPlanes = numberOfPlanes;
            this._summaryPrice = summaryPrice;
        }

        public string companyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public int numberOfPlanes
        {
            get { return _numberOfPlanes; }
            set { _numberOfPlanes = value; }
        }

        public double summaryPrice
        {
            get { return _summaryPrice; }
            set { _summaryPrice = value; }
        }

        public override string ToString()
        {
            return "\n. AirCompany name: \"" + companyName + "\"\n. Number of planes: " + numberOfPlanes
                + "\n. Summary planes price, mls $: " + summaryPrice + "\n";
        }
    }
}
