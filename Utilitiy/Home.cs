using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Tests
{
    public class Home
    {
        public Home()
        {
            driver = null;
        }
        public Home(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        IWebDriver driver;
        [FindsBy(How = How.Id, Using = "searchbox")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "searchsubmit")]
        private IWebElement SearchBtn { get; set; }

        public void IsAt()
        {
            Assert.IsTrue(driver.Title.Equals("Computers database"));
        }
        public void EnterSearchText(string searchText)
        {
            SearchField.SendKeys(searchText);
            SearchBtn.Click();
        }

        public void AssertResult(string ExpectedResult)
        {
            Assert.AreSame(ExpectedResult, driver.FindElement(By.XPath("//table[@class='computers zebra-striped']")));
        }
    }
}