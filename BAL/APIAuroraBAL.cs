using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AuroraCommerceApp.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Net.Http;
using System.IO.Compression;
using System.Data;

namespace AuroraCommerceApp.BAL
{
    public class APIAuroraBAL
    {

        #region Global Declarations
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string message = string.Empty;
  
        DBObjects _dbobjects = new DBObjects();
        public string date = "";

        public static string responseStr = "";
        public static string compressText = "";
        public static string result = "";
        public static string destinationUrl = "";
        readonly XmlDocument receivedAppCastDocument = new XmlDocument();
        #endregion
        #region Run Reports
        public virtual void RunReport()
        {

            List<AuroraAPI> auroraapilist = _dbobjects.GetAPIsList();
            if (auroraapilist.Count > 0)
            {
                foreach (var item in auroraapilist)
                {
                    message += string.Format("Calling API : {0}", item.API_Name + " " + item.API_Url);
                    message += Environment.NewLine;
                    log.Info(message);

                    RunReportAPI(item.API_Name, item.API_Url, item.API_TOKEN);

                }


            }

        }

        public virtual void RunReportAPI(string apiName, string apiUrl, string token)
        {
            try
            {
                Console.WriteLine("Running RunReportAPI for API's");

                GetOrdersData(apiName, apiUrl, token);

                message += string.Format("End ->:{0}", DateTime.Now);
                message += Environment.NewLine;
                log.Info(message);
                Console.WriteLine(message);
            }
            catch (Exception Ex)
            {

                message += string.Format("Exception in function: -> Update: {0}", Ex.GetBaseException().Message);
                message += Environment.NewLine;
                log.Info(message);
                Console.WriteLine(message);
            }

        }


        public static string PrintXML(string xml)
        {
            string result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = System.Xml.Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
                mStream.Close();
                writer.Close();
            }
            catch (Exception ex)
            {

                log.Info(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
                Console.WriteLine(string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message));
            }



