namespace Legerity.Android.Elements.Core
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Interactions;

    /// <summary>
    /// Defines a <see cref="AndroidElement"/> wrapper for the core Android TimePicker control.
    /// </summary>
    public class TimePicker : AndroidElementWrapper
    {
        private static TimeSpan noon = new TimeSpan(12, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/> reference.
        /// </param>
        public TimePicker(AndroidElement element) : base(element)
        {
        }

        /// <summary>
        /// Gets the element associated with the hour text.
        /// </summary>
        public TextView HourTextView => this.TimeHeader.FindElement(By.Id("android:id/hours"));

        /// <summary>
        /// Gets the element associated with the minutes text.
        /// </summary>
        public TextView MinutesTextView => this.TimeHeader.FindElement(By.Id("android:id/minutes"));

        /// <summary>
        /// Gets the element associated with the AM radio button.
        /// </summary>
        public RadioButton AMRadioButton => this.FormatButtonGroup.FindElement(By.Id("android:id/am_label"));

        /// <summary>
        /// Gets the element associated with the PM radio button.
        /// </summary>
        public RadioButton PMRadioButton => this.FormatButtonGroup.FindElement(By.Id("android:id/pm_label"));
        
        private AppiumWebElement Picker => this.Element.FindElement(By.Id("android:id/radial_picker"));

        /// <summary>
        /// Gets the selected time value.
        /// </summary>
        public TimeSpan SelectedTime => this.GetCurrentViewTime();

        private AppiumWebElement TimeHeader => this.Element.FindElement(By.Id("android:id/time_header"));

        private AppiumWebElement FormatButtonGroup => this.TimeHeader.FindElement(By.Id("android:id/ampm_layout"));

        /// <summary>
        /// Allows conversion of a <see cref="AndroidElement"/> to the <see cref="TimePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AndroidElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TimePicker"/>.
        /// </returns>
        public static implicit operator TimePicker(AndroidElement element)
        {
            return new TimePicker(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="TimePicker"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="TimePicker"/>.
        /// </returns>
        public static implicit operator TimePicker(AppiumWebElement element)
        {
            return new TimePicker(element as AndroidElement);
        }

        ///// <summary>
        ///// Sets the selected time of the time picker.
        ///// </summary>
        ///// <param name="hours">The hours to set to.</param>
        ///// <param name="minutes">The minutes to set to.</param>
        ///// <exception cref="T:System.ArgumentOutOfRangeException">Hours must be between 0 and 24.</exception>
        //public void SetTime(int hours, int minutes)
        //{
        //    this.SetTime(new TimeSpan(hours, minutes, 0));
        //}

        ///// <summary>
        ///// Sets the selected time of the time picker.
        ///// </summary>
        ///// <param name="time">The time to set to.</param>
        ///// <exception cref="T:System.ArgumentOutOfRangeException">Hours must be between 0 and 24.</exception>
        //public void SetTime(TimeSpan time)
        //{
        //    if (time.Hours < 0 || time.Hours > 24)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(time), "Hours must be between 0 and 24.");
        //    }

        //    string hourFormat = time > noon ? "PM" : "AM";
        //    int hours = time.Hours > 12 ? time.Hours - 12 : time.Hours;
        //    int minutes = time.Minutes;

        //    this.HourTextView.Element.SendKeys(Keys.NumberPad1);
        //    //this.Element.SendKeys($"{hours}{minutes}");

        //    if (hourFormat.Equals("AM", StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        this.AMRadioButton.Click();
        //    }
        //    else
        //    {
        //        this.PMRadioButton.Click();;
        //    }
        //}
        public void SetTime(int hours, int minutes)
        {
            this.SetTime(new TimeSpan(hours, minutes, 0));
        }

        public void SetTime(TimeSpan time)
        {
            if (time.Hours < 0 || time.Hours > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(time), "Hours must be between 0 and 24.");
            }

            string hourFormat = time > noon ? "PM" : "AM";
            int hours = time.Hours > 12 ? time.Hours - 12 : time.Hours;
            int minutes = time.Minutes;

            // Create an instance of Actions
            Actions actions = new Actions(this.Driver);

            // Click on the HourTextView and send keys
            actions.MoveToElement((IWebElement)this.HourTextView).Click().SendKeys(hours.ToString()).Perform();

            // Click on the MinutesTextView and send keys
            actions.MoveToElement((IWebElement)this.MinutesTextView).Click().SendKeys(minutes.ToString()).Perform();

            if (hourFormat.Equals("AM", StringComparison.CurrentCultureIgnoreCase))
            {
                this.AMRadioButton.Click();
            }
            else
            {
                this.PMRadioButton.Click();
            }
        }




        //private void SetByWheel(int hours, int minutes)
        //{
        //    AppiumWebElement hourElement = this.Picker.FindElementByXPath($".//*[@content-desc='{hours}']");
        //    hourElement.Click();

        //    AppiumWebElement minuteElement = this.Picker.FindElementByXPath($".//*[@content-desc='{minutes}']");
        //    minuteElement.Click();
        //}

        private TimeSpan GetCurrentViewTime()
        {
            int hours = int.Parse(this.HourTextView.Text);
            int minutes = int.Parse(this.MinutesTextView.Text);

            var time = new TimeSpan(hours, minutes, 0);

            if (!this.PMRadioButton.IsSelected)
            {
                return time;
            }

            if (hours > 0)
            {
                time = time.Add(new TimeSpan(12, 0, 0));
            }

            return time;
        }
    }
}
