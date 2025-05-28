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

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Veiculo veiculo)
        {
            bool confirm = await DisplayAlert("Confirmação",
                $"Excluir o veículo '{veiculo.Modelo}' e todos os abastecimentos associados?",
                "Sim", "Não");

            if (confirm)
            {
                // Primeiro exclui abastecimentos
                await App.Banco.ExcluirAbastecimentosPorVeiculoAsync(veiculo.Id);

                // Depois exclui o veículo
                await App.Banco.DeletarVeiculoAsync(veiculo);

                // Atualiza a lista
                ListaVeiculos.ItemsSource = await App.Banco.GetVeiculosAsync();
            }
        }
    }
}