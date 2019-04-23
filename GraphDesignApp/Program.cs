using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraphDesignApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************************");
            Console.WriteLine(" Welcome to my Graphic Design Shop!");
            Console.WriteLine("*************************************");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an User account");
                Console.WriteLine("2. Order Graphic Designs");
                Console.WriteLine("3. Print user accounts");
                Console.WriteLine("4. Print orders for an account");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting us!");
                        return;

                    case "1":
                        CreateUserAccount();   
                        break;

                    case "2":
                        OrderDesigns();
                        break;

                    case "3":
                        PrintUserAccounts();
                        break;

                    case "4":
                        PrintOrdersForUserAccount();
                        break;

                    default:
                        break;
                }
            }
        }

        private static void PrintUserAccounts()
        {
            try
            {
                foreach (var account in ShoppingCart.GetAllUserAccounts())
                {
                    Console.Out.WriteLine("Email:{0}; Phone: {1}; Address:{2}", account.EmailAddress, account.PhoneNumber, account.Address);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PrintUserAccounts failed with Error: {ex.Message}. Please try again!");
            }
        }

        private static void PrintOrdersForUserAccount()
        {
            try
            {
                Console.WriteLine("Enter Email ID for user account to fetch Orders:");
                var email = Console.ReadLine();

                var designs = ShoppingCart.GetGraphicDesignsByUser(email);
                if(designs.Count == 0)
                {
                    Console.WriteLine($"Email ID: {email} does not have any orders!");
                    return;
                }

                foreach (var g1 in designs)
                {
                    Console.WriteLine($"Type:{g1.DesignType}; Color:{g1.Color}; Size:{g1.Size}; Quality:{g1.PaperQuality}; Shipping:{g1.ShippingType}; Price:{g1.UnitPrice};");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PrintOrdersForUserAccount failed with Error: {ex.Message}. Please try again!");
            }
        }

        private static void OrderDesigns()
        {
            try
            {
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

                Console.WriteLine("Enter Email ID:");
                var email = Console.ReadLine();

                Console.WriteLine("User Input: " + email);

                // Create Designs in Shopping Cart
                var shoppingCartDesigns = ShoppingCart.CreateDesigns(
                    designType, designColor, designSize, designQuality, shippingtype, quantity, email);
                foreach (var g1 in shoppingCartDesigns)
                {
                    Console.WriteLine($"Type:{g1.DesignType}; Color:{g1.Color}; Size:{g1.Size}; Quality:{g1.PaperQuality}; Shipping:{g1.ShippingType}; Price:{g1.UnitPrice};");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CreateUserAccount()
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
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Invalid Emaill Address or phone Number. Error: {ex.Message}. Please try again!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sorry something went wrong - {ex} - please try again");
            }
        }
    }
}
