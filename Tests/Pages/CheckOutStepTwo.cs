using System.Globalization;
using OpenQA.Selenium;

namespace HomeWork.Pages;

public class CheckOutStepTwo
{
    private readonly IWebDriver _driver;

    public CheckOutStepTwo(IWebDriver driver)
    {
        _driver = driver;
    }

    /// <summary>
    ///     Получает общее количество товаров в корзине и общую сумму заказа.
    /// </summary>
    /// <returns>Кортеж, содержащий общее количество товаров и общую сумму заказа.</returns>
    public (double, double) GetCartTotal()
    {
        var quantities = _driver.FindElements(By.ClassName("cart_quantity"));
        var total = quantities.Sum(x => int.Parse(x.Text));

        var totalPricesEl = _driver.FindElement(By.CssSelector(".summary_info_label.summary_total_label"));
        var totalPrice = double.Parse(totalPricesEl.Text.Replace("Total: $", ""), CultureInfo.InvariantCulture);

        return (total, totalPrice);
    }
}