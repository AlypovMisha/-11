
using LibraryForLabs;
using System;
using System.Collections;
using System.Collections.Generic;

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

            Print(cars);
            Console.WriteLine();

            //-------------------------Запросы---------------------
            //Находим самый дорогой внедорожник
            OffRoadCar mostExpensiveOC = MostExpensiveOffRoadCar(cars);
            Console.WriteLine($"Самый дорогой внедорожник с ценой {mostExpensiveOC.Cost}");
            mostExpensiveOC.Show();
            Console.WriteLine();

            //Для нахождения средней скорости легковых автомобилей            
            double averageSpeed = FindAverageSpeed(cars);
            Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeed}");
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
            ArrayList clonedCars = (ArrayList)cars.Clone();
            Console.WriteLine("\t\t|||Неотсортированный клон|||");
            Print(clonedCars);
            Console.WriteLine("\t\t|||Отсортированный оригинал|||");
            cars.Sort();
            Print(cars);

            //Поиск
            Cars carForFind = (Cars)cars[12];
            carForFind.Init();
            if (cars.BinarySearch(carForFind) >= 0)
                Console.WriteLine("Элемент найден!");
            else
                Console.WriteLine("Элемент не найден!");
            Console.WriteLine();

            //----------------------------------------------2 часть----------------------------------------

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
            Console.WriteLine($"Самый дорогой внедорожник с ценой {mostExpensiveOC.Cost}");
            mostExpensiveOC.Show();
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
            //Stack<Cars> clonedCarStack = new Stack<Cars>(carStack); - так тоже можно наверное клонировать
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
            Cars carForFind1 = new Cars();
            carForFind1.Init();
            if (stackCars.Contains(carForFind1))
                Console.WriteLine("Элемент найден!");
            else
                Console.WriteLine("Элемент не найден!");



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
            return mostExpensive;
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
            return mostExpensive;
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
            return count > 0 ? totalSpeed / count : 0;
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
            return count > 0 ? totalSpeed / count : 0;
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
            return colors;
        }
    }
}
