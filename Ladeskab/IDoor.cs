using System;
using System.Collections.Generic;
using System.Text;

namespace DoorInterface
{

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorChangedEvent;

        bool _doorLocked { get; set; }

        void LockDoor();

        void UnlockDoor();

        void OnDoorOpen();

        void OnDoorClose();
    }
}


