using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.Aggregates.Transactions
{
    public class WalletFechaTransactionAggregate
    {
        public Guid idWallet { get; set; }

        public string fecha { get; set; }
    }
}
