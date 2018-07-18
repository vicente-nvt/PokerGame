using System.Collections.Generic;

namespace PokerGame.Dominio.Business.RegrasDeDesempate
{
    public class DesempateDeRoyalFlush : IRegraDeDesempate
    {
        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            return new List<Carta>();
        }
    }
}