using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class TextAreaPage : W3SchoolsBasePage
{
    private readonly By _reviewTextAreaLocator = By.Id("w3review");

    public TextAreaPage(WebDriver app) : base(app)
    {
    }

    public TextArea ReviewTextArea => FindElement(_reviewTextAreaLocator);

    public TextAreaPage SetReview(string review)
    {
        ReviewTextArea.SetText(review);
        return this;
    }

    public TextAreaPage AppendReview(string review)
    {
        ReviewTextArea.AppendText(review);
        return this;
    }

    public TextAreaPage ClearReview()
    {
        ReviewTextArea.ClearText();
        return this;
    }
}
