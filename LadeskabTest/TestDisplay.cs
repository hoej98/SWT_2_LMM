using NUnit.Framework;
using Ladeskab;
using System;

namespace LadeskabTest
{
    [TestFixture]
    public class TestDisplay
    {
        // Finished
        #region DisplayTest
        [Test]
        public void ShowConnectPhone_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showConnectPhone();

            //Assert
            Assert.That(uut.msgee == "Tilslut din telefon");
        }

        [Test]
        public void ShowInputRfid_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showInputRfid();

            //Assert
            Assert.That(uut.msgee == "Tryk 'R' for at indtaste RFID");
        }

        [Test]
        public void ShowRFIDError_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showRFIDError();

            //Assert
            Assert.That(uut.msgee == "Forkert RFID tag");
        }

        [Test]
        public void ShowRemovePhone_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showRemovePhone();

            //Assert
            Assert.That(uut.msgee == "Tag din telefon ud af skabet og luk d�ren");
        }

        [Test]
        public void ShowConnectionError_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showConnectionError();

            //Assert
            Assert.That(uut.msgee == "Din telefon er ikke ordentlig tilsluttet. Pr�v igen.");
        }

        [Test]
        public void ShowConfirmation_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showConfirmation();

            //Assert
            Assert.That(uut.msgee == "Skabet er l�st og din telefon lades. Brug dit RFID tag til at l�se op.");
        }
        #endregion
    }
}