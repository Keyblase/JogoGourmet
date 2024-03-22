using System.Collections;
using System.Collections.Specialized;
using System.Windows;

namespace JogoGourmet
{
    public partial class Confirm : Window
    {
        private OrderedDictionary perguntasD;
        private List<string> valoresAssociados;
        private int indiceAtual = 0;
        private readonly MainWindow parent;
        private bool mostrandoValores = false;

        public Confirm(MainWindow caller, OrderedDictionary perguntas)
        {
            InitializeComponent();
            perguntasD = perguntas;
            parent = caller;
            InicializarValoresAssociados();
            MostrarPerguntaAtual();
        }

        private void InicializarValoresAssociados()
        {
            valoresAssociados = new List<string>();
        }

        private void MostrarPerguntaAtual()
        {
            if (indiceAtual < perguntasD.Count)
            {
                int index = 0;
                foreach (DictionaryEntry entry in perguntasD)
                {
                    if (index == indiceAtual)
                    {
                        string? pergunta = entry.Key as string;

                        if (mostrandoValores)
                        {
                            txtPergunta.Text = valoresAssociados.Any() ? $"O prato que pensou é {valoresAssociados.First()}?" : "Não há pratos associados a esta pergunta.";
                        }
                        else
                        {
                            txtPergunta.Text = pergunta;
                        }
                        break;
                    }
                    index++;
                }
            }
            else
            {
                CriaPrato adicionaForm = new CriaPrato(parent, perguntasD);
                this.Hide();
                adicionaForm.Show();
            }
        }

        private void btnSim_Click(object sender, RoutedEventArgs e)
        {
            if (!mostrandoValores && perguntasD.Contains(txtPergunta.Text as object) && ((List<string>)perguntasD[txtPergunta.Text]).Count != 0)
            {
                mostrandoValores = true;
                valoresAssociados = (List<string>)perguntasD[txtPergunta.Text];
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
                indiceAtual++;
            }
            MostrarPerguntaAtual();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            btnNao_Click(sender, null);
        }

        #region VerificarVinculo
        private void VerificarVinculo()
        {
            if (VerificarVinculoExistente(txtPergunta.Text))
            {
                this.Hide();
                Confirm perguntaForm = new Confirm(parent, perguntasD);
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
            return perguntasD.Contains(pergunta) && ((List<string>)perguntasD[pergunta]).Count != 0;
        }
        #endregion
    }
}
