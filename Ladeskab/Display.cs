using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Ladeskab
{
    public class Display : IDisplay
    {
        public string msg { get; set; }

        public void showConnectPhone()
        {
            msg = "Tilslut din telefon";
            Console.WriteLine(msg);
        }

        public void showInputRfid()
        {
            msg = "Tryk 'R' for at indtaste RFID";
            Console.WriteLine(msg);
        }

        public void showRFIDError()
        {
            msg = "Forkert RFID tag";
            Console.WriteLine(msg);
        }

        public void showRemovePhone()
        {
            msg = "Tag din telefon ud af skabet og luk døren";
            Console.WriteLine(msg);
        }

        public void showConnectionError()
        {
            msg = "Din telefon er ikke ordentlig tilsluttet. Prøv igen.";
            Console.WriteLine(msg);
        }

        public void showConfirmation()
        {
            msg = "Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op og 'Enter' for at se status";
            Console.WriteLine(msg);
        }

        public void showChargerNotConnected()
        {
            msg = "Ingen telefon tilsluttet";
            Console.WriteLine(msg);
        }

        public void showChargerFullyCharged()
        {
            msg = "Telefonen er ladt fuldt op. Fjern den venligst fra opladeren.";
            Console.WriteLine(msg);
        }

        public void showChargerChargingNormal()
        {
            msg = "Telefon lader op.";
            Console.WriteLine(msg);
        }

        public void showChargerError()
        {
            msg = "Fejl i opladning.";
            Console.WriteLine(msg);
        }
    }
}
