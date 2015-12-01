using Beans;
using System;
using System.Collections.Generic;

namespace Utils
{
    class PlaneListUtils
    {
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

        //Prints list of Plane objects in console
        public static void printListOfPlanes(List<Plane> planesList)
        {
            Console.WriteLine("\n----------- List of planes ---------------");
            foreach (Plane p in planesList)
            {
                Console.WriteLine(p.ToString());
            }
        }

        //Prints list of Plane objects with its number (index + s1) in console
        public static void printListOfPlanesWPos(List<Plane> planesList)
        {
            Console.WriteLine("\n----------- List of planes ---------------");
            for (int i = 0; i < planesList.Count; i++)
            {
                int position = i + 1;
                Console.WriteLine(position + ") " + planesList[i].ToString());
            }
        }
    }
}
