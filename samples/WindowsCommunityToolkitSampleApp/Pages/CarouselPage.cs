namespace WindowsCommunityToolkitSampleApp.Pages
{
    using Legerity.Windows;
    using Legerity.Windows.Elements.WCT;
    using OpenQA.Selenium;
    using Shouldly;

    /// <summary>
    /// Defines the Carousel page of the Windows Community Toolkit sample application.
    /// </summary>
    public class CarouselPage : AppPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarouselPage"/> class.
        /// </summary>
        public CarouselPage()
        {
        }

        public Carousel Carousel => this.WindowsApp.FindElement(WindowsByExtras.AutomationId("CarouselControl"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@ClassName='TextBlock'][@Name='Carousel']");

        public CarouselPage SelectCarouselItem(string name)
        {
            this.Carousel.SelectItem(name);
            return this;
        }

        public CarouselPage SelectCarouselItem(int index)
        {
            this.Carousel.SelectItem(index);
            return this;
        }

        public void VerifySelectedCarouselItem(string expectedItem)
        {
            this.Carousel.SelectedItem.Text.ShouldBe(expectedItem);
        }

        public void VerifySelectedCarouselItem(int expectedIndex)
        {
            this.Carousel.SelectedIndex.ShouldBe(expectedIndex);
        }
    }
}
