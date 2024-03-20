using System.Windows;

namespace JogoGourmet
{
    /// <summary>
    /// Interaction logic for ComparaPrato.xaml
    /// </summary>
    public partial class ComparaPrato : Window
    {
        public ComparaPrato(string comida)
        {
            InitializeComponent();
            CompareMessage.Text = $"{comida} é ______ mas Bolo de Chocolate não.";
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResponseCancelarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
