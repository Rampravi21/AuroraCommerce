using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AuroraCommerceApp.Model;

namespace AuroraCommerceApp.BAL
{
    public class DBObjects
    {
        #region Global Declarations
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string message = string.Empty;
        static public string GetConnectionString()
        {

            return ConfigurationManager.AppSettings["OracleMCRMDbConnection"];
        }
        #endregion



        public string SaveOrders(Responses objorderresponse, string fascia)
        {
            // Responses objorder = new Responses();
            string connectionString = GetConnectionString();
            string Result = "";
            try
            {


                //foreach (var item in objorderresponse.orderList)
                //{

                string InsertqueryOrders = @"insert into MCRM_GENERAL.MCRM_AURORA_ORDERDATA(OrderID,CustomerID,OrderStatus,PaymentType,
                                                CourierName,ShippingType,TrackingNumber,ChargedCurrency,Currency,ExchangeRate,TaxRate,ShippingSku,ShippingCost,
                                                ShippingTax,CustomShippingCost,CustomShippingLabel,OrderTotal,OrderSubtotal,OrderTax,CouponCode,CouponDiscount,OrderDiscount,
                                                PriceBreakDiscount,LoyaltyDiscount,TotalDiscount,InvoiceNotes,CustomerNotes,CustomerSelectedDlryDt,DateDlryEstimate,DateShipped,
                                                DateCreated,Fascia,LASTUPDATED)
                                                values(:OrderID,:CustomerID,:OrderStatus,:PaymentType,:CourierName,:ShippingType,:TrackingNumber,:ChargedCurrency,:Currency,:ExchangeRate,:TaxRate,:ShippingSku,:ShippingCost,
                                                 :ShippingTax,:CustomShippingCost,:CustomShippingLabel,:OrderTotal,:OrderSubtotal,:OrderTax,:CouponCode,:CouponDiscount,:OrderDiscount,
                                                 :PriceBreakDiscount,:LoyaltyDiscount,:TotalDiscount,:InvoiceNotes,:CustomerNotes,:CustomerSelectedDlryDt,:DateDlryEstimate,:DateShipped,
                                                 :DateCreated,:Fascia,:LASTUPDATED)"; 
               
                try
                {
                    using (OracleConnection connection = new OracleConnection())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        OracleCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.BindByName = true;
                        cmd.ArrayBindCount = objorderresponse.orderList.Count;
                        cmd.CommandText = InsertqueryOrders;
                        cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.OrderID).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CustomerID", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CustomerID).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":OrderStatus", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.OrderStatus).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":PaymentType", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.PaymentType).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CourierName", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CourierName).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":ShippingType", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.ShippingType).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":TrackingNumber", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.TrackingNumber).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":ChargedCurrency", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.ChargedCurrency).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":Currency", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.Currency).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":ExchangeRate", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.ExchangeRate).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":TaxRate", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.TaxRate).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":ShippingSku", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.ShippingSku).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":ShippingCost", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.ShippingCost).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":ShippingTax", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.ShippingTax).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CustomShippingCost", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CustomShippingCost).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CustomShippingLabel", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CustomShippingLabel).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":OrderTotal", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.OrderTotal).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":OrderSubtotal", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.OrderSubtotal).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":OrderTax", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.OrderTax).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CouponCode", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CouponCode).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CouponDiscount", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CouponDiscount).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":OrderDiscount", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.OrderDiscount).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":PriceBreakDiscount", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.PriceBreakDiscount).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":LoyaltyDiscount", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.LoyaltyDiscount).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":TotalDiscount", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.TotalDiscount).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":InvoiceNotes", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.InvoiceNotes).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CustomerNotes", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CustomerNotes).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":CustomerSelectedDlryDt", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.CustomerSelectedDeliveryDate).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":DateDlryEstimate", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.DateCreated).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":DateShipped", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.DateShipped).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":DateCreated", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.DateCreated).ToArray(), ParameterDirection.Input));
                       
                        cmd.Parameters.Add(new OracleParameter(":Fascia", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.Fasica).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":LASTUPDATED", OracleDbType.Varchar2, objorderresponse.orderList.Select(t => t.LastUpdated).ToArray(), ParameterDirection.Input));
                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated == 0)
                        {
                            connection.Dispose();
                        }
                        else if (rowsUpdated > 1)
                        {
                            //Result = "Record's are inserted successfully!!";
                            //message += string.Format("function: -> SaveOrders: {0}", Result);
                            //message += Environment.NewLine;
                            log.Info(" Orders " + rowsUpdated + " Record's are inserted successfully!!");

                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Info(string.Format("Exception in function: Order -> Update: {0}", ex.GetBaseException().Message));
                    Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                }



                


                //}
                string InsertQueryAddress = @"insert into MCRM_GENERAL.MCRM_AURORA_ORDERADDRESS(OrderID,Address_AddressId, Address_CustomerID, Address_StorageType, Address_AddressType,
                                                  Address_EmailAddress, Address_OptOut, Address_Gender, Address_CompanyName, Address_Title, Address_FirstName, Address_AddressLine1,
                                                  Address_AddressLine2, Address_Town, Address_County, Address_PostCode, Address_CountryId,Address_PhNo,Address_Mobile) 
                                                  values( :OrderID,:Address_AddressId,:Address_CustomerID,:Address_StorageType,:Address_AddressType,:Address_EmailAddress,:Address_OptOut,:Address_Gender,:Address_CompanyName,:Address_Title,:Address_FirstName,:Address_AddressLine1,
                                                 :Address_AddressLine2,:Address_Town,:Address_Country,:Address_PostCode,:Address_CountryId,:Address_PhNo,:Address_Mobile)";



                string InsertQueryItems = @"insert into MCRM_GENERAL.MCRM_AURORA_ITEMS(OrderID,Item_OrderItemId, Item_ProductID, Item_ProductReference, Item_ProductEAN, Item_VariationID, Item_BundleId,
                                               Item_VariationEAN, Item_Price, Item_Tax, Item_Discount, Item_TaxRate, Item_Quantity, Item_QtyReturned, Item_LineOrder, Item_AdnlFieldName,
                                               Item_AdnlFieldValue, Item_StatusCode, Item_ReasonCode) 
                                               values(:OrderID,:Item_OrderItemId,:Item_ProductID,:Item_ProductReference,:Item_ProductEAN,:Item_VariationID,:Item_BundleId,
                                               :Item_VariationEAN,:Item_Price,:Item_Tax,:Item_Discount,:Item_TaxRate,:Item_Quantity,:Item_QtyReturned,:Item_LineOrder,:Item_AdnlFieldName,
                                               :Item_AdnlFieldValue,:Item_StatusCode,:Item_ReasonCode)";

                string InsertTrans = @"insert into MCRM_GENERAL.MCRM_AURORA_TRANSACTIONS(OrderID,Trans_TransId,Trans_Amount,Trans_Display,Trans_NameOnCard,Trans_CardExpiry,Trans_CardNumber,Trans_CardType,
                                                 Trans_StatusDetails,Trans_Status,Trans_Provider,Trans_ProviderTaxCode,Trans_ProviderTxID,Trans_ProviderSecurityKey,Trans_ProviderAuthNumber,Trans_ProviderVendorTxCode,
                                                 Trans_ProviderAVSCV2,Trans_ProviderPostCodeResult,Trans_PoviderAddressResult,Trans_ProviderCV2Result,Trans_ProviderSecureStatus,Trans_DateCreated) 
                                                 values(:OrderId,:Trans_TransId,:Trans_Amount,:Trans_Display,:Trans_NameOnCard,:Trans_CardExpiry,:Trans_CardNumber,:Trans_CardType,
                                                 :Trans_StatusDetails,:Trans_Status,:Trans_Provider,:Trans_ProviderTaxCode,:Trans_ProviderTxID,:Trans_ProviderSecurityKey,:Trans_ProviderAuthNumber,:Trans_ProviderVendorTxCode,
                                                 :Trans_ProviderAVSCV2,:Trans_ProviderPostCodeResult,:Trans_PoviderAddressResult,:Trans_ProviderCV2Result,:Trans_ProviderSecureStatus,:Trans_DateCreated)";

                string InsertFraudResults = @"insert into MCRM_GENERAL.MCRM_AURORA_FRAUDRERSULTS(OrderId,FraudResults_Action,FraudResults_Score,FraudResults_MID,FraudResults_DtCreated) 
                                                 values(:OrderId,:FraudResults_Action,:FraudResults_Score,:FraudResults_MID,:FraudResults_DtCreated)";

                string InsertAdnlFields = @"insert into MCRM_GENERAL.MCRM_AURORA_ORDERADDNFIELDS(OrderId,Adnl_FieldId,AdnlFields_FieldName,AdnlFields_Type) 
                                                 values(:OrderId,:Adnl_FieldId,:AdnlFields_FieldName,:AdnlFields_Type)";

                string InsertCountry = @"insert into MCRM_GENERAL.MCRM_AURORA_COUNTRY(ADDRESS_COUNTRYID,ADDRESS_ISO,ADDRESS_NAME) 
                                                 values(:Address_CountryId,:Address_Iso,:Address_Name)";

                try
                {


                    foreach (var itemCountry in objorderresponse.ordercountrylist)
                    {
                        if (!CheckCountryExists(itemCountry.Name, itemCountry.ID))
                        {
                            using (OracleConnection connection = new OracleConnection())
                            {
                                connection.ConnectionString = connectionString;
                                connection.Open();
                                OracleCommand cmd = connection.CreateCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = InsertCountry;


                                cmd.Parameters.Add(new OracleParameter(":Address_CountryId", itemCountry.ID));
                                cmd.Parameters.Add(new OracleParameter(":Address_Iso", itemCountry.ISO));
                                cmd.Parameters.Add(new OracleParameter(":Address_Name", itemCountry.Name));

                                int rowsUpdated = cmd.ExecuteNonQuery();
                                if (rowsUpdated == 0)
                                {
                                    connection.Dispose();
                                }
                                else if (rowsUpdated > 1)
                                {
                                    
                                    log.Info(itemCountry.Name + " Country is inserted successfully!!");

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Info(string.Format("Exception in function: Country -> Update: {0}", ex.GetBaseException().Message));
                    Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));

                }

                //foreach (var itemAdditionalField in objorderresponse.orderAdditionalFieldlist)
                //{

                try
                {


                    using (OracleConnection connection = new OracleConnection())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        OracleCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = InsertAdnlFields;
                        cmd.ArrayBindCount = objorderresponse.orderAdditionalFieldlist.Count;
                        cmd.BindByName = true;
                        cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, objorderresponse.orderAdditionalFieldlist.Select(t => t.OrderID).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":Adnl_FieldId", OracleDbType.Varchar2, objorderresponse.orderAdditionalFieldlist.Select(t => t.FieldID).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":AdnlFields_FieldName", OracleDbType.Varchar2, objorderresponse.orderAdditionalFieldlist.Select(t => t.FieldName).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":AdnlFields_Type", OracleDbType.Varchar2, objorderresponse.orderAdditionalFieldlist.Select(t => t.FieldValue).ToArray(), ParameterDirection.Input));

                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated == 0)
                        {
                            connection.Dispose();
                        }
                        else if (rowsUpdated > 1)
                        {
                            
                            log.Info("AdditionalField's " + rowsUpdated + " are inserted successfully!!");

                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Info(string.Format("Exception in function: AdditionalField -> Update: {0}", ex.GetBaseException().Message));
                    Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                    throw;
                }
                //}
                try
                {

                    //foreach (var itemFraud in objorderresponse.orderFraudResultsResultlist)
                    //{


                    using (OracleConnection connection = new OracleConnection())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        OracleCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = InsertFraudResults;
                        cmd.BindByName = true;
                        cmd.ArrayBindCount = objorderresponse.orderFraudResultsResultlist.Count;
                        cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, objorderresponse.orderFraudResultsResultlist.Select(t => t.OrderID).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":FraudResults_Action", OracleDbType.Varchar2, objorderresponse.orderFraudResultsResultlist.Select(t => t.Action).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":FraudResults_Score", OracleDbType.Varchar2, objorderresponse.orderFraudResultsResultlist.Select(t => t.Score).ToArray(), ParameterDirection.Input)); ;
                        cmd.Parameters.Add(new OracleParameter(":FraudResults_MID", OracleDbType.Varchar2, objorderresponse.orderFraudResultsResultlist.Select(t => t.MID).ToArray(), ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter(":FraudResults_DtCreated", OracleDbType.Varchar2, objorderresponse.orderFraudResultsResultlist.Select(t => t.DateCreated).ToArray(), ParameterDirection.Input));

                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated == 0)
                        {
                            connection.Dispose();
                        }
                        else if (rowsUpdated > 1)
                        {

                            log.Info("Fraud Record's " + rowsUpdated + " are inserted successfully!!");
                        }
                    }
                    //}

                   


                }
                catch (Exception ex)
                {
                    log.Info(string.Format("Exception in function: -> Fraud Result: {0}", ex.GetBaseException().Message));
                    Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                }

                try
                {


                    string sss = "";
                    try
                    {


                        foreach (var itemadder in objorderresponse.orderAddreList)
                        {
                            sss = itemadder.OrderID;
                            using (OracleConnection connection = new OracleConnection())
                            {
                                //string CountryID = getCounteryID(itemadder.Country.Name, itemadder.Country.ID);


                                connection.ConnectionString = connectionString;
                                connection.Open();
                                OracleCommand cmd = connection.CreateCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = InsertQueryAddress;
                                //cmd.BindByName = true;
                                //cmd.ArrayBindCount = objorderresponse.orderAddreList.Count;

                                cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, itemadder.OrderID, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_AddressId", OracleDbType.Varchar2, itemadder.AddressID, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_CustomerID", OracleDbType.Varchar2, itemadder.CustomerID, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_StorageType", OracleDbType.Varchar2, itemadder.StorageType, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_AddressType", OracleDbType.Varchar2, itemadder.AddressType, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_EmailAddress", OracleDbType.Varchar2, itemadder.EmailAddress, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_OptOut", OracleDbType.Varchar2, itemadder.OptOut, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_Gender", OracleDbType.Varchar2, itemadder.Gender, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_CompanyName", OracleDbType.Varchar2, itemadder.CompanyName, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_Title", OracleDbType.Varchar2, itemadder.Title, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_FirstName", OracleDbType.Varchar2, itemadder.FirstName, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_AddressLine1", OracleDbType.Varchar2, itemadder.AddressLine1, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_AddressLine2", OracleDbType.Varchar2, itemadder.AddressLine2, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_Town", OracleDbType.Varchar2, itemadder.Town, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_County", OracleDbType.Varchar2, itemadder.County, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_PostCode", OracleDbType.Varchar2, itemadder.PostCode, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_CountryId", OracleDbType.Varchar2, itemadder.Country.ID, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_PhNo", OracleDbType.Varchar2, itemadder.PhoneNumber, ParameterDirection.Input));
                                cmd.Parameters.Add(new OracleParameter(":Address_Mobile", OracleDbType.Varchar2, itemadder.MobileNumber, ParameterDirection.Input));
                                int rowsUpdated = cmd.ExecuteNonQuery();
                                if (rowsUpdated == 0)
                                {
                                    connection.Dispose();
                                }
                                else if (rowsUpdated == 1)
                                {


                                }
                            }
                        }

                        //catch (Exception)
                        //{
                        //    string ssssssss = sss;
                        //    throw;
                        //}
                        //using (OracleConnection connection = new OracleConnection())
                        //{
                        //    //string CountryID = getCounteryID(itemadder.Country.Name, itemadder.Country.ID);
                        //    try
                        //    {



                        //        connection.ConnectionString = connectionString;
                        //        connection.Open();
                        //        OracleCommand cmd = connection.CreateCommand();
                        //        cmd.CommandType = CommandType.Text;
                        //        cmd.CommandText = InsertQueryAddress;
                        //        cmd.BindByName = true;
                        //        cmd.ArrayBindCount = objorderresponse.orderAddreList.ToList().Count;

                        //        cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.OrderID).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_AddressId", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.AddressID).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_CustomerID", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.CustomerID).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_StorageType", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.StorageType).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_AddressType", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.AddressType).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_EmailAddress", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.EmailAddress).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_OptOut", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.OptOut).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_Gender", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.Gender).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_CompanyName", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.CompanyName).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_Title", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.Title).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_FirstName", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.FirstName).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_AddressLine1", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.AddressLine1).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_AddressLine2", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.AddressLine2).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_Town", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.Town).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_County", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.County).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_PostCode", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.PostCode).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_CountryId", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.Country.ID).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_PhNo", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.PhoneNumber).ToArray(), ParameterDirection.Input));
                        //        cmd.Parameters.Add(new OracleParameter(":Address_Mobile", OracleDbType.Varchar2, objorderresponse.orderAddreList.Select(t => t.MobileNumber).ToArray(), ParameterDirection.Input));
                        //        int rowsUpdated = cmd.ExecuteNonQuery();
                        //        if (rowsUpdated == 0)
                        //        {
                        //            connection.Dispose();
                        //        }
                        //        else if (rowsUpdated == 1)
                        //        {


                        //        }
                        //    }
                        //    catch (Exception ex)



                        //    {

                        //        throw;
                        //    }
                        //}
                        //}

                        //Result = "Address Record's are inserted successfully!!";
                        //message += string.Format("function: -> SaveOrders: {0}", Result);
                        //message += Environment.NewLine;
                        log.Info("Address Record's " + objorderresponse.orderAddreList.Count + " are inserted successfully!!");

                    }
                    catch (Exception ex)
                    {

                        log.Info(string.Format("Exception in function: -> Address Record's: {0}", ex.GetBaseException().Message));
                        Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                        throw;
                    }

                    try
                    {



                        //foreach (var orderitems in objorderresponse.orderItemList)
                        //{
                        using (OracleConnection connection = new OracleConnection())
                        {
                            connection.ConnectionString = connectionString;
                            connection.Open();
                            OracleCommand cmd = connection.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = InsertQueryItems;
                            cmd.ArrayBindCount = objorderresponse.orderItemList.Count;
                            cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.OrderID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_OrderItemId", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.OrderItemID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_ProductID", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.ProductID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_ProductReference", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.ProductReference).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_ProductEAN", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.ProductEAN).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_VariationID", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.VariationID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_BundleId", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.BundleID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_VariationEAN", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.VariationEAN).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_Price", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.Price).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_Tax", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.Tax).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_Discount", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.Discount).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_TaxRate", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.TaxRate).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_Quantity", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.Quantity).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_QtyReturned", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.QuantityReturned).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_LineOrder", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.LineOrder).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_AdnlFieldName", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.AdditionalFields.AdditionalField.FieldName).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_AdnlFieldValue", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.AdditionalFields.AdditionalField.FieldValue).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_StatusCode", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.LineStatus.StatusCode).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Item_ReasonCode", OracleDbType.Varchar2, objorderresponse.orderItemList.Select(t => t.LineStatus.ReasonCode).ToArray(), ParameterDirection.Input));

                            int rowsUpdated = cmd.ExecuteNonQuery();
                            if (rowsUpdated == 0)
                            {
                                connection.Dispose();
                            }
                            else if (rowsUpdated > 1)
                            {
                               
                                log.Info("Item Record's " + rowsUpdated + " are inserted successfully!!");

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Info(string.Format("Exception in function: -> Item Record's : {0}", ex.GetBaseException().Message));
                        Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));

                    }
                    //}
                    try
                    {
                        //foreach (var ordertrans in objorderresponse.orderTransList)
                        //{
                        using (OracleConnection connection = new OracleConnection())
                        {
                            connection.ConnectionString = connectionString;
                            connection.Open();
                            OracleCommand cmd = connection.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = InsertTrans;
                            cmd.ArrayBindCount = objorderresponse.orderTransList.Count;
                            cmd.Parameters.Add(new OracleParameter(":OrderId", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.OrderID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_TransId", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.TransactionID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_Amount", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.Amount).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_Display", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.Display).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_NameOnCard", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.NameOnCard).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_CardExpiry", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.CardExpiry).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_CardNumber", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.CardNumber).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_CardType", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.CardType).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_StatusDetails", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.StatusDetails).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_Status", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.Status).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_Provider", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.Provider).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderTaxCode", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderRelatedVendorTxCode).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderTxID", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderTxID).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderSecurityKey", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderSecurityKey).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderAuthNumber", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderAuthNumber).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderVendorTxCode", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderPostCodeResult).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderAVSCV2", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderAVSCV2).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderPostCodeResult", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderPostCodeResult).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_PoviderAddressResult", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderAddressResult).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderCV2Result", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.ProviderCV2Result).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_ProviderSecureStatus", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.Provider3DSecureStatus).ToArray(), ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter(":Trans_DateCreated", OracleDbType.Varchar2, objorderresponse.orderTransList.Select(t => t.DateCreated).ToArray(), ParameterDirection.Input));

                            int rowsUpdated = cmd.ExecuteNonQuery();
                            if (rowsUpdated == 0)
                            {
                                connection.Dispose();
                            }
                            else if (rowsUpdated > 1)
                            {
                                // Result = "Trans Record's are inserted successfully!!";
                                //message += string.Format("function: -> SaveOrders: {0}", Result);
                                //message += Environment.NewLine;
                                log.Info("Trans Record's " + rowsUpdated + " are inserted successfully!!");

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Info(string.Format("Exception in function: -> TransList : {0}", ex.GetBaseException().Message));
                        Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));

                    }
                    //}


                }
                catch (Exception ex)
                {
                    message += string.Format("Exception in function: -> : {0}", ex.GetBaseException().Message);
                    message += Environment.NewLine;
                    log.Info(message);
                    Result = ex.Message;

                }
                //}


            }
            catch (Exception ex)
            {
                message += string.Format("Exception in function: -> : {0}", ex.GetBaseException().Message);
                message += Environment.NewLine;
                log.Info(message);
                Result = ex.Message;

            }
            return Result;
        }
        private string getCounteryID(string CountryName, string CountryID)
        {
            try
            {
                string connectionString = GetConnectionString();
                using (OracleConnection connection = new OracleConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Address_CountryId FROM MCRM_GENERAL.MCRM_AURORA_Country WHERE Address_Name= '" + CountryName + "' and Address_CountryId= " + CountryID;

                    int rowsUpdated = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                    if (rowsUpdated == 0)
                    {
                        connection.Dispose();
                        log.Info(CountryName + "not exists");
                        return rowsUpdated.ToString();
                    }
                    else if (rowsUpdated > 0)
                    {

                        //Result = "Record's are inserted successfully!!";
                        message += string.Format("function: -> SaveOrders: {0}", "");
                        message += Environment.NewLine;
                        log.Info(CountryName + "already exists");
                        return rowsUpdated.ToString();


                    }
                }
                return "0";

            }
            catch (Exception ex)
            {
                log.Info(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                return "0";
            }
        }

        private bool CheckCountryExists(string CountryName, string CountryID)
        {
            try
            {
                string connectionString = GetConnectionString();

                using (OracleConnection connection = new OracleConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT COUNT(*) FROM MCRM_GENERAL.MCRM_AURORA_Country WHERE Address_Name= '" + CountryName + "' and Address_CountryId= " + CountryID;

                    int rowsUpdated = cmd.ExecuteScalar() != null ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;
                    if (rowsUpdated == 0)
                    {
                        connection.Dispose();
                        return false;
                    }
                    else if (rowsUpdated > 0)
                    {
                        message += string.Format("function: -> SaveOrders: {0}", "");
                        message += Environment.NewLine;
                        return true;
                        //Result = "Record's are inserted successfully!!";
                       
                        //    log.Info(message);

                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                log.Info(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                return false;
            }

        }

        public List<AuroraAPI> GetAPIsList()
        {
            List<AuroraAPI> objauroraAPislist = new List<AuroraAPI>();

            try
            {
                using (OracleConnection connection = new OracleConnection())
                {
                    string sql = @"select * from  MCRM_GENERAL.AURORA_ORDERAPI where ACTIVE=1";
                    connection.ConnectionString = GetConnectionString();
                    // log.Info("Connection String: " + connection.ConnectionString);
                    //log.Info("Openning Connection");
                    connection.Open();
                    //log.Info("Connection Opened");

                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = sql;

                    OracleDataAdapter AuroraOrderAPIsAdapter = new OracleDataAdapter(command);
                    DataSet apislist = new DataSet("apislist");

                    //Fill the DataSet with data from 'APIs list' database table
                    AuroraOrderAPIsAdapter.Fill(apislist);

                    for (int i = 0; i < apislist.Tables[0].Rows.Count; i++)
                    {
                        AuroraAPI objapi = new AuroraAPI();
                        objapi.API_Name = apislist.Tables[0].Rows[i]["API_NAME"].ToString();
                        objapi.API_Url = apislist.Tables[0].Rows[i]["API_URL"].ToString();
                        objapi.API_TOKEN = apislist.Tables[0].Rows[i]["API_TOKEN"].ToString();
                     
                        objauroraAPislist.Add(objapi);
                    }

                }
                return objauroraAPislist;
            }
            catch (Exception ex)
            {

                message += string.Format("Exception in function: -> GetAPIsList: {0}", ex.InnerException + ex.Message + ex.ToString());
                message += Environment.NewLine;
                log.Info(message);
            }
            return objauroraAPislist;
        }
    }
}
