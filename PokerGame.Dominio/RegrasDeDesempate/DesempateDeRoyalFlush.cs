using System.Collections.Generic;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeRoyalFlush : IRegraDeDesempate
    {
        public List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB)
        {
            return new List<Carta>();
        }
    }
}