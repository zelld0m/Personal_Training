using System;
using System.Collections.Generic;

using System.Text;
using ShipR.Data;
using ShipR.Entities;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace ShipR.Business
{
    [DataObject]
    public class PromoManagement
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Promo GetPromoByPromoID(int promoID)
        {
            if (promoID > 0)
                return PromoData.SelectByPromoID(promoID);
            else
                return null;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Promo> GetActivePromosGeneric()
        {
         
            return PromoData.Select();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet GetActivePromos()
        {
            return PromoData.GetActivePromos();
        }

        // ---------------------xxxxxxxxxxxxxxxxxxx ---------------------
        //[DataObjectMethod(DataObjectMethodType.Select)]
        //public static DataSet GetAllInactivePromos()
        //{
        //    return PromoData.GetAllInactivePromos();
        //}


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet GetAllPromos()
        {
            return PromoData.GetAllPromos();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateStatus(int promoId, int status, string createdBy)
        {
            PromoData.UpdateStatus( promoId,  status, createdBy);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void Insert(Promo promo)
        {
            PromoData.SavePromo(promo);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void Update(Promo promo)
        {
            PromoData.SavePromo(promo,true);
        }
           
       [DataObjectMethod(DataObjectMethodType.Select)]
        public static Lookup GetGenericLookUp()
        {        
            return LookUpData.GetGenericLookUp();               // REturning complete Data 
        }

       [DataObjectMethod(DataObjectMethodType.Select)]
       public static DataSet GetCategoryMajors()
       {
           return PromoData.GetCategoryMajors();
       }
        
       [DataObjectMethod(DataObjectMethodType.Select)]
       public static DataSet GetSubMajors(char major)
       {
           return PromoData.GetSubMajors(major);
       }

       [DataObjectMethod(DataObjectMethodType.Select)]
       public static DataSet GetMinors(char major,char submajor)
       {
           return PromoData.GetMinors(major,submajor);
       }


       [DataObjectMethod(DataObjectMethodType.Select)]
       public static DataSet GetSubMinors(char major, char submajor,char minor)
       {
           return PromoData.GetSubMinors(major, submajor,minor);
       }
        
       [DataObjectMethod(DataObjectMethodType.Select)]
       public static DataSet GetAllManufacturers()
       {
           return PromoData.GetAllManufacturers();
       }

      [DataObjectMethod(DataObjectMethodType.Select)]
       public static Hashtable GetAllPaymentMethods()
       {
           return PromoData.GetAllPaymentMethods();
       }


      [DataObjectMethod(DataObjectMethodType.Select)]
      public static int GetEdpByDp(int dpno)
      {
          return PromoData.GetEdpNumberByDP(dpno);
      }

      [DataObjectMethod(DataObjectMethodType.Select)]
      public static int GetDpByEdp(int edp)
      {
          return PromoData.GetDpNumberByEdp(edp);
      }
         
    }
}
