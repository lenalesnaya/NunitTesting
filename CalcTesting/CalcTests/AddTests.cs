using CalcTesting.Calc;

namespace CalcTesting.CalcTests
{
    public class AddTests
    {
        Func<double, double, double>? Add;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Add = Calculator.Add;
        }

        [Category("Positive"), Description("Testing different combinations of natural numbers")]
        [TestCase(0.0, 0.0, ExpectedResult = 0.0)]
        [TestCase(1.0, 0.0, ExpectedResult = 1.0)]
        [TestCase(546.0, 20.0, ExpectedResult = 566.0)]
        public double Add_Positive_NaturalNumbers(double x, double y)
        {
            return Add!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with fractional numbers")]
        [TestCase(0.054, 0.0, ExpectedResult = 0.054)]
        [TestCase(0.58, 303.0, ExpectedResult = 303.58)]
        [TestCase(0.300251, 0.543, ExpectedResult = 0.843251)]
        [TestCase(26.123, 20.001, ExpectedResult = 46.124)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Add_Positive_FractionalNumbers(double x, double y)
        {
            return Add!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with negative numbers")]
        [TestCase(-0.054, 0.0, ExpectedResult = -0.054)]
        [TestCase(-0.58, 303.0, ExpectedResult = 302.42)]
        [TestCase(-0.300251, -0.543, ExpectedResult = -0.843251)]
        [TestCase(-26.0, 20.001, ExpectedResult = -5.999)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Add_Positive_NegativeNumbers(double x, double y)
        {
            return Add!(x, y);
        }

        [Category("LimitValues"), Description("Testing different combinations of limit values")]
        [TestCase(double.MaxValue, double.MinValue, ExpectedResult = 0)]
        [TestCase(double.MaxValue, double.MaxValue, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MinValue, double.MinValue, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.MaxValue, 0.1, ExpectedResult = double.MaxValue)]
        [TestCase(double.MinValue, -0.1, ExpectedResult = double.MinValue)]
        [TestCase(double.MaxValue, 80.00, ExpectedResult = double.MaxValue)]
        [TestCase(double.MinValue, -80.00, ExpectedResult = double.MinValue)]
        public double Add_Positive_LimitValues(double x, double y)
        {
            return Add!(x, y);
        }

        [Category("Negative"), Description("Testing different combinations of erroneous values")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, ExpectedResult = double.NaN)]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.PositiveInfinity, 50.55, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, -50.55, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NaN, double.NaN, ExpectedResult = double.NaN)]
        [TestCase(double.NaN, 6365.654, ExpectedResult = double.NaN)]
        public double Add_Negative_ErroneousValues(double x, double y)
        {
            return Add!(x, y);
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Add = null;
        }
    }
}