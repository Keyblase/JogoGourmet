using System.Windows;

namespace JogoGourmet
{
    public partial class ComparaPrato : Window
    {
        private Dictionary<string, List<string>> perguntasD;
        private string comidaEscolhida = "";
        MainWindow parent;
        public ComparaPrato(MainWindow caller, Dictionary<string, List<string>> perguntas, string comida)
        {
            InitializeComponent();
            perguntasD = perguntas;
            comidaEscolhida = comida;

            CompareMessage.Content = $"{(!string.IsNullOrEmpty(comida) ? comida : "null")} é ___________ mas Bolo de Chocolate não.";
            parent = caller;
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            AdicionaVinculoPrato();
            this.Hide();
            parent.Show();
        }

        private void ResponseCancelarButton_Click(object sender, RoutedEventArgs e)
        {
            AdicionaVinculoPrato();
            this.Hide();
            parent.Show();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdicionaVinculoPrato();
            parent.Show();
        }
        public void AdicionaVinculoPrato()
        {
            perguntasD.Add($"O prato que pensou é {(!string.IsNullOrEmpty(txtNomeVinculoAlimento.Text) ? txtNomeVinculoAlimento.Text : "null")}?", new List<string>() { (!string.IsNullOrEmpty(comidaEscolhida) ? comidaEscolhida : "null") });
        }
    }
}
