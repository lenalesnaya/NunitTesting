using CalcTesting.Calc;

namespace CalcTesting.CalcTests
{
    internal class MultiplyTests
    {
        Func<double, double, double>? Multiply;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Multiply = Calculator.Multiply;
        }

        [Category("Positive"), Description("Testing different combinations of natural numbers")]
        [TestCase(0.0, 0.0, ExpectedResult = 0.0)]
        [TestCase(1.0, 0.0, ExpectedResult = 0.0)]
        [TestCase(546.0, 20.0, ExpectedResult = 10920)]
        public double Multiply_Positive_NaturalNumbers(double x, double y)
        {
            return Multiply!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with fractional numbers")]
        [TestCase(0.054, 0.0, ExpectedResult = 0.0)]
        [TestCase(0.58, 303.0, ExpectedResult = 175.74)]
        [TestCase(0.300251, 0.543, ExpectedResult = 0.163036293)]
        [TestCase(26.123, 20.001, ExpectedResult = 522.486123)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Multiply_Positive_FractionalNumbers(double x, double y)
        {
            return Multiply!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with negative numbers")]
        [TestCase(-0.054, 0.0, ExpectedResult = 0.0)]
        [TestCase(-0.58, 303.0, ExpectedResult = -175.74)]
        [TestCase(-0.300251, -0.543, ExpectedResult = 0.163036293)]
        [TestCase(-26.0, 20.001, ExpectedResult = -520.026)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Multiply_Positive_NegativeNumbers(double x, double y)
        {
            return Multiply!(x, y);
        }

        [Category("LimitValues"), Description("Testing different combinations of limit values")]
        [TestCase(double.MaxValue, double.MinValue, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.MaxValue, double.MaxValue, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MinValue, double.MinValue, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MaxValue, 0.1, ExpectedResult = 1.7976931348623158E+307)]
        [TestCase(double.MinValue, 0.1, ExpectedResult = -1.7976931348623158E+307)]
        [TestCase(double.MinValue, -0.1, ExpectedResult = 1.7976931348623158E+307)]
        [TestCase(double.MaxValue, 2.00, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MinValue, -2.00, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MinValue, 2.00, ExpectedResult = double.NegativeInfinity)]
        public double Multiply_Positive_LimitValues(double x, double y)
        {
            return Multiply!(x, y);
        }

        [Category("Negative"), Description("Testing different combinations of erroneous values")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.PositiveInfinity, 50.55, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 50.55, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NegativeInfinity, -50.55, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NaN, double.NaN, ExpectedResult = double.NaN)]
        [TestCase(double.NaN, 6365.654, ExpectedResult = double.NaN)]
        public double Multiply_Negative_ErroneousValues(double x, double y)
        {
            return Multiply!(x, y);
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Multiply = null;
        }
    }
}