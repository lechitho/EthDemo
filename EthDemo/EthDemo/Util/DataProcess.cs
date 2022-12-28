using EthDemo.EF;
using EthDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthDemo.Util
{
    public class DataProcess
    {
        EthDemo.EF.EthDemo dbContext;
        public DataProcess()
        { 
            dbContext = new EthDemo.EF.EthDemo();
        }

        public void AddBlockRecord(BlockRecordInfoModel blockRecordInfo)
        {
            var obj = new Block { 
                blockNumber = ConvertHelper.FromHex(blockRecordInfo.BlockNumber),
                hash = blockRecordInfo.hash,
                parentHash = blockRecordInfo.ParentHash,
                miner = blockRecordInfo.Miner,
                gasLimit = ConvertHelper.FromHex(blockRecordInfo.GasLimit),
                gasUsed = ConvertHelper.FromHex(blockRecordInfo.GasUsed)
            };
            dbContext.Blocks.Add(obj);
            dbContext.SaveChanges();
        }
        public void AddBlockTransaction(BlockRecordInfoModel blockRecordInfo)
        {
            int blockNumber = ConvertHelper.FromHex(blockRecordInfo.BlockNumber);
            var objBlock = dbContext.Blocks.FirstOrDefault(x => x.blockNumber == blockNumber);
            if (objBlock != null)
            {
                foreach (var item in blockRecordInfo.Transactions)
                {
                    var obj = new Transaction
                    {
                        blockID = objBlock.blockID,
                        hash = item.Hash,
                        from = item.From,
                        to = item.To,
                        value = ConvertHelper.FromHex(item.Value),
                        gas = ConvertHelper.FromHex(item.Gas),
                        gasPrice = ConvertHelper.FromHex(item.GasPrice),
                        transactionIndex = ConvertHelper.FromHex(item.TransactionIndex)
                    };
                    dbContext.Transactions.Add(obj);
                }
            }
            dbContext.SaveChanges();
        }
    }
}
