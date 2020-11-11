using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class TestSuite : TestBase
    {
        [Test]
        public void TestSearchComputers()
        {
            /*Scenario:
             * Access test site
             * Verify site title
             * Search a computer (Default: Amiga)
             * Click Filter button
             * Verify search result
             */
            Pages.Home.IsAt();
            string computer = "Amiga";
            Pages.Home.EnterSearchText(computer);
            Pages.Home.AssertSearchResult(computer);
        }

        [Test]
        public void TestCRUDFunctions()
        {
            /*Scenario:
             * Access test site
             * Verify Add Computer Button
             * Add a Computer
             * Search the recently added computer
             * Verify the added computer in the table
             * Edit the added computer
             * Verify the changes vs. the past version
             * Delete the added computer
             * Verify search result
             */
            Pages.Home.AssertAddComputerBtn();
            string[] added_comp_details = Pages.Home.AddComputerItem();
            Pages.Home.AssertSuccessAddComputer();
            Pages.Home.EnterSearchText(added_comp_details[0]);
            string[] new_comp =  Pages.Home.AssertSearchResult(added_comp_details[0]);
            string[] edit_comp_details = Pages.Home.EditComputerItem(added_comp_details);
            Pages.Home.EnterSearchText(edit_comp_details[0]);
            Pages.Home.AssertSearchResult(edit_comp_details[0]);
            Pages.Home.AssertEditedComputerDetails(new_comp);
            Pages.Home.DeleteComputer(edit_comp_details[0]);
        }
    }
}