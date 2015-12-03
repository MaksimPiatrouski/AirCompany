using Beans;
using System;
using System.Collections.Generic;

namespace Utils
{
    class SortPlanesUtils
    {
        //Sorts Plane objects by maxDistance field 
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
    }
}
