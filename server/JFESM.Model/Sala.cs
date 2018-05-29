using System.Collections.Generic;
using System.Linq;

namespace JFESM.Model {
    public class Sala {
        public List<Jogador> Jogadores { get; set; }
        public JogoDaForca JogoDaForca { get; set; }
        public bool EsperandoPalavras {
            get { return Jogadores.All (j => j.EstaPronto) && Jogadores.Count > 3; }
        }
        public bool PalavrasDiferentes {
            get { return Palavra1 != Palavra2; }
        }
        public string Palavra1 { get; set; }
        public string Palavra2 { get; set; }

        public Sala () {
            Jogadores = new List<Jogador> (6);
        }
        public Jogador AdicionarJogador (string id, string name) {
            Jogador jogador = null;
            if (Jogadores.Count == 0) {
                jogador = new JogadorA ();
            } else if (Jogadores.Count == 1) {
                jogador = new JogadorB ();
            } else if (Jogadores.Count < 6) {
                jogador = new JogadorC ();
            }
            if (Jogadores.Count < 6) {
                jogador.Id = id;
                jogador.Name = name;
                Jogadores.Add (jogador);
                return jogador;
            }

            return null;
        }

        public void IndicarPalavra () {
            if (PalavrasDiferentes) {
                JogoDaForca.Secreta1.Palavra = Palavra1;
                JogoDaForca.Secreta2.Palavra = Palavra2;
            }
        }
    }
}