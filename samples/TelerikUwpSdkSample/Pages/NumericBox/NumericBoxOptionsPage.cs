namespace TelerikUwpSdkSample.Pages.NumericBox
{
    public class NumericBoxOptionsPage : ListPage
    {
        public ConfigurationsPage GoToConfigurations()
        {
            return this.Select<ConfigurationsPage>("Configurations");
        }
    }
}
