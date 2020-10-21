using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    class Display
    {
        public void showConnectPhone()
        {
            Console.WriteLine("Tilslut din telefon");
        }

        public void showInputRfid()
        {
            Console.WriteLine("Tryk 'R' for at intaste RFID");   
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
            Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }
    }
}
