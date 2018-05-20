using System;
using JFESM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFESM.Test.Model {
    [TestClass]
    public class TestBoneco {
        [TestMethod]
        public void TestCriarBoneco () {
            var boneco = new Boneco ();
            Assert.AreEqual (boneco.Membros, 0);
            Assert.IsTrue (boneco.EstaVivo);
        }

        [TestMethod]
        public void TestAdicionarMembroBoneco () {
            var boneco = new Boneco ();
            Assert.AreEqual (boneco.Membros, 0);
            boneco.AdicionarMembro ();
            Assert.AreEqual (boneco.Membros, 1);
            Assert.IsTrue (boneco.EstaVivo);
        }

        [TestMethod]
        public void TestBonecoEnforcado () {
            var boneco = new Boneco ();
            Assert.AreEqual (boneco.Membros, 0);
            for (int i = 0; i < 5; i++) {
                boneco.AdicionarMembro ();
            }
            Assert.AreEqual (boneco.Membros, 5);
            Assert.IsFalse (boneco.EstaVivo);
        }
    }
}