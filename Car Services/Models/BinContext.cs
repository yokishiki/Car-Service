using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderInfo;

namespace Car_Services
{
    class BinContext
    {
        public OrdersInformation OrdersInfo { get; set; }
        private string filePath = "CarServiceData.dat";

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
    }
}