            return result;
        }
        public ResponsesResponseOrder GetOrdersData(string fascia, string api, string token)
        {

            string ss = "";
            try
            {

                //string token1 = fascia == "GoOutdoors" ? "goTOKEN" : fascia == "Blacks" ? "blTOKEN" : fascia == "Millets" ? "miTOKEN" : fascia == "UltimateOutdoors" ? "ulTOKEN" : "";
                //string api1 = fascia == "GoOutdoors" ? "goapi" : fascia == "Blacks" ? "blapi" : fascia == "Millets" ? "miapi" : fascia == "UltimateOutdoors" ? "ulapi" : "";

                // string xmldata = File.ReadAllText(ConfigurationManager.AppSettings["Xmlpath"]);

                //xmldata = xmldata.Replace("<AuthToken></AuthToken>", "<AuthToken>" + ConfigurationManager.AppSettings[token] + "</AuthToken>");

                string RequestXml = GetRequestXml(token, ConfigurationManager.AppSettings["Responelimit"], ConfigurationManager.AppSettings["Responeinterval"]);
                log.Info("API response limit" + ConfigurationManager.AppSettings["Responelimit"]);
                log.Info("API Respone interval" + ConfigurationManager.AppSettings["Responelimit"]);
                // Xml is to send request to Api Call 
                XmlDocument doc3 = new XmlDocument();
                doc3.LoadXml(RequestXml);
                string data = doc3.InnerXml;
                destinationUrl = ConfigurationManager.AppSettings[api];

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(data);
                request.Headers.Add(@"X-AURORA-REQUEST-METHODS:OrderGet");
                request.Headers.Add("X-AURORA-AUTH-TOKEN", "" + token + "");
                request.Method = "POST";
                request.ContentType = "application/json;encoding=utf-8";
                request.ContentLength = bytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpClientHandler handler = new HttpClientHandler();
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
                HttpClient _client = new HttpClient(handler);
                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    responseStr = new StreamReader(responseStream).ReadToEnd();
                    if (responseStr.Contains("content-id"))
                    {
                        compressText = responseStr.Substring(responseStr.LastIndexOf("_data>")).Replace("--MIMEBoundary--", "").Replace("_data>", "").Trim();
                    }
                    result = DecompressString(compressText);
                    //Console.WriteLine(result);
                }
                string outputfilename = "AuroraCommerceApp_" + fascia + "_" + DateTime.Now.ToString("dd-MM-yy-HH-mm-ss").Replace(":", " - ") + ".xml";
                //if (File.Exists(ConfigurationManager.AppSettings["Outputpath"].ToString() + "/output.xml"))
                //    File.Delete(ConfigurationManager.AppSettings["Outputpath"].ToString() + "/output.xml");
                File.AppendAllText(ConfigurationManager.AppSettings["Outputpath"].ToString() + outputfilename, PrintXML(result.ToString()));
                Serializer ser = new Serializer();
                string path = string.Empty;
                string xmlInputData = string.Empty;
                string xmlOutputData = string.Empty;
                path = result;
                // XMl is to read response and insert to database 
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result.ToString());
                XmlNodeList xmllistdata = doc.GetElementsByTagName("Data");
                Responses ordersdetails = new Responses();
                foreach (XmlNode orderNode in xmllistdata[0].ChildNodes)
                {
                    ResponsesResponseOrder orderData = new ResponsesResponseOrder();
                    ss = (orderNode["OrderID"].InnerText);
                    orderData.OrderID = !orderNode["OrderID"].IsEmpty ? (orderNode["OrderID"].InnerText) : "";
                    orderData.CustomerID = !orderNode["CustomerID"].IsEmpty ? (orderNode["CustomerID"].InnerText) : "";
                    orderData.OrderStatus = !orderNode["OrderStatus"].IsEmpty ? orderNode["OrderStatus"].InnerText : "";
                    orderData.PaymentType = !orderNode["PaymentType"].IsEmpty ? orderNode["PaymentType"].InnerText : "";
                    orderData.Fasica = fascia;
                    orderData.LastUpdated = DateTime.Now.ToString();

                    foreach (XmlNode adre in orderNode["Addresses"].ChildNodes)
                    {

                        if (adre.FirstChild != null)
                        {
                            ResponsesResponseOrderAddress resaddr = new ResponsesResponseOrderAddress();
                            resaddr.OrderID = orderData.OrderID;
                            resaddr.AddressID = !adre["AddressID"].IsEmpty ? (adre["AddressID"].InnerText) : "";
                            resaddr.CustomerID = !adre["CustomerID"].IsEmpty ? (adre["CustomerID"].InnerText) : "";
                            resaddr.StorageType = !adre["StorageType"].IsEmpty ? adre["StorageType"].InnerText : "";
                            resaddr.AddressType = !adre["AddressType"].IsEmpty ? adre["AddressType"].InnerText : "";
                            resaddr.EmailAddress = !adre["EmailAddress"].IsEmpty ? adre["EmailAddress"].InnerText : "";
                            resaddr.OptOut = !adre["OptOut"].IsEmpty ? adre["OptOut"].InnerText : "";
                            resaddr.Gender = !adre["Gender"].IsEmpty ? adre["Gender"].InnerText : "";
                            resaddr.CompanyName = !adre["CompanyName"].IsEmpty ? adre["CompanyName"].InnerText : "";
                            resaddr.Title = !adre["Title"].IsEmpty ? adre["Title"].InnerText : "";
                            resaddr.FirstName = !adre["FirstName"].IsEmpty ? adre["FirstName"].InnerText : "";
                            resaddr.LastName = !adre["LastName"].IsEmpty ? adre["LastName"].InnerText : "";
                            resaddr.AddressLine1 = !adre["AddressLine1"].IsEmpty ? adre["AddressLine1"].InnerText : "";
                            resaddr.AddressLine2 = !adre["AddressLine2"].IsEmpty ? adre["AddressLine2"].InnerText : "";
                            resaddr.Town = !adre["Town"].IsEmpty ? adre["Town"].InnerText : "";
                            resaddr.County = !adre["County"].IsEmpty ? adre["County"].InnerText : "";
                            resaddr.PostCode = !adre["PostCode"].IsEmpty ? adre["PostCode"].InnerText : "";
                            ResponsesResponseOrderAddressCountry resCountry = new ResponsesResponseOrderAddressCountry();
                            resaddr.Country = resCountry;
                            resaddr.Country.ID = adre.ChildNodes[16].ChildNodes[0] != null ? (adre.ChildNodes[16].ChildNodes[0].InnerText) : "";
                            resaddr.Country.ISO = adre.ChildNodes[16].ChildNodes[1] != null ? adre.ChildNodes[16].ChildNodes[1].InnerText : "";
                            resaddr.Country.Name = adre.ChildNodes[16].ChildNodes[2] != null ? adre.ChildNodes[16].ChildNodes[2].InnerText : "";
                            resaddr.PhoneNumber = !adre["PhoneNumber"].IsEmpty ? adre["PhoneNumber"].InnerText : "";
                            resaddr.MobileNumber = !adre["MobileNumber"].IsEmpty ? adre["MobileNumber"].InnerText : "";
                            orderData.Addresses = resaddr;
                            ordersdetails.orderAddreList.Add(resaddr);
                        }
                    }



                    orderData.CourierName = !orderNode["CourierName"].IsEmpty ? orderNode["CourierName"].InnerText : "";
                    orderData.ShippingType = !orderNode["ShippingType"].IsEmpty ? orderNode["ShippingType"].InnerText : "";
                    orderData.TrackingNumber = !orderNode["TrackingNumber"].IsEmpty ? orderNode["TrackingNumber"].InnerText : "";
                    orderData.ChargedCurrency = !orderNode["ChargedCurrency"].IsEmpty ? orderNode["ChargedCurrency"].InnerText : "";
                    orderData.ExchangeRate = !orderNode["ExchangeRate"].IsEmpty ? (orderNode["ExchangeRate"].InnerText) : "";
                    orderData.TaxRate = !orderNode["TaxRate"].IsEmpty ? (orderNode["TaxRate"].InnerText) : "";
                    orderData.ShippingSku = !orderNode["ShippingSku"].IsEmpty ? orderNode["ShippingSku"].InnerText : "";
                    orderData.ShippingCost = !orderNode["ShippingCost"].IsEmpty ? (orderNode["ShippingCost"].InnerText) : "";
                    orderData.ShippingTax = !orderNode["ShippingTax"].IsEmpty ? (orderNode["ShippingTax"].InnerText) : "";
                    orderData.CustomShippingCost = !orderNode["CustomShippingCost"].IsEmpty ? (orderNode["CustomShippingCost"].InnerText) : "";
                    orderData.CustomShippingLabel = !orderNode["CustomShippingLabel"].IsEmpty ? orderNode["CustomShippingLabel"].InnerText : "";
                    orderData.OrderTotal = !orderNode["OrderTotal"].IsEmpty ? (orderNode["OrderTotal"].InnerText) : "";
                    orderData.OrderSubtotal = !orderNode["OrderSubtotal"].IsEmpty ? (orderNode["OrderSubtotal"].InnerText) : "";
                    orderData.OrderTax = !orderNode["OrderTax"].IsEmpty ? (orderNode["OrderTax"].InnerText) : "";
                    orderData.CouponCode = !orderNode["CouponCode"].IsEmpty ? orderNode["CouponCode"].InnerText : "";
                    orderData.CouponDiscount = !orderNode["CouponDiscount"].IsEmpty ? (orderNode["CouponDiscount"].InnerText) : "";
                    orderData.OrderDiscount = !orderNode["OrderDiscount"].IsEmpty ? (orderNode["OrderDiscount"].InnerText) : "";
                    orderData.PriceBreakDiscount = !orderNode["PriceBreakDiscount"].IsEmpty ? (orderNode["PriceBreakDiscount"].InnerText) : "";
                    orderData.LoyaltyDiscount = !orderNode["LoyaltyDiscount"].IsEmpty ? (orderNode["LoyaltyDiscount"].InnerText) : "";
                    orderData.TotalDiscount = !orderNode["TotalDiscount"].IsEmpty ? (orderNode["TotalDiscount"].InnerText) : "";
                    orderData.InvoiceNotes = !orderNode["InvoiceNotes"].IsEmpty ? orderNode["InvoiceNotes"].InnerText : "";
                    orderData.CustomerNotes = !orderNode["CustomerNotes"].IsEmpty ? orderNode["CustomerNotes"].InnerText : "";
                    orderData.CustomerSelectedDeliveryDate = !orderNode["CustomerSelectedDeliveryDate"].IsEmpty ? orderNode["CustomerSelectedDeliveryDate"].InnerText : "";
                    orderData.DateDeliveryEstimate = !orderNode["DateDeliveryEstimate"].IsEmpty ? orderNode["DateDeliveryEstimate"].InnerText : "";
                    orderData.DateShipped = !orderNode["DateShipped"].IsEmpty ? orderNode["DateShipped"].InnerText : "";
                    orderData.DateCreated = !orderNode["DateCreated"].IsEmpty ? (orderNode["DateCreated"].InnerText) : "";


                    foreach (XmlNode item in orderNode["Items"].ChildNodes)
                    {
                        if (item.FirstChild != null)
                        {
                            ResponsesResponseOrderItem resItem = new ResponsesResponseOrderItem();
                            resItem.OrderID = orderData.OrderID;
                            resItem.OrderItemID = !item["OrderItemID"].IsEmpty ? (item["OrderItemID"].InnerText) : "";
                            resItem.ProductID = !item["ProductID"].IsEmpty ? (item["ProductID"].InnerText) : "";
                            resItem.ProductReference = !item["ProductReference"].IsEmpty ? (item["ProductReference"].InnerText) : "";
                            resItem.ProductEAN = !item["ProductEAN"].IsEmpty ? item["ProductEAN"].InnerText : "";
                            resItem.VariationID = !item["VariationID"].IsEmpty ? (item["VariationID"].InnerText) : "";
                            resItem.VariationReference = !item["VariationReference"].IsEmpty ? (item["VariationReference"].InnerText) : "";
                            resItem.VariationEAN = !item["VariationEAN"].IsEmpty ? (item["VariationEAN"].InnerText) : "";
                            resItem.BundleID = !item["BundleID"].IsEmpty ? item["BundleID"].InnerText : "";
                            resItem.Price = !item["Price"].IsEmpty ? (item["Price"].InnerText) : "";
                            resItem.Tax = !item["Tax"].IsEmpty ? (item["Tax"].InnerText) : "";
                            resItem.Discount = !item["Discount"].IsEmpty ? (item["Discount"].InnerText) : "";
                            resItem.TaxRate = !item["TaxRate"].IsEmpty ? (item["TaxRate"].InnerText) : "";
                            resItem.Quantity = !item["Quantity"].IsEmpty ? (item["Quantity"].InnerText) : "";
                            resItem.QuantityReturned = !item["QuantityReturned"].IsEmpty ? (item["QuantityReturned"].InnerText) : "";
                            resItem.LineOrder = !item["LineOrder"].IsEmpty ? (item["LineOrder"].InnerText) : "";
                            ResponsesResponseOrderItemLineStatus resLineStatus = new ResponsesResponseOrderItemLineStatus();
                            resItem.LineStatus = resLineStatus;
                            resItem.LineStatus.StatusCode = item.ChildNodes[15].ChildNodes[0] != null ? item.ChildNodes[15].ChildNodes[0].InnerText : "";
                            resItem.LineStatus.ReasonCode = item.ChildNodes[15].ChildNodes[0] != null ? item.ChildNodes[15].ChildNodes[1].InnerText : "";
                            ResponsesResponseOrderItemAdditionalFields resAddnlFields = new ResponsesResponseOrderItemAdditionalFields();
                            ResponsesResponseOrderItemAdditionalFieldsAdditionalField resitemAddnlFields = new ResponsesResponseOrderItemAdditionalFieldsAdditionalField();
                            resItem.AdditionalFields = resAddnlFields;
                            resItem.AdditionalFields.AdditionalField = resitemAddnlFields;
                            resItem.AdditionalFields.AdditionalField.FieldName = item.ChildNodes[16].ChildNodes[0] != null ? item.ChildNodes[16].ChildNodes[0].ChildNodes[0].InnerText : "";
                            resItem.AdditionalFields.AdditionalField.FieldValue = item.ChildNodes[16].ChildNodes[0] != null ? item.ChildNodes[16].ChildNodes[0].ChildNodes[1].InnerText : "";
                            orderData.Items = resItem;
                            ordersdetails.orderItemList.Add(resItem);
                        }
                    }

                    foreach (XmlNode trans in orderNode["Transactions"].ChildNodes)
                    {

                        if (trans.FirstChild != null)
                        {
                            ResponsesResponseOrderTransaction resTrans = new ResponsesResponseOrderTransaction();
                            resTrans.OrderID = orderData.OrderID;
                            resTrans.TransactionID = !trans["TransactionID"].IsEmpty ? (trans["TransactionID"].InnerText) : "";
                            resTrans.Amount = !trans["Amount"].IsEmpty ? (trans["Amount"].InnerText) : "";
                            resTrans.Display = !trans["Display"].IsEmpty ? (trans["Display"].InnerText) : "";
                            resTrans.NameOnCard = !trans["NameOnCard"].IsEmpty ? trans["NameOnCard"].InnerText : "";
                            resTrans.CardNumber = !trans["CardNumber"].IsEmpty ? trans["CardNumber"].InnerText : "";
                            resTrans.CardExpiry = !trans["CardExpiry"].IsEmpty ? trans["CardExpiry"].InnerText : "";
                            resTrans.CardType = !trans["CardType"].IsEmpty ? trans["CardType"].InnerText : "";
                            resTrans.Type = !trans["Type"].IsEmpty ? trans["Type"].InnerText : "";
                            resTrans.Status = !trans["Status"].IsEmpty ? trans["Status"].InnerText : "";
                            resTrans.StatusDetails = !trans["StatusDetails"].IsEmpty ? trans["StatusDetails"].InnerText : "";
                            resTrans.Provider = !trans["Provider"].IsEmpty ? trans["Provider"].InnerText : "";
                            resTrans.ProviderVendorTxCode = !trans["ProviderVendorTxCode"].IsEmpty ? trans["ProviderVendorTxCode"].InnerText : "";
                            resTrans.ProviderSecurityKey = !trans["ProviderSecurityKey"].IsEmpty ? trans["ProviderSecurityKey"].InnerText : "";
                            resTrans.ProviderAuthNumber = !trans["ProviderAuthNumber"].IsEmpty ? trans["ProviderAuthNumber"].InnerText : "";
                            resTrans.ProviderRelatedVendorTxCode = !trans["ProviderRelatedVendorTxCode"].IsEmpty ? trans["ProviderRelatedVendorTxCode"].InnerText : "";
                            resTrans.ProviderAVSCV2 = !trans["ProviderAVSCV2"].IsEmpty ? trans["ProviderAVSCV2"].InnerText : "";
                            resTrans.ProviderAddressResult = !trans["ProviderAddressResult"].IsEmpty ? trans["ProviderAddressResult"].InnerText : "";
                            resTrans.ProviderPostCodeResult = !trans["ProviderPostCodeResult"].IsEmpty ? trans["ProviderPostCodeResult"].InnerText : "";
                            resTrans.ProviderCV2Result = !trans["ProviderCV2Result"].IsEmpty ? trans["ProviderCV2Result"].InnerText : "";
                            resTrans.Provider3DSecureStatus = !trans["Provider3DSecureStatus"].IsEmpty ? trans["Provider3DSecureStatus"].InnerText : "";

                            //DateTime? nullDateTime = null;

                            resTrans.DateCreated = Convert.ToDateTime(trans["DateCreated"].InnerText);
                            orderData.Transactions = resTrans;
                            ordersdetails.orderTransList.Add(resTrans);
                        }
                    }
                    foreach (XmlNode adre in orderNode["Addresses"].ChildNodes)
                    {
                        ResponsesResponseOrderAddress resaddrcountry = new ResponsesResponseOrderAddress();
                        ResponsesResponseOrderAddressCountry resCountry = new ResponsesResponseOrderAddressCountry();
                        resaddrcountry.Country = resCountry;
                        if (adre.FirstChild != null)
                        {
                            if (!ordersdetails.ordercountrylist.Any(t => t.ID == adre.ChildNodes[16].ChildNodes[0].InnerText && t.Name == adre.ChildNodes[16].ChildNodes[2].InnerText))
                            {
                                resCountry.OrderID = orderData.OrderID;
                                resCountry.ID = (adre.ChildNodes[16].ChildNodes[0].InnerText);
                                resCountry.ISO = adre.ChildNodes[16].ChildNodes[1].InnerText;
                                resCountry.Name = adre.ChildNodes[16].ChildNodes[2].InnerText;
                                ordersdetails.ordercountrylist.Add(resCountry);
                            }
                        }
                    }

                    foreach (XmlNode addnlFields in orderNode["AdditionalFields"].ChildNodes)
                    {
                        if (addnlFields.FirstChild != null)
                        {
                            ResponsesResponseOrderAdditionalField resAddtnlFields = new ResponsesResponseOrderAdditionalField();

                            resAddtnlFields.OrderID = orderData.OrderID;
                            resAddtnlFields.FieldID = (addnlFields["FieldID"].InnerText);
                            resAddtnlFields.FieldName = addnlFields["FieldName"].InnerText;
                            resAddtnlFields.FieldValue = addnlFields["FieldValue"].InnerText;
                            //orderData.AdditionalFields = resAddtnlFields;
                            ordersdetails.orderAdditionalFieldlist.Add(resAddtnlFields);
                        }
                    }

                    foreach (XmlNode frdResults in orderNode["FraudResults"].ChildNodes)
                    {

                        ResponsesResponseOrderFraudResults resFraud = new ResponsesResponseOrderFraudResults();

                        if (frdResults.FirstChild != null && frdResults.OuterXml != "<Result></Result>")
                        {

                            resFraud.OrderID = orderData.OrderID;
                            resFraud.Action = frdResults["Action"].InnerText;
                            resFraud.Score = (frdResults["Score"].InnerText);
                            resFraud.MID = (frdResults["MID"].InnerText);
                            resFraud.DateCreated = (frdResults["DateCreated"].InnerText);
                            //orderData.FraudResults = resFraud;
                            ordersdetails.orderFraudResultsResultlist.Add(resFraud);
                        }
                        else
                        {

                            resFraud.OrderID = orderData.OrderID;
                            resFraud.Action = "";
                            resFraud.Score = "";
                            resFraud.MID = "";
                            resFraud.DateCreated = "";
                            //orderData.FraudResults = resFraud;
                            ordersdetails.orderFraudResultsResultlist.Add(resFraud);
                        }
                    }


                    ordersdetails.orderList.Add(orderData);
                }

