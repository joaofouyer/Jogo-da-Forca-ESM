using System.Collections.Generic;
using System.Linq;
using JFESM.Model;
using JFESM.Web.Controllers.Items;

namespace JFESM.Web.Extensions
{
    public static class SalaExtensions
    {
        public static JogadorDTO ToJogadorViewItem(this Jogador jogador)
        {
            return new JogadorDTO()
            {
                Id = jogador.Id,
                Name = jogador.Name,
                EstaPronto = jogador.EstaPronto
            };
        }

        public static IEnumerable<JogadorDTO> ToPlayersViewItems(this IEnumerable<Jogador> players)
        {
            return players.Select(p => p.ToJogadorViewItem()).ToArray();
        }
    }
}