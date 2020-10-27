using NUnit.Framework;
using Ladeskab;
using System;
using System.ComponentModel;
using DoorInterface;
using Moq;

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
            // Arrange
            var uut = new Door();
            DoorEventArgs receivedEventArgs = null;

            uut.DoorChangedEvent +=
                (o, args) =>
                {
                    receivedEventArgs = args;
                };

            // Act
            uut.OnDoorClose();

            // Assert
            Assert.That(receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void LockDoor_IsCorrect()
        {
            // Arrange
            IDoor uut = new Door();

            // Act
            uut.LockDoor();

            // Assert
            Assert.That(uut._doorLocked == true);
        }

        [Test]
        public void UnlockDoor_IsCorrect()
        {
            // Arrange
            var uut = new Door();

            // Act
            uut.UnlockDoor();

            // Assert
            Assert.That(uut._doorLocked == false);
        }
        #endregion
    }
}

//tester jenkins123