using JogoGourmet.Manager;
using System.Windows;

namespace JogoGourmet
{
    public partial class Confirm : Window
    {
        private PratoManager pratoManager;
        private List<string> valoresAssociados;
        private readonly MainWindow parent;
        private bool mostrandoValores = false;

        public Confirm(MainWindow caller, PratoManager manager)
        {
            InitializeComponent();
            pratoManager = manager;
            parent = caller;
            MostrarPerguntaAtual();
        }

        private void MostrarPerguntaAtual()
        {
            if (pratoManager.HasMorePerguntas())
            {
                string pergunta = pratoManager.GetNextPergunta(out valoresAssociados);

                if (mostrandoValores)
                {
                    txtPergunta.Text = valoresAssociados.Any() ? $"O prato que pensou é {valoresAssociados[0]}?" : "Não há pratos associados a esta pergunta.";
                }
                else
                {
                    txtPergunta.Text = pergunta;
                }
            }
            else
            {
                CriaPrato adicionaForm = new CriaPrato(parent, pratoManager);
                this.Hide();
                adicionaForm.Show();
            }
        }

        private void btnSim_Click(object sender, RoutedEventArgs e)
        {
            if (!mostrandoValores && pratoManager.ContainsPergunta(txtPergunta.Text) && pratoManager.GetValoresAssociados(txtPergunta.Text).Count != 0)
            {
                mostrandoValores = true;
                valoresAssociados = pratoManager.GetValoresAssociados(txtPergunta.Text);
            }
            else
            {
                VerificarVinculo();
            }
            MostrarPerguntaAtual();
        }

        private void btnNao_Click(object sender, RoutedEventArgs? e)
        {
            if (mostrandoValores && valoresAssociados.Count > 1)
            {
                valoresAssociados.RemoveAt(0);
            }
            else
            {
                mostrandoValores = false;
                pratoManager.IncrementPerguntaIndex();
            }
            MostrarPerguntaAtual();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            btnNao_Click(sender, null);
        }

        private void VerificarVinculo()
        {
            if (VerificarVinculoExistente(txtPergunta.Text))
            {
                this.Hide();
                Confirm perguntaForm = new Confirm(parent, pratoManager);
                perguntaForm.Show();
            }
            else
            {
                this.Hide();
                Acerto adicionaForm = new Acerto(parent);
                adicionaForm.Show();
            }
        }

        private bool VerificarVinculoExistente(string pergunta)
        {
            if (pergunta != "O prato que pensou é null")
            {
                return false;
            }
            return pratoManager.ContainsPergunta(pergunta) && pratoManager.GetValoresAssociados(pergunta).Count != 0;
        }
    }
}
