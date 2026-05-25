using System.Windows;

namespace Avaliacao;

public partial class MainWindow : Window
{
    string valorTotal;
    string veiculoEscolhido;

    public MainWindow()
    {
        InitializeComponent();
    }


    private void BtnCalcular_OnClick(object sender, RoutedEventArgs e)
    {
        //Validação de Dados: Verificar se os campos txtDistancia e txtPeso não estão vazios. Se algum estiver vazio, exiba uma mensagem de alerta usando MessageBox.Show().
        if (string.IsNullOrEmpty(txtDistancia.Text))
        {
            MessageBox.Show("Informe o valor da distancia!");
            return;
        }

        if (string.IsNullOrEmpty(txtPeso.Text))
        {
            MessageBox.Show("Informe o valor do peso!");
            return;
        }

        //Conversão Segura: Converter os textos digitados para valores numéricos (double ou decimal). Utilize métodos de conversão segura (como TryParse) para garantir que o programa não feche sozinho caso o usuário digite letras acidentalmente.
        if (!double.TryParse(txtDistancia.Text, out var txtDistanciaConv))
        {
            MessageBox.Show("Coloque apenas valores númericos!");
            return;
        }

        if (!double.TryParse(txtPeso.Text, out var txtPesoConv))
        {
            MessageBox.Show("Coloque apenas valores númericos!");
            return;
        }

        //Cálculo da Tarifa Base: O cálculo inicial do frete segue a fórmula: Tarifa Base = (Distancia × 1.50) + (Peso × 0.50)
        double tarifaBase;
        tarifaBase = (txtDistanciaConv * 1.5) + (txtPesoConv * 0.5);

        //Taxa por Tipo de Veículo: Dependendo do veículo selecionado no cmbVeiculo, aplique um acréscimo sobre o valor total: Triciclo Elétrico: Sem taxa adicional (0%). Van Elétrica: Adicionar 20% ao valor total. Caminhão a Hidrogênio: Adicionar 50% ao valor total.
        string veiculoSelecionado = cmbVeiculo.Text;
        double freteTotal = 0;

        switch (veiculoSelecionado)
        {
            case "Triciclo Elétrico (Eco)":
                freteTotal = tarifaBase;
                break;

            case "Van Elétrica":
                freteTotal = tarifaBase * 1.20;
                break;

            case "Caminhão a Hidrogênio":
                freteTotal = tarifaBase * 1.50;
                break;
        }

        veiculoEscolhido = veiculoSelecionado;

        //Desconto de Cupom: Se a caixinha chkCupom estiver marcada (IsChecked == true), aplique um desconto de 10% sobre o valor final acumulado.
        if (chkCupom.IsChecked == true)
        {
            freteTotal = freteTotal * 0.90;
        }

        valorTotal = freteTotal.ToString("C2");

        //Exibição do Resultado: Exiba o valor final calculado na label lblValorTotal, formatado como moeda local (ex: R$ 150,00).
        lblValorTotal.Text = freteTotal.ToString("C2");

        //Liberação do Pedido: Se o calculo for realizado com sucesso, mude a propriedade do botão btnFinalizar para habilitado (IsEnabled = true).
        btnFinalizar.IsEnabled = true;
    }

    private void BtnFinalizar_OnClick(object sender, RoutedEventArgs e)
    {
        //Registrar no Histórico: Capturar o nome do veículo selecionado e o valor final calculado. Junte essas informações em uma única frase (Exemplo: "Veículo: Van Elétrica | Total: R$ 125,50") e adicione-a ao ListBox de histórico usando o método lstHistorico.Items.Add().
        lstHistorico.Items.Add($"Veículo: {veiculoEscolhido} | Total: R$ {valorTotal}");

        //Resetar o Formulário: Limpar os campos de texto (txtDistancia e txtPeso), desmarcar o cupom de desconto, voltar o texto da label lblValorTotal para "R$ 0,00" e voltar o cmbVeiculo para a primeira opção.
        txtDistancia.Clear();
        txtPeso.Clear();
        chkCupom.IsChecked = false;
        lblValorTotal.Text = "R$ 0,00";
        cmbVeiculo.SelectedIndex = 0;

        //Bloqueio de Segurança: Mudar a propriedade do próprio botão btnFinalizar para desabilitado ( IsEnabled = false), impedindo que o mesmo cálculo seja finalizado duas vezes seguidas.
        btnFinalizar.IsEnabled = false;
    }
}