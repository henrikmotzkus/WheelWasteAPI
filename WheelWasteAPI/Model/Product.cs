using System;
using System.Collections.Generic;

#nullable disable

namespace WheelWasteAPI.Model
{
    public partial class Product
    {
        public Product()
        {
            WheelWasteCollectionData = new HashSet<WheelWasteCollectionDatum>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WheelWasteCollectionDatum> WheelWasteCollectionData { get; set; }
    }
}
