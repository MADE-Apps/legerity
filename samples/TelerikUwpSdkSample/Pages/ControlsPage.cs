namespace TelerikUwpSdkSample.Pages
{
    using AutoCompleteBox;

    public class ControlsPage : ListPage
    {
        public AutoCompleteBoxOptionsPage GoToAutoCompleteBox()
        {
            return this.Select<AutoCompleteBoxOptionsPage>("AutoCompleteBox");
        }
    }
}
