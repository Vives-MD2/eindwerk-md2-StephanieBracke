using VidyaBase.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            CollectionViewModel viewModel = new CollectionViewModel();
            BindingContext = viewModel;
            (BindingContext as CollectionViewModel)?.GetCommand.Execute(null);
            InitializeComponent();
        }
    }
}