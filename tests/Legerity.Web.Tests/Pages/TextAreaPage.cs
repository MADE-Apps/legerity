namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextAreaPage : W3SchoolsBasePage
{
    private readonly By reviewTextAreaLocator = By.Id("w3review");

    public TextAreaPage(WebDriver app) : base(app)
    {
    }

    public TextArea ReviewTextArea => FindElement(reviewTextAreaLocator);

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