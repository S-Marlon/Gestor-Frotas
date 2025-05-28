using Frotas.Models;

namespace Frotas.Views;

public partial class CadastroCombustivelPage : ContentPage
{
    private Combustivel combustivelExistente;

    public CadastroCombustivelPage(Combustivel combustivel = null)
    {
        InitializeComponent();

        if (combustivel != null)
        {
            combustivelExistente = combustivel;
            nomeEntry.Text = combustivel.Nome;
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nomeEntry.Text))
        {
            await DisplayAlert("Erro", "Digite um nome para o combustível.", "OK");
            return;
        }

        var novoCombustivel = new Combustivel
        {
            Id = combustivelExistente?.Id ?? 0,
            Nome = nomeEntry.Text.Trim()
        };

        await App.Banco.SalvarCombustivelAsync(novoCombustivel);
        await Navigation.PopAsync();
    }
}
