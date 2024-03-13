using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class NumberInputPage : W3SchoolsBasePage
{
    private readonly By _quantityNumberInputLocator = By.Id("quantity");

    public NumberInputPage(WebDriver app) : base(app)
    {
    }

    public NumberInput QuantityNumberInput => FindElement(_quantityNumberInputLocator);

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
