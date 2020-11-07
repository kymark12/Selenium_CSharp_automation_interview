using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
namespace Tests
{
    public class Browsers
    {
        private IWebDriver webDriver;
        private string baseURL = "http://computer-database.herokuapp.com/computers";
        private string browser = "Firefox"; public void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            Goto(baseURL);
        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
    }
}