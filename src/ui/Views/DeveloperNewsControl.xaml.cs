using System.Windows.Controls;

namespace DeveloperNews.UI.Views
{
    public partial class DeveloperNewsControl : UserControl
    {
        public DeveloperNewsControl()
        {
            InitializeComponent();

            //DataContext = new StartPageFeedViewModel();
        }

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