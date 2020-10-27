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
            msgee = "Tilslut din telefon";
            Console.WriteLine(msgee);
        }

        public void showInputRfid()
        {
            msgee = "Tryk 'R' for at indtaste RFID";
            Console.WriteLine(msgee);
        }

        public void showRFIDError()
        {
            msgee = "Forkert RFID tag";
            Console.WriteLine(msgee);
        }

        public void showRemovePhone()
        {
            msgee = "Tag din telefon ud af skabet og luk døren";
            Console.WriteLine(msgee);
        }

        public void showConnectionError()
        {
            msgee = "Din telefon er ikke ordentlig tilsluttet. Prøv igen.";
            Console.WriteLine(msgee);
        }

        public void showConfirmation()
        {
            msgee = "Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.";
            Console.WriteLine(msgee);
        }
    }
}
