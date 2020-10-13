using DoorInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorChangedEvent;

        public void LockDoor()
        {
        }
        public void UnlockDoor()
        {
        }
        public void OnDoorOpen()
        {
            OnDoorChanged(new DoorEventArgs { DoorOpen = true });
        }
        public void OnDoorClose()
        {
            OnDoorChanged(new DoorEventArgs { DoorOpen = false});
        }

        protected virtual void OnDoorChanged(DoorEventArgs e)
        {
            DoorChangedEvent?.Invoke(this, e);
        }

    }
}
