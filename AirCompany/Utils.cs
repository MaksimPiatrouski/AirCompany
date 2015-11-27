using planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class Utils
    {
        const string exit = "0";
        const string yearSelect = "1";
        const string priceSelect = "2";
        const string distSelect = "3";
        const string speedSelect = "4";
        const string capacitySelect = "5";
        const string loadSelect = "6";
        const string companyName = "Petromax Airlines";

        static double minValueD = 0;
        static double maxValueD = 0;
        static int minValueI = 0;
        static int maxValueI = 0;

        //Creates list of new Plane objects
        public static List<Plane> createPlanesList()
        {
            List<Plane> planesList = new List<Plane>();
            planesList.Add(new PassengerPlane("AirBus A380-900", 2013, 401.4, 656, 15400, 1020, 318.4, 23600, 3));
            planesList.Add(new PassengerPlane("Boeing 747", 2010, 255.3, 581, 14850, 988, 275.6, 21200, 3));
            planesList.Add(new BusinessPlane("Bombardier BD-700", 2008, 48.2, 3, 9360, 950, 18.2, 850));
            planesList.Add(new BusinessPlane("Dassault Falcon 900", 2015, 17.6, 5, 8334, 916, 16.6, 680));
            planesList.Add(new FreightPlane("An-225 Mriya", 2001, 225.3, 4000, 850, 1300, 152000, 2));
            return planesList;
        }

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

        //Prints main menu in console
        public static void printMenu()
        {
            Console.WriteLine("\n------------------ Menu ------------------\n"
                    + "1. Show list of planes\n"
                    + "2. Count summary capacity and load\n"
                    + "3. Sort planes by max range\n"
                    + "4. Find planes by parameter\n"
                    + "5. Print aircompany stats\n"
                    + "0. Exit\n"
                    + "------------------------------------------\n");
        }

        //Prints planes finder Menu in console
        public static void printFinderMenu()
        {
            Console.WriteLine("\nSelect parameter for search:\n"
                            + "1. Year\n" + "2. Price\n" + "3. Max distance\n" + "4. Max speed\n" + "5. Capacity\n" + "6. Max load\n");

        }

        //Allows go back to Main Menu or Exit application
        public static bool hasBackToMenuSelector()
        {
            Console.WriteLine("\nPress any key to back to menu\n" + "Press 0 to exit\n");
            string input = Console.ReadLine();
            if (input == exit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Prints list of Plane objects in console
        public static void printListOfPlanes(List<Plane> planesList)
        {
            Console.WriteLine("\n----------- List of planes ---------------\n");
            foreach (Plane p in planesList)
            {
                Console.WriteLine(p.ToString());
            }
        }

        //Counts and prints summary capacity and maximum load
        public static void printSummarySpecs(List<Plane> planesList)
        {
            double summaryCapacity = 0;
            int summaryLoad = 0;

            foreach (Plane p in planesList)
            {
                summaryCapacity += p.capacity;
                summaryLoad += p.maxLoad;
            }
            Console.WriteLine("\nSummary capacity is " + summaryCapacity + " m3\n"
                                    + "Summary load is " + summaryLoad + " kg\n");
        }

        //Sorts Plane objects by maximum distance
        public static void sortPlanes(List<Plane> planesList)
        {
            planesList.Sort((p1, p2) => p1.maxDistance.CompareTo(p2.maxDistance));
            planesList.Reverse();
            for (int i = 0; i < planesList.Count; i++)
            {
                int position = i + 1;
                Console.WriteLine(position + ") " + planesList[i].ToString());
            }
        }

        //Checks validity of selected parameter
        public static bool hasCorrectSelection(string paramSelector)
        {
            if (paramSelector.Equals(yearSelect) || paramSelector.Equals(priceSelect) || paramSelector.Equals(distSelect) || paramSelector.Equals(speedSelect) ||
                paramSelector.Equals(capacitySelect) || paramSelector.Equals(loadSelect))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Illegal input\n");
                return false;
            }
        }


        //Checks correctness of entered values and initialises variables if values are valid
        public static bool hasCorrectFormat(List<Plane> planesList, string paramSelector)
        {
            bool correctFormat = true;
            Console.WriteLine("Enter min value");
            string min = Console.ReadLine();
            Console.WriteLine("Enter max value");
            string max = Console.ReadLine();

            if (paramSelector.Equals(priceSelect) || paramSelector.Equals(capacitySelect))
            {
                try
                {
                    minValueD = double.Parse(min);
                    maxValueD = double.Parse(max);
                }
                catch (FormatException e)
                {
                    correctFormat = false;
                    Console.WriteLine("Illegal format (" + e.Message + ")\n");
                }
            }
            else
            {
                try
                {
                    minValueI = int.Parse(min);
                    maxValueI = int.Parse(max);
                }
                catch (FormatException e)
                {
                    correctFormat = false;
                    Console.WriteLine("Illegal format (" + e.Message + ")\n");
                }
            }
            return correctFormat;
        }

        //Finds planes by entered parameters and prints list of planes
        public static void findPlanes(List<Plane> planesList, string paramSelector)
        {
            bool correctFormat = hasCorrectFormat(planesList, paramSelector);

            List<Plane> planesFound = new List<Plane>();

            if (correctFormat)
            {
                foreach (Plane p in planesList)
                {
                    if (paramSelector.Equals(yearSelect))
                    {
                        if (p.year >= minValueI && p.year <= maxValueI)
                            planesFound.Add(p);
                    }

                    if (paramSelector.Equals(priceSelect))
                    {
                        if (p.price >= minValueD && p.price <= maxValueD)
                            planesFound.Add(p);
                    }

                    if (paramSelector.Equals(distSelect))
                    {
                        if (p.maxDistance >= minValueI && p.maxDistance <= maxValueI)
                            planesFound.Add(p);
                    }

                    if (paramSelector.Equals(speedSelect))
                    {
                        if (p.maxSpeed >= minValueI && p.maxSpeed <= maxValueI)
                            planesFound.Add(p);
                    }

                    if (paramSelector.Equals(capacitySelect))
                    {
                        if (p.capacity >= minValueD && p.capacity <= maxValueD)
                            planesFound.Add(p);
                    }

                    if (paramSelector.Equals(loadSelect))
                    {
                        if (p.maxLoad >= minValueI && p.maxLoad <= maxValueI)
                            planesFound.Add(p);
                    }
                }

                if (planesFound.Count != 0)
                {
                    Utils.printListOfPlanes(planesFound);
                }
                else
                {
                    Console.WriteLine("No planes found with such paramethers\n");
                }
            }
        }
    }
}

