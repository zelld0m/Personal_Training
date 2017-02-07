using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using ShipR.Entities;
using System.Collections;

namespace ShipR.Data
{
    public class PromoData
    {
        #region Enumerations
        enum StoredProcedures
        {     
           usp_shp_getPromoDataByPromoID,
           usp_shp_addUpdateRules_ExcludeData,
           usp_GetAllActivePromos,
           usp_shp_addUpdatePromoData,
           usp_shp_addUpdateStoreXrefPromoID,
           usp_shp_UpdatePromoStatus,
           usp_shp_getAllLookupTables,
           cat_GetWDMajors,
           Cat_GetWDSubMajors,
           Cat_GetWDMinors,
           Cat_GetWDSubMinors,
           RAP_GetAll_Manufacturers,
           usp_GetAllPromos,
            // ADDD IN ACTIVE PROMO FOR STORED PROC-----------xxxxxxxxxxxxxx---------------------------- 
            //-----------------Create SP on Database with same Name---- copy the code of usp_GetAllActivePromos change the where value to 0 ---------------
            //usp_GetAllInActivePromos,
            prd_GetEdpFromLineListing_DPno,
           prd_GetDPNumberFromLineListing,
           usp_Add_PromoExceptions,
           usp_Delete_PromoExceptions,
           usp_Get_PromoExceptions

        

        };

        enum Parameters
        {
            Name,
           	PromoTypeID,
            PromoID,
			DiscountTypeID,
			Discount,
            HasExcludes,
            StartDate,
            EndDate,
            Status,
            CreatedBy,
            UserSubscriptionID,
			MerchandisingTextPDP,
			MerchandisingTextSearch,
			MerchandisingTextCheckout,
			Comments,
			ShipMethodID,
			ShipMethodName,
			FullOrderOrExactPromo,
            StoreList,
            WeightMin,
            weightmax,      
            EdpNo,
            DpNo,
            edp,
            promoid

	    };



        public enum Fields
        {
            Name,
            PromoID,
            PromoTypeID,
            DiscountTypeID,
            Discount,
            HasExcludes,
            StartDate,
            EndDate,
            Status,
            CreatedBy,
            UserSubscriptionID,
            MerchandisingTextPDP,
            MerchandisingTextSearch,
            MerchandisingTextCheckout,
            Comments,
            ShipMethodID,
            ShipMethodName,
            FullOrderOrExactPromo,  
            ExcludeCategoryCodes,
            ExcludeManufacturers,
            ExcludeSkus,
            ExcludePayMethodIDs,
            ExcludeCompanyIDs,
            ExcludeZoneIDs,
            DollarMin,
            DollarMax,
            WeightMin,
            weightmax,
            IncreasePercent,
            IncreaseWeightThreshold,
            IncreaseDollarThreshold,
            IncreaseDollar,
            StoreIDs,
            CategoryCodes,
            Manufacturers,
            Skus,
            payMethodIds,
            EdpNo,
            DpNo,
            IsMerchandisingTextVisible
        };

        #endregion

        public static void SavePromo(Promo promo)
        {
            SavePromo(promo, false);
        }

        public static void SavePromo(Promo promo, Boolean isUpdate)   //SAVING WHEN BUTTON SUBMIT IS CLICKED  then save in database
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_shp_addUpdatePromoData.ToString());
            if (isUpdate==true)
                db.AddInParameter(command, Parameters.PromoID.ToString(), DbType.Int32, promo.promoID);
          
