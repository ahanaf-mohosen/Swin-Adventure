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
    public class PlayerTests
    {
        [TestMethod]
        public void Identifiable()
        {
            Player me = new Player("me", "yes");
            Assert.IsTrue(me.AreYou("me"));
            Assert.IsTrue(me.AreYou("inventory"));
        }

        [TestMethod]
        public void LocateItems()
        {
            Player me = new Player("me", "yes");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            me.Inventory.Put(sword);
            Assert.AreEqual(sword, me.Locate(sword.FirstId()));
        }

        [TestMethod]
        public void LocateThemselves()
        {
            Player me = new Player("me", "yes");
            Assert.AreEqual(me, me.Locate("me"));
            Assert.AreEqual(me, me.Locate("inventory"));
        }

        [TestMethod]
        public void LocateNothing()
        {
            Player me = new Player("me", "yes");
            Assert.IsNull(me.Locate("hahahahahhaha"));
        }

        [TestMethod]
        public void FullDescription()
        {
            Player me = new Player("me", "yes");
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");

            me.Inventory.Put(sword);
            me.Inventory.Put(shovel);

            Assert.AreEqual($"You are carrying:\n\ta {sword.FirstId()} ({sword.Name})\n\ta {shovel.FirstId()} ({shovel.Name})",
                            me.FullDescription);
        }
    }
}
