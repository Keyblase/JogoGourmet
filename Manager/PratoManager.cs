using System.Collections;
using System.Collections.Specialized;

namespace JogoGourmet.Manager
{
    public class PratoManager
    {
        private OrderedDictionary perguntasD;
        private int indiceAtual = 0;

        public PratoManager()
        {
            perguntasD = new OrderedDictionary();
            InitializePratos();
        }

        private void InitializePratos()
        {
            perguntasD.Add("O prato que pensou é massa?", new List<string> { "Lasanha" });
            perguntasD.Add("O prato que pensou é Bolo de chocolate?", new List<string>());
        }

        public string GetNextPergunta(out List<string> valoresAssociados)
        {
            if (indiceAtual < perguntasD.Count)
            {
                var entry = perguntasD.Cast<DictionaryEntry>().ElementAt(indiceAtual);
                valoresAssociados = entry.Value as List<string> ?? new List<string>();
                return entry.Key as string;
            }

            valoresAssociados = new List<string>();
            return null;
        }

        public void ResetPerguntaIndex()
        {
            indiceAtual = 0;
        }

        public void IncrementPerguntaIndex()
        {
            indiceAtual++;
        }

        public bool HasMorePerguntas()
        {
            return indiceAtual < perguntasD.Count;
        }

        public bool ContainsPergunta(string pergunta)
        {
            return perguntasD.Contains(pergunta);
        }

        public List<string> GetValoresAssociados(string pergunta)
        {
            if (ContainsPergunta(pergunta))
            {
                return (List<string>)perguntasD[pergunta];
            }
            return new List<string>();
        }

        public void AddPrato(string key, List<string> pratosVinculados)
        {
            perguntasD.Add(key, pratosVinculados);
        }
        public void RemoverUltimaPergunta()
        {
            if (perguntasD.Count > 0)
            {
                perguntasD.RemoveAt(perguntasD.Count - 1);
            }
        }

        public void AdicionarPergunta(string pergunta, List<string> pratosVinculados)
        {
            perguntasD.Add(pergunta, pratosVinculados);
        }
    }
}
