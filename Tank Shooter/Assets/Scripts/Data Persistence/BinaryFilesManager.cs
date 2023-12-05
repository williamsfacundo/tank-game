using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TankGame.DataPersistence 
{
    public static class BinaryFilesManager
    {
        public static void Save(object dataToSave, string dataFilePath) 
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file;

            if (!File.Exists(dataFilePath)) 
            {
                file = File.Create(dataFilePath);
            }
            else 
            {
                file = File.Open(dataFilePath, FileMode.Open);
            }

            bf.Serialize(file, dataToSave);

            file.Close();
        }

        public static object Load(string dataFilePath) 
        {   
            if (File.Exists(dataFilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                
                FileStream file = File.Open(dataFilePath, FileMode.Open); 
                
                object data = bf.Deserialize(file);
                
                file.Close();

                return data;
            }

            return null;
        }

        public static bool FileExists(string filePath) 
        {
            return File.Exists(filePath);
        }
    }
}