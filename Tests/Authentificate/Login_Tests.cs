using HomeWork.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace HomeWork.Authentificate;

/// <summary>
///     Тест сайта https://www.saucedemo.com/
/// </summary>
public class LoginTests
{
    /// <summary>
    ///     Имя пользователя некорректное
    /// </summary>
    private const string UserNameInvalid = "111111111";

    /// <summary>
    ///     Пароль некорректный
    /// </summary>
    private const string PasswordInvalid = "111111111";

    /// <summary>
    ///     Драйвер который будет использоваться в тестах
    /// </summary>
    private IWebDriver _driver;

    /// <summary>
    ///     Установка запускаемого пула тестов
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _driver = new EdgeDriver();
    }

    /// <summary>
    ///     Тест на успешный ввод кридов
    /// </summary>
    [Test]
    public void Authenticate_Success()
    {
        _driver.Navigate().GoToUrl(Utils.UrlAuth);

        var elementLogin = _driver.FindElement(By.XPath("//input[@name='user-name']"));
        var elementPassword = _driver.FindElement(By.XPath("//input[@name='password']"));
        var elementSubmitButton = _driver.FindElement(By.XPath("//input[@name='login-button']"));

        elementLogin.SendKeys(Utils.UserNameValid);
        elementPassword.SendKeys(Utils.PasswordValid);

        elementSubmitButton.Click();

        Assert.That(_driver.Url, Is.EqualTo(Utils.UrlProducts));
    }

    /// <summary>
    ///     Тест на неуспешный ввод логина
    /// </summary>
    [Test]
    public void Authenticate_Fail_Username()
    {
        _driver.Navigate().GoToUrl(Utils.UrlAuth);

        var elementLogin = _driver.FindElement(By.XPath("//input[@name='user-name']"));
        var elementPassword = _driver.FindElement(By.XPath("//input[@name='password']"));
        var elementSubmitButton = _driver.FindElement(By.XPath("//input[@name='login-button']"));

        elementLogin.SendKeys(UserNameInvalid);
        elementPassword.SendKeys(Utils.PasswordValid);

        elementSubmitButton.Click();

        Assert.That(_driver.Url, Is.EqualTo(Utils.UrlAuth));
    }

    /// <summary>
    ///     Тест на неуспешный ввод пароля
    /// </summary>
    [Test]
    public void Authenticate_Fail_Password()
    {
        _driver.Navigate().GoToUrl(Utils.UrlAuth);

        var elementLogin = _driver.FindElement(By.XPath("//input[@name='user-name']"));
        var elementPassword = _driver.FindElement(By.XPath("//input[@name='password']"));
        var elementSubmitButton = _driver.FindElement(By.XPath("//input[@name='login-button']"));

        elementLogin.SendKeys(Utils.UserNameValid);
        elementPassword.SendKeys(PasswordInvalid);

        elementSubmitButton.Click();

        Assert.That(_driver.Url, Is.EqualTo(Utils.UrlAuth));
    }

    /// <summary>
    ///     Тест на успешный ввод кридов и поиск по локаторам
    /// </summary>
    [Test]
    public void Locators_Test_Success()
    {
        _driver.Navigate().GoToUrl(Utils.UrlAuth);

        var elementLogin = _driver.FindElement(By.XPath("//input[@name='user-name']"));
        var elementPassword = _driver.FindElement(By.XPath("//input[@name='password']"));
        var elementSubmitButton = _driver.FindElement(By.XPath("//input[@name='login-button']"));

        elementLogin.SendKeys(Utils.UserNameValid);
        elementPassword.SendKeys(Utils.PasswordValid);

        elementSubmitButton.Click();

        var elementId = _driver.FindElement(By.Id("logout_sidebar_link"));
        var elementName = _driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack"));
        var elementXPath = _driver.FindElement(By.XPath("//div[@class='header_label']"));
        var elementSelector = _driver.FindElement(By.CssSelector(".header_label"));
        var elementTag = _driver.FindElement(By.TagName("div"));
        var elementClass = _driver.FindElement(By.ClassName("title"));
        var elementLink = _driver.FindElement(By.LinkText("LinkedIn"));
        var elementPartLink = _driver.FindElement(By.PartialLinkText("Linked"));


        Assert.Multiple(() =>
        {
            Assert.That(elementId.TagName, Is.Not.Null);
            Assert.That(elementName.TagName, Is.Not.Null);
            Assert.That(elementXPath.TagName, Is.Not.Null);
            Assert.That(elementSelector.TagName, Is.Not.Null);
            Assert.That(elementLink.TagName, Is.Not.Null);
            Assert.That(elementPartLink.TagName, Is.Not.Null);
            Assert.That(elementTag.TagName, Is.Not.Null);
            Assert.That(elementClass.TagName, Is.Not.Null);
        });
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}