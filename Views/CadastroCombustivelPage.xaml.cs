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
            valorEntry.Text = combustivel.Valor.ToString("F2");
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nomeEntry.Text) ||
            !decimal.TryParse(valorEntry.Text, out decimal valor))
        {
            await DisplayAlert("Erro", "Preencha todos os campos corretamente.", "OK");
            return;
        }

        var novoCombustivel = new Combustivel
        {
            Id = combustivelExistente?.Id ?? 0,
            Nome = nomeEntry.Text.Trim(),
            Valor = valor
        };

        await App.Banco.SalvarCombustivelAsync(novoCombustivel);
        await Navigation.PopAsync();
    }
}
