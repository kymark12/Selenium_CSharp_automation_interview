using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

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

        [FindsBy(How = How.Id, Using = "add")]
        private IWebElement AddComputerBtn { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        private  IWebElement CompanySelection { get; set; }

        public void IsAt()
        {
            Assert.IsTrue(driver.Title.Equals("Computers database"));
        }
        public void EnterSearchText(string searchText)
        {
            SearchField.Clear();
            SearchField.SendKeys(searchText);
            SearchBtn.Click();
        }

        public void AssertSearchResult(string ExpectedResult)
        {
            string table_Xpath = string.Concat("//table[@class='computers zebra-striped']/tbody/tr/td//a[contains(., ", ExpectedResult,")]");
            Assert.IsTrue(driver.FindElement(By.XPath(table_Xpath)).Displayed);
        }

        public void AssertAddComputerBtn()
        {
            Assert.IsTrue(AddComputerBtn.Displayed);
        }

        public string AddComputerItem()
        {
            AddComputerBtn.Click();
            string[] comp_details = { "BFG 3000", "1993-12-10", "2020-03-20"};
            IList<IWebElement> text_fields = driver.FindElements(By.TagName("input"));
            for (int i = 0; i < text_fields.Count - 1; i++)
            {
                text_fields[i].SendKeys(comp_details[i]);
            }
            var selectElement = new SelectElement(CompanySelection);
            
            return comp_details[0];
        }
    }
}