﻿using System.IO;

namespace Car_Services
{
    class BinContext
    {
        public static OrdersInformation OrdersInfo { get; set; }
        private static string filePath = "BinaryFile/CarServiceData.dat";

        public BinContext()
        {
            OrdersInfo = ReadFromBinaryFile<OrdersInformation>(filePath);
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static void WriteToBinaryFile()
        {
            using (Stream stream = File.Open(filePath, FileMode.CreateNew))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, OrdersInfo);
            }
        }
    }
}
