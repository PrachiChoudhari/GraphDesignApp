using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GraphDesignApp
{
    public static class ShoppingCart
    {
        private static GraphicDesignContext db = new GraphicDesignContext();

        public static List<GraphicDesign> CreateDesigns(
            GraphicDesignType designType, 
            GraphicDesignColor color,
            GraphicDesignSize size, 
            DesignPaperQuality quality,
            ShippingType shippingType,
            int quantity,
            string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("emailAddress", "Email Address is required!");
            }

            var userAccount = GetUserAccountByEmail(email);
            if (userAccount == null)
            {
                throw new ArgumentNullException("emailAddress", "Email Address is invalid!");
            }

            var results = new List<GraphicDesign>();

            for (int i = 0; i < quantity; i++)
            {
                var g1 = new GraphicDesign
                {
                    Color = color,
                    DesignType = designType,
                    PaperQuality = quality,
                    ShippingType = shippingType,
                    Size = size,
                    EmailAddress = email
                };

                switch (g1.DesignType)
                {
                    case GraphicDesignType.Flyer:
                        g1.UnitPrice = 5;
                        break;

                    case GraphicDesignType.InvitationCard:
                        g1.UnitPrice = 7;
                        break;

                    case GraphicDesignType.SocialMediaFlyer:
                        g1.UnitPrice = 4;
                        break;

                    default:
                        break;
                }

                results.Add(g1);
            }

            foreach (var result in results)
            {
                db.Add(result);
            }

            db.SaveChanges();

            return results;
        }

        public static List<UserAccount> GetAllUserAccounts()
        {
            return db.UserAccounts.ToList();
        }

        public static UserAccount GetUserAccountByEmail(string emailAddress)
        {
            return db.UserAccounts.SingleOrDefault(a => a.EmailAddress == emailAddress);
        }

        public static List<GraphicDesign> GetGraphicDesignsByUser(string emailAddress)
        {
            var designs = db.GraphicDesigns.Include(x => x.User).Where(a => a.EmailAddress == emailAddress).ToList();
            return designs;
        }

        public static UserAccount CreateUser(
            string address,
            string email,
            string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("emailAddress", "Email Address is required!");
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentNullException("phoneNumber", "Phone Number is required!");
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException("address", "Address is required!");
            }

            var u1 = new UserAccount
            {
                Address = address,
                EmailAddress = email,
                PhoneNumber = phoneNumber
            };

            db.Add(u1);
            db.SaveChanges();

            return u1;
        }
    }
}
