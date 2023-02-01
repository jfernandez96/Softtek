using Newtonsoft.Json;
using Softtek.Common;
using Softtek.Domain.Dto;
using Softtek.Domain;

namespace Softtek.Web.DynamicClient
{
    public class CommercialClient
    {
        IConfiguration _configuration = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .Build();

        public SaleDto GetUser(UserLogins itemRequest)
        {

            UserDTO? result = new UserDTO();
            #region [Invoke WS]
            #region [Request]

            string sUrlWebService = _configuration.GetValue<string>("UriService") + "Segurity/GetUser";
            var wsHeaderRequest = BaseClient.PostHeaderRequest(sUrlWebService, "");
            #endregion

            var resultService = BaseClient.PostServiceClient(wsHeaderRequest, itemRequest);
            #endregion

            #region [Deserialize]
            if (resultService.ErrorCode == (int)Enumeradores.ResponseCode.ErrorCodeControlled)
                throw new Exception(resultService.ErrorDescription);
            else
                result = JsonConvert.DeserializeObject<UserDTO>(resultService.ErrorDescription);
            #endregion

            return result;
        }
    }
}
