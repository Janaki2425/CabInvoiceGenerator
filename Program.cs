using System;
namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to cab invoice Generator");
            InvoiceGenerator generator = new InvoiceGenerator(RideType.NORMAL);
            double fare = generator.CalculateFare(2.0, 5);
            Console.WriteLine(fare);
        }


    }
}