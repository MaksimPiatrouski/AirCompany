using planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class RemovePlaneUtils
    {
        public static void removePlane(List<Plane> planesList)
        {
            Utils.printListOfPlanesWPos(planesList);
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
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

