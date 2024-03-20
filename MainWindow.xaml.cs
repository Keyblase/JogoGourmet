using System.Windows;
using System.Windows.Controls;

namespace JogoGourmet
{
    public partial class MainWindow : Window
    {
        private Dictionary<int, string> perguntas = new Dictionary<int, string>
        {
            { 0, "O prato que pensou é Massa?" },
            { 1, "O prato que pensou é Bolo de chocolate?" }
        };

        public MainWindow()
        {
            InitializeComponent();
            LoadMessages();
        }

        private void LoadMessages()
        {
            InitialMessage.Text = "Pense em um prato que gosta";
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            Confirm perguntaForm = new(perguntas);
            perguntaForm.Show();
        }
    }
}