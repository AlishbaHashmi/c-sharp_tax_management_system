using System;
using System.Reflection.Metadata;
using System.Threading.Channels;

abstract class ToolVehicle
{
    public int VehicleID { get; set; }
    public string RegNo { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; }
    public static int TotalVehicles { get; set; }
    public static int TotalTaxPayingVehicles { get; set; }
    public static int TotalNonTaxPayingVehicles { get; set; }
    public static decimal TotalTaxCollected { get; set; }

    public ToolVehicle(string regNo, string model, string brand, decimal basePrice, string vehicleType)
    {
        VehicleID = ++TotalVehicles;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = basePrice;
        VehicleType = vehicleType;
    }

    public abstract void PayTax();
    public void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;
        Console.WriteLine($"Vehicle ID {VehicleID} . Your {VehicleType} passed without paying tax.");
    }
    public decimal CalculateTax()
    {
        return 0;
    }
    public class Car : ToolVehicle
    {
        public Car(string regNo, string model, string brand, decimal basePrice, string vehicleType) : base(regNo, model, brand, basePrice, vehicleType) { }
        public override void PayTax()
        {
            TotalTaxPayingVehicles++;
            TotalTaxCollected += 2;
            Console.WriteLine($"Vehicle ID {VehicleID} . Tax paid for your {VehicleType} is $2");
        }
    }
    public class Bike : ToolVehicle
    {
        public Bike(string regNo, string model, string brand, decimal basePrice, string vehicleType) : base(regNo, model, brand, basePrice, vehicleType) { }

        public override void PayTax()
        {
            TotalTaxPayingVehicles++;
            TotalTaxCollected += 1;
            Console.WriteLine($"Vehicle ID {VehicleID} . Tax paid for your {VehicleType} is $1");
        }
    }
    public class HeavyVehicle : ToolVehicle
    {
        public HeavyVehicle(string regNo, string model, string brand, decimal basePrice, string vehicleType) : base(regNo, model, brand, basePrice, vehicleType) { }

        public override void PayTax()
        {
            TotalTaxPayingVehicles++;
            TotalTaxCollected += 4;
            Console.WriteLine($"Vehicle ID {VehicleID} . Tax paid for your {VehicleType}  is $4");
        }
    }
    static void Main(string[] args)
    {
        try
        {
            int taxchoice;
            char presskey;
            do
            {
                Console.WriteLine("Welcome to Tool Vehicle Tax Management System\n");
                Console.WriteLine("Choose your vehicle type:");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Bike");
                Console.WriteLine("3. Heavy Vehicle\n");
                Console.Write("Enter your choice : ");
                int vehiclechoice = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter registration number : ");
                string regNo = Console.ReadLine();
                Console.Write("Enter model : ");
                string model = Console.ReadLine();
                Console.Write("Enter brand : ");
                string brand = Console.ReadLine();
                Console.Write("Enter base price : ");
                decimal basePrice = Convert.ToDecimal(Console.ReadLine());

                switch (vehiclechoice)
                {
                    case 1:
                        Car car = new Car(regNo, model, brand, basePrice, "Car");
                        Console.WriteLine("\nTax for Car is $2");
                        Console.WriteLine("1. Pay Tax");
                        Console.WriteLine("2. Pass without paying tax");
                        Console.Write("Enter your choice : ");
                        taxchoice = Convert.ToInt32(Console.ReadLine());
                        if (taxchoice == 1)
                        {
                            car.PayTax();
                        }
                        else if (taxchoice == 2)
                        {
                            car.PassWithoutPaying();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                    case 2:
                        Bike bike = new Bike(regNo, model, brand, basePrice, "Bike");
                        Console.WriteLine("\nTax for Bike is $1");
                        Console.WriteLine("1. Pay Tax");
                        Console.WriteLine("2. Pass without paying tax");
                        Console.Write("Enter your choice : ");
                        taxchoice = Convert.ToInt32(Console.ReadLine());
                        if (taxchoice == 1)
                        {
                            bike.PayTax();
                        }
                        else if (taxchoice == 2)
                        {
                            bike.PassWithoutPaying();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                    case 3:
                        HeavyVehicle heavyVehicle = new HeavyVehicle(regNo, model, brand, basePrice, "Heavy Vehicle");
                        Console.WriteLine("\nTax for Heavy Vehicle is $4");
                        Console.WriteLine("1. Pay Tax");
                        Console.WriteLine("2. Pass without paying tax");
                        Console.Write("Enter your choice : ");
                        taxchoice = Convert.ToInt32(Console.ReadLine());
                        if (taxchoice == 1)
                        {
                            heavyVehicle.PayTax();
                        }
                        else if (taxchoice == 2)
                        {
                            heavyVehicle.PassWithoutPaying();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.Write("\nDo you want to use it again? Enter Y for continue and N for exit: ");
                presskey = char.Parse(Console.ReadLine());
            } while (presskey == 'Y' || presskey == 'y');
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid ! Please try again.");
        }
        Console.WriteLine($"\nTotal vehicles processed: {TotalVehicles}");
        Console.WriteLine($"Total tax paying vehicles: {TotalTaxPayingVehicles}");
        Console.WriteLine($"Total non-tax paying vehicles: {TotalNonTaxPayingVehicles}");
        Console.WriteLine($"Total tax collected: ${TotalTaxCollected}");
        Console.WriteLine("\nThank you for using Tool Vehicle Tax Management System.");

    }

}