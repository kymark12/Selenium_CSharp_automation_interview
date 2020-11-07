using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class MyFirstPOMTest : TestBase
    {
        [Test]
        public void TestSearchComputers()
        {
            Pages.Home.IsAt();  // Validate current page
            string computer = "Amiga"; //Variable for data-driven method
            Pages.Home.EnterSearchText(computer);
        }
    }
}