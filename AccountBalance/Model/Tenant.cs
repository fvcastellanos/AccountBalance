using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public byte Active { get; set; }
    }
}
