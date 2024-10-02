using JogoGourmet.Manager;
using System.Windows;

namespace JogoGourmet
{
    public partial class CriaPrato : Window
    {
        private PratoManager pratoManager;
        readonly MainWindow parent;
        public CriaPrato(MainWindow caller, PratoManager pratoManager)
        {
            InitializeComponent();
            DefaultMessage.Content = "Qual prato você pensou?";
            this.pratoManager = pratoManager;
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
            ComparaPrato inicioForm = new(parent, pratoManager, alimentoEscolhido.Text);
            inicioForm.Show();
        }
    }
}
