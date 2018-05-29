using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JFESM.Model;
using Microsoft.EntityFrameworkCore;

namespace JFESM.Persistence
{
    public class SalaRepository: ISalaRepository
    {
        private readonly Sala sala;

        public SalaRepository()
        {
            this.sala = new Sala();
        }

        public Jogador AdicionarJogador(string id, string name)
        {
            return sala.AdicionarJogador(id, name);
        }

        public IList<Jogador> GetPlayers()
        {
            return sala.Jogadores;
        }

        public int PegarTotalJogadores()
        {
           return  sala.Jogadores.Count();
        }

        public void SetReady(string id)
        {
            sala.Jogadores.FirstOrDefault(j => j.Id == id).EstaPronto = true;
        }
    }
}