// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class ListPage : W3SchoolsBasePage
{
    private readonly By orderedListLocator = By.TagName("ol");

    public ListPage(WebDriver app) : base(app)
    {
    }

    public List OrderedList => this.FindElements(this.orderedListLocator).FirstOrDefault();
}