using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryAss4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManadatoryAssignment1;

namespace MandatoryAss4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        private static readonly FootballPlayersManager _manager = new FootballPlayersManager();
        private FootballPlayer correctPlayer1 = new FootballPlayer() { Id = 1, Age = 21, Name = "Laudrup", ShirtNumber = 12 };
        private FootballPlayer correctPlayer2 = new FootballPlayer() { Id = 2, Age = 45, Name = "Mikkelsen", ShirtNumber = 9 };
        private FootballPlayer invalidPlayer1 = new FootballPlayer() { Id = 3, Age = -1, Name = "Hansen", ShirtNumber = 10 };

        [TestMethod()]
        public void AddTest()
        {
            //Act. Adding valid player.
            int count = _manager.GetAll().Count;
            _manager.Add(correctPlayer1);
            //Assert. FootballPlayer with name "Laudrup" is added to List and length of list increased to 5.
            Assert.AreEqual("Laudrup", _manager.GetAll()[4].Name);
            Assert.AreEqual(5, _manager.GetAll().Count);

            //Testing that Validate() in Update() throws exception when FootballPlayer is invalid.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _manager.Update(1, invalidPlayer1));
        }
        [TestMethod()]
        public void UpdateTest()
        {
            //Act. Update existing FootballPlayer.
            _manager.Update(4, correctPlayer2);
            //Assert
            Assert.AreEqual("Mikkelsen", _manager.GetById(4).Name);

            //Act. Id out of range
            var player = _manager.Update(999, correctPlayer1);

            //Assert
            Assert.IsNull(player);

            //Test that FootballPlayer throws exception and existing FootballPlayer is unchanged.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _manager.Update(2, invalidPlayer1));
            Assert.AreNotEqual(invalidPlayer1.Name, _manager.GetById(2));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //Act
            var player = _manager.GetById(1);

            //Assert
            Assert.AreEqual("Laudrup", player.Name);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<FootballPlayer> testList = _manager.GetAll();

            Assert.IsNotNull(testList);
            Assert.IsInstanceOfType(testList, typeof(List<FootballPlayer>));
        }
    }
}