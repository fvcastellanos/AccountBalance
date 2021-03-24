using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class FlywaySchemaHistory
    {
        public int InstalledRank { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Script { get; set; }
        public int? Checksum { get; set; }
        public string InstalledBy { get; set; }
        public int ExecutionTime { get; set; }
        public bool Success { get; set; }
    }
}
