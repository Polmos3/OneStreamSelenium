namespace selenium;
using System;
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using selenium.PageObjects;
using Xunit;

public class LoginPersonalBankingFixture : IDisposable
{
    public IWebDriver driver;
    public LoginPage loginPage;
    public LoginPersonalBankingFixture()
    {
        driver = new ChromeDriver();
        loginPage = new LoginPage(driver);
    }
    public void Dispose()
    {
        driver.Quit();
    }
}
public class LoginPersonalBanking : IClassFixture<LoginPersonalBankingFixture>
{
    LoginPersonalBankingFixture fixture;
    private IWebDriver driver;
    private LoginPage loginPage;

    public LoginPersonalBanking(LoginPersonalBankingFixture fixture)
    {
        this.fixture = fixture;
        driver = this.fixture.driver;
        loginPage = this.fixture.loginPage;
    }

    [Fact(DisplayName = "Verify userID can be entered.")]
    public void TypeUsername_Successfully()
    {
        var userID = Environment.GetEnvironmentVariable("USER_ID");
        loginPage.Navigate();
        loginPage.ClickAccountLogin();
        loginPage.ClickPersonalBankingLogin();
        loginPage.TypeUserId(userID);
        Assert.Equal(userID, loginPage.GetUserId());
    }

    [Fact(DisplayName = "Verify userID can be updated.")]
    public void UpdateUsername_Successfully()
    {
        loginPage.ClearUserId();
        loginPage.TypeUserId("update@test.com");
        Assert.Equal("update@test.com", loginPage.GetUserId());
    }

}