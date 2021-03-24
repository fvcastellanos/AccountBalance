using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            ScheduledTransaction = new HashSet<ScheduledTransaction>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte Credit { get; set; }
        public string Tenant { get; set; }
        public short Active { get; set; }

        public virtual ICollection<ScheduledTransaction> ScheduledTransaction { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
