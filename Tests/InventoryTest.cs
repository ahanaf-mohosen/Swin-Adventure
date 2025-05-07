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
    public class InventoryTest
    {
        [TestMethod]
        public void FindItem()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);

            Assert.IsTrue(inventory.HasItem(sword.FirstId()));
        }

        [TestMethod]
        public void NoItemFind()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);

            Assert.IsFalse(inventory.HasItem("gun"));
        }

        [TestMethod]
        public void FetchItem()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);

            // Fetching twice to verify it's not removed
            var fetched = inventory.Fetch(sword.FirstId());
            Assert.AreEqual(sword, fetched);
            Assert.IsTrue(inventory.HasItem(sword.FirstId()));
        }

        [TestMethod]
        public void TakeItem()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            inventory.Put(sword);

            // First take should return the item
            Assert.AreEqual(sword, inventory.Take(sword.FirstId()));

            // Second take should fail, item should be gone
            inventory.Take(sword.FirstId());
            Assert.IsFalse(inventory.HasItem(sword.FirstId()));
        }

        [TestMethod]
        public void ItemList()
        {
            Inventory inventory = new Inventory();
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");

            inventory.Put(sword);
            inventory.Put(shovel);

            string expected = $"\n\ta {sword.FirstId()} ({sword.Name})" +
                              "\n\t" +
                              $"a {shovel.FirstId()} ({shovel.Name})";

            Assert.AreEqual(expected, inventory.Items);
        }
    }
}
