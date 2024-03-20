using System.Windows;

namespace JogoGourmet
{
    /// <summary>
    /// Interaction logic for Confirm.xaml
    /// </summary>
    public partial class Confirm : Window
    {
        private Dictionary<int, string> perguntas;
        private int indicePergunta = 0;
        public Confirm(Dictionary<int, string> perguntas)
        {
            InitializeComponent();
            txtPergunta.Text = perguntas[indicePergunta];
        }

        private void btnSim_Click(object sender, RoutedEventArgs e)
        {
            Acerto adicionaForm = new ();
            adicionaForm.Show();
        }

        private void btnNao_Click(object sender, RoutedEventArgs e)
        {
            indicePergunta++;
            if (indicePergunta < perguntas.Count)
            {
                txtPergunta.Text = perguntas[indicePergunta];
            }
            else
            {
                CriaPrato adicionaForm = new CriaPrato();
                adicionaForm.Show();
            }
        }
    }
}
