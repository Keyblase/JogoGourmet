using System.Collections.Specialized;
using System.Windows;

namespace JogoGourmet
{
    public partial class MainWindow : Window
    {
        private OrderedDictionary dictionary = new OrderedDictionary();

        public MainWindow()
        {
            InitializeComponent();
            LoadMessages();
            InitializeDictionary();
        }

        private void LoadMessages()
        {
            InitialMessage.Content = "Pense em um prato que gosta";
        }

        private void InitializeDictionary()
        {
            dictionary.Add("O prato que pensou é Massa?", new List<string> { "Lasanha" });
            dictionary.Add("O prato que pensou é Bolo de chocolate?", new List<string>());
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            Confirm perguntaForm = new Confirm(this, dictionary);
            this.Hide();
            perguntaForm.Show();
        }
    }
}