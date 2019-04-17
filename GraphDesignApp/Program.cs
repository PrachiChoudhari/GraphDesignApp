using System;

namespace GraphDesignApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Create account:");

                Console.WriteLine("Enter Email ID:");
                var email = Console.ReadLine();

                Console.WriteLine("Enter Address:");
                var address = Console.ReadLine();

                Console.WriteLine("Enter Phone Number:");
                var phoneNumber = Console.ReadLine();

                var u1 = ShoppingCart.CreateUser(address, email, phoneNumber);
                Console.WriteLine($"Email:{u1.EmailAddress};Address:{u1.Address};PhoneNumber:{u1.PhoneNumber};");

                Console.WriteLine("Choose DesignTypes:");
                var designTypes = Enum.GetNames(typeof(GraphicDesignType));
                for (int i = 0; i < designTypes.Length; i++)
                {
                    Console.WriteLine($"{i}. {designTypes[i]}");
                }

                Console.Write("Design Type: ");
                var designType = Enum.Parse<GraphicDesignType>(Console.ReadLine());

                Console.WriteLine("User Input: " + designType);


                Console.WriteLine("Choose DesignColor:");
                var designColors = Enum.GetNames(typeof(GraphicDesignColor));
                for (int i = 0; i < designColors.Length; i++)
                {
                    Console.WriteLine($"{i}. {designColors[i]}");
                }

                Console.Write("Design Color: ");
                var designColor = Enum.Parse<GraphicDesignColor>(Console.ReadLine());

                Console.WriteLine("User Input: " + designColor);


                Console.WriteLine("Choose DesignSize:");
                var designSizes = Enum.GetNames(typeof(GraphicDesignSize));
                for (int i = 0; i < designSizes.Length; i++)
                {
                    Console.WriteLine($"{i}. {designSizes[i]}");
                }

                Console.Write("Design Size: ");
                var designSize = Enum.Parse<GraphicDesignSize>(Console.ReadLine());

                Console.WriteLine("User Input: " + designSize);


                Console.WriteLine("Choose PaperQuality:");
                var designQualitys = Enum.GetNames(typeof(DesignPaperQuality));
                for (int i = 0; i < designQualitys.Length; i++)
                {
                    Console.WriteLine($"{i}. {designQualitys[i]}");
                }

                Console.Write("Design Quality: ");
                var designQuality = Enum.Parse<DesignPaperQuality>(Console.ReadLine());

                Console.WriteLine("User Input: " + designQuality);


                Console.WriteLine("Choose Shipping Type:");
                var shippingTypes = Enum.GetNames(typeof(ShippingType));
                for (int i = 0; i < shippingTypes.Length; i++)
                {
                    Console.WriteLine($"{i}. {shippingTypes[i]}");
                }

                Console.Write("Shipping Type: ");
                var shippingtype = Enum.Parse<ShippingType>(Console.ReadLine());

                Console.WriteLine("User Input: " + shippingtype);

                Console.Write("Enter Quantity: ");
                var quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("User Input: " + quantity);

                var designs = ShoppingCart.CreateDesign(
                    designType, designColor, designSize, designQuality, shippingtype, quantity);
                foreach (var g1 in designs)
                {
                    Console.WriteLine($"Type:{g1.DesignType}; Color:{g1.Color}; Size:{g1.Size}; Quality:{g1.PaperQuality}; Shipping:{g1.ShippingType}; Price:{g1.UnitPrice};");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
