using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLive.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Init()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        [DataRow(3, 5, 8)]
        [DataRow(13, 25, 38)]
        [DataRow(1, 1, 2)]
        public void Add_WithTwoNumbers_ReturnsAddition(int numberOne, int numberTwo, int expectedResult)
        {
            // Act
            var result = _calculator.Add(numberOne, numberTwo);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(1, 1, 0)]
        [DataRow(10, 1, 9)]
        [DataRow(55, 42, 13)]
        public void Substract_WithTwoNumbers_ReturnsSubstract(int numberOne, int numberTwo, int expectedResult)
        {
            var result = _calculator.Subtract(numberOne, numberTwo);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(2, 8, 16)]
        [DataRow(20, 5, 100)]
        [DataRow(1, 0, 0)]
        public void Mulitply_WithTwoNumbers_ReturnsMultiplication(int numberOne, int numberTwo, int expectedResult)
        {
            var result = _calculator.Multiply(numberOne, numberTwo);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Divide_WithSecondNumberAsZero_ThrowsCustomException()
        {
            // Act & Assert en même temps, car levé d'exception
            Assert.ThrowsException<CustomException>(() => _calculator.Divide(8, 0));
        }

        [TestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(10, 2, 5)]
        [DataRow(10, 4, 2.5f)]
        public void Divide_WithTwoNumbersAndSecondNumberIsNotZero_ReturnsDivision(int numberOne, int numberTwo, float expectedResult)
        {
            var result = _calculator.Divide(numberOne, numberTwo);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
