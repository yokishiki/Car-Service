using System.IO;
using System.Linq;

namespace Car_Services
{
    class BinContext
    {
        public static OrdersInformation OrdersInfo { get; set; }
        private static string filePath = "CarServiceData.dat";

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

        public static void WriteOrderToBinaryFile(Order order)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Append))
            {
                var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                order.OrderId = NextIndexOrder();
                OrdersInfo.Orders.Add(order);
                bFormatter.Serialize(fileStream, order);
            }
        }

        public static void WriteCarToBinaryFile(Car car)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Append))
            {
                var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                car.CarId = NextIndexCar();
                OrdersInfo.Cars.Add(car);
                bFormatter.Serialize(fileStream, car);
            }
        }

        public static void WriteOwnerToBinaryFile(Owner owner)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Append))
            {
                var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                owner.OwnerId = NextIndexOwner();
                OrdersInfo.Owners.Add(owner);
                bFormatter.Serialize(fileStream, owner);
            }
        }


        private static int NextIndexOwner()
        {
            int maxInd = OrdersInfo.Owners.Select(x => x.OwnerId).Max();
            return maxInd + 1;
        }

        private static int NextIndexCar()
        {
            int maxInd = OrdersInfo.Cars.Select(x => x.CarId).Max();
            return maxInd + 1;
        }

        private static int NextIndexOrder()
        {
            int maxInd = OrdersInfo.Orders.Select(x => x.OrderId).Max();
            return maxInd + 1;
        }
    }
}
