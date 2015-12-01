using Beans;
using Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utils
{
    class ExternalFileUtils
    {
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

        const int Name = 1;
        const int Year = 2;
        const int Price = 3;
        const int pPass = 4;
        const int pDist = 5;
        const int pSpeed = 6;
        const int pCapacity = 7;
        const int pLoad = 8;
        const int pClasses = 9;

        const int fDist = 4;
        const int fSpeed = 5;
        const int fCapacity = 6;
        const int fLoad = 7;
        const int fHatches = 8;

        const string writeTxt = "1";
        const string readTxt = "2";
        const string serialize = "3";
        const string deserialize = "4";
        const string back = "0";
        const string fileNameTxt = "Planes.txt";
        const string fileNameTxtRead = "PlanesToRead.txt";
        const string fileNameDat = "Planes.dat";

        static string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //Allows to select an action with external file 
        public static void fileActions(List<Plane> planesList)
        {
            bool loop = false;
            do
            {
                Console.WriteLine("1. Write list of planes to txt file\n"
                       + "2. Read planes from txt file\n"
                       + "3. Serialize objects\n"
                       + "4. Deserialize objects\n"
                       + "0. Back to menu or exit\n");

                string planeTypeSelector = Console.ReadLine();
                switch (planeTypeSelector)
                {
                    case writeTxt:
                        ExternalFileUtils.writeTxtFile(planesList);
                        loop = false;
                        break;

                    case readTxt:
                        ExternalFileUtils.readTxtFile(planesList);
                        loop = false;
                        break;

                    case serialize:
                        ExternalFileUtils.serializePlanes(planesList);
                        loop = false;
                        break;

                    case deserialize:
                        ExternalFileUtils.deserializePlanes();
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

        //Writes Plane objects data into txt file
        public static void writeTxtFile(List<Plane> planesList)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\" + fileNameTxt))
                    foreach (Plane p in planesList)
                    {
                        outputFile.WriteLine(p.ToString());
                    }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("\nFile has been wrote successfully (file placed in \"My Documents\")\n");
        }


        public static void readTxtFile(List<Plane> planesList)
        {
            string[] lines = System.IO.File.ReadAllLines(mydocpath + @"\" + fileNameTxtRead);
            Console.WriteLine(lines.Length);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                for (int k = 0; k < values.Length; k++){
                    values[k] = values[k].Trim();
            }

            if (values[0].ToLower().Equals("passengerplane"))
            {
                name = values[Name];
                year = int.Parse(values[Year]);
                if (year > yearNow)
                {
                    throw new IllegalYearException("Entered year has not come yet.");
                }
                price = double.Parse(values[Price]);
                numOfPassengers = int.Parse(values[pPass]);
                maxDistance = int.Parse(values[pDist]);
                maxSpeed = int.Parse(values[pSpeed]);
                capacity = double.Parse(values[pCapacity]);
                maxLoad = int.Parse(values[pLoad]);
                numOfClasses = int.Parse(values[pClasses]);
                planesList.Add(new PassengerPlane(name, year, price, numOfPassengers, maxDistance, maxSpeed, capacity, maxLoad, numOfClasses));
            }
            else if (values[0].ToLower().Equals("freightplane"))
            {
                name = values[Name];
                year = int.Parse(values[Year]);
                if (year > yearNow)
                {
                    throw new IllegalYearException("Entered year has not come yet.");
                }
                price = double.Parse(values[Price]);

                maxDistance = int.Parse(values[fDist]);
                maxSpeed = int.Parse(values[fSpeed]);
                capacity = double.Parse(values[fCapacity]);
                maxLoad = int.Parse(values[fLoad]);
                numOfHatches = int.Parse(values[fHatches]);
                planesList.Add(new FreightPlane(name, year, price, maxDistance, maxSpeed, capacity, maxLoad, numOfHatches));
            }
            else if (values[0].ToLower().Equals("businessplane"))
            {
                name = values[Name];
                year = int.Parse(values[Year]);
                if (year > yearNow)
                {
                    throw new IllegalYearException("Entered year has not come yet.");
                }
                price = double.Parse(values[Price]);
                numOfVipPassengers = int.Parse(values[pPass]);
                maxDistance = int.Parse(values[pDist]);
                maxSpeed = int.Parse(values[pSpeed]);
                capacity = double.Parse(values[pCapacity]);
                maxLoad = int.Parse(values[pLoad]);
                planesList.Add(new BusinessPlane(name, year, price, numOfVipPassengers, maxDistance, maxSpeed, capacity, maxLoad));
            }
            else
            {
                Console.WriteLine("String " + i + 1 + " has wrong format");
            }
        }
        Console.WriteLine("File has been succesfully read. The planes where added to the list");
        }

    //Serializes List of Plane objects into binary file
    public static void serializePlanes(List<Plane> planesList)
    {
        FileStream fsSerialize = new FileStream(mydocpath + @"\" + fileNameDat, FileMode.Create);

        BinaryFormatter formatterSerialize = new BinaryFormatter();
        try
        {
            formatterSerialize.Serialize(fsSerialize, planesList);
            Console.WriteLine("Successfully serialized (file placed in \"My Documents\")\n");
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fsSerialize.Close();
        }

    }

    //Deserializes binary file into List of Plane objects
    public static void deserializePlanes()
    {
        List<Plane> planesList = null;

        FileStream fsDeserialize = new FileStream(mydocpath + @"\" + fileNameDat, FileMode.Open);
        try
        {
            BinaryFormatter formatterDeserialize = new BinaryFormatter();
            planesList = (List<Plane>)formatterDeserialize.Deserialize(fsDeserialize);
            Console.WriteLine("Successfully deserialized.\n");
            PlaneListUtils.printListOfPlanes(planesList);

        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            fsDeserialize.Close();
        }
    }
}
}