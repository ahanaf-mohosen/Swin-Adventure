using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame;

namespace Tests
{
    [TestClass]
    public class BagTests
    {
        Item sword;
        Item shovel;

        [TestInitialize]
        public void Setup()
        {
            sword = new Item(new string[] { "sword" }, "sword", "black blade");
            shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");
        }

        [TestMethod]
        public void LocatesItems()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");
            bag.Inventory.Put(sword);

            Assert.AreEqual(sword, bag.Locate(sword.FirstId()));
            Assert.IsTrue(bag.Inventory.HasItem(sword.FirstId()));
        }

        [TestMethod]
        public void LocatesItself()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");

            Assert.AreEqual(bag, bag.Locate("hahalol"));
        }

        [TestMethod]
        public void LocatesNothing()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");

            Assert.IsNull(bag.Locate("sadfasdfsdafasdf"));
        }

        [TestMethod]
        public void FullDescription()
        {
            Bag bag = new Bag(new string[] { "hahalol" }, "lol", "this yeah woah yeah");

            bag.Inventory.Put(sword);
            bag.Inventory.Put(shovel);

            string expected = $"In the {bag.Name} you can see:\n\ta {sword.FirstId()} ({sword.Name})" +
                              "\n\t" +
                              $"a {shovel.FirstId()} ({shovel.Name})";

            Assert.AreEqual(expected, bag.FullDescription);
        }

        [TestMethod]
        public void BagInBag()
        {
            Bag bag1 = new Bag(new string[] { "bag1" }, "bag1", "red bag");
            Bag bag2 = new Bag(new string[] { "bag2" }, "bag2", "blue bag");

            bag2.Inventory.Put(shovel);
            bag1.Inventory.Put(bag2);

            // Bag 1 can locate bag 2
            Assert.AreEqual(bag2, bag1.Locate("bag2"));

            // Bag1 can locate items directly in it
            bag1.Inventory.Put(sword);
            Assert.AreEqual(sword, bag1.Locate(sword.FirstId()));

            // Bag1 cannot locate items inside bag2
            Assert.IsNull(bag1.Locate(shovel.FirstId()));
        }
    }
}
