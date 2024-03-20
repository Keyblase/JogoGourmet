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
            if (perguntasD.ContainsKey($"O prato que pensou é {comidaEscolhida}"))
            {
                foreach (var palavra in perguntasD[$"O prato que pensou é {comidaEscolhida}"])
                {
                    if (!perguntasD[$"O prato que pensou é {comidaEscolhida}"].Contains(palavra))
                    {
                        perguntasD[$"O prato que pensou é {comidaEscolhida}"].Add(palavra);
                    }
                }
            }
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
