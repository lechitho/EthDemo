using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthDemo.Model
{
    public class BlockResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }
        [JsonProperty("result")]
        public object Result { get; set; }
    }
}
