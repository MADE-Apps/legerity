namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class NumberInputPage : W3SchoolsBasePage
{
    private readonly By quantityNumberInputLocator = By.Id("quantity");

    public NumberInputPage(RemoteWebDriver app) : base(app)
    {
    }

    public NumberInput QuantityNumberInput => this.FindElement(this.quantityNumberInputLocator);

    public NumberInputPage SetQuantity(int quantity)
    {
        this.QuantityNumberInput.SetValue(quantity);
        return this;
    }

    public NumberInputPage IncrementQuantity()
    {
        this.QuantityNumberInput.Increment();
        return this;
    }

    public NumberInputPage DecrementQuantity()
    {
        this.QuantityNumberInput.Decrement();
        return this;
    }
}