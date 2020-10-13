using System;
using Ladeskab;
using UsbSimulator;

class Program
    {
        static void Main(string[] args)
        {
        // Assemble your system here from all the classes
        // Mikkel er idiot tester12345
        Door door = new Door();
        Display display = new Display();
        RFIDReader rfidReader = new RFIDReader();
        UsbChargerSimulator usbCharger = new UsbChargerSimulator();
        StationControl stationControl = new StationControl(door, rfidReader);

        System.Console.WriteLine("Indtast 'E' for 'Exit'\n" +
                                 "Indtast 'O' for 'Open door'\n" +
                                 "Indtast 'C' for 'Close door'\n" +
                                 "Indtast 'K' for 'Connect phone'\n" +
                                 "Indtast 'R' for 'RFID'");

        bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, K, R: ");
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
                        System.Console.WriteLine("Indtast RFID: ");
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

