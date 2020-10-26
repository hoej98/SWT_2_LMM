using NUnit.Framework;
using Ladeskab;
using System;
using DoorInterface;
using RFIDInterface;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using UsbSimulator;
using NSubstitute;
using NSubstitute.Extensions;

namespace LadeskabTest
{
    [TestFixture]
    public class TestStationControl
    {
        //Not Finished

        #region StationControlTest

        //[Test] // UDEN FAKES
        //public void RfidDetected_stateAvailable_isCorrect()
        //{
        //    // Arrange
        //    var uut = new StationControl(new Door(), new RFIDReader(), new UsbChargerSimulator());

        //    // Act
        //    uut._charger.Connected = true;
        //    uut._state = StationControl.LadeskabState.Available;
        //    uut.RfidDetected(1);

        //    // Assert
        //    Assert.That(uut._state == StationControl.LadeskabState.Locked);
        //}


        //[Test]
        //public void RfidDetected_stateAvailable_phoneNotConnected_isCorrect()
        //{
        //    // Arrange
        //    var uut = new StationControl(new Door(), new RFIDReader(), new UsbChargerSimulator());

        //    // Act
        //    uut._charger.Connected = false;
        //    uut._state = StationControl.LadeskabState.Available;
        //    uut.RfidDetected(1);

        //    // Assert
        //    Assert.That(uut._state == StationControl.LadeskabState.Available);
        //}

        [Test]
        public void RfidDetected_Available_ConnectedTrue_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }

        [Test]
        public void RfidDetected_Available_ConnectedFalse_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(false);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Available);
        }
        #endregion

        [Test]
        public void RfidDetected_Available_StartCharge_isCalled()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            fakeCharger.Received().StartCharge();
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }

        [Test]
        public void RfidDete_DoorOpen_isCorrect()
        {
            // Arrange
            var uut = new StationControl(new Door(), new RFIDReader(), new UsbChargerSimulator());

            // Act
            uut._state = StationControl.LadeskabState.DoorOpen;
            uut.RfidDetected(1);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.DoorOpen);
        }

        [Test]
        public void RfidDetected_Locked_idIsOldId_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);
            //State er nu "locked" med _oldId 1, kalder med samme id
            uut.RfidDetected(1);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Available);
        }

        [Test]
        public void RfidDetected_Locked_idIsNotOldId_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);
            // State er nu "locked" med _oldId 1, kalder med andet id
            uut.RfidDetected(2);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }

        [Test]
        public void RfidDetected_Locked_StopCharge_isCalled()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);
            //State er nu "locked" med _oldId 1, kalder med samme id
            uut.RfidDetected(1);

            // Assert
            fakeCharger.Received().StopCharge();
            Assert.That(uut._state == StationControl.LadeskabState.Available);
        }

        [Test]
        public void handleRfidChanged_isCorrect()
        {
            // Arrange
            IRFID fakeRFIDReader = Substitute.For<IRFID>();
            var uut = new StationControl(new Door(), fakeRFIDReader, new UsbChargerSimulator());
            uut._state = StationControl.LadeskabState.Available;

            // Act
            fakeRFIDReader.RFIDChangedEvent += Raise.EventWith(new RFIDEventArgs {RFID_ID = 5});

            // Assert
            // The event change should make a call to RfidDetected, which changes state to Locked.
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }

        [Test]
        public void handleDoorChanged_DoorOpen_isCorrect()
        {
            // Arrange
            IDoor fakeDoor = Substitute.For<IDoor>();
            var uut = new StationControl(fakeDoor, new RFIDReader(), new UsbChargerSimulator());

            // Act
            fakeDoor.DoorChangedEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = true});

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }
    }
}