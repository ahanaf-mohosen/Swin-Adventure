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
    public class LookCommandTests
    {
        private Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
        private Item shovel = new Item(new string[] { "bronze shovel" }, "shovel", "this is a....");
        private Item gem = new Item(new string[] { "gem" }, "shiny gem", "this is a gem :| ");

        [TestMethod]
        public void TestLookAtMe()
        {
            Player me = new Player("me", "yes");
            Look_Command look = new Look_Command();

            Assert.AreEqual(me.FullDescription, look.Execute(me, new string[] { "look", "at", "inventory" }));
        }

        [TestMethod]
        public void TestLookAtGem()
        {
            Player me = new Player("me", "yes");
            me.Inventory.Put(gem);
            Look_Command look = new Look_Command();

            Assert.AreEqual(gem.FullDescription, look.Execute(me, new string[] { "look", "at", "gem" }));
        }

        [TestMethod]
        public void TestLookAtUnk()
        {
            Player me = new Player("me", "yes");
            Look_Command look = new Look_Command();

            Assert.AreEqual("I can't find the gem", look.Execute(me, new string[] { "look", "at", "gem" }));
        }

        [TestMethod]
        public void TestLookAtGemInMe()
        {
            Player me = new Player("me", "yes");
            me.Inventory.Put(gem);
            Look_Command look = new Look_Command();

            Assert.AreEqual(gem.FullDescription, look.Execute(me, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [TestMethod]
        public void TestLookAtGemInBag()
        {
            Player me = new Player("me", "yes");
            Bag bag = new Bag(new string[] { "bag" }, "bag bag bag", "this yeah woah yeah is a bag");

            bag.Inventory.Put(gem);
            me.Inventory.Put(bag);
            Look_Command look = new Look_Command();

            Assert.AreEqual(gem.FullDescription, look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [TestMethod]
        public void TestLookAtGemInNoBag()
        {
            Player me = new Player("me", "yes");
            me.Inventory.Put(gem);
            Look_Command look = new Look_Command();

            Assert.AreEqual("I can't find the bag", look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [TestMethod]
        public void TestLookAtNoGemInBag()
        {
            Player me = new Player("me", "yes");
            Bag bag = new Bag(new string[] { "bag" }, "bag bag bag", "this yeah woah yeah is a bag");

            me.Inventory.Put(bag);
            Look_Command look = new Look_Command();

            Assert.AreEqual("I can't find the gem", look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [TestMethod]
        public void TestInvalidLook()
        {
            Player me = new Player("me", "yes");
            Look_Command look = new Look_Command();

            Assert.AreEqual("Error in look input.", look.Execute(me, new string[] { "stare", "at", "gem" }));
        }
    }
}
