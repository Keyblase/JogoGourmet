using System.Windows;

namespace JogoGourmet
{
    public partial class Confirm : Window
    {
        private Dictionary<string, List<string>> perguntasD;
        private int indicePergunta = 0;
        MainWindow parent;
        public Confirm(MainWindow caller ,Dictionary<string, List<string>> perguntas)
        {
            InitializeComponent();
            txtPergunta.Text = perguntas.First().Key;
            perguntasD = perguntas;
            parent = caller;
        }

        private void VerificarVinculo()
        {

            if (VerificarVinculoExistente("","w"))
            {
                Console.WriteLine("Existe vínculo entre as perguntas.");
            }
            else
            {
                Acerto adicionaForm = new(parent);
                adicionaForm.Show();
            }
        }

        private bool VerificarVinculoExistente(string pergunta1, string pergunta2)
        {
            if (perguntasD.ContainsKey(pergunta1) && perguntasD.ContainsKey(pergunta2))
            {
                foreach (var palavra in perguntasD[pergunta2])
                {
                    if (perguntasD[pergunta1].Contains(palavra))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void btnSim_Click(object sender, RoutedEventArgs e)
        {
            VerificarVinculo();
        }

        private void btnNao_Click(object sender, RoutedEventArgs e)
        {
            indicePergunta++;
            if (indicePergunta < perguntasD.Count)
            {
                txtPergunta.Text = perguntasD.ElementAt(indicePergunta).Key;
            }
            else
            {
                CriaPrato adicionaForm = new CriaPrato(parent,perguntasD);
                this.Close();
                adicionaForm.Show();
            }
        }
    }
}
