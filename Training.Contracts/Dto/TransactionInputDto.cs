using Training.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Contracts.Dto
{
    public class TransactionInputDto
    {
        public int AccID { get; set; }
        public decimal TransMoney { get; set; }
    }
}
