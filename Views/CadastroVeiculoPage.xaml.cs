using Frotas.Models;

namespace Frotas.Views;

public partial class CadastroVeiculoPage : ContentPage
{
    private Veiculo veiculoExistente;

    public CadastroVeiculoPage(Veiculo veiculo = null)
    {
        InitializeComponent();

        if (veiculo != null)
        {
            veiculoExistente = veiculo;
            placaEntry.Text = veiculo.Placa;
            fabricanteEntry.Text = veiculo.Fabricante;
            modeloEntry.Text = veiculo.Modelo;
            corEntry.Text = veiculo.Cor;
            anoEntry.Text = veiculo.Ano.ToString();
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        var veiculo = new Veiculo
        {
            Id = veiculoExistente?.Id ?? 0,
            Placa = placaEntry.Text,
            Fabricante = fabricanteEntry.Text,
            Modelo = modeloEntry.Text,
            Cor = corEntry.Text,
            Ano = int.TryParse(anoEntry.Text, out int ano) ? ano : 0
        };

        await App.Banco.SalvarVeiculoAsync(veiculo);
        await Navigation.PopAsync();
    }
}