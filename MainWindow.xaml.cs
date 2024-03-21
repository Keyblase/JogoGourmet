using System.Windows;

namespace JogoGourmet
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<string>> dictionary = new()
        {
            { "O prato que pensou é Massa?", new List<string> { "Lasanha" } },
            { "O prato que pensou é Bolo de chocolate?", new List<string> { } },
        };

        public MainWindow()
        {
            InitializeComponent();
            LoadMessages();
        }

        private void LoadMessages()
        {
            InitialMessage.Content = "Pense em um prato que gosta";
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            Confirm perguntaForm = new(this,dictionary);
            this.Hide();
            perguntaForm.Show();
        }
    }
}