namespace Frotas.Views;

public partial class RelatoriosPage : ContentPage
{
    public RelatoriosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var abastecimentos = await App.Banco.GetAbastecimentosAsync();
        var combustiveis = await App.Banco.GetCombustiveisAsync();
        var veiculos = await App.Banco.GetVeiculosAsync();

        // 1️⃣ Totais por tipo de combustível (em litros)
        var totais = combustiveis.Select(c =>
        {
            var totalLitros = abastecimentos
                .Where(a => a.CombustivelId == c.Id)
                .Sum(a => a.Litros);

            return $"{c.Nome}: {totalLitros} litros";
        }).ToList();
        TotaisCombustivel.ItemsSource = totais;

        // 2️⃣ Percentuais por combustível
        decimal litrosTotais = abastecimentos.Sum(a => a.Litros);
        var percentuais = combustiveis.Select(c =>
        {
            decimal total = abastecimentos
                .Where(a => a.CombustivelId == c.Id)
                .Sum(a => a.Litros);

            decimal percentual = litrosTotais > 0 ? (total / litrosTotais) * 100 : 0;
            return $"{c.Nome}: {percentual:F1}%";
        }).ToList();
        PercentuaisCombustivel.ItemsSource = percentuais;

        // 3️⃣ Média de consumo por veículo: média = total km / total litros
        var medias = veiculos.Select(v =>
        {
            var abastecs = abastecimentos.Where(a => a.VeiculoId == v.Id).ToList();
            decimal litros = abastecs.Sum(a => a.Litros);
            long km = abastecs.Sum(a => a.Km);
            string resultado = "Sem dados";

            if (litros > 0 && km > 0)
            {
                double media = (double)km / (double)litros;
                resultado = $"{media:F2} km/l";
            }

            return $"{v.Modelo} ({v.Placa}): {resultado}";
        }).ToList();
        MediasVeiculo.ItemsSource = medias;
    }
}