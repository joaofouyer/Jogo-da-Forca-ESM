using System.Collections.Generic;
using System.Threading.Tasks;
using JFESM.Model;

namespace JFESM.Persistence
{
    public interface ISalaRepository
    {
        Task AdicionarJogador();
        // Boneco FindById(long id);
        // Task<IList<Boneco>> FindByName(string name);
    }
}