using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTesting.Base;

namespace SeleniumTesting.HerokuappTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    internal class SortableDataTablesTests<DriverType> : Tests<DriverType>
        where DriverType : IWebDriver, new()
    {
        readonly string? url = TestContext.Parameters["SortableDataTablesUrl"];

        [SetUp]
        public void LocalSetup()
        {
            driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void SortableDataTablesTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(CheckCellValue("//table[1]//tr[1]//td[2]", "John"), Is.True);

                Assert.That(CheckCellValue("//table[1]//tr[2]//td[3]", "fbach@yahoo.com"), Is.True);

                Assert.That(CheckCellValue("//table[1]//th[2]//span", "First Name"), Is.True);

                Assert.That(CheckCellValue(
                    "//table[@id='table2']//tr[1]//td[@class='first-name']", "John"), Is.True);

                Assert.That(CheckCellValue(
                    "//table[@id='table2']//tr[2]//td[@class='email']", "fbach@yahoo.com"), Is.True);

                Assert.That(CheckCellValue(
                    "//table[@id='table2']//span[@class='first-name']", "First Name"), Is.True);
            });
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        private bool CheckCellValue(string cellLocatorString, string cellValue)
        {
            var cell = driver!.FindElement(By.XPath(cellLocatorString));

            return cell.Text.Equals(cellValue);
        }
    }
}