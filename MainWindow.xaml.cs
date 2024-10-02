using JogoGourmet.Manager;
using System.Windows;

namespace JogoGourmet
{
    public partial class MainWindow : Window
    {
        private PratoManager pratoManager;

        public MainWindow()
        {
            InitializeComponent();
            LoadMessages();
            pratoManager = new PratoManager();
        }

        private void LoadMessages()
        {
            InitialMessage.Content = "Pense em um prato que gosta";
        }

        private void ResponseButton_Click(object sender, RoutedEventArgs e)
        {
            Confirm perguntaForm = new Confirm(this, pratoManager);
            this.Hide();
            perguntaForm.Show();
        }
    }
}