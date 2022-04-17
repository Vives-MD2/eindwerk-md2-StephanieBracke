using VidyaBase.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionPage : ContentPage
    {
        ViewCell lastCell;
        public CollectionPage()
        {
            CollectionViewModel viewModel = new CollectionViewModel();
            BindingContext = viewModel;
            (BindingContext as CollectionViewModel)?.GetCommand.Execute(null);
            InitializeComponent();
        }

        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            var value = "#535EEB";
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.FromHex(value);
                lastCell = viewCell;
            }
        }
    }
}