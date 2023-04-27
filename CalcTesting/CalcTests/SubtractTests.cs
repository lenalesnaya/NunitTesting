using CalcTesting.Calc;

namespace CalcTesting.CalcTests
{
    internal class SubtractTests
    {
        Func<double, double, double>? Subtract;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Subtract = Calculator.Subtract;
        }

        [Category("Positive"), Description("Testing different combinations of natural numbers")]
        [TestCase(0.0, 0.0, ExpectedResult = 0.0)]
        [TestCase(1.0, 0.0, ExpectedResult = 1.0)]
        [TestCase(546.0, 20.0, ExpectedResult = 526.0)]
        [TestCase(20.0, 546.0, ExpectedResult = -526.0)]
        public double Subtract_Positive_NaturalNumbers(double x, double y)
        {
            return Subtract!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with fractional numbers")]
        [TestCase(0.0, 0.054, ExpectedResult = -0.054)]
        [TestCase(0.58, 303.0, ExpectedResult = -302.42)]
        [TestCase(0.300251, 0.043, ExpectedResult = 0.257251)]
        [TestCase(26.0003, 27.0001, ExpectedResult = -0.9998)]
        [TestCase(26.0003, 26.0001, ExpectedResult = 0.0002)]
        [TestCase(26.0003, 26.0002, ExpectedResult = 0.0001)]
        [TestCase(26.12300000001, 0.00000000001, ExpectedResult = 26.123)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Subtract_Positive_FractionalNumbers(double x, double y)
        {
            return Subtract!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with negative numbers")]
        [TestCase(-0.054, 0.0, ExpectedResult = -0.054)]
        [TestCase(0.0, -0.00000001, ExpectedResult = 0.00000001)]
        [TestCase(-0.58, 303.02, ExpectedResult = -303.6)]
        [TestCase(-0.300251, -0.543, ExpectedResult = 0.242749)]
        [TestCase(26.0, -20.001, ExpectedResult = 46.001)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Subtract_Positive_NegativeNumbers(double x, double y)
        {
            return Subtract!(x, y);
        }

        [Category("LimitValues"), Description("Testing different combinations of limit values")]
        [TestCase(double.MaxValue, double.MinValue, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MaxValue, double.MaxValue, ExpectedResult = 0.0)]
        [TestCase(double.MinValue, double.MinValue, ExpectedResult = 0.0)]
        [TestCase(double.MaxValue, 0.1, ExpectedResult = double.MaxValue)]
        [TestCase(double.MinValue, -0.1, ExpectedResult = double.MinValue)]
        [TestCase(double.MaxValue, 80.00, ExpectedResult = double.MaxValue)]
        [TestCase(double.MinValue, -80.00, ExpectedResult = double.MinValue)]
        public double Subtract_Positive_LimitValues(double x, double y)
        {
            return Subtract!(x, y);
        }

        [Category("Negative"), Description("Testing different combinations of erroneous values")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, ExpectedResult = double.NaN)]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, ExpectedResult = double.NaN)]
        [TestCase(double.PositiveInfinity, 50.55, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, -50.55, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NaN, double.NaN, ExpectedResult = double.NaN)]
        [TestCase(double.NaN, 6365.654, ExpectedResult = double.NaN)]
        public double Subtract_Negative_ErroneousValues(double x, double y)
        {
            return Subtract!(x, y);
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Subtract = null;
        }
    }
}
