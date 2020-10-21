using NUnit.Framework;
using Ladeskab;
using System;
using DoorInterface;

namespace LadeskabTest
{
    [TestFixture]

    public class TestLadeskab
    {
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
        public void OnDoorOpen_EventFired()
        {
            // arrange
            var uut = new Door();
            DoorEventArgs receivedEventArgs = null;

            uut.DoorChangedEvent +=
                (o, args) =>
                {
                    receivedEventArgs = args;
                };

            //act
            uut.OnDoorOpen();

            //Assert
            Assert.That(receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void OnDoorClose_EventFired()
        {
            // arrange
            var uut = new Door();
            DoorEventArgs receivedEventArgs = null;

            uut.DoorChangedEvent +=
                (o, args) =>
                {
                    receivedEventArgs = args;
                };

            //act
            uut.OnDoorClose();

            //Assert
            Assert.That(receivedEventArgs, Is.Not.Null);
        }

    }
}