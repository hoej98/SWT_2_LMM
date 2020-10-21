using NUnit.Framework;
using Ladeskab;
using System;

namespace LadeskabTest
{
    [TestFixture]

    public class TestLadeskab
    {

#region DisplayTest
        [Test]
        public void ShowConnectPhone_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showConnectPhone();

            //uut.Add(7, 17);

            //Assert
            Assert.That(uut.msg == "Tilslut din telefon");
        }

        [Test]
        public void ShowInputRfid_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showInputRfid();

            //uut.Add(7, 17);

            //Assert
            Assert.That(uut.msg == "Tryk 'R' for at indtaste RFID");
        }

        [Test]
        public void ShowRFIDError_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showRFIDError();

            //uut.Add(7, 17);

            //Assert
            Assert.That(uut.msg == "Forkert RFID tag");
        }

        [Test]
        public void ShowRemovePhone_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showRemovePhone();

            //uut.Add(7, 17);

            //Assert
            Assert.That(uut.msg == "Tag din telefon ud af skabet og luk døren");
        }

        [Test]
        public void ShowConnectionError_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showConnectionError();

            //uut.Add(7, 17);

            //Assert
            Assert.That(uut.msg == "Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }

        [Test]
        public void ShowConfirmation_IsCorrect()
        {
            // arrange
            var uut = new Display();

            //act
            uut.showConfirmation();

            //uut.Add(7, 17);

            //Assert
            Assert.That(uut.msg == "Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        #endregion

#region DoorTest
        [Test]
        public void OnDoorOpen_IsCorrect()
        {
            // arrange
            var uut = new Door();

            //act
            //uut.showConnectPhone();

            //Assert
            //Assert.That(uut.msg == "Tilslut din telefon");
        }
        #endregion

    }
}