using System.Windows;

namespace JogoGourmet
{
    public partial class Acerto : Window
    {
        MainWindow parent;
        public Acerto(MainWindow caller)
        {
            InitializeComponent();
            AcertoMessage.Content = "Acertei denovo!";
            parent = caller;
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
        }
    }
}
