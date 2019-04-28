using GS.NewEgg.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GS.NewEgg
{
    public class NeweggClient
    {
        //店铺参数
        public static string SellerID = "xxxx";
        public static string Authorization = "xxxxxxxxxxxxxxxxxx";
        public static string SecretKey = "xxxxxxxxxxxxxxxxxx";
        public NeweggClient() { }
        public NeweggClient(string sellerID, string authorization, string secretKey) 
        {
            SellerID = sellerID;
            Authorization = authorization;
            SecretKey = secretKey;
        }

        #region 调用接口方法

        /// <summary>
        /// 按【时间段】 查询订单（按10单分页；返回null表示接口调用异常）
        /// </summary>
        /// <param name="OrderDateFrom">订单查询【开始时间】　格式：yyyy-MM-dd HH:mm:ss</param>
        /// <param name="OrderDateTo">订单查询【开始结束】　格式：yyyy-MM-dd HH:mm:ss</param>
        /// <returns></returns>
        public List<NeweggAPIResponse> GetOrdersInfo(DateTime OrderDateFrom, DateTime OrderDateTo)
        {
            List<NeweggAPIResponse> neweggAPIResponseList = new List<NeweggAPIResponse>();

            NeweggAPIResponse orderInfo = GetOrders(1, 1, OrderDateFrom, OrderDateTo);
            if (orderInfo != null)
            {
                int ordersCount = orderInfo.ResponseBody.PageInfo.TotalCount; //时间段内，订单总数量
                int pageSize = 50;
                int pageCount = ordersCount / pageSize;
                if (ordersCount % pageSize != 0)
                {
                    pageCount += 1;
                }
                if (ordersCount > 0)
                {
                    for (int i = 0; i < pageCount; i++)
                    {
                        NeweggAPIResponse ordersInfo = GetOrders(i + 1, pageSize, OrderDateFrom, OrderDateTo);
                        if (ordersInfo != null)
                        {
                            neweggAPIResponseList.Add(ordersInfo);
                        }
                        else
                        {
                            //个别订单号返回的xml有问题，导致异常，只能一个个获取，排除掉异常的订单
                            var loopStart = 1;
                            var loopEnd = 1;
                            if (ordersCount < pageSize)
                            {
                                loopEnd = ordersCount;
                            }
                            else
                            {
                                loopStart = pageSize * i + 1;
                                loopEnd = pageSize * (i + 1);
                                if (loopEnd > ordersCount)
                                {
                                    loopEnd = ordersCount;
                                }
                            }
                            for (var j = loopStart; j <= loopEnd; j++)
                            {
                                ordersInfo = GetOrders(j, 1, OrderDateFrom, OrderDateTo);
                                if (ordersInfo != null)
                                {
                                    neweggAPIResponseList.Add(ordersInfo);
                                }
                            }
                        }
                    }
                }
                return neweggAPIResponseList;
            }
            {
                return null;
            }
        }


        /// <summary>
        /// 按【订单号】 查询某个订单信息（返回null表示接口调用异常或订单号格式错误）
        /// </summary>
        /// <param name="OrderNumber">订单号</param>
        /// <returns></returns>
        //按时间段 调用API接口，获取订单信息
        public NeweggAPIResponse GetOrderInfoByOrderNumber(string OrderNumber)
        {
            try
            {
                //Determine the correct Newegg Marketplace API endpoint to use.

                // Please make sure your request URL is all in lower case 
                string endpoint = @"https://api.newegg.com/marketplace/ordermgmt/order/orderinfo?sellerid={0}";
                endpoint = String.Format(endpoint, SellerID);

                //Create an HttpWebRequest 
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(endpoint) as HttpWebRequest;

                //Remove proxy 
                request.Proxy = null;

                //Specify the request method 
                request.Method = "PUT";

                //Specify the xml/Json request and response content types. 
                request.ContentType = "application/xml";
                request.Accept = "application/xml";

                //Attach authorization information 
                request.Headers.Add("Authorization", Authorization);
                request.Headers.Add("Secretkey", SecretKey);

                //Construct the query criteria in the request body 
                //string requestBody = @"<ContentQueryCriteria><Type>1</Type><Value>9SIAGAZ7SY5852</Value></ContentQueryCriteria>";

                String requestBody = @"<NeweggAPIRequest>"

                + "<OperationType>GetOrderInfoRequest</OperationType>"

                + "<RequestBody>"

                + "<PageIndex>1</PageIndex>"

                + "<PageSize>1</PageSize>"

                + "<RequestCriteria>"

                + "<OrderNumberList>"

                + "<OrderNumber>" + OrderNumber + "</OrderNumber>"

                + "</OrderNumberList>"

                //+ "<Status>1</Status>" //0:Unshipped；1:Partially Shipped；2:Shipped；3:Invoiced；4:Voided

                + "<Type>0</Type>" //0:All (Default)；1:SBN (Shipped by Newegg)；2:SBS (Shipped by Seller)；3:Multi-Channel

                + "<OrderDateFrom>2018-12-01 09:30:47</OrderDateFrom>"

                + "<OrderDateTo>2018-12-01 09:30:47</OrderDateTo>"

                + "<OrderDownloaded>0</OrderDownloaded>"

                + "</RequestCriteria>"

                + "</RequestBody>"

                + "</NeweggAPIRequest>";


                //byte[] byteStr = requestStr.getBytes();

                byte[] byteStr = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = byteStr.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(byteStr, 0, byteStr.Length);
                }

                //Parse the response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        //获得接口返回结果
                        string OrdersInfoStr = StreamToStr(responseStream);
                        //转为xml
                        StringReader Reader = new StringReader(OrdersInfoStr);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Reader);

                        //反序列化为类
                        NeweggAPIResponse ordersInfo = DESerializer<NeweggAPIResponse>(OrdersInfoStr);
                        return ordersInfo;
                    }
                }
            }
            catch (WebException we)//Error Handling for Bad Request
            {
                if (((WebException)we).Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse errResp = ((WebException)we).Response; using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream); Console.WriteLine(String.Format("{0}", reader.ReadToEnd()));
                    }
                }
                return null;
            }
            catch (Exception ex)//unhandle error
            {
                return null;
            }
        }

        //按时间段 调用API接口，获取订单信息
        private static NeweggAPIResponse GetOrders(int PageIndex, int PageSize, DateTime OrderDateFrom, DateTime OrderDateTo)
        {
            try
            {
                //Determine the correct Newegg Marketplace API endpoint to use.

                // Please make sure your request URL is all in lower case 
                string endpoint = @"https://api.newegg.com/marketplace/ordermgmt/order/orderinfo?sellerid={0}";
                endpoint = String.Format(endpoint, SellerID);
                //Create an HttpWebRequest 
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(endpoint) as HttpWebRequest;

                //Remove proxy 
                request.Proxy = null;

                //Specify the request method 
                request.Method = "PUT";

                //Specify the xml/Json request and response content types. 
                request.ContentType = "application/xml";
                request.Accept = "application/xml";

                //Attach authorization information 
                request.Headers.Add("Authorization", Authorization);
                request.Headers.Add("Secretkey", SecretKey);

                //Construct the query criteria in the request body 
                //string requestBody = @"<ContentQueryCriteria><Type>1</Type><Value>9SIAGAZ7SY5852</Value></ContentQueryCriteria>";

                String requestBody = @"<NeweggAPIRequest>"

                + "<OperationType>GetOrderInfoRequest</OperationType>"

                + "<RequestBody>"

                + "<PageIndex>" + PageIndex + "</PageIndex>"

                + "<PageSize>" + PageSize + "</PageSize>"

                + "<RequestCriteria>"

                //+ "<OrderNumberList>"

                //+ "<OrderNumber>449309111</OrderNumber>"

                //+ "<OrderNumber>425684294</OrderNumber>"

                //+ "</OrderNumberList>"

                //+ "<Status>1</Status>" //0:Unshipped；1:Partially Shipped；2:Shipped；3:Invoiced；4:Voided

                + "<Type>0</Type>" //0:All (Default)；1:SBN (Shipped by Newegg)；2:SBS (Shipped by Seller)；3:Multi-Channel

                + "<OrderDateFrom>" + OrderDateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "</OrderDateFrom>"

                + "<OrderDateTo>" + OrderDateTo.ToString("yyyy-MM-dd HH:mm:ss") + "</OrderDateTo>"

                + "<OrderDownloaded>0</OrderDownloaded>"

                + "</RequestCriteria>"

                + "</RequestBody>"

                + "</NeweggAPIRequest>";


                //byte[] byteStr = requestStr.getBytes();

                byte[] byteStr = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = byteStr.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(byteStr, 0, byteStr.Length);
                }

                //Parse the response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        //获得接口返回结果
                        string OrdersInfoStr = StreamToStr(responseStream);
                        //转为xml
                        StringReader Reader = new StringReader(OrdersInfoStr);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Reader);

                        //反序列化为类
                        NeweggAPIResponse ordersInfo = DESerializer<NeweggAPIResponse>(OrdersInfoStr);
                        return ordersInfo;
                    }
                }
            }
            catch (WebException we)//Error Handling for Bad Request
            {
                if (((WebException)we).Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse errResp = ((WebException)we).Response; using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream); Console.WriteLine(String.Format("{0}", reader.ReadToEnd()));
                    }
                }
                return null;
            }
            catch (Exception ex)//unhandle error
            {
                return null;
            }
        }


        /// <summary>
        /// 获取订单最新状态
        /// </summary>
        /// <param name="OrderNumber">订单号</param>
        /// <returns></returns>
        public QueryOrderStatusInfo GetOrderStatusInfo(string OrderNumber)
        {
            try
            {
                //Determine the correct Newegg Marketplace API endpoint to use.

                // Please make sure your request URL is all in lower case 
                string endpoint = @"https://api.newegg.com/marketplace/ordermgmt/orderstatus/orders/{0}?sellerid={1}";
                endpoint = String.Format(endpoint, OrderNumber, SellerID);

                //Create an HttpWebRequest 
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(endpoint) as HttpWebRequest;

                //Remove proxy 
                request.Proxy = null;

                //Specify the request method 
                request.Method = "GET";

                //Specify the xml/Json request and response content types. 
                request.ContentType = "application/xml";
                request.Accept = "application/xml";

                //Attach authorization information 
                request.Headers.Add("Authorization", Authorization);
                request.Headers.Add("Secretkey", SecretKey);

                //Construct the query criteria in the request body 
                //string requestBody = @"<ContentQueryCriteria><Type>1</Type><Value>9SIAGAZ7SY5852</Value></ContentQueryCriteria>";

                //String requestBody = @"";

                //byte[] byteStr = Encoding.UTF8.GetBytes(requestBody);
                //request.ContentLength = byteStr.Length;

                //using (Stream stream = request.GetRequestStream())
                //{
                //    stream.Write(byteStr, 0, byteStr.Length);
                //}

                //Parse the response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        //获得接口返回结果
                        string OrdersStatusInfoStr = StreamToStr(responseStream);
                        //转为xml
                        StringReader Reader = new StringReader(OrdersStatusInfoStr);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Reader);

                        //反序列化为类
                        QueryOrderStatusInfo ordersStatusInfo = DESerializer<QueryOrderStatusInfo>(OrdersStatusInfoStr);
                        return ordersStatusInfo;
                    }
                }

                //string sellerID = inventoryResult.SellerID; 
                //string itemNumber = inventoryResult.ItemNumber;
                //int availableQuantity = inventoryResult.AvailableQuantity;

                //string message = String.Format("SellerID:{0} ItemNumber:{1} Availble Quantity:{2} \r\n Active:{3} SellerPartNumber:{4} ShipByNewegg:{5}",
                //inventoryResult.SellerID, inventoryResult.ItemNumber, inventoryResult.AvailableQuantity, inventoryResult.Active, inventoryResult.SellerPartNumber, inventoryResult.ShipByNewegg);

            }
            catch (WebException we)//Error Handling for Bad Request
            {
                if (((WebException)we).Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse errResp = ((WebException)we).Response; using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream); Console.WriteLine(String.Format("{0}", reader.ReadToEnd()));
                    }
                }
                return null;
            }
            catch (Exception ex)//unhandle error
            {
                return null;
            }
        }

        /// <summary>
        /// 新蛋： 调用API接口，同步订单发货信息 到店铺后台
        /// </summary>
        /// <param name="OrderNumber">活石ERP订单信息</param>
        /// <param name="TrackingNumber">快递单号</param>
        /// <param name="ShipCarrier">快递公司</param>
        /// <param name="ShipService">快递服务</param>
        /// <returns></returns>
        public UpdateOrderStatusInfo updateOrderShopInfo(StandardOrderEgg standardOrder, string TrackingNumber, string ShipCarrier, string ShipService)
        {
            try
            {
                //Determine the correct Newegg Marketplace API endpoint to use.

                // Please make sure your request URL is all in lower case 
                string endpoint = @"https://api.newegg.com/marketplace/ordermgmt/orderstatus/orders/{0}?sellerid={1}";
                endpoint = String.Format(endpoint, standardOrder.PlatformOrderID, SellerID);

                //Create an HttpWebRequest 
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(endpoint) as HttpWebRequest;

                //Remove proxy 
                request.Proxy = null;

                //Specify the request method 
                request.Method = "PUT";

                //Specify the xml/Json request and response content types. 
                request.ContentType = "application/xml";
                request.Accept = "application/xml";

                //Attach authorization information 
                request.Headers.Add("Authorization", Authorization);
                request.Headers.Add("Secretkey", SecretKey);


                String requestBody = @"<UpdateOrderStatus>"

                + "<Action>2</Action>"

                + "<Value>"

                + "<![CDATA["

                + "<Shipment>"

                + "<Header>"

                + "<SellerID>" + SellerID + "</SellerID>"

                + "<SONumber>" + standardOrder.PlatformOrderID + "</SONumber>"

                + "</Header>"

                + "<PackageList>"

                + "<Package>"

                + "<TrackingNumber>" + TrackingNumber + "</TrackingNumber>"

                + "<ShipCarrier>" + ShipCarrier + "</ShipCarrier>"

                + "<ShipService>" + ShipService + "</ShipService>"

                + "<ItemList>";

                //累加商品信息
                for (int i = 0; i < standardOrder.Detail.Count(); i++)
                {
                    requestBody = requestBody + "<Item>";

                    requestBody = requestBody + "<SellerPartNumber>" + standardOrder.Detail.ToList()[i].SellerSku + "</SellerPartNumber>";

                    requestBody = requestBody + "<ShippedQty>" + standardOrder.Detail.ToList()[i].Quantity + "</ShippedQty>";

                    requestBody = requestBody + "</Item>";
                }

                requestBody = requestBody + "</ItemList>"

                + "</Package>"

                + "</PackageList>"

                + "</Shipment>"

                + "]]>"

                + "</Value>"

                + "</UpdateOrderStatus>";


                byte[] byteStr = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = byteStr.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(byteStr, 0, byteStr.Length);
                }

                //Parse the response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("接口调用失败") ;
                    }

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        //获得接口返回结果
                        string OrdersInfoStr = StreamToStr(responseStream);
                        //转为xml
                        StringReader Reader = new StringReader(OrdersInfoStr);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Reader);

                        //反序列化为类
                        UpdateOrderStatusInfo ordersInfo = DESerializer<UpdateOrderStatusInfo>(OrdersInfoStr);
                        return ordersInfo;
                    }
                }
            }
            catch (WebException we)//Error Handling for Bad Request
            {
                var errorMsg = "";
                if (((WebException)we).Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse errResp = ((WebException)we).Response; using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream);
                        errorMsg = String.Format("{0}", reader.ReadToEnd());
                        Console.WriteLine(errorMsg);
                    }
                }
                if (errorMsg.IndexOf("SO011") != -1)
                {
                    UpdateOrderStatusInfo result = new UpdateOrderStatusInfo();
                    result.IsSuccess = UpdateOrderStatusInfoIsSuccess.@true;
                    return result;
                }
                else
                {
                    throw new Exception(errorMsg);
                }
            }
            catch (Exception ex)//unhandle error
            {
                throw ex;
            }
        }

        #endregion

        #region 转换字符格式

        //Stream转化为xml
        public static string StreamToStr(Stream stream)
        {
            byte[] byteFile = null;
            List<byte> bytes = new List<byte>();
            int temp = stream.ReadByte();
            while (temp != -1)
            {
                bytes.Add((byte)temp);
                temp = stream.ReadByte();
            }
            byteFile = bytes.ToArray();
            string str = System.Text.Encoding.Default.GetString(byteFile);
            return str;
        }

        //反序列化
        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
