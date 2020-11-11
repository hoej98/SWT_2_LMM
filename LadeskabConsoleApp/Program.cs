using System;
using Ladeskab;
using UsbSimulator;
using DoorInterface;
using RFIDInterface;
using UsbSimulator;


class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes
        IDoor door = new Door();
        IDisplay display = new Display();
        IRFID rfidReader = new RFIDReader();
        IUsbCharger usbCharger = new UsbChargerSimulator();
        StationControl stationControl = new StationControl(door, rfidReader, usbCharger, display);

        // Udskriver de forskellige muligheder brugeren har i starten
        System.Console.WriteLine("Indtast 'E' for 'Exit'\n" +
                                 "Indtast 'O' for 'Open door'\n" +
                                 "Indtast 'C' for 'Close door'\n" +
                                 "Indtast 'K' for 'Connect phone'\n" +
                                 "Indtast 'R' for 'RFID'");

        // Kalder chargeSurveillance hvert 5. sekund - udskriver status og stopper opladning når fuldt opladt.
        var timer = new System.Threading.Timer(
            e => stationControl.chargeSurveillance(),
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        bool finish = false;
        do
        {
            string input;
            //Console.WriteLine("Indtast E, O, C, K, R: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.OnDoorOpen();
                    break;

                case 'C':
                    door.OnDoorClose();
                    break;

                case 'K':
                    bool isconnect = usbCharger.Connected;
                    while (isconnect == false)
                    {
                        Console.WriteLine("Telefon ikke tilsluttet");
                        break;
                    }
                    Console.WriteLine("Telefon tilsluttet. Luk venligst døren");
                    break;
                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.OnRfidRead(id);
                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}

