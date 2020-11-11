using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public interface IDisplay
    {
        public string msg { get; set; }

        public void showConnectPhone();

        public void showInputRfid();

        public void showRFIDError();

        public void showRemovePhone();

        public void showConnectionError();

        public void showConfirmation();

        public void showChargerNotConnected();

        public void showChargerFullyCharged();

        public void showChargerChargingNormal();

        public void showChargerError();
    }
}
