using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        [FindsBy(How = How.CssSelector, Using = "#main>h1")]
        private IWebElement HeaderLabel { get; set; }

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

        public string[] AssertSearchResult(string ExpectedResult)
        {
            string init_path = TableXpath();
            IWebElement table_Xpath = driver.FindElement(By.XPath(init_path + "//a[contains(., '"+ ExpectedResult +"')]"));
            Assert.IsTrue(table_Xpath.Displayed);
            IList<IWebElement> table_cells = driver.FindElements(By.XPath(init_path));
            string[] added_comp = new string[table_cells.Count];
            int count = 0;
            foreach (IWebElement cell in table_cells)
            {
                added_comp[count] = cell.Text;
                count++;
            }
            return added_comp;
        }

        public void AssertAddComputerBtn()
        {
            Assert.IsTrue(AddComputerBtn.Displayed, "Add Computer button is not visible");
        }

        public void AssertSuccessAddComputer()
        {
            Assert.IsTrue(SuccessMessage.Displayed, "Computer was not added successfully");
        }

        public void AssertEditedComputerDetails(string[] ComputerDetails)
        {
            int counter = 0;
            string base_table = TableXpath();
            IList<IWebElement> cells = driver.FindElements(By.XPath(base_table));
            foreach (IWebElement cell in cells)
            {
                Assert.AreNotEqual(ComputerDetails[counter], cell, "Changes were not saved");
                counter++;
            }
        }

        public string[] AddComputerItem()
        {
            /*Add computer form Page Object Method (POM):
              1. Click Add Computer Button
              2. Generate random model number and month for the computer name and dates
              3. Input data by text field sequence
              4. Select q random Company on the dropdown field
              5. Click "Create this computer" button
            */

            //Data assembly
            int randomModelNumber, randomMonth;
            randomModelNumber = RandomNumberGenerator(3001);
            randomMonth = RandomNumberGenerator(13);
            string[] add_comp_details = { "BFG "+ randomModelNumber, "1993-" + randomMonth + "-10", "2020-03-20"};        

            //Action commands
            AddComputerBtn.Click();
            Assert.AreEqual("Add a computer", HeaderLabel.Text, "Incorrect page");
            IList<IWebElement> text_fields = driver.FindElements(By.TagName("input"));
            for (int i = 0; i < text_fields.Count - 1; i++)
            {
                text_fields[i].Clear();
                text_fields[i].SendKeys(add_comp_details[i]);
            }
            IList<IWebElement> options = CompanySelection.FindElements(By.TagName("option"));
            int selectItems = options.Count;
            int itemNum = RandomNumberGenerator(selectItems);
            var selectElement = new SelectElement(CompanySelection);
            selectElement.SelectByIndex(itemNum);
            CreateButton.Click();
            return add_comp_details;
        }

        public string[] EditComputerItem(string[] AddedCompDetails)
        {
            /*Edit recently added computer Page Object Method (POM):
             * 1. Access added computer model
             * 2. Edit the computer model details
             * 3. Save the new model details
             * 4. Validate the changes on the data table
             * 5. Compare the changes from the details before
             */

            // Same procedure on add computer method this follows AAA test design
            int randomModelNumber, randomMonth;
            string init_path = TableXpath();
            randomModelNumber = RandomNumberGenerator(5001);
            randomMonth = RandomNumberGenerator(13);
            string[] edit_comp_details = { "FOG " + randomModelNumber, "1985-" + randomMonth + "-10", "2020-03-20" };
            IWebElement added_comp = driver.FindElement(By.XPath(init_path + "//a[contains(., '" + AddedCompDetails[0] + "')]"));

            // Action commandss
            added_comp.Click();
            Assert.AreEqual("Edit computer", HeaderLabel.Text, "Incorrect page");
            IList<IWebElement> text_fields = driver.FindElements(By.TagName("input"));
            for (int i = 0; i < text_fields.Count - 2; i++)
            {
                text_fields[i].Clear();
                text_fields[i].SendKeys(edit_comp_details[i]);
            }
            IList<IWebElement> options = CompanySelection.FindElements(By.TagName("option"));
            int selectItems = options.Count;
            int itemNum = RandomNumberGenerator(selectItems);
            var selectElement = new SelectElement(CompanySelection);
            selectElement.SelectByIndex(itemNum);
            CreateButton.Click();
            return edit_comp_details;
        }

    }
}