namespace DeveloperNews.UI.Views
{
    using System.Windows.Controls;

    public partial class DeveloperNewsControl : UserControl
    {
        public DeveloperNewsControl()
            => InitializeComponent();

        //private void btnGo_Click(object sender, RoutedEventArgs e)
        //{
        //    using (XmlReader reader = XmlReader.Create(txtUrl.Text))
        //    {
        //        SyndicationFeed feed = SyndicationFeed.Load(reader);
        //        lstFeedItems.ItemsSource = feed.Items;
        //    }
        //}
    }
}