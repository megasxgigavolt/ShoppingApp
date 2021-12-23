using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AagjIeyBCRp8Wno0qywiM6JhzPJVm251gv4Sw-QoQCqoqqFLglcvVShmMZg1UzT88VD9Ge7Ux8e1dKNI";
            clientSecret = "EJ2yNgVwoapWcZdUCBs88ydbjQ-mpFyTSL7phIb_GaRZhwYTqBfn92__9TgMZe4AAdpSum-lkHM2qEEw";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}