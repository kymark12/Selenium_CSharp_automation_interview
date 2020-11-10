using SeleniumExtras.PageObjects;
using System;
namespace Tests
{
    public class Pages
    {
        public Pages(Browsers browser)
        {
            _browser = browser;
        }
        Browsers _browser { get; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.getDriver);
            PageFactory.InitElements(_browser.getDriver, page);
            return page;
        }
        public Home Home => GetPages<Home>();
    }
}