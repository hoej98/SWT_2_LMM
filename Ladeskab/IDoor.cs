using System;
using System.Collections.Generic;
using System.Text;

namespace DoorInterface
{

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorChangedEvent;
    }
}


