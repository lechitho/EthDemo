using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthDemo.Model
{
    public class BlockTransactionModel
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }
        [JsonProperty("blockNumber")]
        public string BlockNumber { get; set; }
        [JsonProperty("hash")]
        public string Hash { get; set; }
        [JsonProperty("chainId")]
        public string ChainId { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("gas")]
        public string Gas { get; set; }
        [JsonProperty("gasPrice")]
        public string GasPrice { get; set; }
        [JsonProperty("transactionIndex")]
        public string TransactionIndex { get; set; }
    }
}