                try
                {
                    _dbobjects.SaveOrders(ordersdetails, fascia);

                    log.Info("------------------------------");
                    log.Info(outputfilename + "is Imported Successfully!!!!");
                    log.Info("------------------------------");
                }
                catch (Exception ex)
                {
                    string exe = ex.Message;
                    message += string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message);
                    message += Environment.NewLine;
                    log.Info(message);
                    Console.WriteLine(message);

                }
            }
            catch (Exception ex)
            {
                string exe = ex.Message;
                message += string.Format("Exception in function: -> Update: {0}", ex.GetBaseException().Message);
                message += Environment.NewLine;
                log.Info(message);
                Console.WriteLine(message);




            }



            return null;
        }

        private string GetRequestXml(string token, string limit, string interval)
        {
            return @"<?xml version=""1.0"" encoding=""utf-8""?>
                          <AuroraRequestEnvelope xmlns:xsi= ""http://www.w3.org/2001/XMLSchema-instance"">    
                                    <Header>    
                                        <AuthToken>" + token + @"</AuthToken>    
                                    </Header>    
                                    <Requests>    
                                            <Request>    
                                                    <Order>   
                                                            <Get>    
                                                                    <RequestID>1</RequestID>    
                                                                    <Interval>" + interval + @"</Interval>    
                                                                    <OrderStatuses>    
                                                                            <StatusID>2</StatusID>    
                                                                    </OrderStatuses>                                                                 
                                                                      <Limit>" + limit + @"</Limit>    
                                                                    <Paging>    
                                                                            <Limit>" + limit + @"</Limit>    
                                                                            <Page>1</Page>    
                                                                    </Paging>   
                                                            </Get>    
                                                    </Order>    
                                            </Request>    
                                    </Requests>
                            </AuroraRequestEnvelope>";


        }

        public static string DecompressString(string compressedText)
        {
            MemoryStream memStream = new MemoryStream(Convert.FromBase64String(compressedText));
            memStream.ReadByte();
            memStream.ReadByte();
            DeflateStream deflate = new DeflateStream(memStream, CompressionMode.Decompress);
            string doc = new StreamReader(deflate, System.Text.Encoding.UTF8).ReadToEnd();
            return doc;
        }
    }
}
#endregion;