﻿using System;
using Ladeskab;
using UsbSimulator;

class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes
        Door door = new Door();
        Display display = new Display();
        RFIDReader rfidReader = new RFIDReader();
        UsbChargerSimulator usbCharger = new UsbChargerSimulator();
        StationControl stationControl = new StationControl(door, rfidReader);


        bool finish = false;
        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, K(connect phone), R: ");
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
                        Console.WriteLine("Phone not connected");
                        break;
                    }
                    Console.WriteLine("Phone connected. Please close the door");
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

