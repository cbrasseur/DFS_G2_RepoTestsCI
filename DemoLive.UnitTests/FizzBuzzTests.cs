using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLive.UnitTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [TestInitialize]
        public void Init()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-50)]
        [DataRow(-2000)]
        public void GetOutput_WithNegativeParameter_ThrowsArgumentException(int number)
        {
            Assert.ThrowsException<ArgumentException>(() => _fizzBuzz.GetOutput(number));
        }

        [TestMethod]
        [DataRow(15, "FizzBuzz")]
        [DataRow(45, "FizzBuzz")]
        [DataRow(60, "FizzBuzz")]
        public void GetOutput_WithNumberMultipleOf5And3_ReturnsFizzBuzz(
            int number, 
            string expectedResult
        )
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(3, "Fizz")]
        [DataRow(6, "Fizz")]
        [DataRow(9, "Fizz")]
        public void GetOutput_WithMultipleOf3_ReturnsFizz(
            int number,
            string expectedResult)
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(5, "Buzz")]
        [DataRow(10, "Buzz")]
        [DataRow(20, "Buzz")]
        public void GetOutput_WithMultipleOf5_ReturnsBuzz(
            int number,
            string expectedResult
        )
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(4, "4")]
        public void GetOutput_WithNonMultipleOf3And5_ReturnsNumberAsString(
            int number,
            string expectedResult
        )
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
