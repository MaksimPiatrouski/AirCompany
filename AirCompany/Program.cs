using planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class Program
    {
        const string showPlanes = "1";
        const string countSummaryPlanesSpecs = "2";
        const string sortPlanes = "3";
        const string findPlanes = "4";
        const string exit = "0";

        static void Main(string[] args)
        {


            List<Plane> planesList = Utils.createPlanesList();

            bool loop = false;
            do
            {
                Utils.printMenu();

                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case showPlanes:

                        Utils.printListOfPlanes(planesList);
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case countSummaryPlanesSpecs:
                        Utils.countSummarySpecs(planesList);
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case sortPlanes:
                        Utils.sortPlanes(planesList);
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case findPlanes:
                        Utils.printFinderMenu();
                        Utils.findPlanes(planesList);
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case exit:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Illegal input");
                        break;
                }
            }
            while (loop);
        }

    }
}
