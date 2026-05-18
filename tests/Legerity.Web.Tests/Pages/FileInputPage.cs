// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class FileInputPage : W3SchoolsBasePage
{
    private readonly By fileInputLocator = By.Id("myfile");

    public FileInputPage(WebDriver app) : base(app)
    {
    }

    public FileInput FileInput => this.FindElement(this.fileInputLocator);

    public FileInputPage SetFileInputFilePath(string filePath)
    {
        this.FileInput.SetAbsoluteFilePath(filePath);
        return this;
    }

    public FileInputPage ClearFileInput()
    {
        this.FileInput.ClearFile();
        return this;
    }
}