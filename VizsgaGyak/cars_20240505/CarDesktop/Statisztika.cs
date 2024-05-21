using Microsoft.Data.SqlClient;

namespace CarDesktop;

internal class Statisztika
{
    private static List<Car> cars = new();
    private static readonly CarService dbService = new();


    public static void Run()
    {
        try
        {
            Console.WriteLine("Statisztikaa");
        }
        catch (SqlException e)
        {
            Console.WriteLine("Hiba történt az adatok lekérése közben: {0}", e);
        }
    }
}