            db.AddInParameter(command, Parameters.PromoTypeID.ToString(), DbType.Int32, promo.promoTypeId);
            db.AddInParameter(command, Parameters.Name.ToString(), DbType.String, promo.Name);
            db.AddInParameter(command, Parameters.DiscountTypeID.ToString(), DbType.Int32, promo.discountTypeId);       //  db.AddInParameter(command, "DiscountTypeID", DbType.Int32, promo.discountTypeId);
            db.AddInParameter(command, Parameters.Discount.ToString(), DbType.Currency, promo.discount);
            db.AddInParameter(command, Parameters.HasExcludes.ToString(), DbType.Byte, promo.hasExcludes);
            db.AddInParameter(command, Parameters.StartDate.ToString(), DbType.DateTime, promo.startDate);
            db.AddInParameter(command, Parameters.EndDate.ToString(), DbType.DateTime, promo.endDate);
            db.AddInParameter(command, Parameters.Status.ToString(), DbType.Int32, promo.status);
            db.AddInParameter(command, Parameters.CreatedBy.ToString(), DbType.String, promo.createdBy);
            db.AddInParameter(command, Parameters.UserSubscriptionID.ToString(), DbType.Int32, promo.userSubscriptionId);
            db.AddInParameter(command, Parameters.MerchandisingTextPDP.ToString(), DbType.String, promo.merchandisingTextPdp);
            db.AddInParameter(command, Parameters.MerchandisingTextSearch.ToString(), DbType.String, promo.merchandisingTextSearch);
            db.AddInParameter(command, Parameters.MerchandisingTextCheckout.ToString(), DbType.String, promo.merchandisingTextCheckout);
            db.AddInParameter(command, Parameters.Comments.ToString(), DbType.String, promo.comments);
            db.AddInParameter(command, Parameters.ShipMethodID.ToString(), DbType.Int32, promo.shipMethodId);
            db.AddInParameter(command, Parameters.ShipMethodName.ToString(), DbType.String, promo.shipMethodName);
            db.AddInParameter(command, Parameters.FullOrderOrExactPromo.ToString(), DbType.Boolean, promo.fullOrderOrExactPromo);
            db.ExecuteNonQuery(command);
            UpdateRules(SaveStoreXref(promo));
            SavePromoExceptions(promo);

        }
        
        private static Promo SaveStoreXref(Promo promo)
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_shp_addUpdateStoreXrefPromoID.ToString());

            if (promo.promoID == 0)      //0-insert, >0- update
                promo.promoID = getMaxPromoID();            
            db.AddInParameter(command, Parameters.PromoID.ToString(), DbType.Int32, promo.promoID);
            db.AddInParameter(command, Parameters.StoreList.ToString(), DbType.String, promo.stores);
            db.AddInParameter(command, Parameters.PromoTypeID.ToString(), DbType.Int32, promo.promoTypeId);
            db.AddInParameter(command, Parameters.DiscountTypeID.ToString(), DbType.Int32, promo.discountTypeId);
            db.ExecuteNonQuery(command);
            return promo;
        }

        private static Promo SavePromoExceptions(Promo promo)               // SAVE PROMO EXEPTION
        
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command;

            if (promo.IsMerchVisible == 0)  
            {
                command = db.GetStoredProcCommand(StoredProcedures.usp_Add_PromoExceptions.ToString());
                db.AddInParameter(command, Parameters.promoid.ToString(), DbType.Int32, promo.promoID);
                db.ExecuteNonQuery(command);
            }
            else
            {
                command = db.GetStoredProcCommand(StoredProcedures.usp_Delete_PromoExceptions.ToString());
                db.AddInParameter(command, Parameters.promoid.ToString(), DbType.Int32, promo.promoID);
                db.ExecuteNonQuery(command);
            }
            return promo;
        }

        private static void UpdateRules(Promo promo)            // FOR UPDATE PURPOSES ONLY
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_shp_addUpdateRules_ExcludeData.ToString());

            db.AddInParameter(command, Parameters.PromoID.ToString(), DbType.Int32, promo.promoID);
            
            db.AddInParameter(command, "@DollarMin", DbType.Currency, promo.dollarMin);
			db.AddInParameter(command, "@DollarMax", DbType.Currency, promo.dollarMax);
			db.AddInParameter(command, "@WeightMin", DbType.Decimal, promo.weightMin);
			db.AddInParameter(command, "@WeightMax", DbType.Decimal, promo.weightMax);
			db.AddInParameter(command, "@IncreasePercent", DbType.Decimal, promo.increasePercent);
			db.AddInParameter(command, "@IncreaseDollar", DbType.Currency, promo.increaseDollar);
			db.AddInParameter(command, "@IncreaseWeightThreshold", DbType.Decimal, promo.increaseWeightThreshold);
			db.AddInParameter(command, "@IncreaseDollarThreshold", DbType.Currency, promo.increaseDollarThreshold);
			db.AddInParameter(command, "@CategoryCodes", DbType.String, promo.categoryCodes);
			db.AddInParameter(command, "@Manufacturers", DbType.String, promo.manufacturers);
			db.AddInParameter(command, "@SKUs", DbType.String, promo.skus);
			db.AddInParameter(command, "@PayMethodIDs", DbType.String, promo.payMethodIds);
			db.AddInParameter(command, "@ExcludeCategoryCodes", DbType.String, promo.excludeCategoryCodes);
			db.AddInParameter(command, "@ExcludeManufacturers", DbType.String, promo.excludeManufacturers);
			db.AddInParameter(command, "@ExcludeSKUs", DbType.String, promo.excludeSkus);
			db.AddInParameter(command, "@ExcludePayMethodIDs", DbType.String, promo.excludePayMethodIds);
            db.AddInParameter(command, "@ExcludeCompanyIDs", DbType.String, promo.excludeCompanyIds);
            db.AddInParameter(command, "@ExcludeZoneIDs", DbType.String, promo.excludeZoneIds);
            db.ExecuteNonQuery(command);
        }

        private static int getMaxPromoID()
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand idCommand = db.GetSqlStringCommand("SELECT MAX(PromoID) AS LastID FROM Shp_PromoMain");
            return Convert.ToInt32(db.ExecuteScalar(idCommand));
        }
        
        public static Promo SelectByPromoID(int promoID)
        {            
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_shp_getPromoDataByPromoID.ToString());
            db.AddInParameter(command, Parameters.PromoID.ToString(), DbType.Int32, promoID);
            return ReturnPromoFromReader(db.ExecuteReader(command));
        }
            
        public static List<Promo> Select()
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_GetAllActivePromos.ToString());
            return ReturnCollection(db.ExecuteReader(command));
        }

        public static void UpdateStatus(int promoId, int status, string createdBy)
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_shp_UpdatePromoStatus.ToString());
            db.AddInParameter(command, "@PromoID", DbType.Int32, promoId);
            db.AddInParameter(command, "@Status", DbType.Int32, status);
            db.AddInParameter(command, "@CreatedBy", DbType.String, createdBy);
            db.ExecuteNonQuery(command);          
        }

        public static DataSet GetActivePromos()
        {         
                Database db = DatabaseFactory.CreateDatabase("Rap");
                DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_GetAllActivePromos.ToString());
                return db.ExecuteDataSet(command);
        }


        //----------------------------xxxxxxxxxxxxxxxxxx  CREATE FOR INACTIVE PROMO---------------------------
        //public static DataSet GetAllInactivePromos()
        //{
        //    Database db = DatabaseFactory.CreateDatabase("Rap");
        //    DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_GetAllInActivePromos)
        //    return db.ExecuteDataSet(command);
        //}

        public static DataSet GetAllPromos()
        {
            Database db = DatabaseFactory.CreateDatabase("Rap");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.usp_GetAllPromos.ToString());
            return db.ExecuteDataSet(command);
        }


        public static DataSet GetCategoryMajors()
        {
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.cat_GetWDMajors.ToString());
            return db.ExecuteDataSet(command);  
        }

        public static DataSet GetSubMajors(char submajor)
        {
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.Cat_GetWDSubMajors.ToString());
            db.AddInParameter(command, "@major", DbType.String, submajor);            
            return db.ExecuteDataSet(command);
        }

        public static DataSet GetMinors(char major, char submajor)
        {
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.Cat_GetWDMinors.ToString());
            db.AddInParameter(command, "@major", DbType.String, major);
            db.AddInParameter(command, "@submajor", DbType.String, submajor);
            return db.ExecuteDataSet(command);
        }
        
        public static DataSet GetSubMinors(char major, char submajor, char minor)
        {
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.Cat_GetWDSubMinors.ToString());
            db.AddInParameter(command, "@major", DbType.String, major);
            db.AddInParameter(command, "@submajor", DbType.String, submajor);
            db.AddInParameter(command, "@minor", DbType.String, minor);
            return db.ExecuteDataSet(command);
        }

        public static DataSet GetAllManufacturers()
        {
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.RAP_GetAll_Manufacturers.ToString());
            return db.ExecuteDataSet(command);
        }

        public static int GetDpNumberByEdp(int edp)
        {
            Int32 dp = 0;
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.prd_GetDPNumberFromLineListing.ToString());
            db.AddInParameter(command, Parameters.edp.ToString(), DbType.Int32, edp);
            db.AddOutParameter(command, Parameters.DpNo.ToString(), DbType.Int32, 0);
            db.ExecuteNonQuery(command);
            dp = DataHelper.ConvertToInt(db.GetParameterValue(command, Parameters.DpNo.ToString()));
            return dp;
        }

        public static int GetEdpNumberByDP(int dp)
        {
            Int32 edp = 0;
            Database db = DatabaseFactory.CreateDatabase("Cc_product");
            DbCommand command = db.GetStoredProcCommand(StoredProcedures.prd_GetEdpFromLineListing_DPno.ToString());
            db.AddInParameter(command, Parameters.DpNo.ToString(), DbType.Int32, dp);
            db.AddOutParameter(command, Parameters.edp.ToString(), DbType.Int32, 0);
            db.ExecuteNonQuery(command);
            edp = DataHelper.ConvertToInt(db.GetParameterValue(command, Parameters.edp.ToString()));
            return edp;
        }

        public static Hashtable GetAllPaymentMethods()
        {
             Hashtable payment = new Hashtable();
             payment.Add("1", "American Express");
             payment.Add("2", "Visa");
             payment.Add("4", "Master Card");
             payment.Add("8", "Discover");
             payment.Add("16", "Diner's Club");
             payment.Add("18", "PCMall/MacMall Corporate/Consumer");
             payment.Add("28", "Preferred");
             payment.Add("30", "BML");
             payment.Add("64", "Paypal");
             return payment;
        }


        #region ReturnCollections
        private static List<Promo> ReturnCollection(IDataReader idr)
        {
            Lookup lookup = LookUpData.GetGenericLookUp();              // created lookup variable with the value of 
            List<Promo> piList = new List<Promo>();
            if (idr != null)
            {
                while (idr.Read())
                {
                    piList.Add(ReturnPromoFromRecord(idr,lookup));
                }
                idr.Close();
                idr.Dispose();
            }
            return piList;
        }

        private static Promo ReturnPromoFromReader(IDataReader idr)
        {
            Lookup lookup = LookUpData.GetGenericLookUp();     
            Promo sp = null;
            if (idr != null)
            {
                if (idr.Read())
                {
                    sp = ReturnPromoFromRecord(idr, lookup);
                }
                idr.Close();
                idr.Dispose();
            }
            return sp;
        }

        internal static Promo ReturnPromoFromRecord(IDataRecord idr)
        {
           return ReturnPromoFromRecord(idr, null);
        }
        internal static Promo ReturnPromoFromRecord(IDataRecord idr,Lookup lookup)
        {
            Promo p = new Promo();
            p.Name = DataHelper.ConvertToString(idr[Fields.Name.ToString()]);
            p.promoID = DataHelper.ConvertToInt(idr[Fields.PromoID.ToString()]);
            p.promoTypeId = DataHelper.ConvertToInt(idr[Fields.PromoTypeID.ToString()]);
            p.discountTypeId = DataHelper.ConvertToInt(idr[Fields.DiscountTypeID.ToString()]);
            p.discount = DataHelper.ConvertToDouble(idr[Fields.Discount.ToString()]);
            p.hasExcludes = DataHelper.ConvertToInt(idr[Fields.HasExcludes.ToString()]);
            p.startDate = DataHelper.ConvertToString(idr[Fields.StartDate.ToString()]);
            p.endDate = DataHelper.ConvertToString(idr[Fields.EndDate.ToString()]);
            p.status = DataHelper.ConvertToInt(idr[Fields.Status.ToString()]);
            //createdDate 
            //updateDate
            p.createdBy = DataHelper.ConvertToString(idr[Fields.CreatedBy.ToString()]);
            //modifiedBy
            //userSubscriptionFlag 
            p.merchandisingTextPdp = DataHelper.ConvertToString(idr[Fields.MerchandisingTextPDP.ToString()]);
            p.merchandisingTextSearch = DataHelper.ConvertToString(idr[Fields.MerchandisingTextSearch.ToString()]);
            p.comments = DataHelper.ConvertToString(idr[Fields.Comments.ToString()]);
            p.merchandisingTextCheckout = DataHelper.ConvertToString(idr[Fields.MerchandisingTextCheckout.ToString()]);
            p.shipMethodId = DataHelper.ConvertToInt(idr[Fields.ShipMethodID.ToString()]);
            p.shipMethodName = DataHelper.ConvertToString(idr[Fields.ShipMethodName.ToString()]);
            p.fullOrderOrExactPromo = DataHelper.ConvertToBool(idr[Fields.FullOrderOrExactPromo.ToString()]);
            //Name
            //RowID
            p.excludeCategoryCodes = DataHelper.ConvertToString(idr[Fields.ExcludeCategoryCodes.ToString()]);
            p.excludeManufacturers = DataHelper.ConvertToString(idr[Fields.ExcludeManufacturers.ToString()]);
            p.excludeSkus = DataHelper.ConvertToString(idr[Fields.ExcludeSkus.ToString()]);
            p.excludePayMethodIds = DataHelper.ConvertToString(idr[Fields.ExcludePayMethodIDs.ToString()]);
            p.excludeCompanyIds = DataHelper.ConvertToString(idr[Fields.ExcludeCompanyIDs.ToString()]);
            p.excludeZoneIds = DataHelper.ConvertToString(idr[Fields.ExcludeZoneIDs.ToString()]);
            p.dollarMin = DataHelper.ConvertToDouble(idr[Fields.DollarMin.ToString()]);
            p.weightMin = DataHelper.ConvertToDouble(idr[Fields.WeightMin.ToString()]);
            p.weightMax = DataHelper.ConvertToDouble(idr[Fields.weightmax.ToString()]);
            
            p.dollarMax = DataHelper.ConvertToDouble(idr[Fields.DollarMax.ToString()]);
            p.increasePercent = DataHelper.ConvertToDouble(idr[Fields.IncreasePercent.ToString()]);
            p.increaseWeightThreshold = DataHelper.ConvertToDouble(idr[Fields.IncreaseWeightThreshold.ToString()]);
            p.increaseDollarThreshold = DataHelper.ConvertToDouble(idr[Fields.IncreaseDollarThreshold.ToString()]);
                        
            switch (p.promoTypeId)
            {
                case 2: //Categories.
                    p.categoryCodes = DataHelper.ConvertToString(idr[Fields.CategoryCodes.ToString()]);           
                    p.promoExtras = p.categoryCodes;
                    break;
                case 3: //Manufacturers
                    p.manufacturers = DataHelper.ConvertToString(idr[Fields.Manufacturers.ToString()]);
                    p.promoExtras = p.manufacturers;
                    break;
                case 4: //SKULevel
                    p.skus = DataHelper.ConvertToString(idr[Fields.Skus.ToString()]);
                    p.promoExtras = p.skus ;
                    break;
                case 5: //PaymentMethod
                    p.payMethodIds = DataHelper.ConvertToString(idr[Fields.payMethodIds.ToString()]);
                    p.promoExtras = p.payMethodIds;
                    break;
                default:
                    break;
            }

            p.increaseDollar = DataHelper.ConvertToDouble(idr[Fields.IncreaseDollar.ToString()]);
            p.stores = DataHelper.ConvertToString(idr[Fields.StoreIDs.ToString()]);
            //PDP Visibility: value is 0 if ID exist in Shp_PromoExceptions else 1
            p.IsMerchVisible = DataHelper.ConvertToInt(idr[Fields.IsMerchandisingTextVisible.ToString()]);
           
            if (lookup!=null)
            {       
                //Discount Type
                if (p.discountTypeId > 0)
                {
                    DiscountType discountType = lookup.DiscountTypes.Find(delegate(DiscountType disType) { return disType.DiscountTypeID == p.discountTypeId; });
                    p.DiscountType = discountType;
                }
                //Promo Type
                if (p.promoTypeId > 0)
                {
                    PromoType promoType = lookup.PromoTypes.Find(delegate(PromoType proType) { return proType.PromoTypeID == p.promoTypeId; });
                    p.PromoType = promoType;
                }
                //Shipping 
                if (p.shipMethodId > 0)
                {
                    Shipping shipping = lookup.Shippings.Find(delegate(Shipping sh) { return sh.Code == p.shipMethodId; });
                    p.Shipping = shipping;
                }
                //Stores
                List<Store> storesList = new List<Store>();
                if (p.stores.Trim().Length > 0)
                {
                    String[] stores = p.stores.ToString().Split(',');
                    foreach (String st in stores)
                    {
                        Store store = lookup.Stores.Find(delegate(Store dStore) { return dStore.StoreID == Convert.ToInt32(st); });
                        storesList.Add(store);
                    }
                    p.Stores = storesList;
                }
             }
            return p;
        }
        #endregion
    }
}
