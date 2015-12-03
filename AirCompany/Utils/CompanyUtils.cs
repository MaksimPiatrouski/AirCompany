using Beans;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    class CompanyUtils
    {
        const string companyName = "Petromax Airlines";

        //Creates new Company object
        public static Company createCompany(List<Plane> planesList)
    {
        int numberOfPlanes = planesList.Count();
        double summaryPrice = 0;

        foreach (Plane p in planesList)
        {
            summaryPrice += p.price;
        }
        return new Company(companyName, numberOfPlanes, summaryPrice);
    }
}
}
