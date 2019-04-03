using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDesignApp
{
    class GraphicDesign
    {
        #region Properties

        public GraphicDesignType DesignType { get; set; }
        public GraphicDesignColor Color { get; set; }
        public GraphicDesignSize Size { get; set; }
        public DesignPaperQuality PaperQuality { get; set; }
        public ShippingType ShippingType { get; set; }
        public decimal UnitPrice { get; set; }

        #endregion
    }

    public enum GraphicDesignType
    {
        Flyer,
        InvitationCard,
        SocialMediaFlyer,
    }

    public enum GraphicDesignColor
    {
        Red,
        Blue,
        Green,       
        Yellow,
        Orange,
    }

    public enum GraphicDesignSize
    {
        Large,
        Medium,
        Small,
        ExtraSmall,
    }
    
    public enum DesignPaperQuality
    {
        Matte,
        Glossy,
        Regular,
        Card,
    }

    public enum ShippingType
    {
        Delivery,
        PickUp,
    }
}

