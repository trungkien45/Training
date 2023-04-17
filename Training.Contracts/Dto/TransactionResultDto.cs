using Training.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Contracts.Dto
{
    public class TransactionResultDto
    {
        public int TransID { get; set; }
        public int AccID { get; set; }
        public string UserName { get; set; }
        public string AccountFullName { get; set; }
        public decimal TransMoney { get; set; }
        public decimal Balance { get; set; }
        public TransType TransType { get; set; }
        public DateTime DateOfTrans { get; set; }
    }
}
