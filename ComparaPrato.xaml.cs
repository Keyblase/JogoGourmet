using JogoGourmet.Manager;
using System.Windows;

namespace JogoGourmet
{
    public partial class ComparaPrato : Window
    {
        private readonly PratoManager pratoManager;
        private readonly string comidaEscolhida;
        private readonly MainWindow parent;

        public ComparaPrato(MainWindow caller, PratoManager manager, string comida)
        {
            InitializeComponent();
            pratoManager = manager;
            comidaEscolhida = comida;

            CompareMessage.Content = $"{(!string.IsNullOrEmpty(comida) ? comida : "null")} é ___________ mas Bolo de Chocolate não.";
            parent = caller;
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            AdicionaVinculoPrato();
            FecharComparaPrato();
        }

        private void ResponseCancelarButton_Click(object sender, RoutedEventArgs e)
        {
            AdicionaVinculoPrato();
            FecharComparaPrato();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdicionaVinculoPrato();
            FecharComparaPrato();
        }

        private void AdicionaVinculoPrato()
        {
            string novoVinculo = txtNomeVinculoAlimento.Text;
            if (string.IsNullOrEmpty(novoVinculo))
            {
                novoVinculo = "null";
            }

            pratoManager.RemoverUltimaPergunta();
            pratoManager.AdicionarPergunta($"O prato que pensou é {novoVinculo}?", new List<string> { comidaEscolhida ?? "null" });
            pratoManager.AdicionarPergunta("O prato que pensou é Bolo de chocolate?", new List<string>());
        }

        private void FecharComparaPrato()
        {
            this.Hide();
            parent.Show();
            pratoManager.ResetPerguntaIndex();
        }
    }
}

