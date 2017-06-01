

using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using PcMall.Application.Data;
using System.Xml;
using System.Collections;
using System.Xml.Linq;

namespace ElectronicInvoicing
{
    public class Data
    {
        public static DataSet dsAMROrders;
        private static string connB2B = ConfigurationManager.ConnectionStrings["cn_b2b"].ToString();
        private static string connOpsTRACK = ConfigurationManager.ConnectionStrings["cn_opstrack"].ToString();
        private static string connBD = ConfigurationManager.ConnectionStrings["cn_BD"].ToString();
        private static string connOrderStat = ConfigurationManager.ConnectionStrings["cn_orderstat"].ToString();
        private static string connTPOP = ConfigurationManager.ConnectionStrings["cn_tpop"].ToString();
        private static XmlDocument xorders = new XmlDocument();
        private static XmlDocument xpayload = new XmlDocument();
        private static bool useDBorder = false;
        private static bool isShippedComplete = false;
        private static string orderNumber = "";
        private static Utility util = new Utility();

        static Data()
        {
            //getAMROrder();
        }

        public static void getAMROrder(String buyerId, String orderNo)
        {
            orderNumber = orderNo;
            try
            {
                DataSet ds;
                if (!useDBorder)
                {
                    String sql = "SELECT * FROM dbo.CapNet_ariba_order_map (nolock) WHERE buyer_id = '" + buyerId + "' AND cap_order_no = '" + orderNo + "'";

                    ds = SqlAccess.ExecuteDataset(connB2B, CommandType.Text, sql);
                }
                else
                {
                    string macsOrderId = "";
                    object[,] orderParams = { { "@order_no", SqlDbType.VarChar, ParameterDirection.Input, 50, null, null, "J6084058" + macsOrderId } };
                    ds = SqlAccess.ExecuteDataset(connOrderStat, CommandType.StoredProcedure, "usp_Order_Status", orderParams);
                }



                dsAMROrders = ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataSet getOpstrackPoCxml(String orderNo)
        {
            DataSet ds = new DataSet();
            try
            {
                String sql = "SELECT * FROM dbo.xmlordersmacs with (nolock) WHERE OrderNumber = '" + orderNo + "'";
                ds = SqlAccess.ExecuteDataset(connOpsTRACK, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting OpstrackPoCXML");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in getting OpstrackPoCXML - " + ex.Message, Logger.OperationLogFileName);
                throw ex;
            }
            return ds;
        }

        public static DataSet getAMROrderXml(String purchaseNo)
        {
            DataSet ds = new DataSet();

            try
            {

                String sql = "SELECT * FROM dbo.CapNet_ariba_order_map (nolock) WHERE ariba_order_no = '" + purchaseNo + "'";

                ds = SqlAccess.ExecuteDataset(connB2B, CommandType.Text, sql);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting orderXML");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in getting orderXML - " + ex.Message, Logger.OperationLogFileName);
                throw ex;
            }

            return ds;

        }

        public static DataSet getBDPoCxml(String orderNo, bool retry)
        {
            DataSet ds = new DataSet();
            String sql = "";
            try
            {
                if (!retry)
                    sql = "Select Request_Data from Order_Integration_Log as OIL with (nolock) Inner Join Order_Form_PO as OFP with (nolock) on OIL.PO_NO = OFP.PO_NO where OFP.ORDER_ID = '" + orderNo + "'";
                else
                    sql = "Select Request_Data from Order_Integration_Log as OIL with (nolock) Inner Join Order_Form_PO as OFP with (nolock) on OIL.Request_data like '%orderID=\"' + OFP.PO_NO + '\"%' where OFP.ORDER_ID = '" + orderNo + "'";
                ds = SqlAccess.ExecuteDataset(connBD, CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting BDPoCXML");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in getting BDPoCXML - " + ex.Message, Logger.OperationLogFileName);
                throw ex;
            }
            return ds;
        }

        public static bool IsInvoicingReady()
        {
            if (dsAMROrders.Tables.Count > 0)
            {
                if (dsAMROrders.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public static bool IsShippedComplete()
        {
            try
            {
                DataSet ds;
                if (orderNumber != string.Empty)
                {
                    object[,] orderParams = { { "@order_no", SqlDbType.VarChar, ParameterDirection.Input, 50, null, null, orderNumber } };
                    ds = SqlAccess.ExecuteDataset(connOrderStat, CommandType.StoredProcedure, "usp_Order_Status", orderParams);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Order-Status"].ToString().Contains("Shipped Complete"))
                            {
                                isShippedComplete = true;
                            }
                        }
                        else
                        {
                            isShippedComplete = false;
                        }
                    }
                    else
                    {
                        isShippedComplete = false;
                    }

                }
                else
                {
                    isShippedComplete = false;
                }

            }
            catch (Exception ex)
            {
                isShippedComplete = false;
                throw ex;
            }

            return isShippedComplete;
        }

        public static XmlDocument getOrderXml()
        {

            String orderXml = "";

            if (!useDBorder)
            {
                if (dsAMROrders.Tables.Count > 0 && dsAMROrders.Tables[0].Rows.Count > 0)
                {
                    orderXml = dsAMROrders.Tables[0].Rows[0]["OrderXml"].ToString();
                    xorders.LoadXml(orderXml);
                }
            }

            return xorders;
        }

        public static XmlDocument getPayloadXml()
        {

            String payloadXml = "";

            if (!useDBorder)
            {
                if (dsAMROrders.Tables.Count > 0 && dsAMROrders.Tables[0].Rows.Count > 0)
                {
                    payloadXml = dsAMROrders.Tables[0].Rows[0]["payloadXml"].ToString();
                    xpayload.LoadXml(payloadXml);
                }
            }

            return xpayload;
        }

        public static String getCustomerOrderId()
        {
            string order_id = "no customer order id";

            if (dsAMROrders.Tables.Count > 0 && dsAMROrders.Tables[0].Rows.Count > 0)
            {
                if (!useDBorder)
                {
                    order_id = dsAMROrders.Tables[0].Rows[0]["ariba_order_no"].ToString();
                }
                else
                    order_id = dsAMROrders.Tables[0].Rows[0]["PO#"].ToString().Trim();

            }

            return order_id;
        }

        public static String getPayloadId()
        {
            string payload_id = "no payload id";

            if (dsAMROrders.Tables.Count > 0 && dsAMROrders.Tables[0].Rows.Count > 0)
            {
                if (!useDBorder)
                {
                    payload_id = dsAMROrders.Tables[0].Rows[0]["payload"].ToString();
                }
            }

            return payload_id;
        }

        public static void getInvoiceCostSummaryFromXml(ref cxmlInvoiceDetailSummary summary)
        {
            XmlNode subTotal = xorders.SelectSingleNode("/OrderXml/Cart/SubTotal");
            XmlNode taxTotal = xorders.SelectSingleNode("/OrderXml/Cart/TaxTotal");
            XmlNode shipCost = xorders.SelectSingleNode("/OrderXml/Shipping/Shipcost");
            XmlNode grossAmount = xorders.SelectSingleNode("/OrderXml/GrandTotal");

            if (useDBorder)
            {
                double dsubTotal = 0;
                double dTotal = 0;
                double dTax = 0;
                double dShipping = 0;

                dTotal = double.Parse(dsAMROrders.Tables[0].Rows[0]["Total-$-Amount"].ToString());
                dTax = double.Parse(dsAMROrders.Tables[0].Rows[0]["Tax"].ToString());
                dShipping = double.Parse(dsAMROrders.Tables[0].Rows[0]["Shipping"].ToString());

                dsubTotal = dTotal - dTax - dShipping;

                summary.setSubTotalAmount = dsubTotal.ToString();
                summary.setShippingAmount = dShipping.ToString();
                summary.setTax = dTax.ToString();
                summary.setGrossAmount = dTotal.ToString();
                summary.setNetAmount = dTotal.ToString();
                summary.setDueAmount = dTotal.ToString();
            }
            else
            {
                summary.setSubTotalAmount = subTotal != null ? subTotal.InnerText : "0.0";
                summary.setShippingAmount = shipCost != null ? shipCost.InnerText : "0.0";
                summary.setTax = taxTotal != null ? taxTotal.InnerText : "0.0";
                summary.setGrossAmount = grossAmount != null ? grossAmount.InnerText : "0.0";
                summary.setNetAmount = grossAmount != null ? grossAmount.InnerText : "0.0";
                summary.setDueAmount = grossAmount != null ? grossAmount.InnerText : "0.0";
            }


        }

        public static void getInvoiceCostSummaryFromInvoiceStructure(ref cxmlInvoiceDetailSummary summary, InvoiceStructure invoiceStructure)
        {

            double dsubTotal = 0;
            double dTotal = 0;
            double dTax = 0;
            double dShipping = 0;

            dTotal = invoiceStructure.Totals.AMT_Due.Trim().Length <= 0 ? 0 : double.Parse(invoiceStructure.Totals.AMT_Due);
            dTax = invoiceStructure.Totals.Tax.Trim().Length <= 0 ? 0 : double.Parse(invoiceStructure.Totals.Tax);
            dShipping = invoiceStructure.Totals.POSTAGE.Length <= 0 ? 0 : double.Parse(invoiceStructure.Totals.POSTAGE);

            dsubTotal = dTotal - dTax - dShipping;

            //summary.setSubTotalAmount = dsubTotal.ToString();
            summary.setShippingAmount = dShipping.ToString();
            summary.setTax = dTax.ToString();


            if (invoiceStructure.Header.INVHDR_TYPE == InvoiceType.Credit)
            {
                summary.setSubTotalAmount = " -" + dsubTotal.ToString();
                summary.setGrossAmount = " -" + dTotal.ToString();
                summary.setNetAmount = " -" + dTotal.ToString();
                summary.setDueAmount = " -" + dTotal.ToString();
                summary.setTax = " -" + dTax.ToString();
            }
            else
            {
                summary.setSubTotalAmount = dsubTotal.ToString();
                summary.setGrossAmount = dTotal.ToString();
                summary.setNetAmount = dTotal.ToString();
                summary.setDueAmount = dTotal.ToString();
            }

        }

        public static ArrayList getItemsFromXml()
        {
            ArrayList al = new ArrayList();

            XmlNodeList items = xorders.SelectNodes("/OrderXml/Cart/Items/Item");

            if (useDBorder)
            {
                if (dsAMROrders.Tables.Count > 3 && dsAMROrders.Tables[3].Rows.Count > 0)
                {

                    int count = 1;
                    foreach (DataRow row in dsAMROrders.Tables[3].Rows)
                    {
                        cxmlInvoiceDetailItem detailitem = new cxmlInvoiceDetailItem();

                        Double qty = double.Parse(row["Qty"].ToString());
                        Double subTotal = double.Parse(row["Extended-Price"].ToString());
                        Double unitPrice = subTotal / qty;


                        detailitem.setInvoiceLineNumber = count.ToString();
                        detailitem.setQty = qty.ToString();
                        detailitem.setUnitPrice = unitPrice.ToString();
                        detailitem.setSupplierPartID = row["DP#"].ToString().Trim();
                        detailitem.setDescription = row["Description"].ToString().Trim();
                        detailitem.setManufacturerName = row["Manufacturer"].ToString().Trim(); ;
                        detailitem.setManufacturerPartID = row["Mfr-Part#"].ToString().Trim(); ;
                        //detailitem.setExtrinsicPartID = item.Attributes["SpecialSKU"].Value;

                        detailitem.setSubTotal = subTotal.ToString();
                        detailitem.setGrossAmount = subTotal.ToString();
                        detailitem.setNetAmount = subTotal.ToString();

                        al.Add(detailitem);

                        count++;
                    }
                }

            }
            else
            {
                foreach (XmlNode item in items)
                {
                    cxmlInvoiceDetailItem detailitem = new cxmlInvoiceDetailItem();

                    detailitem.setInvoiceLineNumber = item.Attributes["LineItem"].Value;
                    detailitem.setQty = item.Attributes["Quantity"].Value;
                    detailitem.setUnitPrice = item.Attributes["Price"].Value;
                    detailitem.setSupplierPartID = item.Attributes["DpNo"].Value;
                    detailitem.setDescription = item.Attributes["Name"].Value;
                    detailitem.setManufacturerName = item.Attributes["Manufacturer"].Value;
                    detailitem.setManufacturerPartID = item.Attributes["MfgPartNo"].Value;
                    //detailitem.setExtrinsicPartID = item.Attributes["SpecialSKU"].Value;

                    Double qty;
                    Double price;
                    Double subTotal;

                    if (!double.TryParse(item.Attributes["Quantity"].Value, out qty)) { qty = 0; }
                    if (!double.TryParse(item.Attributes["Price"].Value, out price)) { price = 0; }

                    subTotal = price * qty;

                    detailitem.setSubTotal = subTotal.ToString();
                    detailitem.setGrossAmount = subTotal.ToString();
                    detailitem.setNetAmount = subTotal.ToString();

                    al.Add(detailitem);

                }
            }

            return al;
        }

        //public static String getMfgFromPO(FileInvoiceDetails InvDetails, String orderNumber, ref String LineNum)
        //{
        //        return getMfgFromPO(InvDetails, orderNumber, ref LineNum, orderNumber.StartsWith("R")? true:false);
        //}

        public static String getMfgFromPO(FileInvoiceDetails InvDetails, String orderNumber, ref String LineNum)
        {
            String mfgNo = InvDetails.Manufacturer.ITEM_NO;
            String partID = InvDetails.Detail.ITEM_NO;
            bool isBD = orderNumber.StartsWith("R") ? true : false;
            try
            {
                Decimal unitPrice = Convert.ToDecimal(InvDetails.Detail.UNIT_PRICE);
                String Desc = InvDetails.Detail.DESCRIPTION.Trim();
                DataSet ds;
                String orderXml;
                ds = (isBD ? getBDPoCxml(orderNumber.Substring(0, 8), false) : getOpstrackPoCxml(orderNumber.Substring(1, 7)));
                if (ds.Tables.Count == 0 && isBD)
                    ds = getBDPoCxml(orderNumber.Substring(0, 8), true);
                orderXml = (isBD ? ds.Tables[0].Rows[0]["Request_Data"].ToString() : ds.Tables[0].Rows[0]["XmlStr"].ToString());
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(orderXml);
                //XmlNodeList xNodes = xmlDoc.SelectNodes("//OrderRequest/ItemOut/ItemDetail");
                XmlNodeList xNodes = xmlDoc.SelectNodes("//OrderRequest/ItemOut");
                int count = xmlDoc.SelectNodes("//OrderRequest/ItemOut/ItemDetail/UnitPrice/Money[. = " + unitPrice.ToString() + "]").Count;
                foreach (XmlNode node in xNodes)
                {
                    String origPartID = node.SelectSingleNode("ItemID/SupplierPartID").InnerXml;
                    Decimal origUnitPrice = Convert.ToDecimal(node.SelectSingleNode("ItemDetail/UnitPrice/Money").InnerXml); //Convert.ToDecimal(node.Attributes["UnitPrice/Money"].Value);
                    String origDesc = node.SelectSingleNode("ItemDetail/Description").InnerXml;
                    if (!isBD)
                    {
                        String origMfgNo = node.SelectSingleNode("ItemDetail/ManufacturerPartID").InnerXml;
                        if ((mfgNo.Contains(origMfgNo.Trim()) || origMfgNo.Trim().Contains(mfgNo.Trim())) && unitPrice == origUnitPrice)
                        {
                            try
                            {
                                LineNum = node.Attributes["lineNumber"].Value;
                            }
                            catch { }
                            mfgNo = origMfgNo.Trim();
                            break;
                        }
                        else
                        {
                            if (((origDesc.Trim() == Desc || Desc.Contains(origMfgNo.Trim())) && unitPrice == origUnitPrice) || (unitPrice == origUnitPrice && count == 1))
                            {
                                try
                                {
                                    LineNum = node.Attributes["lineNumber"].Value;
                                }
                                catch { }
                                mfgNo = origMfgNo.Trim();
                                break;
                            }
                            else
                            {
                                if (origDesc.Contains("Electronic Waste Fee") && Desc.Contains("CA EWASTE RECYCLING FEE") && unitPrice == origUnitPrice)
                                {
                                    try
                                    {
                                        LineNum = node.Attributes["lineNumber"].Value;
                                    }
                                    catch { }
                                    mfgNo = origMfgNo.Trim();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (partID.Length == 0 && unitPrice == origUnitPrice)
                        {
                            partID = origPartID;
                            InvDetails.Detail.ITEM_NO = origPartID;

                        }
                        if ((partID.ToLower().Contains(origPartID.ToLower().Trim()) || origPartID.ToLower().Trim().Contains(partID.ToLower().Trim())) && unitPrice == origUnitPrice)
                        {
                            try
                            {
                                LineNum = node.Attributes["lineNumber"].Value;
                            }
                            catch { }
                            mfgNo = mfgNo.Trim();
                            break;
                        }
                        else
                        {
                            if (origDesc.Contains("Electronic Waste Fee") && Desc.Contains("CA EWASTE RECYCLING FEE") && unitPrice == origUnitPrice)
                            {
                                try
                                {
                                    LineNum = node.Attributes["lineNumber"].Value;
                                }
                                catch { }
                                mfgNo = mfgNo.Trim();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in matching mfgNo");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in matching mfgNo - " + ex.Message, Logger.OperationLogFileName);
                throw ex;
            }
            return mfgNo;
        }

        public static ArrayList getDetailItems(InvoiceStructure invoiceStructure)
        {
            ArrayList al = new ArrayList();


            int count = 1; //Changed from 0 to 1. Required by AMR for their new e-invoicing link. 11/13/2015 by Gilbert.
            foreach (FileInvoiceDetails invoiceDetails in invoiceStructure.Details)
            {
                String origMfg = "";
                String origLineNum = "";
                if (invoiceStructure.Header.INVHDR_ORDER_NO.StartsWith("O9") || invoiceStructure.Header.INVHDR_ORDER_NO.StartsWith("R"))
                    origMfg = getMfgFromPO(invoiceDetails, invoiceStructure.Header.INVHDR_ORDER_NO, ref origLineNum);
                cxmlInvoiceDetailItem detailitem = new cxmlInvoiceDetailItem();

                detailitem.setInvoiceLineNumber = (origLineNum == "" ? (invoiceStructure.Header.INVHDR_ORDER_NO.StartsWith("O9") ? origLineNum : count.ToString()) : origLineNum);
                if (invoiceStructure.Header.INVHDR_TYPE == InvoiceType.Credit)
                    detailitem.setQty = invoiceDetails.Detail.Qty_Shipped;//this is the field where actual returned item quantity is located.
                else
                    detailitem.setQty = invoiceDetails.Detail.QTY_Ordered;
                detailitem.setUnitPrice = invoiceDetails.Detail.UNIT_PRICE;
                //work item#45 - use ManufacturerPartID if from opstrack. 6/4/2015
                if (invoiceStructure.Header.INVHDR_ORDER_NO.StartsWith("O9"))
                    detailitem.setSupplierPartID = origMfg;
                else
                    detailitem.setSupplierPartID = RemoveLeadingZeroes(invoiceDetails.Detail.ITEM_NO);
                //end work item#45
                detailitem.setDescription = invoiceDetails.Detail.DESCRIPTION;
                detailitem.setManufacturerName = "";
                if (invoiceStructure.Header.INVHDR_ORDER_NO.StartsWith("O9"))
                    detailitem.setManufacturerPartID = origMfg;
                else
                    detailitem.setManufacturerPartID = invoiceDetails.Manufacturer.ITEM_NO;
                detailitem.setExtrinsicPartID = invoiceDetails.Detail.REF_ITEM_NO;

                Double qty;
                Double price;
                Double subTotal;
                if (invoiceStructure.Header.INVHDR_TYPE == InvoiceType.Credit)
                {
                    if (!double.TryParse(invoiceDetails.Detail.Qty_Shipped, out qty)) { qty = 0; }
                }
                else
                {
                    if (!double.TryParse(invoiceDetails.Detail.QTY_Ordered, out qty)) { qty = 0; }
                }
                if (!double.TryParse(invoiceDetails.Detail.UNIT_PRICE, out price)) { price = 0; }

                if (invoiceStructure.Header.INVHDR_TYPE == InvoiceType.Credit)
                {
                    qty = qty * -1;

                }

                subTotal = price * qty;

                detailitem.setQty = qty.ToString();
                detailitem.setSubTotal = subTotal.ToString();
                detailitem.setGrossAmount = subTotal.ToString();
                detailitem.setNetAmount = subTotal.ToString();

                al.Add(detailitem);

                count++;
            }

            al.Sort(new CustomComparer());
            return al;
        }

        public class CustomComparer : IComparer
        {
            Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);

            public int Compare(object x, object y)
            {
                cxmlInvoiceDetailItem detailx = new cxmlInvoiceDetailItem();
                cxmlInvoiceDetailItem detaily = new cxmlInvoiceDetailItem();
                detailx = (cxmlInvoiceDetailItem)x;
                detaily = (cxmlInvoiceDetailItem)y;
                return _comparer.Compare(detailx.LineNum, detaily.LineNum);
            }
        }

        public static cxmlContact getContactAddress(cxmlContactRole role)
        {
            cxmlContact contact = new cxmlContact(role);
            XmlNode addressNode;
            string type = "ShipTo";

            if (role.Equals(cxmlContactRole.billTo)) { type = "BillTo"; }
            if (role.Equals(cxmlContactRole.shipFrom)) { type = "ShipFrom"; }
            //if (role.Equals(cxmlContactRole.remitTo)) { type = "ShipTo"; }
            //if (role.Equals(cxmlContactRole.soldTo)) { type = "ShipTo"; }
            //if (role.Equals(cxmlContactRole.shipTo)) { type = "ShipTo"; }

            addressNode = xorders.SelectSingleNode("//Address[@Type='" + type + "']");

            if (useDBorder)
            {
                if (dsAMROrders.Tables.Count > 1 && dsAMROrders.Tables[1].Rows.Count > 0)
                {

                    foreach (DataRow row in dsAMROrders.Tables[1].Rows)
                    {
                        if ((role.Equals(cxmlContactRole.billTo) || role.Equals(cxmlContactRole.soldTo) || role.Equals(cxmlContactRole.remitTo)) && row["Record-Set"].ToString().Contains("Bill To"))
                        {
                            contact.setName = row["Company"].ToString().Trim();
                            contact.AddStreet(row["Address"].ToString().Trim());
                            contact.AddStreet(row["Ref1"].ToString().Trim());
                            contact.AddStreet(row["Ref2"].ToString().Trim());

                            string city = row["City/State/Zip"].ToString().Split(",".ToCharArray())[0].Trim();
                            string state = row["City/State/Zip"].ToString().Split(",".ToCharArray())[1].Split(" ".ToCharArray())[0].Trim();
                            string zip = row["City/State/Zip"].ToString().Split(",".ToCharArray())[1].Split(" ".ToCharArray())[1].Trim();

                            contact.setCity = city;
                            contact.setState = state;
                            contact.setPostalCode = zip;
                        }
                        if (role.Equals(cxmlContactRole.shipTo) && row["Record-Set"].ToString().Contains("Ship To"))
                        {
                            contact.setName = row["Company"].ToString().Trim();
                            contact.AddStreet(row["Address"].ToString().Trim());
                            contact.AddStreet(row["Ref1"].ToString().Trim());
                            contact.AddStreet(row["Ref2"].ToString().Trim());

                            string city = row["City/State/Zip"].ToString().Split(",".ToCharArray())[0].Trim();
                            string state = row["City/State/Zip"].ToString().Split(",".ToCharArray())[1].Split(" ".ToCharArray())[0].Trim();
                            string zip = row["City/State/Zip"].ToString().Split(",".ToCharArray())[1].Split(" ".ToCharArray())[1].Trim();

                            contact.setCity = city;
                            contact.setState = state;
                            contact.setPostalCode = zip;
                        }
                    }


                }
            }
            else
            {

                if (addressNode != null)
                {

                    XmlNode nName = addressNode.SelectSingleNode("ContactCompany");
                    XmlNode nStreet1 = addressNode.SelectSingleNode("AddressOne");
                    XmlNode nStreet2 = addressNode.SelectSingleNode("AddressTwo");
                    XmlNode nStreet3 = addressNode.SelectSingleNode("AddressThree");
                    XmlNode nCity = addressNode.SelectSingleNode("City");
                    XmlNode nState = addressNode.SelectSingleNode("State");
                    XmlNode nPostalCode = addressNode.SelectSingleNode("Zip");


                    contact.setName = nName != null ? nName.InnerText : "";
                    contact.AddStreet(nStreet1 != null ? nStreet1.InnerText : "");
                    contact.AddStreet(nStreet2 != null ? nStreet2.InnerText : "");
                    contact.AddStreet(nStreet3 != null ? nStreet3.InnerText : "");
                    contact.setCity = nCity != null ? nCity.InnerText : "";
                    contact.setState = nState != null ? nState.InnerText : "";
                    contact.setPostalCode = nPostalCode != null ? nPostalCode.InnerText : "";

                }
            }

            return contact;
        }

        public static String getAMROrderStatus(String orderNo)
        {
            orderNumber = orderNo;
            try
            {
                DataSet ds;

                object[,] orderParams = { { "@order_no", SqlDbType.VarChar, ParameterDirection.Input, 50, null, null, orderNo } };
                ds = SqlAccess.ExecuteDataset(connOrderStat, CommandType.StoredProcedure, "usp_Order_Status", orderParams);




                return ds.Tables[0].Rows[0]["Order-Status"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public static string RemoveLeadingZeroes(String number)
        {
            string cleanedUp = number;

            cleanedUp = RemoveNonNumeric(cleanedUp);

            if (cleanedUp.Length > 0)
            {
                cleanedUp = Int32.Parse(cleanedUp).ToString();
            }

            return cleanedUp;
        }

        private static string RemoveNonNumeric(String number)
        {
            string numbers = "0123456789";
            string newNumber = "";

            if (number.Length > 0)
            {
                foreach (Char ltr in number)
                {
                    if (numbers.Contains(ltr.ToString()))
                    {
                        newNumber += ltr.ToString();
                    }
                }
            }

            return newNumber;
        }

        public static String ReplaceWithOriginalSKU(FileInvoiceDetails details, String orderNumber)
        {
            String sku = details.Detail.ITEM_NO;
            String retSku = details.Detail.ITEM_NO;
            String mfgNo = details.Manufacturer.ITEM_NO;
            String origSku = "";
            String origMfgNo = "";
            //
            try
            {
                DataSet ds = getAMROrderXml(orderNumber);
                String orderXml = ds.Tables[0].Rows[0]["OrderXml"].ToString();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(orderXml);

                XmlNodeList xNodes = xmlDoc.SelectNodes("//Cart/Items/Item");

                foreach (XmlNode node in xNodes)
                {
                    origMfgNo = node.Attributes["MfgPartNo"].Value;
                    origSku = node.Attributes["DpNo"].Value;

                    if (mfgNo.Contains(origMfgNo.Trim()))
                    {
                        if (sku.Equals(origSku.Trim()) == false)
                        {
                            retSku = origSku;


                            break;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in matching sku");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in matching sku - " + ex.Message, Logger.OperationLogFileName);

                throw ex;
            }

            return retSku;
        }
        //Added by Gilbert 6/13/2013. New logic in replacing virtual sku with mall sku.
        //This resolves the issue on the same virtual sku from different VW partners.
        public static DataSet GetVWandMallItemDetails(String orderNo)
        {
            DataSet ds = new DataSet();

            try
            {

                String sql = "select osh.order_no,osh.edp_nos,osh.Line_nos,osh.item_qtys,im1.item_no as 'Shipped_Item',im1.description as 'Shipped Item Description'";
                sql += ",case when im1.status in ('T1','S1') then 'VW Item' else 'Mall Item' end as 'Item_Type',sm.macs_edp_no as 'Related Mall EDP' ";
                sql += ",im2.Item_no as 'Related_Mall_Item',im2.description as 'Related_Mall_Item_Description' ";
                sql += "from isb..order_sub_head osh (nolock) ";
                sql += "inner join isb..item_mast im1 (nolock) on im1.edp_no = osh.edp_nos ";
                sql += "left outer join isb..sku_map sm (nolock) on sm.edp_no = osh.edp_nos ";
                sql += "left outer join isb..item_mast im2 (nolock) on im2.edp_no = sm.macs_edp_no ";
                sql += "where osh.order_no = '" + orderNo + "' ";
                sql += "order by osh.Line_nos";

                ds = SqlAccess.ExecuteDataset(connOrderStat, CommandType.Text, sql);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting PCMall SKU");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in getting PCMall SKU - " + ex.Message, Logger.OperationLogFileName);
                throw ex;
            }

            return ds;
        }
        //end Gilbert
        public static DataSet GetPCMallCurrentSKU(String replacementSKU)
        {
            DataSet ds = new DataSet();

            try
            {

                String sql = "declare @edp int;";
                sql += "exec usp_TP_DerefItem '" + replacementSKU + "', @edp out;";
                sql += "exec usp_TP_GetMallHead @edp out, 0;";
                sql += "exec usp_TP_GetTPBanner @edp;";

                ds = SqlAccess.ExecuteDataset(connTPOP, CommandType.Text, sql);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting PCMall SKU");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in getting PCMall SKU - " + ex.Message, Logger.OperationLogFileName);
                throw ex;
            }

            return ds;
        }

        //Added by Gilbert to get AddressID value from PO cXML in BD. This is a requirement from ARAMARK. 3/30/2017
        public static void getAddressIDs(String OrderID, ref String BillToAddressID, ref String ShipToAddressID)
        {
            try
            {
                DataSet ds = getBDPoCxml(OrderID.Substring(0, 8), false);
                if (ds.Tables.Count == 0)
                    ds = getBDPoCxml(OrderID.Substring(0, 8), true);
                String orderXml = ds.Tables[0].Rows[0]["Request_Data"].ToString();
                XDocument doc = XDocument.Parse(orderXml);
                try
                {
                    BillToAddressID = doc.Descendants("BillTo").FirstOrDefault().Element("Address").Attribute("addressID").Value;
                }
                catch (Exception ex)
                { throw ex; }
                try
                {
                    ShipToAddressID = doc.Descendants("ShipTo").FirstOrDefault().Element("Address").Attribute("addressID").Value;
                }
                catch (Exception ex)
                { throw ex; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getAddressIDs");
                util.CreateStreamWriterFile(DateTime.Now.ToString() + " - " + "Error in getAddressIDs - " + ex.Message, Logger.OperationLogFileName);
            }
        }
        //end Gilbert

    }


    class IncidentCheckingData
    {

        String connCAP = ConfigurationManager.ConnectionStrings["cn_cap"].ToString();
        String connSTG = ConfigurationManager.ConnectionStrings["cn_stg"].ToString();

        public DataSet verifyInAssurrantOrderTable(String incidentId, String sequenceId)
        {

            DataSet ds;

            try
            {


                String sql = "select * from assurant_orders (nolock) where incident_id = " + incidentId + " and sequence_no = " + sequenceId + ";";

                ds = SqlAccess.ExecuteDataset(connCAP, CommandType.Text, sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }

        public DataSet GetOrderHeaderStatus(String order_number)
        {
            DataSet ds;
            String ordNum = "J" + order_number;

            try
            {


                object[,] orderParams = { { "@order_no", SqlDbType.VarChar, ParameterDirection.Input, 50, null, null, ordNum } };
                ds = SqlAccess.ExecuteDataset(connSTG, CommandType.StoredProcedure, "usp_Get_Order_Status_List", orderParams);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }

    }
}
