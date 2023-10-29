using OpenQA.Selenium;

namespace HomeWork.Pages;

/// <summary>
///     Длмашнияя страница
/// </summary>
public class HomePage
{
    private readonly IWebDriver _driver;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    /// <summary>
    ///     Добавляет все товары в корзину, выполняя клик на каждом из них.
    /// </summary>
    public void AddAllItemsToCart()
    {
        var buttons = _driver.FindElements(By.CssSelector(".btn.btn_primary.btn_small.btn_inventory"));
        foreach (var button in buttons) button.Click();
    }

    /// <summary>
    ///     Открывает страницу корзины покупок.
    /// </summary>
    /// <returns>Экземпляр класса CartPage, представляющий страницу корзины покупок.</returns>
    public CartPage OpenCart()
    {
        var cartLink = _driver.FindElement(By.Id("shopping_cart_container"));
        cartLink.Click();
        return new CartPage(_driver);
    }
}