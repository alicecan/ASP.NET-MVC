using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResCodeCalculator.Models;

namespace ResCodeCalculator.Tests
{
    [TestClass]
    public class ResistorUnitTest
    {
        [TestMethod]
        public void TestMega()
        {
            Resistor r = new Resistor();

            double expected = 6.1e6;
            double actual = r.CalculateOhmValue("Blue", "Brown", "Green", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");
        }

        [TestMethod]
        public void TestKilo()
        {
            Resistor r = new Resistor();

            double expected = 610e3;
            double actual = r.CalculateOhmValue("Blue", "Brown", "Yellow", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");
        }

        [TestMethod]
        public void TestOthers()
        {
            Resistor r = new Resistor();

            double expected = 2.7;
            double actual = r.CalculateOhmValue("Red", "Violet", "Gold", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");

            expected = 0.56;
            actual = r.CalculateOhmValue("Green", "Blue", "Silver", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");

            expected = 88e3;
            actual = r.CalculateOhmValue("Gray", "Gray", "Orange", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");

            expected = 8e3;
            actual = r.CalculateOhmValue("Black", "Gray", "Orange", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");

            expected = 1.8e6;
            actual = r.CalculateOhmValue("Brown", "Gray", "Green", "Gold");
            Assert.AreEqual(expected, actual, 0.001, "Resistance value not matched!");
        }

        [TestMethod]
        public void TestTolerance()
        {
            Resistor r = new Resistor();

            int expected = 1;
            int actual = r.CalculateTolerance("Brwon");
            Assert.AreEqual(expected, actual, 0.001, "Tolerance value not matched!");

            expected = 2;
            actual = r.CalculateTolerance("Red");
            Assert.AreEqual(expected, actual, 0.001, "Tolerance value not matched!");

            expected = 5;
            actual = r.CalculateTolerance("Gold");
            Assert.AreEqual(expected, actual, 0.001, "Tolerance value not matched!");

            expected = 10;
            actual = r.CalculateTolerance("Silver");
            Assert.AreEqual(expected, actual, 0.001, "Tolerance value not matched!");
        }
    }
}
