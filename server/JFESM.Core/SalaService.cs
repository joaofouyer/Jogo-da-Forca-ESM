using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JFESM.API;
using JFESM.Model;
using JFESM.Persistence;

namespace JFESM.Core {
    public class SalaService : ISalaService {
        private readonly ISalaRepository salaRepository;

        public SalaService (ISalaRepository salaRepository) {
            this.salaRepository = salaRepository;
        }

        public Jogador AdicionarJogador (string id, string name) {
            return salaRepository.AdicionarJogador (id, name);
        }

        public IList<Jogador> GetPlayers()
        {
            return salaRepository.GetPlayers();
        }

        public async Task<int> PegarTotalJogadores()
        {
            return salaRepository.PegarTotalJogadores();;
        }

        public void SetReady(string id)
        {
            salaRepository.SetReady(id);
        }
    }
}