namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class TextAreaPage : W3SchoolsBasePage
{
    private readonly By reviewTextAreaLocator = By.Id("w3review");

    public TextAreaPage(RemoteWebDriver app) : base(app)
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