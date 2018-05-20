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

        public async Task AdicionarJogador () {
            salaRepository.AdicionarJogador ();
        }
    }
}