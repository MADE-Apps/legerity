namespace TelerikUwpSdkSample.Pages.BulletGraph
{
    public class BulletGraphOptionsPage : ListPage
    {
        public CustomizationsPage GoToCustomizations()
        {
            return this.Select<CustomizationsPage>("Customizations");
        }
    }
}
