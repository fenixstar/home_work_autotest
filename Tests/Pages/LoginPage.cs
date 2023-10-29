using HomeWork.Core;
using OpenQA.Selenium;

namespace HomeWork.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    /// <summary>
    ///     Открывает страницу входа по указанному URL.
    /// </summary>
    public void Open()
    {
        _driver.Navigate().GoToUrl(Utils.UrlAuth);
    }

    /// <summary>
    ///     Вводит имя пользователя в соответствующее поле.
    /// </summary>
    public void EnterUsername()
    {
        var usernameInput = _driver.FindElement(By.Id("user-name"));
        usernameInput.Clear();
        usernameInput.SendKeys(Utils.UserNameValid);
    }

    /// <summary>
    ///     Вводит пароль в соответствующее поле.
    /// </summary>
    public void EnterPassword()
    {
        var passwordInput = _driver.FindElement(By.Id("password"));
        passwordInput.Clear();
        passwordInput.SendKeys(Utils.PasswordValid);
    }

    /// <summary>
    ///     Нажимает кнопку входа.
    /// </summary>
    public void ClickLoginButton()
    {
        var loginButton = _driver.FindElement(By.Id("login-button"));
        loginButton.Click();
    }

    /// <summary>
    ///     Открывает главную страницу после успешного входа.
    /// </summary>
    /// <returns>Экземпляр класса HomePage, представляющий главную страницу.</returns>
    public HomePage OpenHomePage()
    {
        return new HomePage(_driver);
    }
}