using System.Collections.Generic;
using System.Threading.Tasks;
using JFESM.Model;

namespace JFESM.Persistence
{
    public interface ISalaRepository
    {
        Jogador AdicionarJogador(string id, string name);
        IList<Jogador> GetPlayers();
        void SetReady(string id);
        int PegarTotalJogadores();
        // Boneco FindById(long id);
        // Task<IList<Boneco>> FindByName(string name);
    }
}