using DoorInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    // Interface for IDoor
    public class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorChangedEvent;
        public bool _doorLocked { get; set; }

        public void LockDoor()
        {
            _doorLocked = true;
        }
        public void UnlockDoor()
        {
            _doorLocked = false;
        }
        public void OnDoorOpen()
        {
            OnDoorChanged(new DoorEventArgs { DoorOpen = true });
        }
        public void OnDoorClose()
        {
            OnDoorChanged(new DoorEventArgs { DoorOpen = false });
        }

        protected virtual void OnDoorChanged(DoorEventArgs e)
        {
            DoorChangedEvent?.Invoke(this, e);
        }

    }
}
