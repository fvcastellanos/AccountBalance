using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string ImagePath { get; set; }
        public string Tenant { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
