using MySql.Data.MySqlClient;

namespace Bookclub_desktop;

internal class Statisztika
{
    private static List<Member> members = [];
    private static readonly MemberService service = new();

    public static void Run()
    {
        try
        {
            members = service.ReadAllBooks();
            members.ForEach(Console.WriteLine);
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Hiba történt az adatok lekérése közben:");
            Console.WriteLine(e);
        }
    }
}