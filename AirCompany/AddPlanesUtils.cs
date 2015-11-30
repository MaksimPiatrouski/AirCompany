using planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany

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
                            Console.WriteLine(e.Message);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message + "\n");
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
                            Console.WriteLine(e.Message);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message + "\n");
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
                            Console.WriteLine(e.Message);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message + "\n");
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
            Console.Write("Enter price (double): ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter number of passengers (int): ");
            numOfPassengers = int.Parse(Console.ReadLine());
            Console.Write("Enter max distance (int): ");
            maxDistance = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed (int): ");
            maxSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter cargo capacity (double): ");
            capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter max cargo load (int): ");
            maxLoad = int.Parse(Console.ReadLine());
            Console.Write("Enter number of classes (int): ");
            numOfClasses = int.Parse(Console.ReadLine());
            planesList.Add(new PassengerPlane(name, year, price, numOfPassengers, maxDistance, maxSpeed, capacity, maxLoad, numOfClasses));
        }

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
            Console.Write("Enter price (double): ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter max distance (int): ");
            maxDistance = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed (int): ");
            maxSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter cargo capacity (double): ");
            capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter max cargo load (int): ");
            maxLoad = int.Parse(Console.ReadLine());
            Console.Write("Enter number of hatches (int): ");
            numOfHatches = int.Parse(Console.ReadLine());
            planesList.Add(new FreightPlane(name, year, price, maxDistance, maxSpeed, capacity, maxLoad, numOfHatches));
        }

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
            Console.Write("Enter price (double): ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Enter number of VIP passengers (int): ");
            numOfVipPassengers = int.Parse(Console.ReadLine());
            Console.Write("Enter max distance (int): ");
            maxDistance = int.Parse(Console.ReadLine());
            Console.Write("Enter max speed (int): ");
            maxSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter cargo capacity (double): ");
            capacity = double.Parse(Console.ReadLine());
            Console.Write("Enter max cargo load (int): ");
            maxLoad = int.Parse(Console.ReadLine());
            planesList.Add(new BusinessPlane(name, year, price, numOfVipPassengers, maxDistance, maxSpeed, capacity, maxLoad));

        }
    }
}