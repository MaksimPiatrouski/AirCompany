using Beans;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Utils

{
    class AddPlanesUtils
    {
        const string passenger = "1";
        const string freight = "2";
        const string business = "3";
        const string back = "0";

        static string name;
        static int year;
        static double price;
        static int maxDistance;
        static int maxSpeed;
        static double capacity;
        static int maxLoad;
        static int numOfPassengers;
        static int numOfClasses;
        static int numOfHatches;
        static int numOfVipPassengers;
        static int yearNow = DateTime.Now.Year;

        //Allows to add new Plane object to the List
        public static void addPlanes(List<Plane> planesList)
        {
            bool loop = false;
            do
            {
                Console.WriteLine("Select the type of plane:\n"
                    + "1. Passenger plane\n"
                    + "2. Freight plane\n"
                    + "3. Business plane\n"
                    + "0. Back to menu or exit\n");

                string planeTypeSelector = Console.ReadLine();
                switch (planeTypeSelector)
                {
                    case passenger:
                        try
                        {
                            AddPlanesUtils.addPassengerPlane(planesList);
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Illegal format (" + e.Message + ")\n");
                        }
                        catch (IllegalYearException e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        loop = false;
                        break;

                    case freight:
                        try
                        {
                            AddPlanesUtils.addFreightPlane(planesList);
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Illegal format (" + e.Message + ")\n");
                        }
                        catch (IllegalYearException e)
                        {
                            Console.Write(e.Message + "\n");
                        }
                        loop = false;
                        break;

                    case business:
                        try
                        {
                            AddPlanesUtils.addBusinessPlane(planesList);
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Illegal format (" + e.Message + ")\n");
                        }
                        catch (IllegalYearException e)
                        {
                            Console.WriteLine(e.Message + "\n");
                        }
                        loop = false;
                        break;

                    case back:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Illegal selection\n");
                        loop = true;
                        break;
                }
            }
            while (loop);
        }

        //Iitializes data for PassengerPlane constructor
        public static void addPassengerPlane(List<Plane> planesList)
        {
            Console.Write("Enter plane name (string): ");
            name = Console.ReadLine();
            Console.Write("Enter year (int): ");
            year = int.Parse(Console.ReadLine());
            if (year > yearNow)
            {
                throw new IllegalYearException("Entered year has not come yet.");
            }
            Console.Write("Enter price, mln$ (double): ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter number of passengers (int): ");
            numOfPassengers = int.Parse(Console.ReadLine());
            Console.Write("Enter max distance, km (int): ");
            maxDistance = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed, km/h (int): ");
            maxSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter cargo capacity, m3 (double): ");
            capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter max cargo load, kg (int): ");
            maxLoad = int.Parse(Console.ReadLine());
            Console.Write("Enter number of classes (int): ");
            numOfClasses = int.Parse(Console.ReadLine());
            planesList.Add(new PassengerPlane(name, year, price, numOfPassengers, maxDistance, maxSpeed, capacity, maxLoad, numOfClasses));
            Console.WriteLine("Tha plane has been successfully added");
        }

        //Iitializes data for FreightPlane constructor
        public static void addFreightPlane(List<Plane> planesList)
        {
            Console.Write("Enter plane name (string): ");
            name = Console.ReadLine();
            Console.Write("Enter year (int): ");
            year = int.Parse(Console.ReadLine());
            if (year > yearNow)
            {
                throw new IllegalYearException("Entered year has not come yet.");
            }
            Console.Write("Enter price, mln$ (double): ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter max distance, km (int): ");
            maxDistance = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed, km/h (int): ");
            maxSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter cargo capacity, m3 (double): ");
            capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter max cargo load, kg (int): ");
            maxLoad = int.Parse(Console.ReadLine());
            Console.Write("Enter number of hatches (int): ");
            numOfHatches = int.Parse(Console.ReadLine());
            planesList.Add(new FreightPlane(name, year, price, maxDistance, maxSpeed, capacity, maxLoad, numOfHatches));
            Console.WriteLine("Tha plane has been successfully added");
        }

        //Iitializes data for BusinessPlane constructor
        public static void addBusinessPlane(List<Plane> planesList)
        {
            Console.Write("Enter plane name (string): ");
            name = Console.ReadLine();
            Console.Write("Enter year (int): ");
            year = int.Parse(Console.ReadLine());
            if (year > yearNow)
            {
                throw new IllegalYearException("Entered year has not come yet.");
            }
            Console.Write("Enter price, mln$ (double): ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter number of VIP passengers (int): ");
            numOfVipPassengers = int.Parse(Console.ReadLine());
            Console.Write("Enter max distance, km (int): ");
            maxDistance = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed, km/h (int): ");
            maxSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter cargo capacity, m3 (double): ");
            capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter max cargo load, kg (int): ");
            maxLoad = int.Parse(Console.ReadLine());
            planesList.Add(new BusinessPlane(name, year, price, numOfVipPassengers, maxDistance, maxSpeed, capacity, maxLoad));
            Console.WriteLine("Tha plane has been successfully added");
        }
    }
}