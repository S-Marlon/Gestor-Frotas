using Frotas.Models;

namespace Frotas.Views;

public partial class VeiculoPage : ContentPage
{
    public VeiculoPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Carrega os veículos do banco e mostra na CollectionView
        ListaVeiculos.ItemsSource = await App.Banco.GetVeiculosAsync();
    }

    private async void OnAdicionarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroVeiculoPage());
    }

    private async void OnSelecionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Veiculo veiculoSelecionado)
        {
            await Navigation.PushAsync(new CadastroVeiculoPage(veiculoSelecionado));
        }

        // Desmarcar item após o clique
        ListaVeiculos.SelectedItem = null;
    }
}