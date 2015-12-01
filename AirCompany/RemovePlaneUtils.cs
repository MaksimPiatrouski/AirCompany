using Beans;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    class RemovePlaneUtils
    {
        //Removes Plane object from collection by its index
        public static void removePlane(List<Plane> planesList)
        {
            PlaneListUtils.printListOfPlanesWPos(planesList);
            Console.WriteLine("Enter number of plane you want to remove\n");
            try
            {
                int planeToRemove = int.Parse(Console.ReadLine()) - 1;
                string planeName = planesList.ElementAt(planeToRemove).name;
                planesList.RemoveAt(planeToRemove);
                Console.WriteLine("Plane " + planeName + " has been successfully removed\n");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Illegal format (" + e.Message + ")\n");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}

