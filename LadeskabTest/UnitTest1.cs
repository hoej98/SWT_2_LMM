using NUnit.Framework;
using Ladeskab;
using System;

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
        public void OnDoorOpen_IsCorrect()
        {
            // arrange
            var uut = new Door();

            //act
            //uut.showConnectPhone();

            //Assert
            //Assert.That(uut.msg == "Tilslut din telefon");
        }

    }
}