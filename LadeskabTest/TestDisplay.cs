using NUnit.Framework;
using Ladeskab;
using System;
using System.IO;
using NSubstitute;

namespace LadeskabTest
{
    //Tests for display
    [TestFixture]
    public class TestDisplay
    {
        // Finished
        #region DisplayTest
        [Test]
        public void ShowConnectPhone_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showConnectPhone();

            // Assert - Trim() to remove \n and \r and the end of the string from the writer.
            Assert.AreEqual("Tilslut din telefon", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowInputRfid_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showInputRfid();

            // Assert
            Assert.AreEqual("Tryk 'R' for at indtaste RFID", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowRFIDError_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showRFIDError();

            // Assert
            Assert.AreEqual("Forkert RFID tag", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowRemovePhone_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showRemovePhone();

            // Assert
            Assert.AreEqual("Tag din telefon ud af skabet og luk døren", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowConnectionError_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showConnectionError();

            // Assert
            Assert.AreEqual("Din telefon er ikke ordentlig tilsluttet. Prøv igen.", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowConfirmation_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showConfirmation();

            // Assert
            Assert.AreEqual("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op",
                fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowChargerNotConnected_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showChargerNotConnected();

            // Assert
            Assert.AreEqual("Ingen telefon tilsluttet.", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowChargerFullyCharged_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showChargerFullyCharged();

            // Assert
            Assert.AreEqual("Telefonen er ladt fuldt op. Fjern den venligst fra opladeren.", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowChargerChargingNormal_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showChargerChargingNormal();

            // Assert
            Assert.AreEqual("Telefon lader op.", fakeTextWriter.ToString().Trim());
        }

        [Test]
        public void ShowChargerError_IsCorrect()
        {
            // Arrange - Makes a display-uut and sets Console to a new TextWriter, which we can compare the string to
            var uut = new Display();
            TextWriter fakeTextWriter = new StringWriter();
            Console.SetOut(fakeTextWriter);

            // Act
            uut.showChargerError();

            // Assert
            Assert.AreEqual("Fejl i opladning! Fjern straks telefonen.", fakeTextWriter.ToString().Trim());
        }
        #endregion
    }
}