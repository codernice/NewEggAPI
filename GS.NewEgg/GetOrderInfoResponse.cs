﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// 此源代码由 xsd 自动生成, Version=4.0.30319.17929。
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class NeweggAPIResponse {
    
    private NeweggAPIResponseIsSuccess isSuccessField;
    
    private string sellerIDField;
    
    private string operationTypeField;
    
    private NeweggAPIResponseResponseBody responseBodyField;
    
    private string memoField;
    
    private string responseDateField;
    
    /// <remarks/>
    public NeweggAPIResponseIsSuccess IsSuccess {
        get {
            return this.isSuccessField;
        }
        set {
            this.isSuccessField = value;
        }
    }
    
    /// <remarks/>
    public string SellerID {
        get {
            return this.sellerIDField;
        }
        set {
            this.sellerIDField = value;
        }
    }
    
    /// <remarks/>
    public string OperationType {
        get {
            return this.operationTypeField;
        }
        set {
            this.operationTypeField = value;
        }
    }
    
    /// <remarks/>
    public NeweggAPIResponseResponseBody ResponseBody {
        get {
            return this.responseBodyField;
        }
        set {
            this.responseBodyField = value;
        }
    }
    
    /// <remarks/>
    public string Memo {
        get {
            return this.memoField;
        }
        set {
            this.memoField = value;
        }
    }
    
    /// <remarks/>
    public string ResponseDate {
        get {
            return this.responseDateField;
        }
        set {
            this.responseDateField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseIsSuccess {
    
    /// <remarks/>
    @true,
}

/// <summary>
/// 订单信息
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class NeweggAPIResponseResponseBody {
    
    private NeweggAPIResponseResponseBodyPageInfo pageInfoField;
    
    private NeweggAPIResponseResponseBodyOrderInfo[] orderInfoListField;
    
    /// <remarks/>
    public NeweggAPIResponseResponseBodyPageInfo PageInfo {
        get {
            return this.pageInfoField;
        }
        set {
            this.pageInfoField = value;
        }
    }
    
    ///
    [System.Xml.Serialization.XmlArrayItemAttribute("OrderInfo", IsNullable=false)]
    public NeweggAPIResponseResponseBodyOrderInfo[] OrderInfoList {
        get {
            return this.orderInfoListField;
        }
        set {
            this.orderInfoListField = value;
        }
    }
}

/// <summary>
/// 查询结果分页信息
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class NeweggAPIResponseResponseBodyPageInfo {
    
    private int totalCountField;
    
    private int totalPageCountField;
    
    private int pageSizeField;
    
    private int pageIndexField;
    
    /// <remarks/>
    public int TotalCount {
        get {
            return this.totalCountField;
        }
        set {
            this.totalCountField = value;
        }
    }
    
    /// <remarks/>
    public int TotalPageCount {
        get {
            return this.totalPageCountField;
        }
        set {
            this.totalPageCountField = value;
        }
    }
    
    /// <remarks/>
    public int PageSize {
        get {
            return this.pageSizeField;
        }
        set {
            this.pageSizeField = value;
        }
    }
    
    /// <remarks/>
    public int PageIndex {
        get {
            return this.pageIndexField;
        }
        set {
            this.pageIndexField = value;
        }
    }
}

/// <summary>
/// 获取的 订单信息
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class NeweggAPIResponseResponseBodyOrderInfo {
    
    private string sellerIDField;
    
    private string orderNumberField;
    
    private string sellerOrderNumberField;
    
    private string invoiceNumberField;
    
    private NeweggAPIResponseResponseBodyOrderInfoOrderDownloaded orderDownloadedField;
    
    private bool orderDownloadedFieldSpecified;
    
    private string orderDateField;
    
    private NeweggAPIResponseResponseBodyOrderInfoOrderStatus orderStatusField;
    
    private bool orderStatusFieldSpecified;
    
    private NeweggAPIResponseResponseBodyOrderInfoOrderStatusDescription orderStatusDescriptionField;
    
    private bool orderStatusDescriptionFieldSpecified;
    
    private string customerNameField;
    
    private string customerPhoneNumberField;
    
    private string customerEmailAddressField;
    
    private string shipToAddress1Field;
    
    private string shipToAddress2Field;
    
    private string shipToCityNameField;
    
    private string shipToStateCodeField;
    
    private string shipToZipCodeField;
    
    private string shipToCountryCodeField;
    
    private string shipServiceField;
    
    private string shipToFirstNameField;
    
    private string shipToLastNameField;
    
    private string shipToCompanyField;
    
    private decimal orderItemAmountField;
    
    private decimal shippingAmountField;
    
    private decimal salesTaxField;
    
    private bool salesTaxFieldSpecified;
    
    private decimal vATTotalField;
    
    private bool vATTotalFieldSpecified;
    
    private decimal dutyTotalField;
    
    private bool dutyTotalFieldSpecified;
    
    private decimal discountAmountField;
    
    private string orderQtyField;
    
    private decimal refundAmountField;
    
    private decimal orderTotalAmountField;
    
    private NeweggAPIResponseResponseBodyOrderInfoIsAutoVoid isAutoVoidField;
    
    private bool isAutoVoidFieldSpecified;
    
    private int salesChannelField;
    
    private bool salesChannelFieldSpecified;
    
    private int fulfillmentOptionField;
    
    private bool fulfillmentOptionFieldSpecified;
    
    private NeweggAPIResponseResponseBodyOrderInfoItemInfo[] itemInfoListField;
    
    private NeweggAPIResponseResponseBodyOrderInfoPackageInfo[] packageInfoListField;
    
    /// <remarks/>
    public string SellerID {
        get {
            return this.sellerIDField;
        }
        set {
            this.sellerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string OrderNumber {
        get {
            return this.orderNumberField;
        }
        set {
            this.orderNumberField = value;
        }
    }
    
    /// <remarks/>
    public string SellerOrderNumber {
        get {
            return this.sellerOrderNumberField;
        }
        set {
            this.sellerOrderNumberField = value;
        }
    }
    
    /// <summary>
    /// 发票号码
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string InvoiceNumber {
        get {
            return this.invoiceNumberField;
        }
        set {
            this.invoiceNumberField = value;
        }
    }
    
    /// <remarks/>
    public NeweggAPIResponseResponseBodyOrderInfoOrderDownloaded OrderDownloaded {
        get {
            return this.orderDownloadedField;
        }
        set {
            this.orderDownloadedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OrderDownloadedSpecified {
        get {
            return this.orderDownloadedFieldSpecified;
        }
        set {
            this.orderDownloadedFieldSpecified = value;
        }
    }

    /// <summary>
    /// 订单日期（貌似和平台后台显示，有时差）
    /// </summary>
    public string OrderDate {
        get {
            return this.orderDateField;
        }
        set {
            this.orderDateField = value;
        }
    }
    
    /// <summary>
    /// 订单状态（0:Unshipped未发货; 1:PartiallyShipped部分发货;  2:Shipped已发货;  3:Invoiced已生成发票  4:Void）
    /// </summary>
    public NeweggAPIResponseResponseBodyOrderInfoOrderStatus OrderStatus {
        get {
            return this.orderStatusField;
        }
        set {
            this.orderStatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OrderStatusSpecified {
        get {
            return this.orderStatusFieldSpecified;
        }
        set {
            this.orderStatusFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public NeweggAPIResponseResponseBodyOrderInfoOrderStatusDescription OrderStatusDescription {
        get {
            return this.orderStatusDescriptionField;
        }
        set {
            this.orderStatusDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OrderStatusDescriptionSpecified {
        get {
            return this.orderStatusDescriptionFieldSpecified;
        }
        set {
            this.orderStatusDescriptionFieldSpecified = value;
        }
    }
    
    /// <summary>
    /// 客户名称
    /// </summary>
    public string CustomerName {
        get {
            return this.customerNameField;
        }
        set {
            this.customerNameField = value;
        }
    }
    
    /// <summary>
    /// 客户电话号码
    /// </summary>
    public string CustomerPhoneNumber {
        get {
            return this.customerPhoneNumberField;
        }
        set {
            this.customerPhoneNumberField = value;
        }
    }
    
    /// <summary>
    /// 客户邮箱地址
    /// </summary>
    public string CustomerEmailAddress {
        get {
            return this.customerEmailAddressField;
        }
        set {
            this.customerEmailAddressField = value;
        }
    }
    
    /// <summary>
    /// 客户地址：明细，非完整地址（完整地址 = ShipToAddress1 + ShipToCityName + ShipToStateCode + ShipToZipCode +　ShipToCountryCode）
    /// </summary>
    public string ShipToAddress1 {
        get {
            return this.shipToAddress1Field;
        }
        set {
            this.shipToAddress1Field = value;
        }
    }
    
    /// <remarks/>
    public string ShipToAddress2 {
        get {
            return this.shipToAddress2Field;
        }
        set {
            this.shipToAddress2Field = value;
        }
    }

    /// <summary>
    /// 客户地址：城市
    /// </summary>
    public string ShipToCityName {
        get {
            return this.shipToCityNameField;
        }
        set {
            this.shipToCityNameField = value;
        }
    }



    /// <summary>
    /// 州编码
    /// </summary>
    public string ShipToStateCode {
        get {
            return this.shipToStateCodeField;
        }
        set {
            this.shipToStateCodeField = value;
        }
    }


    /// <summary>
    /// 邮编
    /// </summary>
    public string ShipToZipCode {
        get {
            return this.shipToZipCodeField;
        }
        set {
            this.shipToZipCodeField = value;
        }
    }

    /// <summary>
    /// 国家
    /// </summary>
    public string ShipToCountryCode {
        get {
            return this.shipToCountryCodeField;
        }
        set {
            this.shipToCountryCodeField = value;
        }
    }

    /// <summary>
    /// 配送服务类别
    /// </summary>
    public string ShipService {
        get {
            return this.shipServiceField;
        }
        set {
            this.shipServiceField = value;
        }
    }
    
    /// <remarks/>
    public string ShipToFirstName {
        get {
            return this.shipToFirstNameField;
        }
        set {
            this.shipToFirstNameField = value;
        }
    }
    
    /// <remarks/>
    public string ShipToLastName {
        get {
            return this.shipToLastNameField;
        }
        set {
            this.shipToLastNameField = value;
        }
    }
    
    /// <remarks/>
    public string ShipToCompany {
        get {
            return this.shipToCompanyField;
        }
        set {
            this.shipToCompanyField = value;
        }
    }
    
    /// <summary>
    /// 商品金额合计
    /// </summary>
    public decimal OrderItemAmount {
        get {
            return this.orderItemAmountField;
        }
        set {
            this.orderItemAmountField = value;
        }
    }
    
    /// <remarks/>
    public decimal ShippingAmount {
        get {
            return this.shippingAmountField;
        }
        set {
            this.shippingAmountField = value;
        }
    }
    
    /// <remarks/>
    public decimal SalesTax {
        get {
            return this.salesTaxField;
        }
        set {
            this.salesTaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SalesTaxSpecified {
        get {
            return this.salesTaxFieldSpecified;
        }
        set {
            this.salesTaxFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public decimal VATTotal {
        get {
            return this.vATTotalField;
        }
        set {
            this.vATTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool VATTotalSpecified {
        get {
            return this.vATTotalFieldSpecified;
        }
        set {
            this.vATTotalFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public decimal DutyTotal {
        get {
            return this.dutyTotalField;
        }
        set {
            this.dutyTotalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DutyTotalSpecified {
        get {
            return this.dutyTotalFieldSpecified;
        }
        set {
            this.dutyTotalFieldSpecified = value;
        }
    }
    
    /// <summary>
    /// 折扣金额
    /// </summary>
    public decimal DiscountAmount {
        get {
            return this.discountAmountField;
        }
        set {
            this.discountAmountField = value;
        }
    }
    
    /// <summary>
    /// 商品数量
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string OrderQty {
        get {
            return this.orderQtyField;
        }
        set {
            this.orderQtyField = value;
        }
    }
    
    /// <summary>
    /// 退款金额
    /// </summary>
    public decimal RefundAmount {
        get {
            return this.refundAmountField;
        }
        set {
            this.refundAmountField = value;
        }
    }


    /// <summary>
    /// 订单金额
    /// </summary>
    public decimal OrderTotalAmount {
        get {
            return this.orderTotalAmountField;
        }
        set {
            this.orderTotalAmountField = value;
        }
    }
    
    /// <remarks/>
    public NeweggAPIResponseResponseBodyOrderInfoIsAutoVoid IsAutoVoid {
        get {
            return this.isAutoVoidField;
        }
        set {
            this.isAutoVoidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IsAutoVoidSpecified {
        get {
            return this.isAutoVoidFieldSpecified;
        }
        set {
            this.isAutoVoidFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int SalesChannel {
        get {
            return this.salesChannelField;
        }
        set {
            this.salesChannelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SalesChannelSpecified {
        get {
            return this.salesChannelFieldSpecified;
        }
        set {
            this.salesChannelFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int FulfillmentOption {
        get {
            return this.fulfillmentOptionField;
        }
        set {
            this.fulfillmentOptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool FulfillmentOptionSpecified {
        get {
            return this.fulfillmentOptionFieldSpecified;
        }
        set {
            this.fulfillmentOptionFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ItemInfo", IsNullable=false)]
    public NeweggAPIResponseResponseBodyOrderInfoItemInfo[] ItemInfoList {
        get {
            return this.itemInfoListField;
        }
        set {
            this.itemInfoListField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("PackageInfo", IsNullable=false)]
    public NeweggAPIResponseResponseBodyOrderInfoPackageInfo[] PackageInfoList {
        get {
            return this.packageInfoListField;
        }
        set {
            this.packageInfoListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseResponseBodyOrderInfoOrderDownloaded {
    
    /// <remarks/>
    @true,
    
    /// <remarks/>
    @false,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseResponseBodyOrderInfoOrderStatus {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseResponseBodyOrderInfoOrderStatusDescription {
    
    /// <remarks/>
    Unshipped,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("Partially Shipped")]
    PartiallyShipped,
    
    /// <remarks/>
    Shipped,
    
    /// <remarks/>
    Invoiced,
    
    /// <remarks/>
    Voided,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseResponseBodyOrderInfoIsAutoVoid {
    
    /// <remarks/>
    @true,
    
    /// <remarks/>
    @false,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class NeweggAPIResponseResponseBodyOrderInfoItemInfo {
    
    private string sellerPartNumberField;
    
    private string neweggItemNumberField;
    
    private string mfrPartNumberField;
    
    private string uPCCodeField;
    
    private string descriptionField;
    
    private string orderedQtyField;
    
    private string shippedQtyField;
    
    private decimal unitPriceField;
    
    private decimal extendUnitPriceField;
    
    private decimal extendShippingChargeField;
    
    private decimal extendSalesTaxField;
    
    private decimal extendVATField;
    
    private decimal extendDutyField;
    
    private NeweggAPIResponseResponseBodyOrderInfoItemInfoStatus statusField;
    
    private bool statusFieldSpecified;
    
    private string statusDescriptionField;


    /// <summary>
    /// 商家商品编码2（新蛋运营填写规则：店铺＋平台＋活石sku）
    /// </summary>
    public string SellerPartNumber {
        get {
            return this.sellerPartNumberField;
        }
        set {
            this.sellerPartNumberField = value;
        }
    }

    /// <summary>
    /// 新蛋官方商品编码
    /// </summary>
    public string NeweggItemNumber {
        get {
            return this.neweggItemNumberField;
        }
        set {
            this.neweggItemNumberField = value;
        }
    }

    /// <summary>
    /// 商家商品编码（活石sku）
    /// </summary>
    public string MfrPartNumber {
        get {
            return this.mfrPartNumberField;
        }
        set {
            this.mfrPartNumberField = value;
        }
    }
    
    /// <remarks/>
    public string UPCCode {
        get {
            return this.uPCCodeField;
        }
        set {
            this.uPCCodeField = value;
        }
    }
    
    /// <remarks/>
    public string Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }

    /// <summary>
    //　商品数量
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string OrderedQty {
        get {
            return this.orderedQtyField;
        }
        set {
            this.orderedQtyField = value;
        }
    }
    
    /// <summary>
    /// 商品发货数量
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string ShippedQty {
        get {
            return this.shippedQtyField;
        }
        set {
            this.shippedQtyField = value;
        }
    }
    
    /// <summary>
    /// 商品单价
    /// </summary>
    public decimal UnitPrice {
        get {
            return this.unitPriceField;
        }
        set {
            this.unitPriceField = value;
        }
    }
    
    /// <remarks/>
    public decimal ExtendUnitPrice {
        get {
            return this.extendUnitPriceField;
        }
        set {
            this.extendUnitPriceField = value;
        }
    }
    
    /// <remarks/>
    public decimal ExtendShippingCharge {
        get {
            return this.extendShippingChargeField;
        }
        set {
            this.extendShippingChargeField = value;
        }
    }
    
    /// <remarks/>
    public decimal ExtendSalesTax {
        get {
            return this.extendSalesTaxField;
        }
        set {
            this.extendSalesTaxField = value;
        }
    }
    
    /// <remarks/>
    public decimal ExtendVAT {
        get {
            return this.extendVATField;
        }
        set {
            this.extendVATField = value;
        }
    }
    
    /// <remarks/>
    public decimal ExtendDuty {
        get {
            return this.extendDutyField;
        }
        set {
            this.extendDutyField = value;
        }
    }
    
    /// <remarks/>
    public NeweggAPIResponseResponseBodyOrderInfoItemInfoStatus Status {
        get {
            return this.statusField;
        }
        set {
            this.statusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool StatusSpecified {
        get {
            return this.statusFieldSpecified;
        }
        set {
            this.statusFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string StatusDescription {
        get {
            return this.statusDescriptionField;
        }
        set {
            this.statusDescriptionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseResponseBodyOrderInfoItemInfoStatus {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class NeweggAPIResponseResponseBodyOrderInfoPackageInfo {
    
    private NeweggAPIResponseResponseBodyOrderInfoPackageInfoPackageType packageTypeField;
    
    private bool packageTypeFieldSpecified;
    
    private string shipCarrierField;
    
    private string shipServiceField;
    
    private string trackingNumberField;
    
    private string shipDateField;
    
    private NeweggAPIResponseResponseBodyOrderInfoPackageInfoItemInfo[] itemInfoListField;
    
    /// <remarks/>
    public NeweggAPIResponseResponseBodyOrderInfoPackageInfoPackageType PackageType {
        get {
            return this.packageTypeField;
        }
        set {
            this.packageTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PackageTypeSpecified {
        get {
            return this.packageTypeFieldSpecified;
        }
        set {
            this.packageTypeFieldSpecified = value;
        }
    }
    
    /// <summary>
    /// 发货快递：UPS、UPS MI、FedEX、DHL、USPS（NOTE: Please specify the ship carrier name other than above. Please refer to the following XML formatted example.）
    /// </summary>
    public string ShipCarrier {
        get {
            return this.shipCarrierField;
        }
        set {
            this.shipCarrierField = value;
        }
    }
    
    /// <summary>
    /// 发货方式：Shipping  service type,  such as air, ground, etc. Please reference your shipping carrier directly
    /// </summary>
    public string ShipService {
        get {
            return this.shipServiceField;
        }
        set {
            this.shipServiceField = value;
        }
    }
    
    /// <summary>
    /// 快递单号
    /// </summary>
    public string TrackingNumber {
        get {
            return this.trackingNumberField;
        }
        set {
            this.trackingNumberField = value;
        }
    }
    
    /// <summary>
    /// 发货时间
    /// </summary>
    public string ShipDate {
        get {
            return this.shipDateField;
        }
        set {
            this.shipDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ItemInfo", IsNullable=false)]
    public NeweggAPIResponseResponseBodyOrderInfoPackageInfoItemInfo[] ItemInfoList {
        get {
            return this.itemInfoListField;
        }
        set {
            this.itemInfoListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum NeweggAPIResponseResponseBodyOrderInfoPackageInfoPackageType {
    
    /// <remarks/>
    Shipped,
    
    /// <remarks/>
    Unshipped,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class NeweggAPIResponseResponseBodyOrderInfoPackageInfoItemInfo {
    
    private string sellerPartNumberField;
    
    private string mfrPartNumberField;
    
    private string shippedQtyField;


    /// <summary>
    /// 商家商品编码2（新蛋运营填写规则：店铺＋平台＋活石sku）
    /// </summary>
    public string SellerPartNumber {
        get {
            return this.sellerPartNumberField;
        }
        set {
            this.sellerPartNumberField = value;
        }
    }


    /// <summary>
    /// 商家商品编码（活石sku）
    /// </summary>
    public string MfrPartNumber {
        get {
            return this.mfrPartNumberField;
        }
        set {
            this.mfrPartNumberField = value;
        }
    }

    /// <summary>
    /// 发货数量
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
    public string ShippedQty {
        get {
            return this.shippedQtyField;
        }
        set {
            this.shippedQtyField = value;
        }
    }
}
