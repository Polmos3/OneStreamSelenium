using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace selenium.PageObjects
{

    public class LoginPage : PageObject
    {
        // WebElements declaration
        private IWebElement AccountLogin => FindElementVisible("//*[@id='top-menu']//a[.='Account Login']");
        private IWebElement PersonalBankingLogin => FindElementVisible("//*[@id='top-menu']//a[@title='Personal Banking Login']");
        private IWebElement UserId => FindElementVisible("//*[@id='userId']");


        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public void Navigate()
        {

        driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("LOGIN_URL"));
        }

        public void HoverOverAccountLogin()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(AccountLogin).Perform();
        }

        public void ClickPersonalBankingLogin()
        {
            PersonalBankingLogin.Click();
        }

        public void TypeUserId(string userId)
        {
            UserId.SendKeys(userId);
        }

        public void ClearUserId()
        {
            UserId.Clear();
        }
        public string GetUserId()
        {
            return UserId.GetAttribute("value");
        }
    }
}