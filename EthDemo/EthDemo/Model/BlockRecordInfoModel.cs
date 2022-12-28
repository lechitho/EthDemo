using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthDemo.Model
{
    public class BlockRecordInfoModel
    {
        [JsonProperty("number")]
        public string BlockNumber { get; set; }
        [JsonProperty("hash")]
        public string hash { get; set; }
        [JsonProperty("parentHash")]
        public string ParentHash { get; set; }
        [JsonProperty("miner")]
        public string Miner { get; set; }
        [JsonProperty("gasLimit")]
        public string GasLimit { get; set; }
        [JsonProperty("gasUsed")]
        public string GasUsed { get; set; }
        [JsonProperty("transactions")]
        public List<BlockTransactionModel> Transactions { get; set; }
    }
}
