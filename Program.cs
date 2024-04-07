
using LibraryForLabs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Лабораторная_работа_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------1 часть-----------------------------------
            ArrayList cars = new ArrayList(20);
            Console.WriteLine("\t\t|||1 часть|||");

            //Заполнение массива случайно
            Random rand = new Random();
            for (int i = 0; i < cars.Capacity; i++)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        PassengerCar car = new PassengerCar();
                        car.RandomInit();
                        cars.Add(car);
                        break;
                    case 2:
                        TruckCar car1 = new TruckCar();
                        car1.RandomInit();
                        cars.Add(car1);
                        break;
                    case 3:
                        OffRoadCar car2 = new OffRoadCar();
                        car2.RandomInit();
                        cars.Add(car2);
                        break;
                    case 4:
                        Cars car3 = new Cars();
                        car3.RandomInit();
                        cars.Add(car3);
                        break;
                }
            }
            //cars.Add(52);
            Print(cars);
            Console.WriteLine();
            ////-------------------------Запросы---------------------
            //Находим самый дорогой внедорожник
            OffRoadCar mostExpensiveOC = MostExpensiveOffRoadCar(cars);
            Console.WriteLine($"Самый дорогой внедорожник с ценой {mostExpensiveOC.Cost}");
            mostExpensiveOC.Show();
            Console.WriteLine();

            //Для нахождения средней скорости легковых автомобилей            
            double averageSpeed = FindAverageSpeed(cars);
            if (averageSpeed >= 0)
                Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeed}");
            else
                Console.WriteLine();
            Console.WriteLine();

            //Цвета внедорожников с включенным полным приводом
            Console.WriteLine("Цвета внедорожников с включенным полным приводом:");
            foreach (string color in ColorsAWD(cars))
            { Console.WriteLine(color); }
            Console.WriteLine();

            //Суммарная стоимость всех автомобилей
            double sumCost = SumCost(cars);
            Console.WriteLine($"Суммарная стоимость всех автомобилей: {sumCost}");
            Console.WriteLine();

            //-------------------------Добавление и Удаление---------------------
            //Добавление удаление элементов
            cars.Add(new PassengerCar("Honda", 2018, "Blue", 2250000, 15.3, 5, 230, 2));
            sumCost = SumCost(cars);
            Console.WriteLine($"Суммарная стоимость всех автомобилей после добавления: {sumCost}");
            cars.RemoveAt(20);
            sumCost = SumCost(cars);
            Console.WriteLine($"Суммарная стоимость всех автомобилей после удаления: {sumCost}");

            //-------------------------Клонирование и поиск---------------------

            //Клонирование коллекции
            ArrayList clonedCars = new ArrayList(20);
            //ArrayList clonedCars = new ArrayList(cars);

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i] is OffRoadCar)
                {
                    OffRoadCar c = (OffRoadCar)cars[i];
                    OffRoadCar clonedCar = new OffRoadCar(c.Brand, c.ReleaseYear, c.Color, c.Cost, c.Clearance, c.LoadCapacity, c.Awd, c.OffRoadType, c.id.number);
                    clonedCars.Add(clonedCar);
                    continue;
                }
                if (cars[i] is PassengerCar)
                {
                    PassengerCar c = (PassengerCar)cars[i];
                    PassengerCar clonedCar = new PassengerCar(c.Brand, c.ReleaseYear, c.Color, c.Cost, c.Clearance, c.NumberOfSeats, c.TopSpeed, c.id.number);
                    clonedCars.Add(clonedCar);
                    continue;
                }
                if (cars[i] is TruckCar)
                {
                    TruckCar c = (TruckCar)cars[i];
                    TruckCar clonedCar = new TruckCar(c.Brand, c.ReleaseYear, c.Color, c.Cost, c.Clearance, c.LoadCapacity, c.id.number);
                    clonedCars.Add(clonedCar);
                    continue;
                }
                if (cars[i] is Cars)
                {
                    Cars c = (Cars)cars[i];
                    Cars clonedCar = new Cars(c.Brand, c.ReleaseYear, c.Color, c.Cost, c.Clearance);
                    clonedCars.Add(clonedCar);
                }
            }
            if (cars[2] is Cars)
            {
                ((Cars)cars[2]).Cost = 777777;
            }
            Console.WriteLine("\t\t|||Неотсортированный клон|||");
            //cars[2] = new Cars("Ford", 1999, "White", 777777, 21);
            Print(clonedCars);
            Console.WriteLine("\t\t|||Отсортированный оригинал|||");
            cars.Sort();
            Print(cars);
            //Поиск
            Console.WriteLine("Какой тип авто вы хотите найти? (1 - OffRoad, 2 - PassengerCar, 3 - TruckCars, 4 - Cars)");
            switch (Console.ReadLine())
            {
                case "1":
                    OffRoadCar offRoadCarForFind = new OffRoadCar();
                    offRoadCarForFind.Init();
                    cars.Sort();
                    if (cars.BinarySearch(offRoadCarForFind) >= 0
                        && cars[cars.BinarySearch(offRoadCarForFind)] is OffRoadCar
                        && ((OffRoadCar)cars[cars.BinarySearch(offRoadCarForFind)]).LoadCapacity == offRoadCarForFind.LoadCapacity
                        && cars[cars.BinarySearch(offRoadCarForFind)] is OffRoadCar
                        && ((OffRoadCar)cars[cars.BinarySearch(offRoadCarForFind)]).Awd == offRoadCarForFind.Awd
                        && ((OffRoadCar)cars[cars.BinarySearch(offRoadCarForFind)]).OffRoadType == offRoadCarForFind.OffRoadType)
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
                case "2":
                    PassengerCar passengerCarForFind = new PassengerCar();
                    passengerCarForFind.Init();
                    cars.Sort();
                    if (cars.BinarySearch(passengerCarForFind) >= 0
                        && cars[cars.BinarySearch(passengerCarForFind)] is PassengerCar
                        && ((PassengerCar)cars[cars.BinarySearch(passengerCarForFind)]).TopSpeed == passengerCarForFind.TopSpeed
                        && ((PassengerCar)cars[cars.BinarySearch(passengerCarForFind)]).NumberOfSeats == passengerCarForFind.NumberOfSeats)
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
                case "3":
                    TruckCar truckCarForFind = new TruckCar();
                    truckCarForFind.Init();
                    cars.Sort();
                    if (cars.BinarySearch(truckCarForFind) >= 0
                        && cars[cars.BinarySearch(truckCarForFind)] is TruckCar
                        && ((TruckCar)cars[cars.BinarySearch(truckCarForFind)]).LoadCapacity == truckCarForFind.LoadCapacity)
                    {
                        Console.WriteLine("Элемент найден!");
                    }
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
                case "4":
                    Cars carForFind = new Cars();
                    carForFind.Init();
                    cars.Sort();
                    if (cars.BinarySearch(carForFind) >= 0 && cars[cars.BinarySearch(carForFind)] is Cars)
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
            }


            Console.WriteLine();
            Console.ReadLine();
            ////----------------------------------------------2 часть----------------------------------------

            Console.WriteLine("\t\t|||2 часть|||");
            Stack<Cars> stackCars = new Stack<Cars>(20);
            //Заполнение случайными элементами
            for (int i = 0; i < 20; i++)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        PassengerCar car = new PassengerCar();
                        car.RandomInit();
                        stackCars.Push(car);
                        break;
                    case 2:
                        TruckCar car1 = new TruckCar();
                        car1.RandomInit();
                        stackCars.Push(car1);
                        break;
                    case 3:
                        OffRoadCar car2 = new OffRoadCar();
                        car2.RandomInit();
                        stackCars.Push(car2);
                        break;
                    case 4:
                        Cars car3 = new Cars();
                        car3.RandomInit();
                        stackCars.Push(car3);
                        break;
                }
            }
            //Вывод
            //Print(StackCars);

            //-------------------------Запросы---------------------
            //Находим самый дорогой внедорожник
            mostExpensiveOC = MostExpensiveOffRoadCar(stackCars);
            if (mostExpensiveOC != null)
            {
                Console.WriteLine($"Самый дорогой внедорожник с ценой {mostExpensiveOC.Cost}");
                mostExpensiveOC.Show();
            }
            Console.WriteLine();

            //Для нахождения средней скорости легковых автомобилей            
            averageSpeed = FindAverageSpeed(stackCars);
            Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeed}");
            Console.WriteLine();

            //Цвета внедорожников с включенным полным приводом
            Console.WriteLine("Цвета внедорожников с включенным полным приводом:");
            foreach (string color in ColorsAWD(stackCars))
            { Console.WriteLine(color); }
            Console.WriteLine();

            //Суммарная стоимость всех автомобилей
            sumCost = SumCost(stackCars);
            Console.WriteLine($"Суммарная стоимость всех автомобилей: {sumCost}");
            Console.WriteLine();

            //-------------------------Добавление и Удаление---------------------
            //Добавление удаление элементов
            stackCars.Push(new PassengerCar("Honda", 2018, "Blue", 2250000, 15.3, 5, 230, 2));
            sumCost = SumCost(stackCars);
            Console.WriteLine($"Суммарная стоимость всех автомобилей после добавления: {sumCost}");
            stackCars.Pop();
            sumCost = SumCost(stackCars);
            Console.WriteLine($"Суммарная стоимость всех автомобилей после удаления: {sumCost}");

            //-------------------------Клонирование и поиск---------------------

            //Клонирование коллекции
            Stack<Cars> clonedStackCars = new Stack<Cars>(20);
            List<Cars> cars1 = stackCars.ToList();
            for (int i = 19; i >= 0; i--)
            {
                clonedStackCars.Push((Cars)cars1[i].Clone());
            }

            Console.WriteLine("\t\t|||Неотсортированный клон|||");
            Print(clonedStackCars);
            Console.WriteLine("\t\t|||Отсортированный оригинал|||");
            cars1.Sort();
            cars1.Reverse();
            stackCars = new Stack<Cars>(cars1);
            Print(stackCars);

            //Поиск
            Console.WriteLine("Какой тип авто вы хотите найти? (1 - OffRoad, 2 - PassengerCar, 3 - TruckCars, 4 - Cars)");
            switch (Console.ReadLine())
            {
                case "1":
                    OffRoadCar offRoadCarForFind1 = new OffRoadCar();
                    offRoadCarForFind1.Init();
                    if (stackCars.Contains(offRoadCarForFind1))
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
                case "2":
                    PassengerCar passengerCarForFind1 = new PassengerCar();
                    passengerCarForFind1.Init();
                    if (stackCars.Contains(passengerCarForFind1))
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
                case "3":
                    TruckCar truckCarForFind1 = new TruckCar();
                    truckCarForFind1.Init();
                    if (stackCars.Contains(truckCarForFind1))
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
                case "4":
                    Cars carForFind1 = new Cars();
                    carForFind1.Init();
                    if (stackCars.Contains(carForFind1))
                        Console.WriteLine("Элемент найден!");
                    else
                        Console.WriteLine("Элемент не найден!");
                    break;
            }





            //----------------------------------------------3 часть----------------------------------------

            Console.WriteLine("\t\t|||3 часть|||");
            Console.WriteLine();
            int numberOfElements = 1000; // количество элементов в коллекциях
            TestCollections testCollections = new TestCollections(numberOfElements);
            testCollections.PrintElements();
            PassengerCar randCarForSearch = new PassengerCar();
            randCarForSearch.RandomInit();
            Console.WriteLine();

            //Нахождение первого автомобиля
            Console.WriteLine("Нахождение первого автомобиля");
            testCollections.SearchInListCars(testCollections.ReturnFirstCar());
            testCollections.SearchInListCarsString(testCollections.ReturnFirstCar().ToString());
            testCollections.SearchDictionaryCarsKey(testCollections.ReturnFirstCarForDictionary());
            testCollections.SearchDictionaryCarsValue(testCollections.ReturnFirstCar());
            testCollections.SearchDictionaryCarsKeyString(testCollections.ReturnFirstCarForDictionary().ToString());
            testCollections.SearchDictionaryCarsValueString(testCollections.ReturnFirstCar());
            Console.WriteLine();

            //Нахождение срединного автомобиля
            Console.WriteLine("Нахождение срединного автомобиля");
            testCollections.SearchInListCars(testCollections.ReturnMiddleCar());
            testCollections.SearchInListCarsString(testCollections.ReturnMiddleCar().ToString());
            testCollections.SearchDictionaryCarsKey(testCollections.ReturnMiddleCarForDictionary());
            testCollections.SearchDictionaryCarsValue(testCollections.ReturnMiddleCar());
            testCollections.SearchDictionaryCarsKeyString(testCollections.ReturnMiddleCarForDictionary().ToString());
            testCollections.SearchDictionaryCarsValueString(testCollections.ReturnMiddleCar());
            Console.WriteLine();

            //Нахождение последнего автомобиля
            Console.WriteLine("Нахождение последнего автомобиля");
            testCollections.SearchInListCars(testCollections.ReturnLastCar());
            testCollections.SearchInListCarsString(testCollections.ReturnLastCar().ToString());
            testCollections.SearchDictionaryCarsKey(testCollections.ReturnLastCarForDictionary());
            testCollections.SearchDictionaryCarsValue(testCollections.ReturnLastCar());
            testCollections.SearchDictionaryCarsKeyString(testCollections.ReturnLastCarForDictionary().ToString());
            testCollections.SearchDictionaryCarsValueString(testCollections.ReturnLastCar());
            Console.WriteLine();

            Console.WriteLine("Нахождение не находящегося в коллекции автомобиля");
            testCollections.SearchInListCars(randCarForSearch);
            testCollections.SearchInListCarsString(randCarForSearch.ToString());
            testCollections.SearchDictionaryCarsKey(randCarForSearch);
            testCollections.SearchDictionaryCarsValue(randCarForSearch);
            testCollections.SearchDictionaryCarsKeyString(randCarForSearch.ToString());
            testCollections.SearchDictionaryCarsValueString(randCarForSearch);
            Console.ReadKey();
        }

        //Вывод массива
        public static void Print(ArrayList cars)
        {
            foreach (Cars car in cars)
            {
                car.Show();
                Console.WriteLine();
            }
        }
        public static void Print(Stack<Cars> StackCars)
        {
            foreach (Cars car in StackCars)
            {
                car.Show();
                Console.WriteLine();
            }
        }

        //Самый дорогой внедорожник
        public static OffRoadCar MostExpensiveOffRoadCar(ArrayList cars)
        {
            int maxCost = 0;
            OffRoadCar mostExpensive = new OffRoadCar();
            foreach (Cars item in cars)
            {
                if (typeof(OffRoadCar) == item.GetType() && maxCost < item.Cost)
                {
                    maxCost = item.Cost;
                    mostExpensive = (OffRoadCar)item;
                }
            }
            if (maxCost != 0)
                return mostExpensive;
            else
            {
                Console.WriteLine("Внедорожников не было в коллекции");
                return null;
            }
        }
        public static OffRoadCar MostExpensiveOffRoadCar(Stack<Cars> StackCars)
        {
            int maxCost = 0;
            OffRoadCar mostExpensive = new OffRoadCar();
            foreach (Cars item in StackCars)
            {
                if (typeof(OffRoadCar) == item.GetType() && maxCost < item.Cost)
                {
                    maxCost = item.Cost;
                    mostExpensive = (OffRoadCar)item;
                }
            }
            if (mostExpensive is OffRoadCar)
                return mostExpensive;
            else
            {
                Console.WriteLine("Внедорожников не было в коллекции");
                return null;
            }
        }

        //Нахождение средней скорости легковых автомобилей
        public static double FindAverageSpeed(ArrayList cars)
        {
            int count = 0;
            double totalSpeed = 0;
            foreach (var item in cars)
            {
                if (item is PassengerCar car)
                {
                    totalSpeed += car.TopSpeed;
                    count++;
                }
            }
            return count > 0 ? totalSpeed / count : -1;
        }
        public static double FindAverageSpeed(Stack<Cars> StackCars)
        {
            int count = 0;
            double totalSpeed = 0;
            foreach (var item in StackCars)
            {
                if (item is PassengerCar car)
                {
                    totalSpeed += car.TopSpeed;
                    count++;
                }
            }
            return count > 0 ? totalSpeed / count : -1;
        }

        //Суммарная стоимость всех автомобилей
        public static double SumCost(ArrayList cars)
        {
            double totalCost = 0;
            foreach (Cars car in cars)
            {
                totalCost += car.Cost;
            }
            return totalCost;
        }
        //Суммарная стоимость всех автомобилей
        public static double SumCost(Stack<Cars> StackCars)
        {
            double totalCost = 0;
            foreach (Cars car in StackCars)
            {
                totalCost += car.Cost;
            }
            return totalCost;
        }


        //Нахождение цветов полноприводных внедорожников
        public static string[] ColorsAWD(ArrayList cars)
        {
            int countAWD = 0;
            // Подсчитываем количество внедорожников с включенным полным приводом
            foreach (var item in cars)
            {
                OffRoadCar car = item as OffRoadCar;
                if (car != null && car.Awd)
                    countAWD++;
            }
            string[] colors = new string[countAWD];

            // Заполняем массив цветов
            int index = 0;
            foreach (var item in cars)
            {
                OffRoadCar car = item as OffRoadCar;
                if (car != null && car.Awd)
                {
                    colors[index] = car.Color;
                    index++;
                }
            }
            if (colors.Length == 0)
                Console.WriteLine("Внедорожников с полным приводом не было");
            return colors;
        }
        public static string[] ColorsAWD(Stack<Cars> StackCars)
        {
            int countAWD = 0;
            foreach (var item in StackCars)
            {
                OffRoadCar car = item as OffRoadCar;
                if (car != null && car.Awd)
                    countAWD++;
            }
            string[] colors = new string[countAWD];

            int index = 0;
            foreach (var item in StackCars)
            {
                OffRoadCar car = item as OffRoadCar;
                if (car != null && car.Awd)
                {
                    colors[index] = car.Color;
                    index++;
                }
            }
            if(colors.Length == 0)
                Console.WriteLine("Внедорожников с полным приводом не было");
            return colors;
        }
    }
}
