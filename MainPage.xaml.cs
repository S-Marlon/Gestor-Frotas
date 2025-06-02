using Frotas.Views;

namespace Frotas
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnVeiculosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VeiculoPage());
        }

        private async void OnCombustiveisClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CombustivelPage());
        }

        private async void OnAbastecimentosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AbastecimentoPage());
        }
        private async void OnRelatoriosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatoriosPage());
        }


    }

}
