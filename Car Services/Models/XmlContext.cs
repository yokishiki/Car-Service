using System;
using System.Collections.Generic;
using System.Xml.Linq;
using OrderInfo;

namespace Car_Services
{
    class XmlContext
    {
        public List<Order> Orders { get; set; }
        public List<Car> Cars { get; set; }
        public List<Owner> Owners { get; set; }

        private Dictionary<int, int> ownerIndexId;
        private Dictionary<int, int> carIndexId;

        public XmlContext()
        {
            ownerIndexId = new Dictionary<int, int>();
            carIndexId = new Dictionary<int, int>();

            Owners = new List<Owner>();
            Cars = new List<Car>();
            Orders = new List<Order>();

            XDocument xdoc = XDocument.Load("carservicedata.xml");

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
                order.TimeStart = Convert.ToDateTime(orderXml.Element("timestart").Value);
                if (orderXml.Element("timefinish").Value == "")
                    order.TimeFinish = null;
                else
                    order.TimeFinish = Convert.ToDateTime(orderXml.Element("timefinish").Value);
                order.Price = int.Parse(orderXml.Element("price").Value);
                order.CarId = int.Parse(orderXml.Element("carid").Value);
                order.Car = Cars[carIndexId[order.CarId]];
                Orders.Add(order);
            }
        }
    }
}
