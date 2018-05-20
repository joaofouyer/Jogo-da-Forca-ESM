using System.Collections.Generic;

namespace JFESM.Model
{
    public class Sala
    {
        private int id = 0;
        public List<Jogador> Jogadores { get; set; }
        public string Palavra1 { get; set; }
        public string Palavra2 { get; set; }

        public Sala(){
            Jogadores = new List<Jogador>(6);
        }
        public void AdicionarJogador(){
            if(Jogadores.Count == 0){
                Jogadores.Add(new JogadorA(){Id = id});
            }else if (Jogadores.Count == 1){
                Jogadores.Add(new JogadorB(){Id = id});
            }else if (Jogadores.Count < 6){
                Jogadores.Add(new JogadorC(){Id = id});                
            }
            id++;
        }
    }
}