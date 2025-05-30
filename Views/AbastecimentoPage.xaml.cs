using Frotas.Models;

namespace Frotas.Views;

public partial class AbastecimentoPage : ContentPage
{
    public AbastecimentoPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListaAbastecimentos.ItemsSource = await App.Banco.GetAbastecimentosAsync();
    }

    private async void OnAdicionarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroAbastecimentoPage());
    }

    private async void OnSelecionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Abastecimento selecionado)
        {
            await Navigation.PushAsync(new CadastroAbastecimentoPage(selecionado));
        }

        ListaAbastecimentos.SelectedItem = null;
    }

    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Abastecimento abastecimento)
        {
            bool confirm = await DisplayAlert("Confirmação",
                $"Deseja excluir o abastecimento de {abastecimento.Litros} litros em {abastecimento.Data:dd/MM/yyyy}?",
                "Sim", "Não");

            if (confirm)
            {
                await App.Banco.DeletarAbastecimentoAsync(abastecimento);
                ListaAbastecimentos.ItemsSource = await App.Banco.GetAbastecimentosAsync();
            }
        }
    }
}