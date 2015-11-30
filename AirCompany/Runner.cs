using planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class Runner
    {
        const string showPlanes = "1";
        const string addPlanes = "2";
        const string removePlanes = "3";
        const string countSummaryPlanesSpecs = "4";
        const string sortPlanes = "5";
        const string findPlanes = "6";
        const string showCompanyStats = "7";
        const string workWExternal = "8";

        const string exit = "0";

        static void Main(string[] args)
        {


            List<Plane> planesList = Utils.createPlanesList();
            Company myCompany = Utils.createCompany(planesList);

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

                    case addPlanes:
                        AddPlanesUtils.addPlanes(planesList);
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case removePlanes:
                        RemovePlaneUtils.removePlane(planesList);
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case countSummaryPlanesSpecs:
                        Utils.printSummarySpecs(planesList);
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

                    case showCompanyStats:
                        Console.WriteLine(myCompany.ToString());
                        loop = Utils.hasBackToMenuSelector();
                        break;

                    case workWExternal:
                        ExternalFileUtils.fileActions(planesList);
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
