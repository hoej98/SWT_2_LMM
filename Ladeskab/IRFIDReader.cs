using System;
using System.Collections.Generic;
using System.Text;

namespace RFIDInterface
{
    public class RFIDEventArgs : EventArgs
    {
        public int RFID_ID { get; set; }
    }

    public interface IRFID
    {
        event EventHandler<RFIDEventArgs> RFIDChangedEvent;

        void OnRfidRead(int id);
    }
}