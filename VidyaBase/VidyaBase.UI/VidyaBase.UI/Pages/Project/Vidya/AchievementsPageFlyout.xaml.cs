using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchievementsPageFlyout : ContentPage
    {
        public ListView ListView;

        public AchievementsPageFlyout()
        {
            InitializeComponent();

            BindingContext = new AchievementsPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class AchievementsPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AchievementsPageFlyoutMenuItem> MenuItems { get; set; }

            public AchievementsPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AchievementsPageFlyoutMenuItem>(new[]
                {
                    new AchievementsPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new AchievementsPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new AchievementsPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new AchievementsPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new AchievementsPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}