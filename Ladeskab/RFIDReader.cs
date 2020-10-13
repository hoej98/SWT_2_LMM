using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    class RFIDReader
    {
        public StationControl _stationControl = new StationControl();
        public void OnRfidRead(int id)
        {
            _stationControl.RfidDetected(id);
        }
    }
}
