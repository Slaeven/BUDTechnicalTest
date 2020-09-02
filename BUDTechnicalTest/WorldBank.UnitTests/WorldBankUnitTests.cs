using BUDTechnicalTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.UnitTests
{
    [TestClass]
    public class WorldBankUnitTests
    {
        [TestMethod]
        public void ConstructISOList_CreateList_ListReturn()
        {
            var worldTest = new WorldBankCountryAPI();

            var isoCodesResult = worldTest.ConstructISOList();

            Assert.IsNotNull(isoCodesResult);
        }

        [TestMethod]
        public void InputCheck_ListEmpty_FalseReturn()
        {
            var worldTest = new WorldBankCountryAPI();
            List<string> testInput = new List<string>();

            bool inputCheckReturn = worldTest.InputCheck(testInput, "GB");

            Assert.IsFalse(inputCheckReturn);
        }

        [TestMethod]
        public void InputCheck_IncorrectInput_FalseReturn()
        {
            var worldTest = new WorldBankCountryAPI();
            List<string> testInput = new List<string>();
            testInput.Add("GB");

            bool inputCheckReturn = worldTest.InputCheck(testInput, "BUD");

            Assert.IsFalse(inputCheckReturn);
        }

        [TestMethod]
        public void InputCheck_CorrectInput_TrueReturn()
        {
            var worldTest = new WorldBankCountryAPI();
            List<string> testInput = new List<string>();
            testInput.Add("GB");

            bool inputCheckReturn = worldTest.InputCheck(testInput, "GB");

            Assert.IsTrue(inputCheckReturn);
        }

        [TestMethod]
        public void InputCheck_NullList_FalseReturn()
        {
            var worldTest = new WorldBankCountryAPI();
            List<string> testInput = new List<string>();
            testInput = null;

            bool inputCheckReturn = worldTest.InputCheck(testInput, "GB");

            Assert.IsFalse(inputCheckReturn);
        }

        [TestMethod]
        public void DisplayXML_NullString_FalseReturn()
        {
            var worldTest = new WorldBankCountryAPI();
            string testInput = null;

            bool inputCheckReturn = worldTest.DisplayXML(testInput);

            Assert.IsFalse(inputCheckReturn);
        }

        [TestMethod]
        public void DisplayXML_CorrectString_TrueReturn()
        {
            var worldTest = new WorldBankCountryAPI();
            string testInput = "GB";

            bool inputCheckReturn = worldTest.DisplayXML(testInput);

            Assert.IsTrue(inputCheckReturn);
        }
    }
}
