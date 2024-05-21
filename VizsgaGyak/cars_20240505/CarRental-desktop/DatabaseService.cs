using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarRental_desktop
{
    internal class DatabaseService
    {
        private static string DB_HOST = "localhost";
        private static string DB_USER = "root";
        private static string DB_PASSWORD= "";
        private static string DB_NAME= "vizsga_gyakorlas";

        private MySqlConnection connection;

        public DatabaseService()
        {
            MySqlBaseConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = DB_HOST;
            builder.UserID = DB_USER;
            builder.Password = DB_PASSWORD;
            builder.Database = DB_NAME;

            this.connection = new MySqlConnection(builder.ConnectionString);
            this.connection.Open();
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            string sql = "SELECT * FROM cars";

            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = sql;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string licensePlateNumber = reader.GetString("license_plate_number");
                    string brand = reader.GetString("brand");
                    string model = reader.GetString("model");
                    int dailyCost = reader.GetInt32("daily_cost");
                    Car car = new Car(id,licensePlateNumber,brand,model,dailyCost);
                    cars.Add(car);

                }
            }

            return cars;
        }

        public void UpdateCar(Car car)
        {
            string sql = "UPDATE cars SET license_plate_number = @licensePlateNumber, brand = @brand, model = @model, daily_cost = @dailyCost WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@licensePlateNumber", car.LicensePlateNumber);
            cmd.Parameters.AddWithValue("@brand", car.Brand);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@dailyCost", car.DailyCost);
            cmd.Parameters.AddWithValue("@id", car.Id);

            cmd.ExecuteNonQuery();
        }


        public void DeleteCar(int carId)
        {
            string sql = "DELETE FROM cars WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", carId);

            cmd.ExecuteNonQuery();
        }



    }
}
