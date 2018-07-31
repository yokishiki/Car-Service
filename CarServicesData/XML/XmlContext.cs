using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Globalization;
using System.Linq;

namespace Car_Services
{
    class XmlContext
    {
        public List<Order> Orders { get; set; }
        public List<Car> Cars { get; set; }
        public List<Owner> Owners { get; set; }

        private Dictionary<int, int> ownerIndexId;
        private Dictionary<int, int> carIndexId;

        private string filePath = "carservicedata.xml";
        private XDocument xdoc;

        public XmlContext()
        {
            ownerIndexId = new Dictionary<int, int>();
            carIndexId = new Dictionary<int, int>();

            Owners = new List<Owner>();
            Cars = new List<Car>();
            Orders = new List<Order>();

            xdoc = XDocument.Load(filePath);
            CultureInfo cultureInfo = new CultureInfo("ru-RU");

            foreach (var ownerXml in xdoc.Descendants("owner"))
            {
                Owner owner = new Owner();
                owner.OwnerId = int.Parse(ownerXml.Attribute("ownerid").Value);
                owner.LastName = ownerXml.Element("lastname").Value;
                owner.FirstName = ownerXml.Element("firstname").Value;
                owner.FatherName = ownerXml.Element("fathername").Value;
                owner.Year = int.Parse(ownerXml.Element("year").Value);
                owner.Phone = ownerXml.Element("phone").Value;
                Owners.Add(owner);
                ownerIndexId.Add(owner.OwnerId, Owners.Count - 1);
            }

            foreach (var carXml in xdoc.Descendants("car"))
            {
                Car car = new Car();
                car.CarId = int.Parse(carXml.Attribute("carid").Value);
                car.Manufacturer = carXml.Element("manufacturer").Value;
                car.Model = carXml.Element("model").Value;
                car.Year = int.Parse(carXml.Element("year").Value);
                car.Transmission = carXml.Element("transmission").Value;
                car.Power = int.Parse(carXml.Element("power").Value);
                car.OwnerId = int.Parse(carXml.Element("ownerid").Value);
                car.Owner = Owners[ownerIndexId[car.OwnerId]];
                Cars.Add(car);
                carIndexId.Add(car.CarId, Cars.Count - 1);
            }

            foreach (var orderXml in xdoc.Descendants("order"))
            {
                Order order = new Order();
                order.OrderId = int.Parse(orderXml.Attribute("orderid").Value);
                order.WorkName = orderXml.Element("workname").Value;
                order.TimeStart = Convert.ToDateTime(orderXml.Element("timestart").Value,cultureInfo);
                if (orderXml.Element("timefinish").Value == "")
                    order.TimeFinish = null;
                else
                    order.TimeFinish = Convert.ToDateTime(orderXml.Element("timefinish").Value, cultureInfo);
                order.Price = int.Parse(orderXml.Element("price").Value);
                order.CarId = int.Parse(orderXml.Element("carid").Value);
                order.Car = Cars[carIndexId[order.CarId]];
                Orders.Add(order);
            }
        }

        public void WriteOrderToXmlFile(Order order)
        {
            order.OrderId = NextIndexOrder();
            Orders.Add(order);
            XElement xOrder = xdoc.Descendants("orders").First();
            xOrder.Add(new XElement("order", new XAttribute("orderid", order.OrderId.ToString()),
                new XElement("workname", order.WorkName),
                new XElement("timestart", order.TimeStart.ToString()),
                new XElement("timefinish", order.TimeFinish.ToString()),
                new XElement("price", order.Price.ToString()),
                new XElement("carid", order.Car.CarId.ToString())));
            xdoc.Save(filePath);
        }

        public void WriteCarToXmlFile(Car car)
        {
            car.CarId = NextIndexCar();
            Cars.Add(car);
            XElement xCar = xdoc.Descendants("cars").First();
            xCar.Add(new XElement("car", new XAttribute("carid", car.CarId.ToString()),
                new XElement("manufacturer", car.Manufacturer),
                new XElement("model", car.Model),
                new XElement("year", car.Year.ToString()),
                new XElement("transmission", car.Transmission),
                new XElement("power", car.Power.ToString()),
                new XElement("ownerid", car.Owner.OwnerId.ToString())));
            xdoc.Save(filePath);
        }

        public void WriteOwnerToXmlFile(Owner owner)
        {
            owner.OwnerId = NextIndexOwner();
            Owners.Add(owner);
            XElement xOwner = xdoc.Descendants("owners").First();
            xOwner.Add(new XElement("owner", new XAttribute("ownerid", owner.OwnerId.ToString()),
                new XElement("firstname", owner.FirstName),
                new XElement("lastname", owner.LastName),
                new XElement("fathername", owner.FatherName),
                new XElement("year", owner.Year.ToString()),
                new XElement("phone", owner.Phone)));
            xdoc.Save(filePath);
        }

        private int NextIndexOwner()
        {
            int maxInd = Owners.Select(x => x.OwnerId).Max();
            return maxInd + 1;
        }

        private int NextIndexCar()
        {
            int maxInd = Cars.Select(x => x.CarId).Max();
            return maxInd + 1;
        }

        private int NextIndexOrder()
        {
            int maxInd = Orders.Select(x => x.OrderId).Max();
            return maxInd + 1;
        }
    }
}
