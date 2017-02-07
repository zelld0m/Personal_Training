using System;
using System.Collections.Generic;

using System.Text;

namespace ShipR.Entities
{
    [Serializable]
    public class Promo
    {
        public Promo()
        {
            //no logic
        }
        public string Name { get; set; }
        public int promoID { get; set; }
        public int promoTypeId { get; set; }
        public int discountTypeId { get; set; }
        public double discount { get; set; }
        public int hasExcludes { get; set; }
        public string startDate { get; set; }
        public string endDate  { get; set; }
        public int status  { get; set; }
        public string createdBy { get; set; }
        public int userSubscriptionId  { get; set; }
		public string merchandisingTextPdp  { get; set; }
        public string merchandisingTextSearch  { get; set; }
        public string merchandisingTextCheckout  { get; set; }
        public string comments  { get; set; }
        public int shipMethodId  { get; set; }
        public string shipMethodName  { get; set; }
        public bool fullOrderOrExactPromo  { get; set; }
		public string stores  { get; set; }    
		public double dollarMin  { get; set; }
        public double dollarMax  { get; set; }
        public double weightMin { get; set; }
        public double weightMax  { get; set; }
		public double increasePercent  { get; set; }
        public double increaseDollar  { get; set; }
        public double increaseWeightThreshold  { get; set; }
		public double increaseDollarThreshold  { get; set; }
        public string promoExtras  { get; set; }
		public string excludeCategoryCodes  { get; set; }
        public string excludeManufacturers  { get; set; }
        public string excludeSkus { get; set; }
		public string excludePayMethodIds  { get; set; }
        public string excludeCompanyIds  { get; set; } 
        public string excludeZoneIds  { get; set; }
        public string categoryCodes { get; set; }
        public string manufacturers { get; set; }
        public string skus { get; set; }
        public string payMethodIds { get; set; }
        public List<Store> Stores { get; set; }
        public PromoType PromoType { get; set; }
        public DiscountType DiscountType { get; set; }
        public Shipping Shipping { get; set; }
        public int IsMerchVisible { get; set; }
    }
}
