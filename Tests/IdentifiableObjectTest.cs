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
    public class IdentifiableObjectTest
    {
        [TestMethod]
        public void TestAreYou()
        {
            // tests if AreYou works - correct answer
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fred"));
        }

        [TestMethod]
        public void TestNotAreYou()
        {
            // tests if AreYou works - wrong answer
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsFalse(id.AreYou("wilma"));
        }

        [TestMethod]
        public void TestAreYouCaseSensitive()
        {
            // tests if AreYou works with case insensitivity
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fReD")); // Assuming AreYou is case-insensitive
        }

        [TestMethod]
        public void TestFirstID()
        {
            // tests if FirstId works - returns first element
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual("fred", id.FirstId());
        }

        [TestMethod]
        public void TestAddID()
        {
            // tests if AddId works - adds an element
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("wilma"));
        }
    }
}
