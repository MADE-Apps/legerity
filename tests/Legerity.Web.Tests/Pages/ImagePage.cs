// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class ImagePage : W3SchoolsBasePage
{
    private readonly By imageLocator = By.TagName("img");

    public ImagePage(WebDriver app) : base(app)
    {
    }

    public Image Image => this.FindElement(this.imageLocator);
}