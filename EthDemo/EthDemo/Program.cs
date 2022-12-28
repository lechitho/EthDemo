using EthDemo.IntegrateApi;
using EthDemo.Model;
using EthDemo.Util;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EthDemo
{
    static class Program
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            var api = new BlockChanInfo();
            var data = new DataProcess();
            for (int i = 12100001; i < 12100500; i++)
            {
                var objGetBlockByNumber = new BlockRequestModel
                {
                    Id = 1,
                    JsonRpc = "2.0",
                    Method = "eth_getBlockByNumber",
                    Params = new object[] { ConvertHelper.ToHex(i), true } //"0xa1c054"
                };
                log.Info("call api eth_getBlockByNumber");
                var blockInfo = api.GetBlockByNumberAsync(objGetBlockByNumber);
                if (blockInfo != null)
                {
                    BlockRecordInfoModel blockRecordInfo = JsonConvert.DeserializeObject<BlockRecordInfoModel>(blockInfo.Result.ToString());
                    data.AddBlockRecord(blockRecordInfo);
                    var objBlockTransaction = new BlockRequestModel
                    {
                        Id = 1,
                        JsonRpc = "2.0",
                        Method = "eth_getBlockTransactionCountByNumber",
                        Params = new object[] { ConvertHelper.ToHex(i) }
                    };
                    log.Info("call api eth_getBlockTransactionCountByNumber");
                    var transactionCount = api.GetBlockTransactionCountByNumber(objBlockTransaction);
                    if (transactionCount != 0) 
                    {
                        data.AddBlockTransaction(blockRecordInfo);
                    }

                }
            }

            Console.WriteLine("Closing in 3 sec.");
            Thread.Sleep(1000);
            Console.WriteLine("Closing in 2 sec.");
            Thread.Sleep(1000);
            Console.WriteLine("Goodbye.");
            Thread.Sleep(500);
        }
    }
}
