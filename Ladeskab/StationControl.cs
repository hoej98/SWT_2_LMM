using DoorInterface;
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
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variableeee
        public LadeskabState _state { get; set; }

        private IUsbCharger _charger;
        private IDisplay _display;
        private IDoor _door = new Door();
        private ILog _log = new Log("logfile.txt");

        private int _oldId;

        public StationControl(IDoor door, IRFID rfid, IUsbCharger Usb, IDisplay Display)
        {
            door.DoorChangedEvent += handleDoorChanged;
            rfid.RFIDChangedEvent += handleRFIDChanged;
            this._charger = Usb;
            this._display = Display;
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

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected == true)
                    {
                        _charger.StartCharge();
                        _door.LockDoor();
                        _oldId = id;
                        _log.writeLog(id);
                        _display.showConfirmation();
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.showConnectionError();
                        _state = LadeskabState.Available;
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
                        _log.writeLog(id);
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

        // Overvågning af ladestrøm
        public void chargeSurveillance()
        {
            // Ladning ikke startet / Ingen forbindele til telefon
            if (_charger.CurrentValue == 0)
            {
                _display.showChargerNotConnected();
            }
            // Telefonen er fuldt opladt, kan frakobles
            else if (_charger.CurrentValue > 0 && _charger.CurrentValue <= 5)
            {
                _display.showChargerFullyCharged();
                _charger.StopCharge();
            }
            // Opladning foregår normalt
            else if (_charger.CurrentValue > 0 && _charger.CurrentValue <= 500)
            {
                _display.showChargerChargingNormal();
            }
            // Der er noget galt, frakoble telefon
            else if (_charger.CurrentValue > 500)
            {
                _display.showChargerError();
            }
        }
    }
}
