using System.Windows;

namespace JogoGourmet
{
    public partial class Confirm : Window
    {
        private Dictionary<string, List<string>> perguntasD;
        private string[] keys; // Armazena as chaves do dicionário
        private int indicePerguntaAtual = 0; // Índice da chave atual no dicionário
        private int indicePerguntaFilhoAtual = 0; // Índice da pergunta filho atual na lista associada à chave atual
        readonly MainWindow parent;

        public Confirm(MainWindow caller, Dictionary<string, List<string>> perguntas, string perguntaAtual = "", bool verificarVinculo = false)
        {
            InitializeComponent();
            perguntasD = perguntas;
            keys = perguntas.Keys.ToArray();
            parent = caller;

            if (verificarVinculo)
            {
                txtPergunta.Text = $"O prato que pensou é {perguntas[perguntaAtual][0]}?";
            }
            else
            {
                txtPergunta.Text = keys[0];
            }
        }
        private void btnSim_Click(object sender, RoutedEventArgs e)
        {
            VerificarVinculo();
        }

        private void btnNao_Click(object sender, RoutedEventArgs e)
        {
            if (indicePerguntaFilhoAtual < perguntasD[keys[indicePerguntaAtual]].Count - 1)
            {
                indicePerguntaFilhoAtual++;
                txtPergunta.Text = $"O prato que pensou é {perguntasD[keys[indicePerguntaAtual]][indicePerguntaFilhoAtual]}?";
            }
            else
            {
                indicePerguntaAtual++;

                if (indicePerguntaAtual < keys.Length)
                {
                    indicePerguntaFilhoAtual = 0;
                    txtPergunta.Text = keys[indicePerguntaAtual];
                }
                else
                {
                    CriaPrato adicionaForm = new(parent, perguntasD);
                    this.Close();
                    adicionaForm.Show();
                }
            }
        }

        #region VerificarVinculo
        private void VerificarVinculo()
        {
            if (VerificarVinculoExistente(txtPergunta.Text))
            {
                this.Hide();
                Confirm perguntaForm = new(parent, perguntasD, txtPergunta.Text, true);
                perguntaForm.Show();
            }
            else
            {
                this.Hide();
                Acerto adicionaForm = new(parent);
                adicionaForm.Show();
            }
        }

        private bool VerificarVinculoExistente(string pergunta)
        {
            return perguntasD.ContainsKey(pergunta) && perguntasD[pergunta].Any();
        }
        #endregion 
        
    }
}
