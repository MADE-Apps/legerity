// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class NumberInputPage : W3SchoolsBasePage
{
    private readonly By quantityNumberInputLocator = By.Id("quantity");

    public NumberInputPage(WebDriver app) : base(app)
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