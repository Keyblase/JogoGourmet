﻿using System.Windows;

namespace JogoGourmet
{
    public partial class Confirm : Window
    {
        private Dictionary<string, List<string>> perguntasD;
        private List<string> valoresAssociados;
        private int indiceAtual = 0;
        private MainWindow parent;
        private bool mostrandoValores = false;

        public Confirm(MainWindow caller, Dictionary<string, List<string>> perguntas)
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
                string pergunta = perguntasD.Keys.ElementAt(indiceAtual);

                if (mostrandoValores)
                {
                    txtPergunta.Text = valoresAssociados.Any() ? $"O prato que pensou é {valoresAssociados.First()}?" : "Não há pratos associados a esta pergunta.";
                }
                else
                {
                    txtPergunta.Text = pergunta;
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
            if (!mostrandoValores && perguntasD.ContainsKey(txtPergunta.Text) && perguntasD[txtPergunta.Text].Any())
            {
                mostrandoValores = true;
                valoresAssociados = perguntasD[txtPergunta.Text];
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
                Confirm perguntaForm = new(parent, perguntasD);
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
            if (pergunta != "O prato que pensou é null")
            {
                return false;
            }
            return perguntasD.ContainsKey(pergunta) && perguntasD[pergunta].Any();
        }
        #endregion

    }
}
