namespace XamlControlsGallery.Tests.Text
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.Text;

    [TestClass]
    public class NumberBoxTests : BaseTestClass
    {
        private static NumberBoxPage NumberBoxPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            NumberBoxPage = new NavigationMenu().GoToNumberBoxPage();
        }

        [TestMethod]
        public void SetSpinnerNumberBoxValue()
        {
            // Arrange
            double expected = 1500;

            // Act
            NumberBoxPage.SetSpinnerNumberBoxValue(expected);

            // Assert
            NumberBoxPage.VerifySpinnerNumberBoxValue(expected);
        }

        [TestMethod]
        public void IncrementSpinnerNumberBoxValue()
        {
            // Arrange
            double initial = 1500;
            double increment = NumberBoxPage.SpinnerNumberBox.SmallChange;
            var expected = initial + increment;

            NumberBoxPage.SetSpinnerNumberBoxValue(initial);

            // Act
            NumberBoxPage.IncrementSpinnerNumberBoxValue();

            // Assert
            NumberBoxPage.VerifySpinnerNumberBoxValue(expected);
        }

        [TestMethod]
        public void DecrementSpinnerNumberBoxValue()
        {
            // Arrange
            double initial = 1500;
            double increment = NumberBoxPage.SpinnerNumberBox.SmallChange;
            var expected = initial - increment;

            NumberBoxPage.SetSpinnerNumberBoxValue(initial);

            // Act
            NumberBoxPage.DecrementSpinnerNumberBoxValue();

            // Assert
            NumberBoxPage.VerifySpinnerNumberBoxValue(expected);
        }
    }
}