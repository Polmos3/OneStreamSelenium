using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace selenium.PageObjects;

public abstract class PageObject
{
    protected IWebDriver driver;

    public PageObject(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Quit()
    {
        driver.Quit();
    }

    public IWebElement FindElementVisible(string xpath, int timeOut = 2)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
        return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
    }

    public IWebElement FindElement(string xpath, int timeOut = 2)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
        return wait.Until(driver => driver.FindElement(By.XPath(xpath)));
    }
}
