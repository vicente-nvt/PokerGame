using System.Collections.Generic;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public interface IRegraDeDesempate
    {
        List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB);
    }
}