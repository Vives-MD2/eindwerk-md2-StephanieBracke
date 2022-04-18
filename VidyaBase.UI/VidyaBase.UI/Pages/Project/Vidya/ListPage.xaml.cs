using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : TabbedPage
    {
        public ListPage()
        {
            var viewModel = new WishlistViewModel();
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}