using OpenQA.Selenium;

namespace HomeWork.Pages;

public class CartPage
{
    private readonly IWebDriver _driver;

    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }

    /// <summary>
    ///     Получает количество товаров в корзине.
    /// </summary>
    /// <returns>Количество товаров в корзине.</returns>
    public int GetItemCountInCart()
    {
        IReadOnlyCollection<IWebElement> buttons =
            _driver.FindElements(By.CssSelector(".btn.btn_primary.btn_small.btn_inventory"));
        return buttons.Count;
    }

    /// <summary>
    ///     Нажимает кнопку "Оформить заказ" и переходит на страницу оформления заказа.
    /// </summary>
    /// <returns>Экземпляр класса CheckoutStepOne, представляющий страницу оформления заказа (шаг 1).</returns>
    public CheckoutStepOne ClickCheckoutButton()
    {
        var checkoutButton = _driver.FindElement(By.Id("checkout"));
        checkoutButton.Click();
        return new CheckoutStepOne(_driver);
    }
}