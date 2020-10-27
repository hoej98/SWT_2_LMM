﻿using NUnit.Framework;
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
        // Finished
        #region StationControlTest

        [Test]
        public void RfidDetected_Available_ConnectedTrue_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, new Display());

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            // State changes to "locked" if the connected is true.
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }

        [Test]
        public void RfidDetected_Available_ConnectedFalse_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(false);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, new Display());

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            // State doesn't change if connected is false.
            Assert.That(uut._state == StationControl.LadeskabState.Available);
        }

        [Test]
        public void RfidDetected_Available_StartCharge_isCalled()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, new Display());

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            fakeCharger.Received().StartCharge();
        }

        [Test]
        public void RfidDetected_DoorOpen_isCorrect()
        {
            // Arrange
            var uut = new StationControl(new Door(), new RFIDReader(), new UsbChargerSimulator(), new Display());

            // Act
            uut._state = StationControl.LadeskabState.DoorOpen;
            uut.RfidDetected(1);

            // Assert
            // Doesn't do anything, state doesn't change
            Assert.That(uut._state == StationControl.LadeskabState.DoorOpen);
        }

        [Test]
        public void RfidDetected_Locked_idIsOldId_isCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, new Display());

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // State is "locked" with _oldId = 1
            Assert.That(uut._state == StationControl.LadeskabState.Locked);

            // Calling with same id, changing state to available
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

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, new Display());

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // State is "locked" with _oldId = 1
            Assert.That(uut._state == StationControl.LadeskabState.Locked);

            // Calling with different id, doesn't change state
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

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, new Display());

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // State is "locked" with _oldId = 1
            Assert.That(uut._state == StationControl.LadeskabState.Locked);

            // Calling with same id, calling StopCharge
            uut.RfidDetected(1);

            // Assert
            fakeCharger.Received().StopCharge();
        }

        [Test]
        public void handleRfidChanged_isCorrect()
        {
            // Arrange
            IRFID fakeRFIDReader = Substitute.For<IRFID>();
            var uut = new StationControl(new Door(), fakeRFIDReader, new UsbChargerSimulator(), new Display());
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
            Display fakeDisplay = Substitute.For<Display>();
            var uut = new StationControl(fakeDoor, new RFIDReader(), new UsbChargerSimulator(), fakeDisplay);

            // Act
            fakeDoor.DoorChangedEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = true});

            // Assert
            Assert.That(fakeDisplay.msgee == "Tilslut din telefon");
        }

        [Test]
        public void handleDoorChanged_DoorClosed_isCorrect()
        {
            // Arrange
            IDoor fakeDoor = Substitute.For<IDoor>();
            Display fakeDisplay = Substitute.For<Display>();
            var uut = new StationControl(fakeDoor, new RFIDReader(), new UsbChargerSimulator(), fakeDisplay);

            // Act
            fakeDoor.DoorChangedEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = false });

            // Assert
            Assert.That(fakeDisplay.msgee == "Tryk 'R' for at indtaste RFID");
        }

        #endregion
    }
}