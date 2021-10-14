using System;
using System.Collections.Generic;

#nullable disable

namespace WheelWasteAPI.Model
{
    public partial class WheelWasteCollectionDatum
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int DeviceId { get; set; }
        public int ProductId { get; set; }

        public virtual Device Device { get; set; }
        public virtual Product Product { get; set; }
    }
}
