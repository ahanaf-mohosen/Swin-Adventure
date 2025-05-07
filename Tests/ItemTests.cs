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
    public class ItemTests
    {
        [TestMethod]
        public void Identifiable()
        {
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Assert.IsTrue(sword.AreYou("sword"));
        }

        [TestMethod]
        public void ShortDescription()
        {
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Assert.AreEqual($"a {sword.FirstId()} ({sword.Name})", sword.ShortDescription);
        }

        [TestMethod]
        public void LongDescription()
        {
            Item sword = new Item(new string[] { "sword" }, "sword", "black blade");
            Assert.AreEqual("black blade", sword.FullDescription);
        }
    }
}

