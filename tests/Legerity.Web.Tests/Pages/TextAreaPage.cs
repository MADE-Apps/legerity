// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class TextAreaPage : W3SchoolsBasePage
{
    private readonly By reviewTextAreaLocator = By.Id("w3review");

    public TextAreaPage(WebDriver app) : base(app)
    {
    }

    public TextArea ReviewTextArea => this.FindElement(this.reviewTextAreaLocator);

    public TextAreaPage SetReview(string review)
    {
        this.ReviewTextArea.SetText(review);
        return this;
    }

    public TextAreaPage AppendReview(string review)
    {
        this.ReviewTextArea.AppendText(review);
        return this;
    }

    public TextAreaPage ClearReview()
    {
        this.ReviewTextArea.ClearText();
        return this;
    }
}