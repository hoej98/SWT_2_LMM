using NUnit.Framework;
using Ladeskab;
using System;
using UsbSimulator;
using NSubstitute;

namespace LadeskabTest
{
    [TestFixture]
    public class TestStationControl
    {
        //Not Finished

        #region StationControlTest

        //[Test]
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
        public void RfidDetected_Available_ConnectedTrue_isCorrectFAKES()
        {
            // Arrange
            IUsbCharger fake = Substitute.For<IUsbCharger>();
            fake.Connected.Returns(true);

            var uut = new StationControl(new Door(), new RFIDReader(), fake);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }

        [Test]
        public void RfidDetected_Available_ConnectedFalse_isCorrectFAKES()
        {
            // Arrange
            IUsbCharger fake = Substitute.For<IUsbCharger>();
            fake.Connected.Returns(false);

            var uut = new StationControl(new Door(), new RFIDReader(), fake);

            // Act
            uut._state = StationControl.LadeskabState.Available;
            uut.RfidDetected(1);

            // Assert
            Assert.That(uut._state == StationControl.LadeskabState.Locked);
        }
        #endregion
    }
}