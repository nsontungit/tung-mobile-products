using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace entities.main
{
    public partial class Option
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? Active { get; set; }
    }
}
