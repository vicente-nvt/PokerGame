using System.Collections.Generic;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeRoyalFlush : IRegraDeDesempate
    {
        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            return new List<Carta>();
        }
    }
}