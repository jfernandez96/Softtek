using log4net;
using Newtonsoft.Json;
using Softtek.Common;
using Softtek.Domain.Core;
using System;
using System.IO;
using System.Net;


namespace Softtek.Configuration.DynamicClient
{
    public class BaseClient
    {
        #region [POST]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpWebRequest PostHeaderRequest(string url, string valueToken)
        {
            #region [Force TLS 2.0]
            //ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            #endregion

            HttpWebRequest headerRequest = (HttpWebRequest)WebRequest.Create(url);
            headerRequest.ContentType = "application/json";
            headerRequest.Method = "POST";

            if (!String.IsNullOrEmpty(valueToken))
                headerRequest.Headers.Add("Authorization", "Bearer " + valueToken);

            return headerRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wsRequest"></param>
        /// <param name="itemRequest"></param>
        /// <returns></returns>
        public static BaseResponse PostServiceClient<T>(HttpWebRequest wsRequest, T itemRequest)
        {
            ILog logService = LogManager.GetLogger("GlobokasWeb");

            BaseResponse result = new BaseResponse();

            try
            {
                using (var streamWriter = new StreamWriter(wsRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(itemRequest);

                    #region [LogRegister]

                    logService.Info("EndPoint => " + wsRequest.Address.AbsoluteUri);
                    logService.Info("JSON Request => " + json);

                    #endregion

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse wsResponse = null;

                try
                {
                    wsResponse = (HttpWebResponse)wsRequest.GetResponse();
                }
                catch (WebException wex)
                {
                    wsResponse = (HttpWebResponse)wex.Response;

                    if (wsResponse == null)
                        throw new Exception(wex.GetBaseException().Message);
                }

                var sResponseJson = new StreamReader(wsResponse.GetResponseStream()).ReadToEnd();

                #region [LogRegister]
                logService.Info("JSON Response => " + sResponseJson);
                #endregion

                if (String.IsNullOrEmpty(sResponseJson))
                    throw new Exception("Response is Null");

                switch (wsResponse.StatusCode)
                {
                    case HttpStatusCode.OK:
                        result.ErrorCode = (int)Enumeradores.ResponseCode.CorrectCode;
                        result.ErrorDescription = sResponseJson;
                        break;

                    case HttpStatusCode.InternalServerError:
                        result.ErrorCode = (int)Enumeradores.ResponseCode.ErrorCodeControlled;
                        result.ErrorDescription = sResponseJson;
                        break;

                    default:
                        result.ErrorCode = (int)Enumeradores.ResponseCode.ErrorCodeApplication;
                        result.ErrorDescription = "Error in Http Status Code: " + wsResponse.StatusDescription;
                        break;
                }

                result.ErrorDescription = sResponseJson;
            }
            catch (Exception ex)
            {
                var sMessage = "Detalle => " + ex.Message;
                logService.Error(sMessage);

                result.ErrorCode = (int)Enumeradores.ResponseCode.ErrorCodeControlled;
                result.ErrorDescription = "Method: BaseClient.ServiceClient => " + ex.Message;
            }

            return result;
        }

        public static BaseResponse PostServiceClient<T>(HttpWebRequest wsRequest)
        {
            ILog logService = LogManager.GetLogger("GlobokasWeb");

            BaseResponse result = new BaseResponse();

            try
            {
                using (var streamWriter = new StreamWriter(wsRequest.GetRequestStream()))
                {
                    //string json = JsonConvert.SerializeObject(itemRequest);

                    #region [LogRegister]

                    logService.Info("EndPoint => " + wsRequest.Address.AbsoluteUri);
                    //logService.Info("JSON Request => " + json);

                    #endregion

                    //streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse wsResponse = null;

                try
                {
                    wsResponse = (HttpWebResponse)wsRequest.GetResponse();
                }
                catch (WebException wex)
                {
                    wsResponse = (HttpWebResponse)wex.Response;

                    if (wsResponse == null)
                        throw new Exception(wex.GetBaseException().Message);
                }

                var sResponseJson = new StreamReader(wsResponse.GetResponseStream()).ReadToEnd();

                #region [LogRegister]
                logService.Info("JSON Response => " + sResponseJson);
                #endregion

                if (String.IsNullOrEmpty(sResponseJson))
                    throw new Exception("Response is Null");

                switch (wsResponse.StatusCode)
                {
                    case HttpStatusCode.OK:
                        result.ErrorCode = (int)Enumeradores.ResponseCode.CorrectCode;
                        result.ErrorDescription = sResponseJson;
                        break;

                    case HttpStatusCode.InternalServerError:
                        result.ErrorCode = (int)Enumeradores.ResponseCode.ErrorCodeControlled;
                        result.ErrorDescription = sResponseJson;
                        break;

                    default:
                        result.ErrorCode = (int)Enumeradores.ResponseCode.ErrorCodeApplication;
                        result.ErrorDescription = "Error in Http Status Code: " + wsResponse.StatusDescription;
                        break;
                }

                result.ErrorDescription = sResponseJson;
            }
            catch (Exception ex)
            {
                var sMessage = "Detalle => " + ex.Message;
                logService.Error(sMessage);

                result.ErrorCode = (int)Enumeradores.ResponseCode.ErrorCodeControlled;
                result.ErrorDescription = "Method: BaseClient.ServiceClient => " + ex.Message;
            }

            return result;
        }
        #endregion

    }
}
