using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EthDemo.Model;
using Newtonsoft.Json;
using EthDemo.Util;

namespace EthDemo.IntegrateApi
{
    public class BlockChanInfo
    {
        private readonly string alchemyAPIUri = ConfigurationManager.AppSettings["AlchemyAPIURL"];
        private readonly string alchemyKey = ConfigurationManager.AppSettings["AlchemyKey"];
        public BlockResponseModel GetBlockByNumberAsync(BlockRequestModel blockRequest)
        {
            BlockResponseModel result = null;
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(blockRequest);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{alchemyAPIUri}{alchemyKey}"),
                Headers = { { "accept", "application/json" }, },
                Content = new StringContent(json)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                }
            };
            using (var response = client.SendAsync(request).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<BlockResponseModel>(jsonResponse);
                }
            }
            return result;
        }
        public int GetBlockTransactionCountByNumber(BlockRequestModel blockRequest)
        {
            int count = 0;
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(blockRequest);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{alchemyAPIUri}{alchemyKey}"),
                Headers = { { "accept", "application/json" }, },
                Content = new StringContent(json)
                { Headers = { ContentType = new MediaTypeHeaderValue("application/json") } }
            };
            using (var response = client.SendAsync(request).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    object result = JsonConvert.DeserializeObject<BlockResponseModel>(jsonResponse).Result;
                    if (!string.IsNullOrEmpty(result.ToString()))
                    {
                        count = ConvertHelper.FromHex(result.ToString());
                    }
                    
                }
            }
            return count;
        }
    }
}
