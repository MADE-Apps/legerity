namespace TelerikUwpSdkSample.Pages.BusyIndicator
{
    public class BusyIndicatorOptionsPage : ListPage
    {
        public ConfigurationsPage GoToConfigurations()
        {
            return this.Select<ConfigurationsPage>("Configurations");
        }
    }
}
