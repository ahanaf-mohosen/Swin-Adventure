using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureGame;

namespace Tests
{
    [TestClass]
    public class LocationTests
    {
        private Location _lake;
        private Item _sword;
        private Player _me;

        [TestInitialize]
        public void Init()
        {
            _lake = new Location(new string[] { "location", "_lake" }, "_lake", "Frozen blue _lake spans across the Sivon Lands");
            _sword = new Item(new string[] { "_sword" }, "_sword", "black blade");
            _me = new Player("_me", "yes");
        }

        [TestMethod]
        public void LocationIdentifyItself()
        {
            Assert.AreEqual(_lake, _lake.Locate("_lake"));
            Assert.AreEqual(_lake, _lake.Locate("location"));
        }

        [TestMethod]
        public void LocationCanLocateItems()
        {
            _lake.Inventory.Put(_sword);
            Assert.AreEqual(_sword, _lake.Locate("_sword"));
        }

        [TestMethod]
        public void PlayerCanLocateItemsInTheirLocation()
        {
            _lake.Inventory.Put(_sword); // put _sword in _lake
            _me.Location = _lake;        // set player's location to _lake
            Assert.AreEqual(_sword, _me.Locate("_sword"));
        }

        [TestMethod]
        public void PlayersCanLocateTheirLocation()
        {
            _me.Location = _lake;
            Assert.AreEqual(_lake, _me.Locate("_lake"));
        }
    }
}
