using CalcTesting.Calc;

namespace CalcTesting.CalcTests
{
    internal class DivideTests
    {
        Func<double, double, double>? Divide;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Divide = Calculator.Divide;
        }

        [Category("Positive"), Description("Testing different combinations of natural numbers")]
        [TestCase(5000.0, 584.0, ExpectedResult = 8.56164384)]
        [TestCase(0.0, 91.0, ExpectedResult = 0)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Divide_Positive_NaturalNumbers(double x, double y)
        {
            return Divide!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with fractional numbers")]
        [TestCase(0.258, 0.0000001, ExpectedResult = 2580000.0)]
        [TestCase(0.58, 303.0, ExpectedResult = 0.00191419142)]
        [TestCase(44448.0, 30.58976, ExpectedResult = 1453.03526)]
        [TestCase(52.300251, 0.543, ExpectedResult = 96.317221)]
        [TestCase(26.123, 20.001, ExpectedResult = 1.3060847)]
        [TestCase(0.0, 255.041, ExpectedResult = 0)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Divide_Positive_FractionalNumbers(double x, double y)
        {
            return Divide!(x, y);
        }

        [Category("Positive"), Description("Testing different combinations with negative numbers")]
        [TestCase(-0.58, 303.0, ExpectedResult = -0.00191419142)]
        [TestCase(-0.300251, -0.543, ExpectedResult = 0.552948435)]
        [TestCase(-26.0, 20.001, ExpectedResult = -1.299935)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Divide_Positive_NegativeNumbers(double x, double y)
        {
            return Divide!(x, y);
        }

        [Category("LimitValues"), Description("Testing different combinations of limit values")]
        [TestCase(double.MaxValue, double.MinValue, ExpectedResult = -1.0)]
        [TestCase(double.MaxValue, double.MaxValue, ExpectedResult = 1.0)]
        [TestCase(double.MinValue, double.MinValue, ExpectedResult = 1.0)]
        [TestCase(double.MaxValue, 0.1, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MaxValue, -0.1, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.MinValue, -0.1, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.MaxValue, 80.00, ExpectedResult = 2.2471164185778947E+306)]
        [TestCase(double.MinValue, -80.00, ExpectedResult = 2.2471164185778947E+306)]
        [DefaultFloatingPointTolerance(0.00001)]
        public double Divide_Positive_LimitValues(double x, double y)
        {
            return Divide!(x, y);
        }

        [Category("Negative"), Description("Testing division by zero")]
        [TestCase(0.0, 0.0, ExpectedResult = double.NaN)]
        [TestCase(1.0, 0.0, ExpectedResult = double.PositiveInfinity)]
        [TestCase(-1.0, 0.0, ExpectedResult = double.NegativeInfinity)]
        public double Divide_Negative_DivisionByZero(double x, double y)
        {
            return Divide!(x, y);
        }

        [Category("Negative"), Description("Testing different combinations of erroneous values")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, ExpectedResult = double.NaN)]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, ExpectedResult = double.NaN)]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, ExpectedResult = double.NaN)]
        [TestCase(double.PositiveInfinity, 50.55, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, -50.55, ExpectedResult = double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 50.55, ExpectedResult = double.NegativeInfinity)]
        [TestCase(double.NaN, double.NaN, ExpectedResult = double.NaN)]
        [TestCase(double.NaN, 6365.654, ExpectedResult = double.NaN)]
        public double Divide_Negative_ErroneousValues(double x, double y)
        {
            return Divide!(x, y);
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Divide = null;
        }
    }
}
