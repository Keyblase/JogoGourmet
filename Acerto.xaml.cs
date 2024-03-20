using System.Windows;

namespace JogoGourmet
{
    public partial class Acerto : Window
    {
        public Acerto()
        {
            InitializeComponent();
            AcertoMessage.Content = "Acertei denovo!";
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicioForm = new ();
            inicioForm.Show();
        }
    }
}
