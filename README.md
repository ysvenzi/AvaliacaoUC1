# 📑 Atividade Avaliativa: Sistema EcoExpress Logística 🚚🌱

Bem-vindas à atividade prática avaliativa de Introdução à Programação em C#!

Neste desafio, vocês serão responsáveis por desenvolver a inteligência (o código lógico) do sistema interno de uma
transportadora ecológica chamada **EcoExpress**. A interface gráfica (UI) em **WPF** já foi construída e fornecida para
vocês. O objetivo de vocês é fazer o programa funcionar de acordo com as regras de negócio descritas abaixo.

---

## 🎨 A Interface do Usuário (UI)

O design visual foi estruturado usando XAML. Caso precisem recriar ou analisar o layout, o arquivo `MainWindow.xaml`
contém os seguintes componentes principais que vocês deverão interagir via código:

* `txtDistancia` (TextBox): Onde o usuário digita a distância em quilômetros.
* `txtPeso` (TextBox): Onde o usuário digita o peso da carga em quilos.
* `cmbVeiculo` (ComboBox): Onde o usuário seleciona o meio de transporte.
* `chkCupom` (CheckBox): Caixa de seleção para aplicar desconto de fidelidade.
* `btnCalcular` (Button): Botão que dispara o cálculo do frete.
* `btnFinalizar` (Button): Botão que conclui o pedido e salva no histórico.
* `lblValorTotal` (TextBlock): Texto que exibe o resultado final do cálculo.
* `lstHistorico` (ListBox): Lista que armazena os pedidos finalizados.

---

## ⚙️ Regras de Negócio e Requisitos do Código

Vocês devem abrir o arquivo `MainWindow.xaml.cs` (Code-Behind) e programar os eventos de clique dos botões para que o
sistema funcione da seguinte forma:

### 1. Botão "Calcular Frete" (`BtnCalcular_OnClick`)

Ao clicar neste botão, o sistema deve:

1. **Validação de Dados:** Verificar se os campos `txtDistancia` e `txtPeso` não estão vazios. Se algum estiver vazio,
   exiba uma mensagem de alerta usando `MessageBox.Show()`.
2. **Conversão Segura:** Converter os textos digitados para valores numéricos (`double` ou `decimal`). Utilize métodos
   de conversão segura (como `TryParse`) para garantir que o programa não feche sozinho caso o usuário digite letras
   acidentalmente.
3. **Cálculo da Tarifa Base:** O cálculo inicial do frete segue a fórmula:
   $$\text{Tarifa Base} = (\text{Distancia} \times 1.50) + (\text{Peso} \times 0.50)$$
4. **Taxa por Tipo de Veículo:** Dependendo do veículo selecionado no `cmbVeiculo`, aplique um acréscimo sobre o valor
   total:
    * **Triciclo Elétrico:** Sem taxa adicional (0%).
    * **Van Elétrica:** Adicionar **20%** ao valor total.
    * **Caminhão a Hidrogênio:** Adicionar **50%** ao valor total.
5. **Desconto de Cupom:** Se a caixinha `chkCupom` estiver marcada (`IsChecked == true`), aplique um **desconto de 10%**
   sobre o valor final acumulado.
6. **Exibição do Resultado:** Exiba o valor final calculado na label `lblValorTotal`, formatado como moeda local (ex:
   `R$ 150,00`).
7. **Liberação do Pedido:** Se o calculo for realizado com sucesso, mude a propriedade do botão `btnFinalizar` para
   habilitado (`IsEnabled = true`).

### 2. Botão "Finalizar Pedido" (`BtnFinalizar_OnClick`)

Ao clicar neste botão, o sistema deve:

1. **Registrar no Histórico:** Capturar o nome do veículo selecionado e o valor final calculado. Junte essas informações
   em uma única frase (Exemplo: `"Veículo: Van Elétrica | Total: R$ 125,50"`) e adicione-a ao `ListBox` de histórico
   usando o método `lstHistorico.Items.Add()`.
2. **Resetar o Formulário:** Limpar os campos de texto (`txtDistancia` e `txtPeso`), desmarcar o cupom de desconto,
   voltar o texto da label `lblValorTotal` para `"R$ 0,00"` e voltar o `cmbVeiculo` para a primeira opção.
3. **Bloqueio de Segurança:** Mudar a propriedade do próprio botão `btnFinalizar` para desabilitado (
   `IsEnabled = false`), impedindo que o mesmo cálculo seja finalizado duas vezes seguidas.

---

## 🛠️ Critérios de Avaliação

A avaliação levará em conta os seguintes pontos:

* **Lógica de Programação:** Uso correto de estruturas condicionais (`if`, `else` ou `switch`).
* **Manipulação de Variáveis:** Declaração correta de tipos de dados (`string`, `double`/`decimal`, `bool`).
* **Conversão de Tipos:** Conversão de texto das caixas de entrada para tipos numéricos sem gerar erros em tempo de
  execução.
* **Boas Práticas:** Organização do código, recuo (indentação) e nomes de variáveis claros.

*Boa sorte! Usem a lógica e desenvolvam uma excelente solução sustentável.* 🌿💾