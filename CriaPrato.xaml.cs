using System.Windows;

namespace JogoGourmet
{
    public partial class CriaPrato : Window
    {
        private Dictionary<string, List<string>> perguntasD;
        MainWindow parent;
        public CriaPrato(MainWindow caller, Dictionary<string, List<string>> perguntas)
        {
            InitializeComponent();
            DefaultMessage.Content = "Qual prato você pensou?";
            perguntasD = perguntas;
            parent = caller;
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            perguntasD.Add($"O prato que pensou é {alimentoEscolhido.Text}",new List<string>() { alimentoEscolhido.Text });
            this.Close();
            ComparaPrato inicioForm = new(parent,perguntasD, alimentoEscolhido.Text);
            inicioForm.Show();
        }

        private void ResponseCancelaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
