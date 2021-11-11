namespace Legerity.Web
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Defines a specific <see cref="AppManagerOptions"/> for a Web application.
    /// </summary>
    public class WebAppManagerOptions : AppManagerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebAppManagerOptions"/> class.
        /// </summary>
        /// <param name="driverType">The type of web application driver to start.</param>
        /// <param name="driverDirectoryPath">The path to the web application driver directory.</param>
        public WebAppManagerOptions(WebAppDriverType driverType, string driverDirectoryPath)
        {
            this.DriverType = driverType;
            this.DriverUri = driverDirectoryPath;
        }

        /// <summary>
        /// Gets or sets the type of web application driver to start.
        /// </summary>
        public WebAppDriverType DriverType { get; set; }

        /// <summary>
        /// Gets or sets the URL of the web application to load.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the desired size of the window for the web application.
        /// <para>
        /// The default value is 1280x800.
        /// </para>
        /// <para>
        /// If <see cref="Maximize"/> is set to true, this value is ignored.
        /// </para>
        /// </summary>
        public Size DesiredSize { get; set; } = new Size(1280, 800);

        /// <summary>
        /// Gets or sets a value indicating whether to maximize the window for the web application.
        /// </summary>
        public bool Maximize { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Platform [{this.DriverType}], {base.ToString()}, {this.GetOptionDetails()}";
        }

        private string GetOptionDetails()
        {
            var options = new List<string>();

            if (!string.IsNullOrWhiteSpace(this.Url))
            {
                options.Add($"URL [{this.Url}]");
            }

            return string.Join(", ", options);
        }
    }
}