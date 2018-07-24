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

        static List<Owner> GenOwner()
        {
            List<string> fio = new List<string>() { "Нюхтилина Эвелина Борисовна",
"Маслов ﻿Август Самсонович",
"Остроумов Святослав Макарович",
"Бычкова Христина Иосифовна",
"Малинов Адам Иннокентиевич",
"Овсова Любава Иларионовна",
"Кравков Пахом Онисимович",
"Янышева Нона Фомевна",
"Чукчов Максимильян Трофимович",
"Форофонтов Феофан Матвеевич",
"Алябьева Инга Юлиевна",
"Громыко Дементий Игоревич",
"Токарев Елисей Артемович",
"Изюмова Агафья Глебовна",
"Лобза Алина Давидовна",
"Ипатьева Арина Иосифовна",
"Капралов Яков Захарович",
"Кулатова Лиана Василиевна",
"Этуша Алла Емельяновна",
"Якунин Вадим Егорович",
"Косарёва Берта Михеевна",
"Кочергов Леонид Игоревич",
"Журавлёв Данила Иосифович",
"Яфаев Чеслав Кондратиевич",
"Другакова Варвара Борисовна",
"Ивашин Прохор Егорович",
"Козырева Валентина Игоревна",
"Малюгина Василиса Родионовна",
"Лобачёва Лариса Ильевна",
"Дудинов Кузьма Геннадиевич"};

            List<Owner> owlist = new List<Owner>();
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                Owner tmp = new Owner();
                tmp.FirstName = fio[i].Split()[1];
                tmp.LastName = fio[i].Split()[0];
                tmp.FatherName = fio[i].Split()[2];
                tmp.Phone = "+7910" + rnd.Next(1000000, 10000000);
                tmp.Year = rnd.Next(1940, 2000);
                tmp.OwnerId = i + 1;
                owlist.Add(tmp);
            }

            return owlist;
        }

        static List<Car> GetCars(List<Owner> ow)
        {
            List<Car> carList = new List<Car>();
            List<string> manuf = new List<string>()
            {
                "Ford",
"KIA",
"Toyota",
"Citroen",
"Mitsubishi",
"Mitsubishi",
"LADA",
"BMW",
"Opel",
"KIA",
"Skoda",
"Honda",
"Volkswagen",
"Renault",
"Ford",
"Nissan",
"Daewoo",
"Volkswagen",
"KIA",
"Ford",
"Ford",
"KIA",
"Toyota",
"Citroen",
"Mitsubishi",
"Mitsubishi",
"LADA",
"BMW",
"Opel",
"KIA",
"Skoda",
"Honda",
"Volkswagen",
"Renault",
"Ford",
"Nissan",
"Daewoo",
"Volkswagen",
"KIA",
"Ford"
            };
            List<string> mdls = new List<string>()
            {
                "C-MAX",
"Rio",
"RAV4",
"Jumpy",
"Lancer",
"Outlander",
"Priora",
"X5",
"Astra",
"Sorento",
"Oktavia",
"Civic",
"Jetta",
"Duster",
"Focus",
"Teana",
"Matiz",
"Golf",
"Spectra",
"Focus",
"C-MAX",
"Rio",
"RAV4",
"Jumpy",
"Lancer",
"Outlander",
"Priora",
"X5",
"Astra",
"Sorento",
"Oktavia",
"Civic",
"Jetta",
"Duster",
"Focus",
"Teana",
"Matiz",
"Golf",
"Spectra",
"Focus"
            };
            List<string> trans = new List<string>()
            {
                "МКПП", "АКПП", "Вариатор"
            };
            Random rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                Car tmp = new Car();
                tmp.CarId = i + 1;
                tmp.Manufacturer = manuf[rnd.Next(40)];
                tmp.Model = mdls[rnd.Next(40)];
                tmp.OwnerId = rnd.Next(30) + 1;
                tmp.Owner = ow[tmp.OwnerId - 1];
                tmp.Power = rnd.Next(80, 130);
                tmp.Transmission = trans[rnd.Next(3)];
                tmp.Year = rnd.Next(1990, 2015);
                carList.Add(tmp);
            }
            return carList;
        }

        static List<Order> GetOrders(List<Car> cars)
        {
            List<Order> orderList = new List<Order>();
            List<string> works = new List<string>()
            {
                "Замена гидрокомпенсаторов",
"Замена маслосъемных колпачков",
"Замена амортизаторов",
"Замена и ремонт элементов подвески автомобиля",
"Замена гидроусилителя руля",
"Замена рулевого управления",
"Ремонт радиатора",
"Замена троса сцепления",
"Установка противотуманных фар",
"Установка парктроника",
"Компьютерная диагностика электрооборудования",
"Замена свечей накаливания",
"Ремонт механизма стеклоочистителя",
"Замена форсунок омывателя стекол",
"Замена моторчика омывателя",
"Замена гидрокомпенсаторов",
"Замена маслосъемных колпачков",
"Замена амортизаторов",
"Замена и ремонт элементов подвески автомобиля",
"Замена гидроусилителя руля",
"Замена рулевого управления",
"Ремонт радиатора",
"Замена троса сцепления",
"Установка противотуманных фар",
"Установка парктроника",
"Компьютерная диагностика электрооборудования",
"Замена свечей накаливания",
"Ремонт механизма стеклоочистителя",
"Замена форсунок омывателя стекол",
"Замена моторчика омывателя",
"Замена гидрокомпенсаторов",
"Замена маслосъемных колпачков",
"Замена амортизаторов",
"Замена и ремонт элементов подвески автомобиля",
"Замена гидроусилителя руля",
"Замена рулевого управления",
"Ремонт радиатора",
"Замена троса сцепления",
"Установка противотуманных фар",
"Установка парктроника",
"Компьютерная диагностика электрооборудования",
"Замена свечей накаливания",
"Ремонт механизма стеклоочистителя",
"Замена форсунок омывателя стекол",
"Замена моторчика омывателя",
"Замена свечей накаливания",
"Ремонт механизма стеклоочистителя",
"Замена форсунок омывателя стекол",
"Замена моторчика омывателя",
"Замена гидрокомпенсаторов"
            };
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                Order tmp = new Order();
                tmp.CarId = rnd.Next(40) + 1;
                tmp.Car = cars[tmp.CarId - 1];
                tmp.OrderId = i + 1;
                tmp.Price = (rnd.Next(20) + 1) * 500;
                if (rnd.Next(7) >= 6)
                    tmp.TimeFinish = null;
                else
                    tmp.TimeFinish = new DateTime(2018, rnd.Next(5) + 2, rnd.Next(28) + 1, rnd.Next(10, 18), rnd.Next(0, 60), 0);
                tmp.TimeStart = new DateTime(2018, rnd.Next(4) + 1, rnd.Next(28) + 1, rnd.Next(10, 18), rnd.Next(0, 60), 0);
                if (tmp.TimeFinish != null && tmp.TimeStart >= tmp.TimeFinish)
                    tmp.TimeFinish = null;
                tmp.WorkName = works[i];
                orderList.Add(tmp);
            }
            return orderList;
        }


        /// <summary>
        /// Здесь создается файл CarServiceData.dat
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            OrdersInformation of = new OrdersInformation();
            of.Orders = GetOrders(GetCars(GenOwner()));

            using (Stream stream = File.Open("CarServiceData.dat", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, of);
            }
        }
    }

}
