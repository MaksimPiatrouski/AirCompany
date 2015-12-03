using Beans;
using System;
using System.Collections.Generic;
using Utils;

namespace Runner
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


            List<Plane> planesList = PlaneListUtils.createPlanesList();
            Company myCompany = CompanyUtils.createCompany(planesList);

            bool loop = false;
            do
            {
                NavigationUtils.printMenu();

                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case showPlanes:
                        PlaneListUtils.printListOfPlanes(planesList);
                        loop = NavigationUtils.hasBackToMenuSelector();
                        break;

                    case addPlanes:
                        AddPlanesUtils.addPlanes(planesList);
                        loop = NavigationUtils.hasBackToMenuSelector();
                        break;

                    case removePlanes:
                        RemovePlaneUtils.removePlane(planesList);
                        loop = NavigationUtils.hasBackToMenuSelector();
                        break;

                    case countSummaryPlanesSpecs:
                        SumarySpecsUtils.planesSummarySpecs(planesList);
                        loop = NavigationUtils.hasBackToMenuSelector();
                        break;

                    case sortPlanes:
                        SortPlanesUtils.sortPlanes(planesList);
                        loop = NavigationUtils.hasBackToMenuSelector();
                        break;

                    case findPlanes:
                        NavigationUtils.printFinderMenu();
                        string paramSelector = Console.ReadLine();
                        bool correctSelection = FindPlaneUtils.hasCorrectSelection(paramSelector);
                        if (correctSelection)
                        {
                            FindPlaneUtils.findPlanes(planesList, paramSelector);
                            loop = NavigationUtils.hasBackToMenuSelector();
                        }
                        break;

                    case showCompanyStats:
                        Console.WriteLine(myCompany.ToString());
                        loop = NavigationUtils.hasBackToMenuSelector();
                        break;

                    case workWExternal:
                        ExternalFileUtils.fileActions(planesList);
                        loop = NavigationUtils.hasBackToMenuSelector();
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
