namespace CarRental_desktop
{
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
            LicensePlateNumber = "";
            Brand = "";
            Model = "";
            DailyCost = 0;
        }

        public int Id { get; }

        public string LicensePlateNumber { get; }

        public string Brand { get; }

        public string Model { get; }

        public int DailyCost { get; }

        public override string ToString()
        {
            return $"{LicensePlateNumber} - {Brand} - {Model} - {DailyCost} Ft";
        }
    }
}