using System.Collections.Specialized;
using System.Windows;

namespace JogoGourmet
{
    public partial class CriaPrato : Window
    {
        private OrderedDictionary perguntasD = new OrderedDictionary();
        MainWindow parent;
        public CriaPrato(MainWindow caller, OrderedDictionary perguntas)
        {
            InitializeComponent();
            DefaultMessage.Content = "Qual prato você pensou?";
            perguntasD = perguntas;
            parent = caller;
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdicionaVinculoPrato();
        }

        private void ResponseCancelaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdicionaVinculoPrato();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdicionaVinculoPrato();
        }
        public void AdicionaVinculoPrato()
        {
            ComparaPrato inicioForm = new(parent, perguntasD, alimentoEscolhido.Text);
            inicioForm.Show();
        }
    }
}
