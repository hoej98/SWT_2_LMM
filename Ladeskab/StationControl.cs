﻿using DoorInterface;
using RFIDInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IUsbCharger _charger = new UsbChargerSimulator();
        private int _oldId;
        private Door _door = new Door();
        private Display _display = new Display();
        private RFIDReader _rfidReader;
        

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil
        public bool dooropen;

        public StationControl(IDoor door, IRFID rfid)
        {
            door.DoorChangedEvent += handleDoorChanged;
            rfid.RFIDChangedEvent += handleRFIDChanged;
        }

        public void handleDoorChanged(object sender, DoorEventArgs e)
        {
            if (e.DoorOpen)
            {
                doorOpenedMessage();
            }
            else
            {
                DoorClosedMessage();
            }
        }

        public void handleRFIDChanged(object sender, RFIDEventArgs e)
        {
            RfidDetected(e.RFID_ID);
           
        }
        // Her mangler constructor

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _charger.StartCharge();
                        _door.LockDoor();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        _display.showConfirmation();
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.showConnectionError();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        _display.showRemovePhone();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.showRFIDError();
                    }

                    break;
            }
        }

        public void doorOpenedMessage()
        {
            _display.showConnectPhone();
        }

        public void DoorClosedMessage()
        {
            _display.showInputRfid();
        }

    }
}
