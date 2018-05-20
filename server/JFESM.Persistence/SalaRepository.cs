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

        public async Task AdicionarJogador()
        {
            sala.AdicionarJogador();
        }
    }
}