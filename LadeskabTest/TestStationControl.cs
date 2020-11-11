using NUnit.Framework;
using Ladeskab;
using System;
using System.Linq.Expressions;
using DoorInterface;
using RFIDInterface;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using UsbSimulator;
using NSubstitute;
using NSubstitute.Exceptions;
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
            // Call with id = 1
            uut.RfidDetected(1);

            // State is "locked" with _oldId = 1
            Assert.That(uut._state == StationControl.LadeskabState.Locked);

            // Calling with same id, unlocking and changing state to available
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

            // Calling with different id, stays locked and doesn't change state
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
            IDisplay fakeDisplay = Substitute.For<IDisplay>();
            var uut = new StationControl(fakeDoor, new RFIDReader(), new UsbChargerSimulator(), fakeDisplay);

            // Act
            fakeDoor.DoorChangedEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = true});

            // Assert
            fakeDisplay.Received().showConnectPhone();
        }

        [Test]
        public void handleDoorChanged_DoorClosed_isCorrect()
        {
            // Arrange
            IDoor fakeDoor = Substitute.For<IDoor>();
            IDisplay fakeDisplay = Substitute.For<IDisplay>();
            var uut = new StationControl(fakeDoor, new RFIDReader(), new UsbChargerSimulator(), fakeDisplay);

            // Act
            fakeDoor.DoorChangedEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = false });

            // Assert
            fakeDisplay.Received().showInputRfid();
        }

        [Test]
        public void chargerSurveillance_ValueIsZero_IsCorrect()
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.CurrentValue.Returns(0);
            IDisplay fakeDisplay = Substitute.For<IDisplay>();

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, fakeDisplay);

            // Act
            uut.chargeSurveillance();

            // Assert
            fakeDisplay.Received().showChargerNotConnected();
        }

        [TestCase(1)]
        [TestCase(3.5)]
        [TestCase(5)]
        public void chargerSurveillance_ValueLessThanFive_IsCorrect(double value)
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.CurrentValue.Returns(value);
            IDisplay fakeDisplay = Substitute.For<IDisplay>();

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, fakeDisplay);

            // Act
            uut.chargeSurveillance();

            // Assert
            fakeDisplay.Received().showChargerFullyCharged();
        }

        [TestCase(6.00)]
        [TestCase(250.05)]
        [TestCase(500.00)]
        public void chargerSurveillance_ValueLessThanFiveHundred_IsCorrect(double value)
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.CurrentValue.Returns(value);
            IDisplay fakeDisplay = Substitute.For<IDisplay>();

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, fakeDisplay);

            // Act
            uut.chargeSurveillance();

            // Assert
            fakeDisplay.Received().showChargerChargingNormal();
        }

        [TestCase(500.01)]
        [TestCase(750)]
        [TestCase(1000)]
        public void chargerSurveillance_ValueOverFiveHundred_IsCorrect(double value)
        {
            // Arrange
            IUsbCharger fakeCharger = Substitute.For<IUsbCharger>();
            fakeCharger.CurrentValue.Returns(value);
            IDisplay fakeDisplay = Substitute.For<IDisplay>();

            var uut = new StationControl(new Door(), new RFIDReader(), fakeCharger, fakeDisplay);

            // Act
            uut.chargeSurveillance();

            // Assert
            fakeDisplay.Received().showChargerError();
        }

        #endregion
    }
}