using System.Linq;
using System.Windows;

namespace JogoGourmet
{
    public partial class ComparaPrato : Window
    {
        private Dictionary<string, List<string>> perguntasD;
        private string comidaEscolhida = "";

        MainWindow parent;
        public ComparaPrato(MainWindow caller, Dictionary<string, List<string>> perguntas,string comida)
        {
            InitializeComponent();
            perguntasD = perguntas;
            comidaEscolhida = comida;

            CompareMessage.Content = $"{comida} é ___________ mas Bolo de Chocolate não.";
            parent = caller;
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            perguntasD.Add($"O prato que pensou é {txtNomeVinculoAlimento.Text}?", new List<string>() { comidaEscolhida });
            this.Close();
            parent.Show();
        }

        private void ResponseCancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
