using System;

namespace Utils
{
    class NavigationUtils
    {
        const string exit = "0";

        //Prints Main Menu in console
        public static void printMenu()
        {
            Console.WriteLine("\n------------------ Menu ------------------\n"
                    + "1. Show list of planes\n"
                    + "2. Add Planes\n"
                    + "3. Remove planes\n"
                    + "4. Count summary capacity and load\n"
                    + "5. Sort planes by max range\n"
                    + "6. Find planes by paramether\n"
                    + "7. Print aircompany stats\n"
                    + "8. Work with external files\n"
                    + "0. Exit\n"
                    + "------------------------------------------");
        }

        //Prints Finder Menu in console
        public static void printFinderMenu()
        {
            Console.WriteLine("\nSelect paramether for search:\n"
                            + "1. Year\n" + "2. Price, mln$\n" + "3. Max distance, km\n" + "4. Max speed, km/h\n" + "5. Capacity, m3\n" + "6. Max load, kg\n");
        }

        //Lets to back to Main Menu or Exit app
        public static bool hasBackToMenuSelector()
        {
            Console.WriteLine("\nPress any key to back to menu\n" + "Press 0 to exit");
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
    }
}
