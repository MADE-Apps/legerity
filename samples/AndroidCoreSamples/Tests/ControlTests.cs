namespace AndroidCoreSamples.Tests
{
    using System;
    using AndroidCoreSamples;
    using Legerity;
    using Legerity.Android.Elements.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Shouldly;

    [TestClass]
    public class ControlTests : BaseTestClass
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void EditTextTest()
        {
            EditText editText = AppManager.AndroidApp.FindElement(By.Id("editText1"));

            editText.IsEnabled.ShouldBeTrue();

            editText.SetText("Hello, World!");

            editText.Text.ShouldBe("Hello, World!");

            editText.AppendText(" And more text after!");

            editText.Text.ShouldBe("Hello, World! And more text after!");

            editText.ClearText();

            editText.Text.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void ToggleButtonTest()
        {
            ToggleButton toggleButton = AppManager.AndroidApp.FindElement(By.Id("toggleButton1"));

            toggleButton.IsEnabled.ShouldBeTrue();

            toggleButton.ToggleOn();

            toggleButton.IsOn.ShouldBeTrue();

            toggleButton.ToggleOff();

            toggleButton.IsOn.ShouldBeFalse();
        }

        [TestMethod]
        public void CheckBoxTest()
        {
            CheckBox checkBox = AppManager.AndroidApp.FindElement(By.Id("checkBox1"));

            checkBox.IsEnabled.ShouldBeTrue();

            checkBox.CheckOn();

            checkBox.IsChecked.ShouldBeTrue();

            checkBox.CheckOff();

            checkBox.IsChecked.ShouldBeFalse();
        }

        [TestMethod]
        public void RadioButtonTest()
        {
            RadioButton radioButton = AppManager.AndroidApp.FindElement(By.Id("radioButton1"));

            radioButton.IsEnabled.ShouldBeTrue();

            radioButton.IsSelected.ShouldBeFalse();

            radioButton.Click();

            radioButton.IsSelected.ShouldBeTrue();
        }

        [TestMethod]
        public void SwitchTest()
        {
            Switch switchElement = AppManager.AndroidApp.FindElement(By.Id("switch1"));

            switchElement.IsEnabled.ShouldBeTrue();

            switchElement.ToggleOn();

            switchElement.IsOn.ShouldBeTrue();

            switchElement.ToggleOff();

            switchElement.IsOn.ShouldBeFalse();
        }

        [TestMethod]
        public void SpinnerTest()
        {
            Spinner spinner = AppManager.AndroidApp.FindElement(By.Id("spinner1"));

            spinner.IsEnabled.ShouldBeTrue();

            spinner.SelectItem("Austria");

            spinner.SelectedItem.ShouldBe("Austria");
        }


        [TestMethod]
        public void TextViewTest()
        {
            TextView textView = AppManager.AndroidApp.FindElement(By.Id("textView1"));

            textView.IsEnabled.ShouldBeTrue();

            textView.Text.ShouldBe("Hello World!");
        }

        [TestMethod]
        public void DatePickerTest()
        {
            DatePicker datePicker = AppManager.AndroidApp.FindElement(By.Id("datePicker1"));

            datePicker.IsEnabled.ShouldBeTrue();

            var setDate = new DateTime(2020, 12, 25);

            datePicker.SetDate(setDate);

            DateTime newSelectedDate = datePicker.SelectedDate.Date;

            newSelectedDate.Date.ShouldBe(setDate.Date);
        }
    }
}