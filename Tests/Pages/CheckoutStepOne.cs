using OpenQA.Selenium;

namespace HomeWork.Pages;

public class CheckoutStepOne
{
    private readonly IWebDriver _driver;

    public CheckoutStepOne(IWebDriver driver)
    {
        _driver = driver;
    }

    /// <summary>
    ///     Заполняет информацию для оформления заказа, включая имя, фамилию и почтовый индекс.
    /// </summary>
    /// <param name="firstName">Имя покупателя.</param>
    /// <param name="lastName">Фамилия покупателя.</param>
    /// <param name="zipCode">Почтовый индекс покупателя.</param>
    public void FillBillingInformation(string firstName, string lastName, string zipCode)
    {
        var firstNameInput = _driver.FindElement(By.Id("first-name"));
        var lastNameInput = _driver.FindElement(By.Id("last-name"));
        var zipCodeInput = _driver.FindElement(By.Id("postal-code"));

        firstNameInput.SendKeys(firstName);
        lastNameInput.SendKeys(lastName);
        zipCodeInput.SendKeys(zipCode);
    }

    /// <summary>
    ///     Нажимает кнопку "Продолжить" и переходит на следующий этап оформления заказа.
    /// </summary>
    /// <returns>Экземпляр класса CheckOutStepTwo, представляющий следующий этап оформления заказа (шаг 2).</returns>
    public CheckOutStepTwo ClickContinueButton()
    {
        var continueButton = _driver.FindElement(By.Id("continue"));
        continueButton.Click();
        return new CheckOutStepTwo(_driver);
    }
}