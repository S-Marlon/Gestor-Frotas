using Frotas.Models;

namespace Frotas.Views;

public partial class CombustivelPage : ContentPage
{
    public CombustivelPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListaCombustiveis.ItemsSource = await App.Banco.GetCombustiveisAsync();
    }

    private async void OnAdicionarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroCombustivelPage());
    }

    private async void OnSelecionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Combustivel selecionado)
        {
            await Navigation.PushAsync(new CadastroCombustivelPage(selecionado));
        }

        ListaCombustiveis.SelectedItem = null;
    }
    
    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Combustivel combustivel)
        {
            bool emUso = await App.Banco.CombustivelEmUsoAsync(combustivel.Id);
            if (emUso)
            {
                await DisplayAlert("Erro", "Este combustível está em uso e não pode ser excluído.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirmação",
                $"Deseja excluir o combustível '{combustivel.Nome}'?",
                "Sim", "Não");

            if (confirm)
            {
                await App.Banco.DeletarCombustivelAsync(combustivel);
                ListaCombustiveis.ItemsSource = await App.Banco.GetCombustiveisAsync();
            }
        }
    }
}
