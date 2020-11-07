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
             * Verify added computer on the table
             * Edit the added computer
             * Verify the changes vs. the past version
             * Delete the added computer
             * Verify search result
             */
            Pages.Home.AssertAddComputerBtn();
            string added_comp = Pages.Home.AddComputerItem();
            Pages.Home.EnterSearchText(added_comp);
            Pages.Home.AssertSearchResult(added_comp);
        }
    }
}