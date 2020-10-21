using NUnit.Framework;
using Ladeskab;
using System;
using DoorInterface;

namespace LadeskabTest
{
    [TestFixture]
    public class TestDoor
    {
        // Not Finished
        #region DoorTest
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
        #endregion
    }
}

//tester jenkins123