using NUnit.Framework;
using Ladeskab;
using System;
using RFIDInterface;

namespace LadeskabTest
{
    [TestFixture]
    public class TestRFIDReader
    {
        // Not Finished
        #region RFIDReaderTest
        [Test]
        public void OnRfidRead_EventFired()
        {
            // arrange
            var uut = new RFIDReader();
            RFIDEventArgs receivedEventArgs = null;

            uut.RFIDChangedEvent +=
                (o, args) =>
                {
                    receivedEventArgs = args;
                };

            //act
            uut.OnRfidRead();

            //Assert
            Assert.That(receivedEventArgs, Is.Not.Null);
        }


        #endregion
    }
}