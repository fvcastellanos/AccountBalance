using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class ScheduledTransaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public string Cron { get; set; }
        public double Amount { get; set; }
        public string Tenant { get; set; }

        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
