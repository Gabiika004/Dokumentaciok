using MySql.Data.MySqlClient;
using System.Reflection;

namespace Bookclub_desktop;

public class MemberService
{
    private readonly MySqlConnection connection;
    private readonly string DB_HOST = "localhost";
    private readonly string DB_NAME = "vizsga_gyakorlas";
    private readonly string DB_PASS = "";
    private readonly string DB_USER = "root";

    public MemberService()
    {
        MySqlBaseConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = DB_HOST;
        builder.UserID = DB_USER;
        builder.Password = DB_PASS;
        builder.Database = DB_NAME;

        connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();
    }

    public List<Member> ReadAllBooks()
    {
        string str = "SELECT * FROM members";
        List<Member> members = new List<Member>();
        MySqlCommand cmd = this.connection.CreateCommand();
        cmd.CommandText = str;

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string name = reader.GetString("name");

                // Null ellenőrzés és kezelése
                string gender = reader.IsDBNull(reader.GetOrdinal("gender"))
                    ? "Ismeretlen"
                    : SetGender(reader.GetString("gender"));
                DateTime birthDate = reader.GetDateTime("birth_date");
                bool banned = reader.GetBoolean("banned");

                Member member = new Member(name,gender,birthDate,banned);
                members.Add(member);
            }
        }

        return members;
    }

    private string SetGender(string gener)
    {
        switch (gener)
        {
            case "M":
                return "Férfi";
            case "F":
                return "Nő";
            default:
               return "Ismeretlen";
        }
    }

    public void UpdateMemberBannedStatus(Member member)
    {
        string sql = $"UPDATE members SET banned = @banned WHERE name = @name";
        MySqlCommand cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@banned", !member.Banned);
        cmd.Parameters.AddWithValue("@name", member.Name);
        cmd.ExecuteNonQuery();


    }
}