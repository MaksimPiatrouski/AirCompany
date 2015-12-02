namespace Beans
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
<<<<<<< HEAD
            return "\nAirCompany: " + companyName + "\n. Number of planes: " + numberOfPlanes
=======
            return "\n. AirCompany name: \"" + companyName + "\"\n. Number of planes: " + numberOfPlanes
>>>>>>> 0792511ef831006e683b2b2b73f00cd2faefab63
                + "\n. Summary planes price, mls $: " + summaryPrice + "\n";
        }
    }
}
