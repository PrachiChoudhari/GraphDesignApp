using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraphDesignApp
{
    public class GraphicDesign
    {
        #region Properties

        public int GraphicDesignId { get; set; }
        public GraphicDesignType DesignType { get; set; }
        public GraphicDesignColor Color { get; set; }
        public GraphicDesignSize Size { get; set; }
        public DesignPaperQuality PaperQuality { get; set; }
        public ShippingType ShippingType { get; set; }
        public decimal UnitPrice { get; set; }
        public string EmailAddress { get; set; }

        public virtual UserAccount User { get; set; }

        #endregion
    }

    public enum GraphicDesignType
    {
        [Display(Name = "Flyer")]
        Flyer,

        [Display(Name = "Invitation Card")]
        InvitationCard,

        [Display(Name = "Social Media Flyer")]
        SocialMediaFlyer,
    }

    public enum GraphicDesignColor
    {
        [Display(Name = "Red")]
        Red,
        [Display(Name = "Blue")]
        Blue,
        [Display(Name = "Green")]
        Green,
        [Display(Name = "Yellow")]
        Yellow,
        [Display(Name = "Orange")]
        Orange,
    }

    public enum GraphicDesignSize
    {
        [Display(Name = "Large")]
        Large,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "Small")]
        Small,
        [Display(Name = "ExtraSmall")]
        ExtraSmall,
    }
    
    public enum DesignPaperQuality
    {
        [Display(Name = "Matte")]
        Matte,
        [Display(Name = "Glossy")]
        Glossy,
        [Display(Name = "Regular")]
        Regular,
        [Display(Name = "Card")]
        Card,
    }

    public enum ShippingType
    {
        [Display(Name = "Delivery")]
        Delivery,
        [Display(Name = "PickUp")]
        PickUp,
    }
}

