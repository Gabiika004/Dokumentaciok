using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarRental_desktop
{
    public class Statisztika
    {
        static List<Car> cars;

        public Statisztika()
        {
        }


        public static void RunExercises()
        {
            try
            {
                GetAllCars();
                //cars.ForEach(Console.WriteLine);
                GetCarsByGivenDailyCostCheaperThan(20000);
                GetCarByGivenDailyCostExpensiveThan(26000);
                GetMostExpensiveCar();
                GetCarsOrderdByBrand();
                GivenCarDailyCostsExpensiveThanAGivenDailyCost(GetCarByGivenLicenseplateNumber(), 25000);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Hiba: {0}",ex);
                throw;
            }

        }

        private static void GetAllCars()
        {
            DatabaseService database = new DatabaseService();
            cars = database.GetAllCars();
        }

        //public async Task<List<Car>> GetCarsFromApi()
        //{ 
        //    cars = new List<Car>();

        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            using (HttpResponseMessage response = await client.GetAsync(_baseUrl))
        //            {
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    string jsonResponse = await response.Content.ReadAsStringAsync();
        //                    JObject jsonData = JObject.Parse(jsonResponse);
        //                    JArray carsJsonArray = (JArray)jsonData["data"];
        //                    cars = carsJsonArray.ToObject<List<Car>>();
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Hiba a kérés feldolgozásában. Státusz kód: {response.StatusCode}");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }

        //    return cars;
        //}

        static void GetCarsByGivenDailyCostCheaperThan(int dailyCost)
        {
            var cheaperCars = cars.Count(car => car.DailyCost < dailyCost);

            Console.WriteLine($"{dailyCost} Ft-nál olcsóbb napidíjú autók száma: {cheaperCars}");
            Console.WriteLine("---------");
        }


        static bool ExpensiveThan(int param, List<Car> cars)
        {
            return cars.Any(car => car.DailyCost > param);
        }



        static void GetCarByGivenDailyCostExpensiveThan(int dailyCost)
        {
            string exist = ExpensiveThan(dailyCost, cars) ? "Van" : "Nincs";
            Console.WriteLine($"{exist} az adatok között 26.000 Ft-nál drágább napidíjú autó");
            Console.WriteLine("---------");
        }

        static void GetMostExpensiveCar()
        {
            int max = cars[0].DailyCost;
            Car mostExpensiveCar = cars[0];

            for (int i = 1; i < cars.Count; i++)
            {
                if (cars[i].DailyCost > max)
                {
                    max = cars[i].DailyCost;
                    mostExpensiveCar = cars[i];
                }
            }

            Console.WriteLine($"Legdrágább napidíjú autó: {mostExpensiveCar}");
            Console.WriteLine("---------");
        }

        static void GetCarsOrderdByBrand()
        {
            Dictionary<string, int> BrandsCount = new Dictionary<string, int>();

            foreach (var car in cars)
            {
                if (BrandsCount.ContainsKey(car.Brand))
                {
                    BrandsCount[car.Brand] += 1;
                }
                else
                {
                    BrandsCount.Add(car.Brand,1);
                }
            }

            Console.WriteLine("Autók száma:");
            foreach (var item in BrandsCount)
            {
                Console.WriteLine($"    {item.Key}: {item.Value}");
            }
            Console.WriteLine("---------");
        }

        private static Car GetCarByGivenLicenseplateNumber()
        {
            Console.WriteLine("Adjon meg egy rendszámot (AAA-111):");
            string licensePlateNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(licensePlateNumber))
            {
                Console.WriteLine("Érvénytelen rendszám!");
                return null;
            }

            Car foundCar = cars.FirstOrDefault(car => car.LicensePlateNumber == licensePlateNumber);

            if (foundCar == null)
            {
                Console.WriteLine("Nincs ilyen autó!");
            }

            return foundCar;
        }



        static void GivenCarDailyCostsExpensiveThanAGivenDailyCost(Car car,int dailyCost)
        {
            if (car != null)
            {
                List<Car> _cars = new List<Car>() { car };

                string exist = ExpensiveThan(dailyCost, _cars) ? "" : "nem ";
                Console.WriteLine($"A megadott autó napidíja {exist}nagyobb mint {dailyCost} Ft");
                Console.WriteLine("---------");
            }
        }

    }
}