using Frotas.Models;

namespace Frotas.Views;

public partial class CadastroAbastecimentoPage : ContentPage
{
    private Abastecimento abastecimentoExistente;
    private List<Veiculo> veiculos;
    private List<Combustivel> combustiveis;

    public CadastroAbastecimentoPage(Abastecimento abastecimento = null)
    {
        InitializeComponent();
        abastecimentoExistente = abastecimento;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        veiculos = await App.Banco.GetVeiculosAsync();
        combustiveis = await App.Banco.GetCombustiveisAsync();

        veiculoPicker.ItemsSource = veiculos;
        combustivelPicker.ItemsSource = combustiveis;

        if (abastecimentoExistente != null)
        {
            veiculoPicker.SelectedItem = veiculos.FirstOrDefault(v => v.Id == abastecimentoExistente.VeiculoId);
            combustivelPicker.SelectedItem = combustiveis.FirstOrDefault(c => c.Id == abastecimentoExistente.CombustivelId);
            litrosEntry.Text = abastecimentoExistente.Litros.ToString("F2");
            precoLitroEntry.Text = abastecimentoExistente.PrecoLitro.ToString("F2");
            kmEntry.Text = abastecimentoExistente.Km.ToString();
            dataPicker.Date = abastecimentoExistente.Data;
        }
        else
        {
            dataPicker.Date = DateTime.Now;
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (veiculoPicker.SelectedItem is not Veiculo veiculo ||
            combustivelPicker.SelectedItem is not Combustivel combustivel ||
            !decimal.TryParse(litrosEntry.Text, out decimal litros) ||
            !decimal.TryParse(precoLitroEntry.Text, out decimal preco) ||
            !long.TryParse(kmEntry.Text, out long km))
        {
            await DisplayAlert("Erro", "Preencha todos os campos corretamente.", "OK");
            return;
        }

        var novoAbastecimento = new Abastecimento
        {
            Id = abastecimentoExistente?.Id ?? 0,
            VeiculoId = veiculo.Id,
            CombustivelId = combustivel.Id,
            Litros = litros,
            PrecoLitro = preco,
            Km = km,
            Data = dataPicker.Date
        };

        await App.Banco.SalvarAbastecimentoAsync(novoAbastecimento);
        await Navigation.PopAsync();
    }

}
