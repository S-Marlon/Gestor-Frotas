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
            modeloEntry.Text = veiculo.Modelo;
            marcaEntry.Text = veiculo.Marca;
            anoEntry.Text = veiculo.Ano.ToString();
            placaEntry.Text = veiculo.Placa;
            kmEntry.Text = veiculo.KmAtual.ToString();
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        var novoVeiculo = new Veiculo
        {
            Id = veiculoExistente?.Id ?? 0,
            Modelo = modeloEntry.Text,
            Marca = marcaEntry.Text,
            Ano = int.TryParse(anoEntry.Text, out int ano) ? ano : 0,
            Placa = placaEntry.Text,
            KmAtual = double.TryParse(kmEntry.Text, out double km) ? km : 0
        };

        await App.Banco.SalvarVeiculoAsync(novoVeiculo);
        await Navigation.PopAsync();
    }
}