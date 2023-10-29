using HomeWork.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace HomeWork.AddToCardCase;

/// <summary>
///     Тест функционала добавления в корзину
/// </summary>
public class AddToCardTests
{
    /// <summary>
    ///     Драйвер который будет использоваться в тестах
    /// </summary>
    private IWebDriver driver;

    /// <summary>
    ///     Объект страницы авторизации
    /// </summary>
    private LoginPage loginPage;

    /// <summary>
    ///     Установка запускаемого пула тестов
    /// </summary>
    [SetUp]
    public void Setup()
    {
        driver = new EdgeDriver();
        loginPage = new LoginPage(driver);
    }

    /// <summary>
    ///     Тест на успешное добавление товаров в корзину с использованием паттерна pageObject
    /// </summary>
    [Test]
    public void AddToCart_SelectAllItems_Successfully()
    {
        //Авторизация
        loginPage.Open();
        loginPage.EnterUsername();
        loginPage.EnterPassword();
        loginPage.ClickLoginButton();

        //Переход на главную страницу
        var homePage = loginPage.OpenHomePage();
        homePage.AddAllItemsToCart();

        //Переход на страницу корзины
        var cartPage = homePage.OpenCart();

        //Переход на страницу оформления
        var checkoutStepOnePage = cartPage.ClickCheckoutButton();
        checkoutStepOnePage.FillBillingInformation("John", "Doe", "123456");

        //Переход на страницу подтверждения
        var checkOutStepTwo = checkoutStepOnePage.ClickContinueButton();
        var (itemCountInCart, cartTotal) = checkOutStepTwo.GetCartTotal();

        Assert.Multiple(() =>
        {
            Assert.That(itemCountInCart, Is.EqualTo(6));
            Assert.That(cartTotal, Is.EqualTo(140.34));
        });
    }

    /// <summary>
    ///     Очистка ресурсов
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}