namespace XamlControlsGallery.Pages
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    public class SettingsPage : BasePage
    {
        public ToggleSwitch SoundToggle => this.WindowsApp.FindElement(ByExtensions.AutomationId("soundToggle"));

        protected override By Trait => By.XPath(".//*[@Name='Settings'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Toggles the sound option by the given on state.
        /// </summary>
        /// <param name="toggleOn">A value indicating whether to toggle sound on.</param>
        /// <returns>
        /// The <see cref="SettingsPage"/>.
        /// </returns>
        public SettingsPage ToggleSoundOption(bool toggleOn)
        {
            if (toggleOn)
            {
                this.SoundToggle.ToggleOn();
            }
            else
            {
                this.SoundToggle.ToggleOff();
            }

            return this;
        }

        /// <summary>
        /// Verifies that the toggle sound option is in the expected on state.
        /// </summary>
        /// <param name="expectedToggleOn">
        /// A value indicating whether the expected state is on.
        /// </param>
        /// <returns>
        /// The <see cref="SettingsPage"/>.
        /// </returns>
        /// <exception cref="AssertFailedException">
        /// Thrown if the toggle sound option is not in the expected state.
        /// </exception>
        public SettingsPage VerifyToggleSoundOption(bool expectedToggleOn)
        {
            if ((!expectedToggleOn || !this.SoundToggle.IsOn) && (expectedToggleOn || this.SoundToggle.IsOn))
            {
                throw new AssertFailedException(
                    $"The toggle switch 'soundToggle' was not in the expected state. Expected toggle on: {expectedToggleOn}.");
            }

            return this;
        }
    }
}