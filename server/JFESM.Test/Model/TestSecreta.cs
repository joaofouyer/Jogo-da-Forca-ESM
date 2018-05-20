using System;
using JFESM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFESM.Test.Model {

    [TestClass]
    public class TestSecreta {

        [TestMethod]
        public void TestCriarSecreta () {
            var secreta = new Secreta ("Teste");
            Assert.AreEqual (secreta.Palavra, "-----");
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void TestSecretaValorNulloJogaExcecao () {
            var secreta = new Secreta (null);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void TestSecretaStringVaziaJogaExcecao () {
            var secreta = new Secreta ("");
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void TestSecretaStringEspacoJogaExcecao () {
            var secreta = new Secreta (" ");
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void TestSecretaDuasPalavrasJogaExcecao () {
            var secreta = new Secreta ("Test Test");
        }

        [TestMethod]
        public void TestDestacarLetraContida () {
            var secreta = new Secreta ("Teste");
            Assert.AreEqual (secreta.Palavra, "-----");
            var acertou = secreta.Destacar('T');
            Assert.IsTrue(acertou);
            Assert.AreEqual (secreta.Palavra, "T----");
        }

        [TestMethod]
        public void TestDestacarLetraNaoContida () {
            var secreta = new Secreta ("Teste");
            Assert.AreEqual (secreta.Palavra, "-----");
            var acertou = secreta.Destacar('x');
            Assert.IsFalse(acertou);
            Assert.AreEqual (secreta.Palavra, "-----");
        }
    }
}