using Exceptions;
using Beans;
using System;
using System.Collections.Generic;

namespace Utils
{
    class FindPlaneUtils
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
                Console.WriteLine("Illegal input. No such paramether found\n");
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
                    if (minValueI > maxValueI)
                        throw new IllegalMinMaxValuesException("Max value is less than min value");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    correctFormat = false;
                    Console.WriteLine("Illegal format (" + e.Message + ")\n");
                }
                catch (IllegalMinMaxValuesException e)
                {
                    correctFormat = false;
                    Console.WriteLine(e.Message + "\n");
                }

            }
            else
            {
                try
                {
                    minValueI = int.Parse(min);
                    maxValueI = int.Parse(max);
                    if (minValueI > maxValueI)
                        throw new IllegalMinMaxValuesException("Max value is less than min value");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    correctFormat = false;
                    Console.WriteLine("Illegal format (" + e.Message + ")\n");
                }
                catch (IllegalMinMaxValuesException e)
                {
                    correctFormat = false;
                    Console.WriteLine(e.Message + "\n");
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
                try
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
                        PlaneListUtils.printListOfPlanes(planesFound);
                    }
                    else
                    {
                        throw new NoSuchPlaneException("No planes found with such paramethers");
                    }
                }
                catch (NoSuchPlaneException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
