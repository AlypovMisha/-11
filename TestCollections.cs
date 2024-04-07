using LibraryForLabs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Лабораторная_работа_11
{
    public class TestCollections
    {
        private LinkedList<PassengerCar> linkedListCars;
        private LinkedList<string> linkedListString;
        private Dictionary<Cars, PassengerCar> dictionaryCar;
        private Dictionary<string, PassengerCar> dictionaryStringCar;
        private Stopwatch sw = new Stopwatch();

        public TestCollections(int numberOfElements)
        {
            linkedListCars = new LinkedList<PassengerCar>();
            linkedListString = new LinkedList<string>();
            dictionaryCar = new Dictionary<Cars, PassengerCar>();
            dictionaryStringCar = new Dictionary<string, PassengerCar>();

            for (int i = 0; i < numberOfElements; i++)
            {
                PassengerCar passengerCar = new PassengerCar();
                passengerCar.RandomInit();
                Cars car = passengerCar.BaseCar;
                try
                {
                    dictionaryCar.Add(passengerCar.BaseCar, passengerCar);
                    dictionaryStringCar.Add(car.ToString(), passengerCar);
                    linkedListCars.AddLast(passengerCar);
                    linkedListString.AddLast(passengerCar.ToString());
                }
                catch
                {
                    Console.WriteLine("Объекты с уникальными значениями не могут быть созданы. Все возможные комбинации были добавлены.");
                }
            }

        }

        public void PrintElements()
        {
            Console.WriteLine("Первый элемент: " + linkedListCars.First.Value);
            Console.WriteLine("Средний элемент: " + GetMiddleElement(linkedListCars));
            Console.WriteLine("Последний элемент: " + linkedListCars.Last.Value);
        }

        public PassengerCar ReturnFirstCar()
        {
            return linkedListCars.First.Value;
        }

        public Cars ReturnFirstCarForDictionary()
        {
            return ReturnFirstCar().BaseCar;
        }

        public PassengerCar ReturnLastCar()
        {
            return linkedListCars.Last.Value;
        }

        public Cars ReturnLastCarForDictionary()
        {
            return ReturnLastCar().BaseCar;
        }

        public PassengerCar ReturnMiddleCar()
        {
            return GetMiddleElement(linkedListCars);
        }

        public Cars ReturnMiddleCarForDictionary()
        {
            return ReturnMiddleCar().BaseCar;
        }

        // Метод для измерения времени поиска элемента в коллекции LinkedList<PassengerCar>
        public void SearchInListCars(PassengerCar car)
        {
            PassengerCar k = new PassengerCar(car.Brand, car.ReleaseYear, car.Color, car.Cost, car.Clearance, car.NumberOfSeats, car.TopSpeed, car.id.number);
            sw.Restart();
            bool isContain = linkedListCars.Contains(k);
            sw.Stop();
            if (isContain)
            {
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            }
            else
            {
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
            }
        }

        // Метод для измерения времени поиска элемента в коллекции LinkedList<string>
        public void SearchInListCarsString(string carStr)
        {
            string k = carStr;
            sw.Restart();
            bool isContain = linkedListString.Contains(k);
            sw.Stop();
            if (isContain)
            {
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            }
            else
            {
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
            }
        }

        // Метод для измерения времени поиска элемента в коллекции Dictionary
        public void SearchDictionaryCarsKey(Cars car)
        {
            Cars k = new Cars(car.Brand,car.ReleaseYear, car.Color, car.Cost, car.Clearance);
            sw.Restart();
            bool isContain = dictionaryCar.ContainsKey(k);
            sw.Stop();
            if (isContain)
            {
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            }
            else
            {
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
            }
        }
        // Метод для измерения времени поиска элемента в коллекции Dictionary
        public void SearchDictionaryCarsValue(PassengerCar car)
        {
            PassengerCar k = new PassengerCar(car.Brand, car.ReleaseYear, car.Color, car.Cost, car.Clearance, car.NumberOfSeats, car.TopSpeed, car.id.number);
            sw.Restart();
            bool isContain = dictionaryCar.ContainsValue(k);
            sw.Stop();
            if (isContain)
            {
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            }
            else
            {
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
            }
        }

        // Метод для измерения времени поиска элемента в коллекции Dictionary
        public void SearchDictionaryCarsKeyString(string carStr)
        {
            string k = carStr;
            sw.Restart();
            bool isContain = dictionaryStringCar.ContainsKey(k);
            sw.Stop();
            if (isContain)
            {
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            }
            else
            {
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
            }
        }
        // Метод для измерения времени поиска элемента в коллекции Dictionary
        public void SearchDictionaryCarsValueString(PassengerCar car)
        {
            PassengerCar k = new PassengerCar(car.Brand, car.ReleaseYear, car.Color, car.Cost, car.Clearance, car.NumberOfSeats, car.TopSpeed, car.id.number);
            sw.Restart();
            bool isContain = dictionaryStringCar.ContainsValue(k);
            sw.Stop();
            if (isContain)
            {
                Console.WriteLine($"Элемент найден за {sw.ElapsedTicks}");
            }
            else
            {
                Console.WriteLine($"Элемент не найден за {sw.ElapsedTicks}");
            }
        }
        private static T GetMiddleElement<T>(LinkedList<T> linkedList)
        {
            if (linkedList == null || linkedList.Count == 0)
            {
                throw new ArgumentException("Список пуст.");
            }
            LinkedListNode<T> slow = linkedList.First;
            LinkedListNode<T> fast = linkedList.First;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow.Value;
        }

    }
}
