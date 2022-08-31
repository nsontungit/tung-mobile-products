using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace core.models
{
    public class LaptopDto
    {
        [Required]
        public string Name { get; set; }
        public float ScreenSize { get; set; }
        public string Resolution { get; set; }
        public int? Ram { get; set; }
        public int? Rom { get; set; }
        public decimal? Price { get; set; }
        public string Brand { get; set; }
    }
}
