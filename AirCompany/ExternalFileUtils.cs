using planes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class ExternalFileUtils
    {
        const string writeTxt = "1";
        const string serialize = "2";
        const string deserialize = "3";
        const string back = "0";
        const string fileNameTxt = "Planes.txt";
        const string fileNameDat = "Planes.dat";

        static string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void fileActions(List<Plane> planesList)
        {
            bool loop = false;
            do
            {
                Console.WriteLine("1. Write list of planes to txt file\n"
                       + "2. Serialize objects\n"
                       + "3. Deserialize objects\n"
                       + "0. Back to menu or exit\n");

                string planeTypeSelector = Console.ReadLine();
                switch (planeTypeSelector)
                {
                    case writeTxt:
                        ExternalFileUtils.writeTxtFile(planesList);
                        loop = false;
                        break;

                    case serialize:
                        ExternalFileUtils.serializePlanes(planesList);
                        loop = false;
                        break;

                    case deserialize:
                        ExternalFileUtils.deserializePlanes(planesList);
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

        public static void deserializePlanes(List<Plane> planesList)
        {
            List<Plane> planesListDeserialize = null;

            FileStream fsDeserialize = new FileStream(mydocpath + @"\" + fileNameDat, FileMode.Open);
            try
            {
                BinaryFormatter formatterDeserialize = new BinaryFormatter();
                planesList = (List<Plane>)formatterDeserialize.Deserialize(fsDeserialize);
                Console.WriteLine("Successfully deserialized.");
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