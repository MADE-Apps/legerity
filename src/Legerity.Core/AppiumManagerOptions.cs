namespace Legerity;

using OpenQA.Selenium.Appium;

/// <summary>
/// Defines a base model that represents Appium specific configuration options for the <see cref="AppManager"/>.
/// </summary>
public abstract class AppiumManagerOptions : AppManagerOptions
{
    /// <summary>
    /// Gets or sets the additional options to apply to the <see cref="AppiumOptions"/>.
    /// </summary>
    public (string, object)[] AdditionalOptions { get; set; }

    /// <summary>
    /// Gets or sets the options to configure the Appium driver.
    /// <para>
    /// This property is null until the <see cref="Configure"/> method is called.
    /// <see cref="Configure"/> is called automatically when calling the <see cref="AppManager.StartApp"/> method.
    /// </para>
    /// </summary>
    public AppiumOptions AppiumOptions
    {
        get => this.DriverOptions as AppiumOptions;
        set => this.DriverOptions = value;
    }

    /// <summary>
    /// Configures the <see cref="AppiumOptions"/> with the specified additional options.
    /// </summary>
    public virtual void Configure()
    {
        this.AppiumOptions = new AppiumOptions();

        if (this.AdditionalOptions == null)
        {
            return;
        }

        foreach ((string capabilityName, object capabilityValue) in this.AdditionalOptions)
        {
            this.AppiumOptions.AddAdditionalAppiumOption(capabilityName, capabilityValue);
        }
    }
}