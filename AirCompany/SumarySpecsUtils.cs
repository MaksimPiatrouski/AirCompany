using Beans;
using System;
using System.Collections.Generic;

namespace Utils
{
    class SumarySpecsUtils
    {
        //Counts and prints summary capacity and maxLoad
        public static void planesSummarySpecs(List<Plane> planesList)
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
    }
}