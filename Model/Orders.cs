using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraCommerceApp.Model
{


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Responses
    {

        private ResponsesResponse responseField;

        /// <remarks/>
        public ResponsesResponse Response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }


        }
        public List<ResponsesResponseOrder> orderList = new List<ResponsesResponseOrder>();
        public List<ResponsesResponseOrderAddress> orderAddreList = new List<ResponsesResponseOrderAddress>();
        public List<ResponsesResponseOrderItem> orderItemList = new List<ResponsesResponseOrderItem>();
        public List<ResponsesResponseOrderTransaction> orderTransList = new List<ResponsesResponseOrderTransaction>();
        public List<ResponsesResponseOrderAddressCountry> ordercountrylist = new List<ResponsesResponseOrderAddressCountry>();
        public List<ResponsesResponseOrderAdditionalField> orderAdditionalFieldlist = new List<ResponsesResponseOrderAdditionalField>();
        public List<ResponsesResponseOrderFraudResults> orderFraudResultsResultlist = new List<ResponsesResponseOrderFraudResults>();

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponse
    {

        private byte requestIDField;

        private string ackField;

        private ResponsesResponsePaging pagingField;

        private ResponsesResponseOrder[] dataField;

        /// <remarks/>
        public byte RequestID
        {
            get
            {
                return this.requestIDField;
            }
            set
            {
                this.requestIDField = value;
            }
        }

        /// <remarks/>
        public string Ack
        {
            get
            {
                return this.ackField;
            }
            set
            {
                this.ackField = value;
            }
        }

        /// <remarks/>
        public ResponsesResponsePaging Paging
        {
            get
            {
                return this.pagingField;
            }
            set
            {
                this.pagingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Order", IsNullable = false)]
        public ResponsesResponseOrder[] Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponsePaging
    {

        private string tokenField;

        /// <remarks/>
        public string Token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
    }


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

    public partial class ResponsesResponseOrder
    {

        private string fasica;
        private string orderIDField;

        private string customerIDField;

        private string orderStatusField;

        private string paymentTypeField;

        private ResponsesResponseOrderAddress addressesField;

        private string courierNameField;

        private string shippingTypeField;

        private string trackingNumberField;

        private string chargedCurrencyField;

        private string currencyField;

        private string exchangeRateField;

        private string taxRateField;

        private string shippingSkuField;

        private string shippingCostField;

        private string shippingTaxField;

        private string customShippingCostField;

        private string customShippingLabelField;

        private string orderTotalField;

        private string orderSubtotalField;

        private string orderTaxField;

        private string couponCodeField;

        private string couponDiscountField;

        private string orderDiscountField;

        private string priceBreakDiscountField;

        private string loyaltyDiscountField;

        private string totalDiscountField;

        private string invoiceNotesField;

        private string customerNotesField;

        private string customerSelectedDeliveryDateField;

        private string dateDeliveryEstimateField;

        private string dateShippedField;

        private string dateCreatedField;

        private string clickAndCollectField;


        private string lastUpdated;
        //   private ResponsesResponseOrderItem[] itemsField;
        //    private ResponsesResponseOrderTransaction[] transactionsField;
        //     private ResponsesResponseOrderAdditionalField[] additionalFieldsField;

        private ResponsesResponseOrderItem itemsField;
        private ResponsesResponseOrderTransaction transactionsField;
        private ResponsesResponseOrderAdditionalField additionalFieldsField;

        private ResponsesResponseOrderFraudResults fraudResultsField;

        /// <remarks/>
        public string OrderID
        {
            get
            {
                return this.orderIDField;
            }
            set
            {
                this.orderIDField = value;
            }
        }

        /// <remarks/>
        public string CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        public string OrderStatus
        {
            get
            {
                return this.orderStatusField;
            }
            set
            {
                this.orderStatusField = value;
            }
        }

        /// <remarks/>
        public string PaymentType
        {
            get
            {
                return this.paymentTypeField;
            }
            set
            {
                this.paymentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Address", IsNullable = false)]
        public ResponsesResponseOrderAddress Addresses
        {
            get
            {
                return this.addressesField;
            }
            set
            {
                this.addressesField = value;
            }



        }

        /// <remarks/>
        public string CourierName
        {
            get
            {
                return this.courierNameField;
            }
            set
            {
                this.courierNameField = value;
            }
        }

        /// <remarks/>
        public string ShippingType
        {
            get
            {
                return this.shippingTypeField;
            }
            set
            {
                this.shippingTypeField = value;
            }
        }

        /// <remarks/>
        public string TrackingNumber
        {
            get
            {
                return this.trackingNumberField;
            }
            set
            {
                this.trackingNumberField = value;
            }
        }

        /// <remarks/>
        public string ChargedCurrency
        {
            get
            {
                return this.chargedCurrencyField;
            }
            set
            {
                this.chargedCurrencyField = value;
            }
        }

        /// <remarks/>
        public string Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        public string ExchangeRate
        {
            get
            {
                return this.exchangeRateField;
            }
            set
            {
                this.exchangeRateField = value;
            }
        }

        /// <remarks/>
        public string TaxRate
        {
            get
            {
                return this.taxRateField;
            }
            set
            {
                this.taxRateField = value;
            }
        }

        /// <remarks/>
        public string ShippingSku
        {
            get
            {
                return this.shippingSkuField;
            }
            set
            {
                this.shippingSkuField = value;
            }
        }

        /// <remarks/>
        public string ShippingCost
        {
            get
            {
                return this.shippingCostField;
            }
            set
            {
                this.shippingCostField = value;
            }
        }

        /// <remarks/>
        public string ShippingTax
        {
            get
            {
                return this.shippingTaxField;
            }
            set
            {
                this.shippingTaxField = value;
            }
        }

        /// <remarks/>
        public string CustomShippingCost
        {
            get
            {
                return this.customShippingCostField;
            }
            set
            {
                this.customShippingCostField = value;
            }
        }

        /// <remarks/>
        public string CustomShippingLabel
        {
            get
            {
                return this.customShippingLabelField;
            }
            set
            {
                this.customShippingLabelField = value;
            }
        }

        /// <remarks/>
        public string OrderTotal
        {
            get
            {
                return this.orderTotalField;
            }
            set
            {
                this.orderTotalField = value;
            }
        }

        /// <remarks/>
        public string OrderSubtotal
        {
            get
            {
                return this.orderSubtotalField;
            }
            set
            {
                this.orderSubtotalField = value;
            }
        }

        /// <remarks/>
        public string OrderTax
        {
            get
            {
                return this.orderTaxField;
            }
            set
            {
                this.orderTaxField = value;
            }
        }

        /// <remarks/>
        public string CouponCode
        {
            get
            {
                return this.couponCodeField;
            }
            set
            {
                this.couponCodeField = value;
            }
        }

        /// <remarks/>
        public string CouponDiscount
        {
            get
            {
                return this.couponDiscountField;
            }
            set
            {
                this.couponDiscountField = value;
            }
        }

        /// <remarks/>
        public string OrderDiscount
        {
            get
            {
                return this.orderDiscountField;
            }
            set
            {
                this.orderDiscountField = value;
            }
        }

        /// <remarks/>
        public string PriceBreakDiscount
        {
            get
            {
                return this.priceBreakDiscountField;
            }
            set
            {
                this.priceBreakDiscountField = value;
            }
        }

        /// <remarks/>
        public string LoyaltyDiscount
        {
            get
            {
                return this.loyaltyDiscountField;
            }
            set
            {
                this.loyaltyDiscountField = value;
            }
        }

        /// <remarks/>
        public string TotalDiscount
        {
            get
            {
                return this.totalDiscountField;
            }
            set
            {
                this.totalDiscountField = value;
            }
        }

        /// <remarks/>
        public string InvoiceNotes
        {
            get
            {
                return this.invoiceNotesField;
            }
            set
            {
                this.invoiceNotesField = value;
            }
        }

        /// <remarks/>
        public string CustomerNotes
        {
            get
            {
                return this.customerNotesField;
            }
            set
            {
                this.customerNotesField = value;
            }
        }

        /// <remarks/>
        public string CustomerSelectedDeliveryDate
        {
            get
            {
                return this.customerSelectedDeliveryDateField;
            }
            set
            {
                this.customerSelectedDeliveryDateField = value;
            }
        }

        /// <remarks/>
        public string DateDeliveryEstimate
        {
            get
            {
                return this.dateDeliveryEstimateField;
            }
            set
            {
                this.dateDeliveryEstimateField = value;
            }
        }

        /// <remarks/>
        public string DateShipped
        {
            get
            {
                return this.dateShippedField;
            }
            set
            {
                this.dateShippedField = value;
            }
        }

        /// <remarks/>
        public string DateCreated
        {
            get
            {
                return this.dateCreatedField;
            }
            set
            {
                this.dateCreatedField = value;
            }
        }

        /// <remarks/>
        public string ClickAndCollect
        {
            get
            {
                return this.clickAndCollectField;
            }
            set
            {
                this.clickAndCollectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Item", IsNullable = false)]
        public ResponsesResponseOrderItem Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Transaction", IsNullable = false)]
        public ResponsesResponseOrderTransaction Transactions
        {
            get
            {
                return this.transactionsField;
            }
            set
            {
                this.transactionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("AdditionalField", IsNullable = false)]
        public ResponsesResponseOrderAdditionalField AdditionalFields
        {
            get
            {
                return this.additionalFieldsField;
            }
            set
            {
                this.additionalFieldsField = value;
            }
        }

        /// <remarks/>
        public ResponsesResponseOrderFraudResults FraudResults
        {
            get
            {
                return this.fraudResultsField;
            }
            set
            {
                this.fraudResultsField = value;
            }
        }

        public string Fasica
        {
            get
            {
                return fasica;
            }

            set
            {
                fasica = value;
            }
        }

        public string LastUpdated
        {
            get
            {
                return lastUpdated;
            }

            set
            {
                lastUpdated = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderAddress
    {
        private string orderId;
        private string addressIDField;

        private string customerIDField;

        private string storageTypeField;

        private string addressTypeField;

        private string emailAddressField;

        private string optOutField;

        private string genderField;

        private string companyNameField;

        private string titleField;

        private string firstNameField;

        private string lastNameField;

        private string addressLine1Field;

        private string addressLine2Field;

        private string townField;

        private string countyField;

        private string postCodeField;

        private ResponsesResponseOrderAddressCountry countryField;

        private string phoneNumberField;

        private string mobileNumberField;

        /// <remarks/>
        public string OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }

        public string AddressID
        {
            get
            {
                return this.addressIDField;
            }
            set
            {
                this.addressIDField = value;
            }
        }

        /// <remarks/>
        public string CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        public string StorageType
        {
            get
            {
                return this.storageTypeField;
            }
            set
            {
                this.storageTypeField = value;
            }
        }

        /// <remarks/>
        public string AddressType
        {
            get
            {
                return this.addressTypeField;
            }
            set
            {
                this.addressTypeField = value;
            }
        }

        /// <remarks/>
        public string EmailAddress
        {
            get
            {
                return this.emailAddressField;
            }
            set
            {
                this.emailAddressField = value;
            }
        }

        /// <remarks/>
        public string OptOut
        {
            get
            {
                return this.optOutField;
            }
            set
            {
                this.optOutField = value;
            }
        }

        /// <remarks/>
        public string Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public string AddressLine1
        {
            get
            {
                return this.addressLine1Field;
            }
            set
            {
                this.addressLine1Field = value;
            }
        }

        /// <remarks/>
        public string AddressLine2
        {
            get
            {
                return this.addressLine2Field;
            }
            set
            {
                this.addressLine2Field = value;
            }
        }

        /// <remarks/>
        public string Town
        {
            get
            {
                return this.townField;
            }
            set
            {
                this.townField = value;
            }
        }

        /// <remarks/>
        public string County
        {
            get
            {
                return this.countyField;
            }
            set
            {
                this.countyField = value;
            }
        }

        /// <remarks/>
        public string PostCode
        {
            get
            {
                return this.postCodeField;
            }
            set
            {
                this.postCodeField = value;
            }
        }

        /// <remarks/>
        public ResponsesResponseOrderAddressCountry Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }

        /// <remarks/>
        public string MobileNumber
        {
            get
            {
                return this.mobileNumberField;
            }
            set
            {
                this.mobileNumberField = value;
            }
        }

        
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

    public partial class ResponsesResponseOrderAddressCountry
    {
        private string orderId;
        private string idField;

        private string iSOField;

        private string nameField;

        /// <remarks/>
        public string OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }

        /// <remarks/>
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string ISO
        {
            get
            {
                return this.iSOField;
            }
            set
            {
                this.iSOField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderItem
    {
        private string orderId;
        private string orderItemIDField;

        private string productIDField;

        private string productReferenceField;

        private string productEANField;

        private string variationIDField;

        private string variationReferenceField;

        private string variationEANField;

        private string bundleIDField;

        private string priceField;

        private string taxField;

        private string discountField;

        private string taxRateField;

        private string quantityField;

        private string quantityReturnedField;

        private string lineOrderField;

        private ResponsesResponseOrderItemLineStatus lineStatusField;

        private ResponsesResponseOrderItemAdditionalFields additionalFieldsField;

        /// <remarks/>
        public string OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }


        /// <remarks/>
        public string OrderItemID
        {
            get
            {
                return this.orderItemIDField;
            }
            set
            {
                this.orderItemIDField = value;
            }
        }

        /// <remarks/>
        public string ProductID
        {
            get
            {
                return this.productIDField;
            }
            set
            {
                this.productIDField = value;
            }
        }

        /// <remarks/>
        public string ProductReference
        {
            get
            {
                return this.productReferenceField;
            }
            set
            {
                this.productReferenceField = value;
            }
        }

        /// <remarks/>
        public string ProductEAN
        {
            get
            {
                return this.productEANField;
            }
            set
            {
                this.productEANField = value;
            }
        }

        /// <remarks/>
        public string VariationID
        {
            get
            {
                return this.variationIDField;
            }
            set
            {
                this.variationIDField = value;
            }
        }

        /// <remarks/>
        public string VariationReference
        {
            get
            {
                return this.variationReferenceField;
            }
            set
            {
                this.variationReferenceField = value;
            }
        }

        /// <remarks/>
        public string VariationEAN
        {
            get
            {
                return this.variationEANField;
            }
            set
            {
                this.variationEANField = value;
            }
        }

        /// <remarks/>
        public string BundleID
        {
            get
            {
                return this.bundleIDField;
            }
            set
            {
                this.bundleIDField = value;
            }
        }

        /// <remarks/>
        public string Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public string Tax
        {
            get
            {
                return this.taxField;
            }
            set
            {
                this.taxField = value;
            }
        }

        /// <remarks/>
        public string Discount
        {
            get
            {
                return this.discountField;
            }
            set
            {
                this.discountField = value;
            }
        }

        /// <remarks/>
        public string TaxRate
        {
            get
            {
                return this.taxRateField;
            }
            set
            {
                this.taxRateField = value;
            }
        }

        /// <remarks/>
        public string Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public string QuantityReturned
        {
            get
            {
                return this.quantityReturnedField;
            }
            set
            {
                this.quantityReturnedField = value;
            }
        }

        /// <remarks/>
        public string LineOrder
        {
            get
            {
                return this.lineOrderField;
            }
            set
            {
                this.lineOrderField = value;
            }
        }

        /// <remarks/>
        public ResponsesResponseOrderItemLineStatus LineStatus
        {
            get
            {
                return this.lineStatusField;
            }
            set
            {
                this.lineStatusField = value;
            }
        }

        /// <remarks/>
        public ResponsesResponseOrderItemAdditionalFields AdditionalFields
        {
            get
            {
                return this.additionalFieldsField;
            }
            set
            {
                this.additionalFieldsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderItemLineStatus
    {

        private string statusCodeField;

        private string reasonCodeField;

        /// <remarks/>
        public string StatusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <remarks/>
        public string ReasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderItemAdditionalFields
    {

        private ResponsesResponseOrderItemAdditionalFieldsAdditionalField additionalFieldField;

        /// <remarks/>
        public ResponsesResponseOrderItemAdditionalFieldsAdditionalField AdditionalField
        {
            get
            {
                return this.additionalFieldField;
            }
            set
            {
                this.additionalFieldField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderItemAdditionalFieldsAdditionalField
    {

        private string fieldNameField;

        private string fieldValueField;

        /// <remarks/>
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }

        /// <remarks/>
        public string FieldValue
        {
            get
            {
                return this.fieldValueField;
            }
            set
            {
                this.fieldValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderTransaction
    {
        private string orderId;

        private string transactionIDField;

        private string amountField;

        private string displayField;

        private string nameOnCardField;

        private string cardNumberField;

        private string cardExpiryField;

        private string cardTypeField;

        private string typeField;

        private string statusField;

        private string statusDetailsField;

        private string providerField;

        private string providerVendorTxCodeField;

        private string providerTxIDField;

        private string providerSecurityKeyField;

        private string providerAuthNumberField;

        private string providerRelatedVendorTxCodeField;

        private string providerAVSCV2Field;

        private string providerAddressResultField;

        private string providerPostCodeResultField;

        private string providerCV2ResultField;

        private string provider3DSecureStatusField;

        private DateTime dateCreatedField;


        /// <remarks/>
        public string OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }
        /// <remarks/>
        public string TransactionID
        {
            get
            {
                return this.transactionIDField;
            }
            set
            {
                this.transactionIDField = value;
            }
        }

        /// <remarks/>
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <remarks/>
        public string Display
        {
            get
            {
                return this.displayField;
            }
            set
            {
                this.displayField = value;
            }
        }

        /// <remarks/>
        public string NameOnCard
        {
            get
            {
                return this.nameOnCardField;
            }
            set
            {
                this.nameOnCardField = value;
            }
        }

        /// <remarks/>
        public string CardNumber
        {
            get
            {
                return this.cardNumberField;
            }
            set
            {
                this.cardNumberField = value;
            }
        }

        /// <remarks/>
        public string CardExpiry
        {
            get
            {
                return this.cardExpiryField;
            }
            set
            {
                this.cardExpiryField = value;
            }
        }

        /// <remarks/>
        public string CardType
        {
            get
            {
                return this.cardTypeField;
            }
            set
            {
                this.cardTypeField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string StatusDetails
        {
            get
            {
                return this.statusDetailsField;
            }
            set
            {
                this.statusDetailsField = value;
            }
        }

        /// <remarks/>
        public string Provider
        {
            get
            {
                return this.providerField;
            }
            set
            {
                this.providerField = value;
            }
        }

        /// <remarks/>
        public string ProviderVendorTxCode
        {
            get
            {
                return this.providerVendorTxCodeField;
            }
            set
            {
                this.providerVendorTxCodeField = value;
            }
        }

        /// <remarks/>
        public string ProviderTxID
        {
            get
            {
                return this.providerTxIDField;
            }
            set
            {
                this.providerTxIDField = value;
            }
        }

        /// <remarks/>
        public string ProviderSecurityKey
        {
            get
            {
                return this.providerSecurityKeyField;
            }
            set
            {
                this.providerSecurityKeyField = value;
            }
        }

        /// <remarks/>
        public string ProviderAuthNumber
        {
            get
            {
                return this.providerAuthNumberField;
            }
            set
            {
                this.providerAuthNumberField = value;
            }
        }

        /// <remarks/>
        public string ProviderRelatedVendorTxCode
        {
            get
            {
                return this.providerRelatedVendorTxCodeField;
            }
            set
            {
                this.providerRelatedVendorTxCodeField = value;
            }
        }

        /// <remarks/>
        public string ProviderAVSCV2
        {
            get
            {
                return this.providerAVSCV2Field;
            }
            set
            {
                this.providerAVSCV2Field = value;
            }
        }

        /// <remarks/>
        public string ProviderAddressResult
        {
            get
            {
                return this.providerAddressResultField;
            }
            set
            {
                this.providerAddressResultField = value;
            }
        }

        /// <remarks/>
        public string ProviderPostCodeResult
        {
            get
            {
                return this.providerPostCodeResultField;
            }
            set
            {
                this.providerPostCodeResultField = value;
            }
        }

        /// <remarks/>
        public string ProviderCV2Result
        {
            get
            {
                return this.providerCV2ResultField;
            }
            set
            {
                this.providerCV2ResultField = value;
            }
        }

        /// <remarks/>
        public string Provider3DSecureStatus
        {
            get
            {
                return this.provider3DSecureStatusField;
            }
            set
            {
                this.provider3DSecureStatusField = value;
            }
        }

        /// <remarks/>
        public DateTime DateCreated
        {
            get
            {
                return this.dateCreatedField;
            }
            set
            {
                this.dateCreatedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderAdditionalField
    {

        private string orderId;

        private string fieldIDField;

        private string fieldNameField;

        private string fieldValueField;



        public string OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }

        /// <remarks/>
        public string FieldID
        {
            get
            {
                return this.fieldIDField;
            }
            set
            {
                this.fieldIDField = value;
            }
        }

        /// <remarks/>
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }

        /// <remarks/>
        public string FieldValue
        {
            get
            {
                return this.fieldValueField;
            }
            set
            {
                this.fieldValueField = value;
            }
        }
    }

    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public partial class ResponsesResponseOrderFraudResults
    //{

       

    //    /// <remarks/>
    //    //public ResponsesResponseOrderFraudResultsResult Result
    //    //{
    //    //    get
    //    //    {
    //    //        return this.resultField;
    //    //    }
    //    //    set
    //    //    {
    //    //        this.resultField = value;
    //    //    }
    //    //}
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponsesResponseOrderFraudResults
    {

        private string orderId;

        private string actionField;

        private string scoreField;

        private string mIDField;

        private string dateCreatedField;



        public string OrderID
        {
            get
            {
                return this.orderId;
            }
            set
            {
                this.orderId = value;
            }
        }



        /// <remarks/>
        public string Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }

        /// <remarks/>
        public string Score
        {
            get
            {
                return this.scoreField;
            }
            set
            {
                this.scoreField = value;
            }
        }

        /// <remarks/>
        public string MID
        {
            get
            {
                return this.mIDField;
            }
            set
            {
                this.mIDField = value;
            }
        }

        /// <remarks/>
        public string DateCreated
        {
            get
            {
                return this.dateCreatedField;
            }
            set
            {
                this.dateCreatedField = value;
            }
        }
    }




}
