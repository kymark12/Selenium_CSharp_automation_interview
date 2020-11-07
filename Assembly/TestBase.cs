using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected Browsers browser;
        protected Pages Pages;
        [SetUp]
        public void StartUpTest()
        {
            browser = new Browsers();
            browser.Init();
            Pages = new Pages(browser);
        }
        [TearDown]
        public void EndTest()
        {
            browser.Close();
        }
    }