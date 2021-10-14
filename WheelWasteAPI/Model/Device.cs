using System;
using System.Collections.Generic;

#nullable disable

namespace WheelWasteAPI.Model
{
    public partial class Device
    {
        public Device()
        {
            WheelWasteCollectionData = new HashSet<WheelWasteCollectionDatum>();
            Wheels = new HashSet<Wheel>();
        }

        public int Id { get; set; }
        public string Serial { get; set; }

        public virtual ICollection<WheelWasteCollectionDatum> WheelWasteCollectionData { get; set; }
        public virtual ICollection<Wheel> Wheels { get; set; }
    }
}
