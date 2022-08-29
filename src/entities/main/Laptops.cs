using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace entities.main
{
    public partial class Laptops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float ScreenSize { get; set; }
        public string Resolution { get; set; }
        public int? Ram { get; set; }
        public int? Rom { get; set; }
        public decimal? Price { get; set; }
        public string Brand { get; set; }
    }
}
