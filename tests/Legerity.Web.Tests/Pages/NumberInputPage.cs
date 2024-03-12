namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class NumberInputPage : W3SchoolsBasePage
{
    private readonly By quantityNumberInputLocator = By.Id("quantity");

    public NumberInputPage(WebDriver app) : base(app)
    {
    }

    public NumberInput QuantityNumberInput => FindElement(quantityNumberInputLocator);

    public NumberInputPage SetQuantity(int quantity)
    {
        QuantityNumberInput.SetValue(quantity);
        return this;
    }

    public NumberInputPage IncrementQuantity()
    {
        QuantityNumberInput.Increment();
        return this;
    }

    public NumberInputPage DecrementQuantity()
    {
        QuantityNumberInput.Decrement();
        return this;
    }
}