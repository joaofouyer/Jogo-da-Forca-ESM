using System.Collections.Generic;
using System.Threading.Tasks;
using JFESM.Model;

namespace JFESM.API
{
    public interface ISalaService
    {
        Jogador AdicionarJogador(string Id, string name);
        IList<Jogador> GetPlayers();
        void SetReady(string id);
        Task<int> PegarTotalJogadores();
    }
}