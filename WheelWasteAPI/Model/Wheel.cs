using System;
using System.Collections.Generic;

#nullable disable

namespace WheelWasteAPI.Model
{
    public partial class Wheel
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Location { get; set; }

        public virtual Device Device { get; set; }
    }
}
