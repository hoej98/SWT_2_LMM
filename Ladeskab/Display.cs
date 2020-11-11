using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Ladeskab
{
    public class Display : IDisplay
    {
        public void showConnectPhone()
        {
            Console.WriteLine("Tilslut din telefon");
        }

        public void showInputRfid()
        {
            Console.WriteLine("Tryk 'R' for at indtaste RFID");
        }

        public void showRFIDError()
        {
            Console.WriteLine("Forkert RFID tag");
        }

        public void showRemovePhone()
        {
            Console.WriteLine("Tag din telefon ud af skabet og luk døren");
        }

        public void showConnectionError()
        {
            Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }

        public void showConfirmation()
        {
            Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op og 'Enter' for at se status");
        }

        public void showChargerNotConnected()
        {
            Console.WriteLine("Ingen telefon tilsluttet.");
        }

        public void showChargerFullyCharged()
        {
            Console.WriteLine("Telefonen er ladt fuldt op. Fjern den venligst fra opladeren.");
        }

        public void showChargerChargingNormal()
        {
            Console.WriteLine("Telefon lader op.");
        }

        public void showChargerError()
        {
            Console.WriteLine("Fejl i opladning.");
        }
    }
}
