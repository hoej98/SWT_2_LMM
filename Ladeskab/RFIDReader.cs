using RFIDInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class RFIDReader : IRFID
    {
        public event EventHandler<RFIDEventArgs> RFIDChangedEvent;
        public void OnRfidRead(int id)
        {
            OnRFIDChanged(new RFIDEventArgs { RFID_ID = id });
        }

        protected virtual void OnRFIDChanged(RFIDEventArgs e)
        {
            RFIDChangedEvent?.Invoke(this, e);
        }
    }
}