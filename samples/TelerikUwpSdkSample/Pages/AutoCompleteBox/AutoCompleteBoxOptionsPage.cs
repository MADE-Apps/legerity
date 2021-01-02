namespace TelerikUwpSdkSample.Pages.AutoCompleteBox
{
    public class AutoCompleteBoxOptionsPage : ListPage
    {
        public FilterSettingsPage GoToFilterSettings()
        {
            return this.Select<FilterSettingsPage>("Filter Settings");
        }
    }
}
