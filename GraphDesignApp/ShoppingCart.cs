using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDesignApp
{
    static class ShoppingCart
    {
        public static GraphicDesign CreateDesign(
            GraphicDesignType designType, 
            GraphicDesignColor color,
            GraphicDesignSize size, 
            DesignPaperQuality quality,
            ShippingType shippingType)
        {
            var g1 = new GraphicDesign
            {
                Color = color,
                DesignType = designType,
                PaperQuality = quality,
                ShippingType = shippingType,
                Size = size
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

            return g1;
        }

        public static UserAccount CreateUser(
            string address,
            string email,
            string phoneNumber)
        {
            var u1 = new UserAccount
            {
                
                Address = address,
                EmailAddress = email,
                PhoneNumber = phoneNumber
            };

            return u1;
        }
    }
}
