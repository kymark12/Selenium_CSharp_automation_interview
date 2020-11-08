using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
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

        [FindsBy(How = How.XPath, Using = "//table[@class='computers zebra-striped']")]
        private IWebElement BaseTable { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        private  IWebElement CompanySelection { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn.primary")]
        private IWebElement CreateButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.warning")]
        private IWebElement SuccessMessage { get; set; }

        public int RandomNumberGenerator(int len)
        {
            Random rand = new Random();
            int rand_num = rand.Next(1, len - 1);
            return rand_num;
        }

        public string TableXpath()
        {
            string base_xpath = "//table[@class='computers zebra-striped']";
            string mid_path = "/tbody/tr/td";
            string full_path = base_xpath + mid_path;
            return full_path;
        }

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
            string init_path = TableXpath();
            IWebElement table_Xpath = driver.FindElement(By.XPath(init_path + "//a[contains(., '"+ ExpectedResult +"')]"));
            Assert.IsTrue(table_Xpath.Displayed);
        }

        public void AssertAddComputerBtn()
        {
            Assert.IsTrue(AddComputerBtn.Displayed);
        }

        public string AddComputerItem()
        {
            /*Add computer form page object method:
              1. Click Add Computer Button
              2. Generate random model number and month for the computer name and dates
              3. Input data by text field sequence
              4. Select q random Company on the dropdown field
              5. Click "Create this computer" button
            */
            AddComputerBtn.Click();
            int randomModelNumber, randomMonth;
            randomModelNumber = RandomNumberGenerator(3001);
            randomMonth = RandomNumberGenerator(13);
            string[] comp_details = { "BFG "+ randomModelNumber, "1993-" + randomMonth + "-10", "2020-03-20"};
            IList<IWebElement> text_fields = driver.FindElements(By.TagName("input"));
            for (int i = 0; i < text_fields.Count - 1; i++)
            {
                text_fields.Clear();
                text_fields[i].SendKeys(comp_details[i]);
            }
            var selectElement = new SelectElement(CompanySelection);
            IList<IWebElement> options = CompanySelection.FindElements(By.TagName("option"));
            int selectItems = options.Count;
            int itemNum = RandomNumberGenerator(selectItems);
            selectElement.SelectByIndex(itemNum);
            CreateButton.Click();
            return comp_details[0];
        }

        public void AssertSuccessAddComputer()
        {
            Assert.IsTrue(SuccessMessage.Displayed);
        }
    }
}