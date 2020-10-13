using System;
using System.Collections.Generic;
using System.Text;

namespace DoorInterface
{

    public class DoorEventArgs : EventArgs
    {
        public bool DoorOpen { get; set; }
}

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorChangedEvent;
    }
}


