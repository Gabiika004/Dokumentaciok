namespace CarDesktop;

internal class Car
{
    public Car(int id, string licensePlateNumber, string brand, string model, int dailyCost)
    {
        Id = id;
        LicensePlateNumber = licensePlateNumber;
        Brand = brand;
        Model = model;
        DailyCost = dailyCost;
    }

    public Car()
    {
        Id = 0;
        LicensePlateNumber = string.Empty;
        Brand = string.Empty;
        Model = string.Empty;
        DailyCost = 0;
    }

    public int Id { get; set; }
    public string LicensePlateNumber { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int DailyCost { get; set; }

    public override string ToString()
    {
        return $"{Id} - {LicensePlateNumber} - {Brand} - {Model} - {DailyCost}";
    }
}