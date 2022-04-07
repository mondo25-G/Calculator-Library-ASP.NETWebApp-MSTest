using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator.Library;

namespace Calculator.Library.Tests
{
    [TestClass]
    public class CalculatorTests
    {

        //Roy Asherov's naming strategy for unit tests:
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]

        #region Test Division

        //Arrange
        [DataTestMethod]
        [DataRow(5,"",20,4,"")]
        [DataRow(3, "", Int32.MaxValue, Int32.MaxValue/3,"")]
        public void Division_PositiveNumeratorPositiveDenominator_ReturnsPositiveInt(int expected, string expectedErr, int numerator, int denominator,string err)
        {
            //Actual
            int actual = Calculator.Division(numerator, denominator,out err);

            //One concern: Division_PositiveNumeratorPositiveDenominator ,but test more than one aspects of that concern.
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        //Arrange
        [DataTestMethod]
        [DataRow(5, "", -20, -4,"")]
        [DataRow(2, "", Int32.MinValue, Int32.MinValue / 2,"")]
        public void Division_NegativeNumeratorNegativeDenominator_ReturnsPositiveInt(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Division(numerator, denominator, out err);

            //One concern: Division_NegativeNumeratorNegativeDenominator ,but test more than one aspects of that concern.
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        //Arrange
        [DataTestMethod]
        [DataRow(-3, "", 15, -4,"")]
        [DataRow(-1, "",19,-12,"")]
        public void Division_PositiveNumeratorWithNegativeDenominator_ReturnsNegativeInt(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Division(numerator, denominator, out err);

            //One concern: Division_PositiveNumeratorWithNegativeNumerator ,but test more than one aspects of that concern.
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        //Arrange
        [DataTestMethod]
        [DataRow(0, "Attempted to divide by zero.", 15, 0, "")]
        [DataRow(0, "Attempted to divide by zero.", Int32.MaxValue, 0, "")]
        [DataRow(0, "Attempted to divide by zero.", -15, 0, "")]
        [DataRow(0, "Attempted to divide by zero.", Int32.MinValue, 0, "")]
        [DataRow(0, "Attempted to divide by zero.", 0, 0, "")]
        public void Division_AnyNumeratorWithZeroDenominator_ReturnsZeroAndError(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Division(numerator, denominator, out err);

            //One concern: Division_PositiveNumeratorWithNegativeNumerator ,but test more than one aspects of that concern.
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }
        #endregion

        #region Test Multiplication

        //Arrange
        [DataTestMethod]
        [DataRow(0, "Arithmetic operation resulted in an overflow.", Int32.MaxValue,Int32.MaxValue, "")]
        [DataRow(0, "Arithmetic operation resulted in an overflow.", Int32.MinValue, Int32.MaxValue, "")]
        [DataRow(0, "Arithmetic operation resulted in an overflow.", Int32.MinValue, Int32.MinValue, "")]
        [DataRow(0, "Arithmetic operation resulted in an overflow.", Int32.MinValue, -1, "")] //There's a nice edge case.
        public void Multiplication_NonZeroMultiplicants_ReturnsZeroAndError(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Multiplication(numerator, denominator, out err);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        //Arrange
        [DataTestMethod]
        [DataRow(0, "", Int32.MaxValue, 0, "")]
        [DataRow(0, "", 0,Int32.MinValue, "")]
        [DataRow(0, "", 0, 0, "")]
        public void Multiplication_AtLeastOneZeroMultiplicant_ReturnsZero(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Multiplication(numerator, denominator, out err);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        //Arrange
        [DataTestMethod]
        [DataRow(Int32.MaxValue, "", Int32.MaxValue, 1, "")]
        [DataRow(156, "", 12, 13, "")]
        [DataRow(120000, "",-60000, -2, "")]
        public void Multiplication_NonZeroMultiplicants_ReturnsPositive(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Multiplication(numerator, denominator, out err);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        [DataTestMethod]
        [DataRow(Int32.MinValue, "", Int32.MinValue, 1, "")]
        [DataRow(-156, "", -12, 13, "")]
        [DataRow(-120000, "", 60000, -2, "")]
        public void Multiplication_NonZeroMultiplicants_ReturnsNegative(int expected, string expectedErr, int numerator, int denominator, string err)
        {
            //Actual
            int actual = Calculator.Multiplication(numerator, denominator, out err);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedErr, err);
        }

        #endregion

        //TODO: Add tests for Addition and Subtraction

    }
}
