namespace TelerikUwpSdkSample.Pages
{
    using AutoCompleteBox;
    using BulletGraph;

    public class ControlsPage : ListPage
    {
        public AutoCompleteBoxOptionsPage GoToAutoCompleteBox()
        {
            return this.Select<AutoCompleteBoxOptionsPage>("AutoCompleteBox");
        }

        public BulletGraphOptionsPage GoToBulletGraph()
        {
            return this.Select<BulletGraphOptionsPage>("BulletGraph");
        }
    }
}
