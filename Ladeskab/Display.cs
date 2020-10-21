using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class Display
    {
        public string msg;
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
