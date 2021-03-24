using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class Account
    {
        public Account()
        {
            ScheduledTransaction = new HashSet<ScheduledTransaction>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Tenant { get; set; }
        public string AccountNumber1 { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<ScheduledTransaction> ScheduledTransaction { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
