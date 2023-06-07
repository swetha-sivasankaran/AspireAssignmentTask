using System;
using System.Collections.Generic;

namespace Assignment.Contracts.Data.Entities{
    public partial class App
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string Developer { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
