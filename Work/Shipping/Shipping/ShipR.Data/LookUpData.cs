using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using ShipR.Entities;
using System.Data;
using System.Data.Common;

namespace ShipR.Data
{
    public class LookUpData
    {
        #region Enumerations
        enum StoredProcedures
        {          
            usp_shp_getAllLookupTables
        };

        enum Parameters
        {
            PromoID,
	    };

        public enum Fields
        {      
            PromoID,
            store_ref,
            store,
            PromoTypeID,
            PromoTypeDesc,
            DiscountTypeID,
            DiscountTypeDesc,
            DetailedDesc,
            Code,
            Type,
            Delivery,
            Display,
            Notes1,
            Notes2,
        };
        #endregion


        public static Lookup GetGenericLookUp()  // USED IN START PAGE   // MAIN                // GOES INTO Lookup CLASS
        {      
             Database db = DatabaseFactory.CreateDatabase("Rap");                                                                   // Create Container or Database
             DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_shp_getAllLookupTables.ToString());                   // get command using stored Procedure
             Lookup  lookup=new Lookup();
             lookup.Stores = ReturnStoreCollection(db.ExecuteReader(command));                                                      // FILL STORES
             lookup.PromoTypes = ReturnPromotypeCollection(db.ExecuteReader(command));                                              // FILL PROMOTYPES
             lookup.DiscountTypes = ReturnDiscountTypeCollection(db.ExecuteReader(command));                                        // Fill DiscountTypes
             lookup.Shippings = ReturnShippingCollection(db.ExecuteReader(command));                                                // Fill Shippings
             return lookup;
        }

        #region Store
        private static List<Store> ReturnStoreCollection(IDataReader idr)   // COLLECT ALL STORES IN A LIST 
        {
            List<Store> piList = new List<Store>();
            if (idr != null)
            {
                while (idr.Read())
                    piList.Add(ReturnStoreFromRecord(idr)); // uses method within the Class 
                idr.Close();
                idr.Dispose();
            }
            return piList;
        }

        private static Store ReturnStoresFromReader(IDataReader idr)
        {
            Store sp = null;
            if (idr != null)
            {
                if (idr.Read())
                    sp = ReturnStoreFromRecord(idr);// uses method within the Class 
                idr.Close();
                idr.Dispose();
            }
            return sp;
        }

        internal static Store ReturnStoreFromRecord(IDataRecord idr)
        {
            Store p = new Store();
            p.StoreID = DataHelper.ConvertToInt(idr[Fields.store_ref.ToString()]);
            p.StoreName = DataHelper.ConvertToString(idr[Fields.store.ToString()]);
            return p;
        }
        #endregion

        #region Promotype
        private static List<PromoType> ReturnPromotypeCollection(IDataReader idr)
        {
            idr.NextResult();
            List<PromoType> piList = new List<PromoType>();
            if (idr != null)
            {
                while (idr.Read())
                    piList.Add(ReturnPromoTypeFromRecord(idr));// uses method within the Class 
                idr.Close();
                idr.Dispose();
            }
            return piList;
        }

        private static PromoType ReturnPromoTypeFromReader(IDataReader idr)
        {
            PromoType sp = null;
            if (idr != null)
            {
                if (idr.Read())
                    sp = ReturnPromoTypeFromRecord(idr);// uses method within the Class 
                idr.Close();
                idr.Dispose();
            }
            return sp;
        }

        internal static PromoType ReturnPromoTypeFromRecord(IDataRecord idr)
        {
            PromoType p = new PromoType();
            p.PromoTypeID = DataHelper.ConvertToInt(idr[Fields.PromoTypeID.ToString()]);
            p.PromoTypeDesc = DataHelper.ConvertToString(idr[Fields.PromoTypeDesc.ToString()]);
            return p;
        }
        #endregion

        #region DiscountType
        private static List<DiscountType> ReturnDiscountTypeCollection(IDataReader idr)
        {
            idr.NextResult();
            idr.NextResult();
            List<DiscountType> piList = new List<DiscountType>();
            if (idr != null)
            {
                while (idr.Read())
                    piList.Add(ReturnDiscountTypeFromRecord(idr));
                idr.Close();
                idr.Dispose();
            }
            return piList;
        }

        private static DiscountType ReturnDiscountTypeFromReader(IDataReader idr)
        {
            DiscountType sp = null;
            if (idr != null)
            {
                if (idr.Read())
                    sp = ReturnDiscountTypeFromRecord(idr);
                idr.Close();
                idr.Dispose();
            }
            return sp;
        }

        internal static DiscountType ReturnDiscountTypeFromRecord(IDataRecord idr)
        {
            DiscountType p = new DiscountType();
            p.DiscountTypeID = DataHelper.ConvertToInt(idr[Fields.DiscountTypeID.ToString()]);
            p.DiscountTypeDesc = DataHelper.ConvertToString(idr[Fields.DiscountTypeDesc.ToString()]);
            p.DetailedDesc = DataHelper.ConvertToString(idr[Fields.DetailedDesc.ToString()]);
            return p;
        }
        #endregion

        #region Shipping
        private static List<Shipping> ReturnShippingCollection(IDataReader idr)
        {
            idr.NextResult();
            idr.NextResult();
            idr.NextResult();
            List<Shipping> piList = new List<Shipping>();
            if (idr != null)
            {
                while (idr.Read())
                    piList.Add(ReturnShippingFromRecord(idr));
                idr.Close();
                idr.Dispose();
            }
            return piList;
        }

        private static Shipping ReturnShippingFromReader(IDataReader idr)
        {
            Shipping sp = null;
            if (idr != null)
            {
                if (idr.Read())
                    sp = ReturnShippingFromRecord(idr);
                idr.Close();
                idr.Dispose();
            }
            return sp;
        }

        internal static Shipping ReturnShippingFromRecord(IDataRecord idr)
        {
            Shipping p = new Shipping();
            p.Code = DataHelper.ConvertToInt(idr[Fields.Code.ToString()]);
            p.Type = DataHelper.ConvertToString(idr[Fields.Type.ToString()]);
            p.Delivery = DataHelper.ConvertToString(idr[Fields.Delivery.ToString()]);
            p.Display = DataHelper.ConvertToString(idr[Fields.Display.ToString()]);
            p.Notes1 = DataHelper.ConvertToString(idr[Fields.Notes1.ToString()]);
            p.Notes2 = DataHelper.ConvertToString(idr[Fields.Notes2.ToString()]);

            return p;
        }
        #endregion
    }
}
