namespace Bookclub_desktop;

public class Member
{
    public Member(string name, string gender, DateTime birthDate, bool banned)
    {
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
        Banned = banned;
        FormattedBirthDate = birthDate.ToString("yyyy-MM-dd");
        BannedStr = banned ? "X" : "";

    }

    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Banned { get; set; }
    public string BannedStr { get; set; }
    public string FormattedBirthDate { get; set; }
    public override string ToString()
    {
        return $"{Name} ({FormattedBirthDate})";
    }
}