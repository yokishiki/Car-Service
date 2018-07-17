using Car_Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCreateData
{
    class Program
    {
        /// <summary>
        /// Здесь создается файл CarServiceData.dat
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            OrdersInformation of = new OrdersInformation();
            Owner owner = new Owner();
            owner.LastName = "Капустин";
            owner.FirstName = "Тимофей";
            owner.FatherName = "Сидорович";
            owner.OwnerId = 1;
            owner.Year = 1983;
            owner.Phone = "+79155482710";
            of.Owners = new List<Owner>();
            of.Owners.Add(owner);

            Car car = new Car();
            car.CarId = 1;
            car.Manufacturer = "Volkswagen";
            car.Model = "Golf";
            car.Owner = owner;
            car.OwnerId = 1;
            car.Power = 122;
            car.Transmission = "АКПП";
            car.Year = 2014;
            of.Cars = new List<Car>();
            of.Cars.Add(car);

            Order order = new Order();
            order.OrderId = 1;
            order.CarId = 1;
            order.Car = car;
            order.Price = 2000;
            order.WorkName = "Замена фар";
            order.TimeStart = Convert.ToDateTime("2018-07-05 15:16");
            order.TimeFinish = Convert.ToDateTime("2018-07-06 12:14");
            of.Orders = new List<Order>();
            of.Orders.Add(order);
            using (Stream stream = File.Open("CarServiceData.dat", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, of);
            }
        }
    }

}
