using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthDemo.Model
{
    public class BlockRequestModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; } // "eth_getBlockByNumber"
        [JsonProperty("params")]
        public object[] Params { get; set; }
    }
}
