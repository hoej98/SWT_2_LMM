using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    class Door
    {
        private StationControl _stationControl = new StationControl();
        public void LockDoor()
        {
            Console.WriteLine("Vi er lort");
        }
        public void UnlockDoor()
        {
        }
        public void OnDoorOpen()
        {
            _stationControl.DoorOpened();
        }
        public void OnDoorClose()
        {
            _stationControl.DoorClosed();
        }

    }
}
