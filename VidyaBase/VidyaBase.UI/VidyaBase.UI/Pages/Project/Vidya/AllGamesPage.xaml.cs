using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllGamesPage : ContentPage
    {
        public AllGamesPage()
        {
            InitializeComponent();
            GetAllGames();
        }

        public async void GetAllGames()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://metacriticapi.p.rapidapi.com/games?platform=pc&genre=action&filter=date&page=1"),
                Headers =
    {
        { "x-rapidapi-host", "metacriticapi.p.rapidapi.com" },
        { "x-rapidapi-key", "af5da978ddmsh0d191f40937e568p1e203fjsnbb40d46a3a18" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
               await DisplayAlert("Alert", body, "Ok");
            }
            
        }
    }
}